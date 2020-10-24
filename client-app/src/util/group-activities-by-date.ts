import { IActivity } from "../models";

/**
 * Utility method to sort and group activities by date
 */
export const groupActivitiesByDate = (activities: IActivity[]) => {
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
};
