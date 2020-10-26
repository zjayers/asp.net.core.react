import { IActivity, IUser } from "../models";

export const checkActivityAttendeeProps = (
  activity: IActivity,
  user: IUser
) => {
  activity.isGoing = activity.attendees.some(
    (at) => at.userName === user?.userName
  );

  activity.isHost = activity.attendees.some(
    (at) => at.userName === user?.userName && at.isHost
  );
};
