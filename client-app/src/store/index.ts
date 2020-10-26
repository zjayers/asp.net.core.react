import { createContext } from "react";
import ActivityStore from "./Activities/activityStore";
import GuiStore from "./Gui/GuiStore";
import ModalStore from "./Modal/modalStore";
import UserStore from "./Users/userStore";
import { configure } from "mobx";

configure({ enforceActions: "always" });

export class RootStore {
  activityStore: ActivityStore;
  userStore: UserStore;
  guiStore: GuiStore;
  modalStore: ModalStore;

  constructor() {
    this.activityStore = new ActivityStore(this);
    this.userStore = new UserStore(this);
    this.guiStore = new GuiStore(this);
    this.modalStore = new ModalStore(this);
  }
}

export const RootContext = createContext(new RootStore());
