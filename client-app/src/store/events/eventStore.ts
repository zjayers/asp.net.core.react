import { makeAutoObservable, runInAction } from "mobx";
import { SyntheticEvent } from "react";
import { eventsApi } from "../../api";
import { history } from "../../app/features/browser-history";
import { IAttendee, IEvent, IUser } from "../../models";
import { catchAsync } from "../../util/catch-async";
import { checkActivityAttendeeProps } from "../../util/check-activity-attendee-props";
import { groupActivitiesByDate } from "../../util/group-activities-by-date";
import { setActivityDateTime } from "../../util/set-activity-date-time";
import { RootStore } from "../index";

const DEFAULT_EVENT: IEvent = {
  id: "",
  title: "",
  category: "",
  description: "",
  date: new Date(),
  time: new Date(),
  comments: [],
  city: "",
  venue: "",
  attendees: [],
  isGoing: false,
  isHost: false,
};

export default class EventStore {
  private rootStore: RootStore;

  // * Observables
  public eventRegistry = new Map();
  public selectedEvent: IEvent = DEFAULT_EVENT;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  // * Computed
  get activitiesByDate() {
    const activityArr = Array.from(this.eventRegistry.values());
    return groupActivitiesByDate(activityArr);
  }

  public clearSelectedActivity = () => {
    this.selectedEvent = DEFAULT_EVENT;
  };

  public setSelectedActivity = (id: string | null) => {
    this.selectedEvent = this.eventRegistry.get(id);
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

    if (this.selectedEvent) {
      if (isGoing) {
        await eventsApi.createAttendee(this.selectedEvent.id);
        runInAction(() => this.selectedEvent.attendees.push(attendee));
      } else {
        await eventsApi.removeAttendee(this.selectedEvent.id);
        runInAction(
          () =>
            (this.selectedEvent.attendees = this.selectedEvent.attendees.filter(
              (a) => a.userName !== attendee.userName
            ))
        );
      }

      runInAction(() => {
        this.selectedEvent.isGoing = isGoing;
        this.eventRegistry.set(this.selectedEvent.id, this.selectedEvent);
        this.rootStore.guiStore.loadingSecondary = false;
      });
    }
  };

  private processActivity = async (
    apiCall: Function,
    registryAction: Function,
    activity: IEvent = DEFAULT_EVENT
  ) => {
    this.rootStore.guiStore.submitting = true;
    await apiCall();

    runInAction(() => {
      this.rootStore.guiStore.submitting = false;
      registryAction();
      this.selectedEvent = activity;
      this.rootStore.guiStore.editMode = false;
      history.push(`/events/${activity.id}`);
    });
  };

  // * Actions

  public getAllActivities = catchAsync(async () => {
    this.rootStore.guiStore.loadingInitial = true;

    const currentUser = this.rootStore.userStore.user!;

    const newActivities = await eventsApi.getAll();

    runInAction(() => {
      newActivities.forEach((a) => {
        setActivityDateTime(a);
        checkActivityAttendeeProps(a, currentUser);
        this.eventRegistry.set(a.id, a);
      });

      this.rootStore.guiStore.loadingInitial = false;
    });
  }, this.resetLoadingIndicators);

  public getOneActivity = catchAsync(async (id: string) => {
    let activity = this.eventRegistry.get(id);
    const currentUser = this.rootStore.userStore.user!;

    if (!activity && id) {
      this.rootStore.guiStore.loadingInitial = true;
      activity = await eventsApi.getOne(id);
    }

    return runInAction(() => {
      setActivityDateTime(activity);
      checkActivityAttendeeProps(activity, currentUser);

      this.selectedEvent = activity;
      this.eventRegistry.set(id, activity);
      this.rootStore.guiStore.loadingInitial = false;
      return activity;
    });
  }, this.resetLoadingIndicators);

  public createOneActivity = catchAsync(async (activity: IEvent) => {
    await this.processActivity(
      () => {
        const attendee = this.createAttendeeFromUser(
          this.rootStore.userStore.user!
        );
        attendee.isHost = true;
        activity.attendees = [attendee];
        activity.comments = [];
        return eventsApi.createOne(activity);
      },
      () => this.eventRegistry.set(activity.id, activity),
      activity
    );
    runInAction(() => {
      this.rootStore.guiStore.submitting = false;
    });
  }, this.resetLoadingIndicators);

  public editOneActivity = catchAsync(async (activity: IEvent) => {
    await this.processActivity(
      () => eventsApi.updateOne(activity),
      () => this.eventRegistry.set(activity.id, activity),
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
        () => eventsApi.deleteOne(id),
        () => this.eventRegistry.delete(id)
      );

      runInAction(() => {
        if (this.selectedEvent?.id === id) {
          this.selectedEvent = DEFAULT_EVENT;
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
