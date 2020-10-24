import { makeAutoObservable, observable } from "mobx";
import { RootStore } from "../index";

export default class ModalStore {
  rootStore: RootStore;
  modal = {
    open: false,
    body: null,
  };

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this, {
      modal: observable.shallow,
    });
  }

  openModal = (content: any) => {
    this.modal.open = true;
    this.modal.body = content;
  };

  closeModal = () => {
    this.modal.open = false;
    this.modal.body = null;
  };
}
