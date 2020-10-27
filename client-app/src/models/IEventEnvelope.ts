import { IEvent } from "./IEvent";

export interface IEventEnvelope {
  events: IEvent[];
  eventCount: number;
}
