import { history } from "../app/features/browser-history";

export const navigateToNotFoundPage = () => {
  history.push("/notFound");
};
