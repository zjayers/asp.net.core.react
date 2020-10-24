import { useContext } from "react";
import { RootContext } from "../store";

export const useActivityStore = () => useContext(RootContext).activityStore;
