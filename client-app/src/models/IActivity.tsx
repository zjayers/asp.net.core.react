export interface IActivity {
  id: string;
  title: string;
  description: string;
  category: string;
  date: Date;
  time?: Date;
  city: string;
  venue: string;
}
