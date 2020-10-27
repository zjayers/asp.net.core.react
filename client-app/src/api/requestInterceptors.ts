import { AxiosRequestConfig } from "axios";

export const getJwtTokenFromLocalStorage = (config: AxiosRequestConfig) => {
  const token = window.localStorage.getItem("jwt");
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
};

export const rejectErrorAsPromise = (e: any) => Promise.reject(e);
