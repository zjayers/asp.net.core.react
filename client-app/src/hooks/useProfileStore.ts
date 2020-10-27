import { useContext } from "react";
import { RootContext } from "../store";

export const useProfileStore = () => useContext(RootContext).profileStore;
