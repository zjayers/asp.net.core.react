import axios, { AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../app/features/browser-history";
import { IActivity, IUser, IUserFormValues } from "../models";

/* Defaults */
axios.defaults.baseURL = "http://localhost:5000/api";

/* Intercept request and send jwts with requests */
axios.interceptors.request.use(
  (config) => {
    const token = window.localStorage.getItem("jwt");
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  (e) => Promise.reject(e)
);

/* Errors */
axios.interceptors.response.use(undefined, (error) => {
  if (error.message === "Network Error" || !error.response) {
    toast.error(
      "Network error occurred! Please check your internet connection."
    );

    throw error;
  }

  const { status, data, config } = error.response;

  switch (status) {
    // Bad Request
    case 400:
      config.method === "get" &&
        data.errors.hasOwnProperty("id") &&
        navigateToNotFoundPage();
      break;
    // Not Found
    case 404:
      navigateToNotFoundPage();
      break;
    // Internal Server Error
    case 500:
      toast.error("Server error occurred! Please try again later.");
      break;
  }

  throw error.response;
});

const navigateToNotFoundPage = () => {
  history.push("/notFound");
};

/* Utility function to extract the data property from axios responses*/
const responseBody = (response: AxiosResponse) => response.data;

/* Generic Requests */
const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

/* Specialized Requests for Activities */
const eventsApi = {
  getAll: (): Promise<IActivity[]> => requests.get("/events"),
  getOne: (id: string): Promise<IActivity> => requests.get(`/events/${id}`),
  createOne: (activity: IActivity) => requests.post("/events", activity),
  createAttendee: (id: string) => requests.post(`/events/${id}/attend`, {}),
  updateOne: (activity: IActivity) =>
    requests.put(`/events/${activity.id}`, activity),
  deleteOne: (id: string) => requests.delete(`/events/${id}`),
  removeAttendee: (id: string) => requests.delete(`/events/${id}/attend`),
};

const usersApi = {
  getCurrentUser: (): Promise<IUser> => requests.get("/user"),
  login: (user: IUserFormValues): Promise<IUser> =>
    requests.post("/user/login", user),
  register: (user: IUserFormValues): Promise<IUser> =>
    requests.post("/user/register", user),
};

export default {
  activitiesApi: eventsApi,
  usersApi,
};
