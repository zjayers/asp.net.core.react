/* Specialized Requests for Activities */
import { IEvent, IEventEnvelope } from "../models";
import { requests } from "./baseRequests";

export const eventsApi = {
  getAll: (params: URLSearchParams): Promise<IEventEnvelope> =>
    requests.get(`/events`, params),

  getOne: (id: string): Promise<IEvent> => requests.get(`/events/${id}`),
  createOne: (activity: IEvent) => requests.post("/events", activity),
  createAttendee: (id: string) => requests.post(`/events/${id}/attend`, {}),
  updateOne: (activity: IEvent) =>
    requests.put(`/events/${activity.id}`, activity),
  deleteOne: (id: string) => requests.delete(`/events/${id}`),
  removeAttendee: (id: string) => requests.delete(`/events/${id}/attend`),
};
