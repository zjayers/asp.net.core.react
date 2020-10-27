import { useContext } from "react";
import { RootContext } from "../store";

export const useUserStore = () => useContext(RootContext).userStore;
