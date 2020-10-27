import { useContext } from "react";
import { RootContext } from "../store";

export const useEventStore = () => useContext(RootContext).eventStore;
