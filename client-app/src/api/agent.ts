import axios from "axios";
import {
  getJwtTokenFromLocalStorage,
  rejectErrorAsPromise,
} from "./requestInterceptors";
import { catchHttpErrorAndToast } from "./responseInterceptors";

/* Defaults */
axios.defaults.baseURL = process.env.REACT_APP_API_URL;

/* Intercept request and send jwts with requests */
axios.interceptors.request.use(
  getJwtTokenFromLocalStorage,
  rejectErrorAsPromise
);

/* Errors */
axios.interceptors.response.use(undefined, catchHttpErrorAndToast);
