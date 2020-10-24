import { makeAutoObservable } from "mobx";
import { RootStore } from "../index";

export default class GuiStore {
  rootStore: RootStore;

  // * Observables
  loadingInitial = false;
  editMode = false;
  submitting = false;
  target = "";

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  // * Actions

  /**
   * Set form edit mode
   */
  setEditMode = (mode: boolean) => (this.rootStore.guiStore.editMode = mode);

  /**
   * Set button submission flag
   */
  setSubmitting = (mode: boolean) =>
    (this.rootStore.guiStore.submitting = mode);

  /**
   * Set target button when submitting
   */
  setTarget = (targetName: string) =>
    (this.rootStore.guiStore.target = targetName);
}
