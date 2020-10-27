import { createContext } from "react";
import EventStore from "./events/eventStore";
import CommentStore from "./comments/commentStore";
import GuiStore from "./gui/GuiStore";
import ModalStore from "./Modal/modalStore";
import ProfileStore from "./Profile/profileStore";
import UserStore from "./Users/userStore";
import { configure } from "mobx";

configure({ enforceActions: "always" });

export class RootStore {
  eventStore: EventStore;
  userStore: UserStore;
  guiStore: GuiStore;
  modalStore: ModalStore;
  profileStore: ProfileStore;
  commentStore: CommentStore;

  constructor() {
    this.eventStore = new EventStore(this);
    this.userStore = new UserStore(this);
    this.guiStore = new GuiStore(this);
    this.modalStore = new ModalStore(this);
    this.profileStore = new ProfileStore(this);
    this.commentStore = new CommentStore(this);
  }
}

export const RootContext = createContext(new RootStore());
