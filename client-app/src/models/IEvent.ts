import { IAttendee } from "./IAttendee";
import { IComment } from "./IComment";

export interface IEvent {
  id: string;
  title: string;
  description: string;
  category: string;
  date: Date;
  time?: Date;
  city: string;
  venue: string;
  attendees: IAttendee[];
  comments: IComment[];
  isGoing: boolean;
  isHost: boolean;
}
