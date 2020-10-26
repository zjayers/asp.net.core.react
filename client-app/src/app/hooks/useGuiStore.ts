import { useContext } from "react";
import { RootContext } from "../../store";

export const useGuiStore = () => useContext(RootContext).guiStore;
