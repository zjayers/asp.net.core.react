import { IAttendee } from "./IAttendee";

export interface IActivity {
  id: string;
  title: string;
  description: string;
  category: string;
  date: Date;
  time?: Date;
  city: string;
  venue: string;
  attendees: IAttendee[];
  isGoing: boolean;
  isHost: boolean;
}
