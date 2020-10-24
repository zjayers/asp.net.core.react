import { makeAutoObservable } from "mobx";
import agent from "../../../api/agent";
import { IUser, IUserFormValues } from "../../../models";
import { catchAsync } from "../../../util/catch-async";
import { RootStore } from "../index";

export default class UserStore {
  rootStore: RootStore;

  // * Observables
  user: IUser | null = null;
  // * Actions
  login = catchAsync(async (values: IUserFormValues) => {
    this.user = await agent.usersApi.login(values);
  });

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  // * Computed
  get isUserLoggedIn() {
    return !!this.user;
  }
}
