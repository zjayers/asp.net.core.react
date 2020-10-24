import { makeAutoObservable, runInAction } from "mobx";
import { SyntheticEvent } from "react";
import agent from "../../../api/agent";
import { IActivity } from "../../../models";
import { catchAsync } from "../../../util/catch-async";
import { groupActivitiesByDate } from "../../../util/group-activities-by-date";
import { history } from "../../features/browser-history";
import { RootStore } from "../index";

const DEFAULT_ACTIVITY = {
  id: "",
  title: "",
  category: "",
  description: "",
  date: new Date(),
  time: new Date(),
  city: "",
  venue: "",
};

export default class ActivityStore {
  rootStore: RootStore;

  // * Observables
  activityRegistry = new Map();
  selectedActivity: IActivity = DEFAULT_ACTIVITY;

  // * Actions
  /**
   * GET all activities from the API
   */
  getAllActivities = catchAsync(async () => {
    this.rootStore.guiStore.loadingInitial = true;

    const newActivities = await agent.activitiesApi.getAll();

    runInAction(() => {
      newActivities.forEach((a) => {
        a.date = new Date(a.date);
        this.activityRegistry.set(a.id, a);
      });

      this.rootStore.guiStore.loadingInitial = false;
    });
  });

  /**
   * GET one activity from the API
   */
  getOneActivity = catchAsync(async (id: string) => {
    let activity = this.activityRegistry.get(id);

    if (!activity && id) {
      this.rootStore.guiStore.loadingInitial = true;
      activity = await agent.activitiesApi.getOne(id);
    }

    return runInAction(() => {
      activity.date = new Date(activity.date);
      activity.time = activity.date;
      this.selectedActivity = activity;
      this.activityRegistry.set(id, activity);
      this.rootStore.guiStore.loadingInitial = false;
      return activity;
    });
  });
  /**
   * Set the selected activity observable to null
   */
  clearSelectedActivity = () => {
    this.selectedActivity = DEFAULT_ACTIVITY;
  };
  /**
   * Set the selected activity observable to an activity from the registry
   */
  setSelectedActivity = (id: string | null) => {
    this.selectedActivity = this.activityRegistry.get(id);
    this.rootStore.guiStore.editMode = false;
  };
  /**
   * Utility method to process redundant API calls
   */
  private processActivity = async (
    apiCall: Function,
    registryAction: Function,
    activity: IActivity = DEFAULT_ACTIVITY
  ) => {
    this.rootStore.guiStore.submitting = true;
    await apiCall();

    runInAction(() => {
      this.rootStore.guiStore.submitting = false;

      registryAction();
      this.selectedActivity = activity;
      this.rootStore.guiStore.editMode = false;
      history.push(`/activities/${activity.id}`);
    });
  };
  /**
   * POST one activity to the API
   */
  createOneActivity = catchAsync(async (activity: IActivity) => {
    await this.processActivity(
      () => agent.activitiesApi.createOne(activity),
      () => this.activityRegistry.set(activity.id, activity),
      activity
    );
    runInAction(() => {
      this.rootStore.guiStore.submitting = false;
    });
  });
  /**
   * PUT one activity in the API
   */
  editOneActivity = catchAsync(async (activity: IActivity) => {
    await this.processActivity(
      () => agent.activitiesApi.updateOne(activity),
      () => this.activityRegistry.set(activity.id, activity),
      activity
    );
    runInAction(() => {
      this.rootStore.guiStore.submitting = false;
    });
  });
  /**
   * DELETE one activity from the API
   */
  deleteOneActivity = catchAsync(
    async (e: SyntheticEvent<HTMLButtonElement>, id: string) => {
      this.rootStore.guiStore.target = e.currentTarget.name;

      await this.processActivity(
        () => agent.activitiesApi.deleteOne(id),
        () => this.activityRegistry.delete(id)
      );

      runInAction(() => {
        if (this.selectedActivity?.id === id) {
          this.selectedActivity = DEFAULT_ACTIVITY;
          this.rootStore.guiStore.editMode = false;
        }
      });
    }
  );

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  // * Computed
  get activitiesByDate() {
    const activityArr = Array.from(this.activityRegistry.values());
    return groupActivitiesByDate(activityArr);
  }
}
