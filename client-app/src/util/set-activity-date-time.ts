import { IEvent } from "../models";

export const setActivityDateTime = (activity: IEvent) =>
  (activity.date = activity.time = new Date(activity.date));
