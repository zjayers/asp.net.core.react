import { toast } from "react-toastify";
import { history } from "../app/features/browser-history";
import { navigateToNotFoundPage } from "../util/navigate-to-not-found-page";

export const catchHttpErrorAndToast = (error: any) => {
  if (error.message === "Network Error" || !error.response) {
    toast.error(
      "Network error occurred! Please check your internet connection."
    );

    throw error;
  }

  const { status, data, config, headers } = error.response;

  switch (status) {
    // Bad Request
    case 400:
      config.method === "get" &&
        data.errors.hasOwnProperty("id") &&
        navigateToNotFoundPage();
      break;
    // Unauthorized
    case 401:
      console.log(headers["www-authenticate"]);

      if (
        headers["www-authenticate"] &&
        headers["www-authenticate"].includes("The token expired")
      ) {
        window.localStorage.removeItem("jwt");
        history.push("/");
        history.push("/");
        history.push("/");
        history.push("/");
        history.push("/");
        history.push("/");
        history.push("/");
        history.push("/");
        history.push("/");
        toast.info("Your session has expired. Please login again.");
      }
      console.log(error.response);
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
};
