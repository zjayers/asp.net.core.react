import { useContext } from "react";
import { RootContext } from "../store";

export const useCommentStore = () => useContext(RootContext).commentStore;
