import { useContext } from "react";
import { RootContext } from "../../store";

export const useModalStore = () => useContext(RootContext).modalStore;
