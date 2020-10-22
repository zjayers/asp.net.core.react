import axios, { AxiosResponse } from "axios";
import { IActivity } from "../models";

axios.defaults.baseURL = "http://localhost:5000/api";

const sleep = (ms: number) => (response: AxiosResponse) =>
  new Promise<AxiosResponse>((resolve) =>
    setTimeout(() => resolve(response), ms)
  );

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string) => axios.get(url).then(sleep(1000)).then(responseBody),
  post: (url: string, body: {}) =>
    axios.post(url, body).then(sleep(1000)).then(responseBody),
  put: (url: string, body: {}) =>
    axios.put(url, body).then(sleep(1000)).then(responseBody),
  delete: (url: string) =>
    axios.delete(url).then(sleep(1000)).then(responseBody),
};

const activitiesApi = {
  getAll: (): Promise<IActivity[]> => requests.get("/activities"),
  getOne: (id: string): Promise<IActivity> => requests.get(`/activities/${id}`),
  createOne: (activity: IActivity) => requests.post("/activities", activity),
  updateOne: (activity: IActivity) =>
    requests.put(`/activities/${activity.id}`, activity),
  deleteOne: (id: string) => requests.delete(`/activities/${id}`),
};

export default {
  activitiesApi,
};
