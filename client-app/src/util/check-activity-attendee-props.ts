import { IEvent, IUser } from "../models";

export const checkActivityAttendeeProps = (activity: IEvent, user: IUser) => {
  activity.isGoing = activity.attendees.some(
    (at) => at.userName === user?.userName
  );

  activity.isHost = activity.attendees.some(
    (at) => at.userName === user?.userName && at.isHost
  );
};
