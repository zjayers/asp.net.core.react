import { IUser, IUserFormValues } from "../../models";
import { autorun, makeAutoObservable, reaction, runInAction } from "mobx";

import { RootStore } from "../index";
import { catchAsync } from "../../util/catch-async";
import { history } from "../../app/features/browser-history";
import { usersApi } from "../../api";

export default class UserStore {
  rootStore: RootStore;

  // * Observables
  user: IUser | null = null;
  token: string | null = null;
  loadingFacebook = false;
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

  get isTokenValid() {
    const token = window.localStorage.getItem("jwt");
    return !!token;
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
        this.user = user;
        this.setToken(user.token);
        this.rootStore.modalStore.closeModal();
        history.push("/events");
      }
    });
  };

  fbLogin = catchAsync(
    async (response: any) => {
      this.loadingFacebook = true;
      const user = await usersApi.fbLogin(response.accessToken);
      this.setUserTokenAndContinue(user);
      runInAction(() => {
        this.loadingFacebook = false;
      });
    },
    () => (this.loadingFacebook = false)
  );
  login = catchAsync(async (values: IUserFormValues) => {
    const user = await usersApi.login(values);
    this.setUserTokenAndContinue(user);
  });
  register = catchAsync(async (values: IUserFormValues) => {
    const user = await usersApi.register(values);
    this.setUserTokenAndContinue(user);
  });
}
