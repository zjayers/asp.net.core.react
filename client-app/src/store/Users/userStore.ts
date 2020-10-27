import { autorun, makeAutoObservable, reaction, runInAction } from "mobx";
import { usersApi } from "../../api";
import { IUser, IUserFormValues } from "../../models";
import { catchAsync } from "../../util/catch-async";
import { history } from "../../app/features/browser-history";
import { RootStore } from "../index";

export default class UserStore {
  rootStore: RootStore;

  // * Observables
  user: IUser | null = null;
  token: string | null = null;
  getUser = catchAsync(async () => {
    const user = await usersApi.getCurrentUser();
    runInAction(() => (this.user = user));
  });

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);

    autorun(() => {
      runInAction(() => {
        this.token = window.localStorage.getItem("jwt");
      });
    });

    reaction(
      () => this.token,
      (token) => {
        runInAction(() => {
          token
            ? window.localStorage.setItem("jwt", token)
            : window.localStorage.removeItem("jwt");
        });
      }
    );
  }

  // * Computed
  get isUserLoggedIn() {
    return !!this.user;
  }

  logout = () => {
    this.setToken(null);
    this.user = null;
    history.push("/");
  };

  setToken = (token: string | null) => {
    window.localStorage.setItem("jwt", token || "");
    this.token = token;
  };

  private setUserTokenAndContinue = (user: IUser | null) => {
    runInAction(() => {
      if (user?.token) {
        this.setToken(user.token);
        this.rootStore.modalStore.closeModal();
        history.push("/events");
      }
    });
  };

  // * Actions
  login = catchAsync(async (values: IUserFormValues) => {
    const user = await usersApi.login(values);
    this.setUserTokenAndContinue(user);
  });
  register = catchAsync(async (values: IUserFormValues) => {
    const user = await usersApi.register(values);
    this.setUserTokenAndContinue(user);
  });
}
