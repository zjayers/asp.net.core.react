import { IActivity } from "../models";

export const setActivityDateTime = (activity: IActivity) =>
  (activity.date = activity.time = new Date(activity.date));
