import axios, { AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../app/features/browser-history";
import { IActivity, IUser, IUserFormValues } from "../models";

/* Defaults */
axios.defaults.baseURL = "http://localhost:5000/api";

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

  throw error;
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
const activitiesApi = {
  getAll: (): Promise<IActivity[]> => requests.get("/activities"),
  getOne: (id: string): Promise<IActivity> => requests.get(`/activities/${id}`),
  createOne: (activity: IActivity) => requests.post("/activities", activity),
  updateOne: (activity: IActivity) =>
    requests.put(`/activities/${activity.id}`, activity),
  deleteOne: (id: string) => requests.delete(`/activities/${id}`),
};

const usersApi = {
  getCurrentUser: (): Promise<IUser> => requests.get("/user"),
  login: (user: IUserFormValues): Promise<IUser> =>
    requests.post("/user/login", user),
  register: (user: IUserFormValues): Promise<IUser> =>
    requests.post("/user/register", user),
};

export default {
  activitiesApi,
  usersApi,
};
