import { makeAutoObservable } from "mobx";
import { RootStore } from "../index";

export default class GuiStore {
  rootStore: RootStore;

  // * Observables
  appLoaded = false;
  loadingInitial = false;
  loadingSecondary = false;
  editMode = false;
  submitting = false;
  target = "";

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  /**
   * Set form edit mode
   */
  setEditMode = (mode: boolean) => (this.rootStore.guiStore.editMode = mode);

  // * Actions
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

  setAppAsLoaded = () => (this.appLoaded = true);
}
