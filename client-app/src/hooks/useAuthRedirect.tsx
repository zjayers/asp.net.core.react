import React from "react";
import { Redirect } from "react-router-dom";
import { useUserStore } from "./useUserStore";

export const useAuthRedirect = (Component: JSX.Element) => {
  const { isUserLoggedIn, isTokenValid } = useUserStore();

  if (isUserLoggedIn && isTokenValid) {
    return <Redirect to="/events" />;
  }

  return Component;
};
