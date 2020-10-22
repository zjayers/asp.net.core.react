import { action, makeAutoObservable } from "mobx";
import { createContext, SyntheticEvent } from "react";
import agent from "../../../api/agent";
import { IActivity } from "../../../models";

class ActivityStore {
  activityRegistry = new Map();
  selectedActivity: IActivity | null = null;
  loadingInitial = false;
  editMode = false;
  submitting = false;
  target = "";

  constructor() {
    makeAutoObservable(this);
  }

  get activitiesByDate() {
    return Array.from(this.activityRegistry.values()).sort(
      (a, b) => Date.parse(a.date) - Date.parse(b.date)
    );
  }

  setEditMode = (mode: boolean) => (this.editMode = mode);

  setSubmitting = (mode: boolean) => (this.submitting = mode);

  setTarget = (targetName: string) => (this.target = targetName);

  openCreateForm = () => {
    this.selectedActivity = null;
    this.editMode = true;
  };

  setSelectedActivity = (id: string | null) => {
    this.selectedActivity = this.activityRegistry.get(id);
    this.editMode = false;
  };

  getAllActivities = async () => {
    this.loadingInitial = true;

    const newActivities = await agent.activitiesApi.getAll();
    newActivities.forEach((a) => {
      a.date = a.date.split(".")[0];
      this.activityRegistry.set(a.id, a);
    });

    this.loadingInitial = false;
  };

  createOneActivity = async (activity: IActivity) =>
    await this.processActivity(
      () => agent.activitiesApi.createOne(activity),
      () => this.activityRegistry.set(activity.id, activity),
      activity
    );

  editOneActivity = async (activity: IActivity) =>
    await this.processActivity(
      () => agent.activitiesApi.updateOne(activity),
      () => this.activityRegistry.set(activity.id, activity),
      activity
    );

  deleteOneActivity = async (
    e: SyntheticEvent<HTMLButtonElement>,
    id: string
  ) => {
    this.target = e.currentTarget.name;

    await this.processActivity(
      () => agent.activitiesApi.deleteOne(id),
      () => this.activityRegistry.delete(id)
    );

    if (this.selectedActivity?.id === id) {
      this.selectedActivity = null;
      this.editMode = false;
    }
  };

  private processActivity = async (
    apiCall: Function,
    registryAction: Function,
    activity: IActivity | null = null
  ) => {
    this.submitting = true;
    await apiCall();
    this.submitting = false;

    registryAction();
    this.selectedActivity = activity;
    this.editMode = false;
  };
}

const ActivityContext = createContext(new ActivityStore());
export default ActivityContext;
