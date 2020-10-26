import { makeAutoObservable, runInAction } from "mobx";
import { SyntheticEvent } from "react";
import agent from "../../api/agent";
import { IActivity, IUser } from "../../models";
import { IAttendee } from "../../models/IAttendee";
import { catchAsync } from "../../util/catch-async";
import { checkActivityAttendeeProps } from "../../util/check-activity-attendee-props";
import { groupActivitiesByDate } from "../../util/group-activities-by-date";
import { setActivityDateTime } from "../../util/set-activity-date-time";
import { history } from "../../app/features/browser-history";
import { RootStore } from "../index";

const DEFAULT_ACTIVITY: IActivity = {
  id: "",
  title: "",
  category: "",
  description: "",
  date: new Date(),
  time: new Date(),
  city: "",
  venue: "",
  attendees: [],
  isGoing: false,
  isHost: false,
};

export default class ActivityStore {
  private rootStore: RootStore;

  // * Observables
  public activityRegistry = new Map();
  public selectedActivity: IActivity = DEFAULT_ACTIVITY;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  // * Computed
  get activitiesByDate() {
    const activityArr = Array.from(this.activityRegistry.values());
    return groupActivitiesByDate(activityArr);
  }

  public clearSelectedActivity = () => {
    this.selectedActivity = DEFAULT_ACTIVITY;
  };

  public setSelectedActivity = (id: string | null) => {
    this.selectedActivity = this.activityRegistry.get(id);
    this.rootStore.guiStore.editMode = false;
  };

  private createAttendeeFromUser = (user: IUser): IAttendee => {
    return {
      displayName: user.displayName,
      isHost: false,
      userName: user.userName,
      image: user.image!,
    };
  };

  private resetLoadingIndicators = () => {
    this.rootStore.guiStore.loadingInitial = false;
    this.rootStore.guiStore.loadingSecondary = false;
  };

  private processAttendees = async (isGoing: boolean) => {
    const attendee = this.createAttendeeFromUser(
      this.rootStore.userStore.user!
    );
    this.rootStore.guiStore.loadingSecondary = true;

    if (this.selectedActivity) {
      if (isGoing) {
        await agent.activitiesApi.createAttendee(this.selectedActivity.id);
        runInAction(() => this.selectedActivity.attendees.push(attendee));
      } else {
        await agent.activitiesApi.removeAttendee(this.selectedActivity.id);
        runInAction(
          () =>
            (this.selectedActivity.attendees = this.selectedActivity.attendees.filter(
              (a) => a.userName !== attendee.userName
            ))
        );
      }

      runInAction(() => {
        this.selectedActivity.isGoing = isGoing;
        this.activityRegistry.set(
          this.selectedActivity.id,
          this.selectedActivity
        );
        this.rootStore.guiStore.loadingSecondary = false;
      });
    }
  };

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
      history.push(`/events/${activity.id}`);
    });
  };

  // * Actions

  public getAllActivities = catchAsync(async () => {
    this.rootStore.guiStore.loadingInitial = true;

    const currentUser = this.rootStore.userStore.user!;

    const newActivities = await agent.activitiesApi.getAll();

    runInAction(() => {
      newActivities.forEach((a) => {
        setActivityDateTime(a);
        checkActivityAttendeeProps(a, currentUser);
        this.activityRegistry.set(a.id, a);
      });

      this.rootStore.guiStore.loadingInitial = false;
    });
  }, this.resetLoadingIndicators);

  public getOneActivity = catchAsync(async (id: string) => {
    let activity = this.activityRegistry.get(id);
    const currentUser = this.rootStore.userStore.user!;

    if (!activity && id) {
      this.rootStore.guiStore.loadingInitial = true;
      activity = await agent.activitiesApi.getOne(id);
    }

    return runInAction(() => {
      setActivityDateTime(activity);
      checkActivityAttendeeProps(activity, currentUser);

      this.selectedActivity = activity;
      this.activityRegistry.set(id, activity);
      this.rootStore.guiStore.loadingInitial = false;
      return activity;
    });
  }, this.resetLoadingIndicators);

  public createOneActivity = catchAsync(async (activity: IActivity) => {
    await this.processActivity(
      () => {
        const attendee = this.createAttendeeFromUser(
          this.rootStore.userStore.user!
        );
        attendee.isHost = true;
        activity.attendees = [attendee];
        return agent.activitiesApi.createOne(activity);
      },
      () => this.activityRegistry.set(activity.id, activity),
      activity
    );
    runInAction(() => {
      this.rootStore.guiStore.submitting = false;
    });
  }, this.resetLoadingIndicators);

  public editOneActivity = catchAsync(async (activity: IActivity) => {
    await this.processActivity(
      () => agent.activitiesApi.updateOne(activity),
      () => this.activityRegistry.set(activity.id, activity),
      activity
    );
    runInAction(() => {
      this.rootStore.guiStore.submitting = false;
    });
  }, this.resetLoadingIndicators);

  public deleteOneActivity = catchAsync(
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
    },
    this.resetLoadingIndicators
  );

  public createAttendanceForOneActivity = catchAsync(async () => {
    await this.processAttendees(true);
  }, this.resetLoadingIndicators);

  public cancelAttendanceForOneActivity = catchAsync(async () => {
    await this.processAttendees(false);
  }, this.resetLoadingIndicators);
}
