import { makeAutoObservable, runInAction } from "mobx";
import { createContext, SyntheticEvent } from "react";
import { toast } from "react-toastify";
import agent from "../../../api/agent";
import { IActivity } from "../../../models";
import { history } from "../../features/browser-history";

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

class ActivityStore {
  // * Observables
  activityRegistry = new Map();
  selectedActivity: IActivity = DEFAULT_ACTIVITY;
  loadingInitial = false;
  editMode = false;
  submitting = false;
  target = "";

  constructor() {
    makeAutoObservable(this);
  }

  // * Computed
  get activitiesByDate() {
    const activityArr = Array.from(this.activityRegistry.values());
    return ActivityStore.groupActivitiesByDate(activityArr);
  }

  /**
   * Utility method to sort and group activities by date
   */
  private static groupActivitiesByDate(activities: IActivity[]) {
    const sortedActivities = activities.sort(
      (a, b) => a.date.getTime() - b.date.getTime()
    );

    return Object.entries(
      sortedActivities.reduce((activities, activity) => {
        const date = activity.date.toISOString().split("T")[0];
        activities[date] = activities[date]
          ? [...activities[date], activity]
          : [activity];
        return activities;
      }, {} as { [key: string]: IActivity[] })
    );
  }

  setEditMode = (mode: boolean) => (this.editMode = mode);

  // * Actions

  /**
   * Set button submission flag
   */
  setSubmitting = (mode: boolean) => (this.submitting = mode);

  /**
   * Set target button when submitting
   */
  setTarget = (targetName: string) => (this.target = targetName);

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
    this.editMode = false;
  };

  // Catch all function for wrapping async api calls
  private catchAsync = (fn: Function) => {
    return async (...args: any) => {
      try {
        return await fn(...args);
      } catch (e) {
        runInAction(() => {
          this.submitting = false;
        });
        toast.error(e.message);
        throw e;
      }
    };
  };

  /**
   * GET all activities from the API
   */
  getAllActivities = this.catchAsync(async () => {
    this.loadingInitial = true;

    const newActivities = await agent.activitiesApi.getAll();

    runInAction(() => {
      newActivities.forEach((a) => {
        a.date = new Date(a.date);
        this.activityRegistry.set(a.id, a);
      });

      this.loadingInitial = false;
    });
  });
  /**
   * GET one activity from the API
   */
  getOneActivity = this.catchAsync(async (id: string) => {
    let activity = this.activityRegistry.get(id);

    if (!activity && id) {
      this.loadingInitial = true;
      activity = await agent.activitiesApi.getOne(id);
    }

    return runInAction(() => {
      activity.date = new Date(activity.date);
      activity.time = activity.date;
      this.selectedActivity = activity;
      this.activityRegistry.set(id, activity);
      this.loadingInitial = false;
      return activity;
    });
  });

  /**
   * Utility method to process redundant API calls
   */
  private processActivity = async (
    apiCall: Function,
    registryAction: Function,
    activity: IActivity = DEFAULT_ACTIVITY
  ) => {
    this.submitting = true;
    await apiCall();

    runInAction(() => {
      this.submitting = false;

      registryAction();
      this.selectedActivity = activity;
      this.editMode = false;
      history.push(`/activities/${activity.id}`);
    });
  };

  /**
   * POST one activity to the API
   */
  createOneActivity = this.catchAsync(
    async (activity: IActivity) =>
      await this.processActivity(
        () => agent.activitiesApi.createOne(activity),
        () => this.activityRegistry.set(activity.id, activity),
        activity
      )
  );
  /**
   * PUT one activity in the API
   */
  editOneActivity = this.catchAsync(
    async (activity: IActivity) =>
      await this.processActivity(
        () => agent.activitiesApi.updateOne(activity),
        () => this.activityRegistry.set(activity.id, activity),
        activity
      )
  );
  /**
   * DELETE one activity from the API
   */
  deleteOneActivity = this.catchAsync(
    async (e: SyntheticEvent<HTMLButtonElement>, id: string) => {
      this.target = e.currentTarget.name;

      await this.processActivity(
        () => agent.activitiesApi.deleteOne(id),
        () => this.activityRegistry.delete(id)
      );

      runInAction(() => {
        if (this.selectedActivity?.id === id) {
          this.selectedActivity = DEFAULT_ACTIVITY;
          this.editMode = false;
        }
      });
    }
  );
}

const ActivityContext = createContext(new ActivityStore());
export default ActivityContext;
