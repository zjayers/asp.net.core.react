import { makeAutoObservable, runInAction } from "mobx";
import { profilesApi } from "../../api";
import { IPhoto, IProfile } from "../../models";
import { catchAsync } from "../../util/catch-async";
import { RootStore } from "../index";

export default class ProfileStore {
  rootStore: RootStore;
  profile: IProfile | null = null;
  loadingProfile = true;
  loadingAvatar = false;
  uploadingFile = false;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  get isCurrentUser() {
    if (this.rootStore.userStore.user && this.profile) {
      return this.rootStore.userStore.user.userName === this.profile.userName;
    }

    return false;
  }

  loadProfile = catchAsync(
    async (username: string) => {
      this.loadingProfile = true;
      const profile = await profilesApi.getProfile(username);
      runInAction(() => {
        this.profile = profile;
        this.loadingProfile = false;
      });
    },
    () => {
      this.loadingProfile = false;
    }
  );

  updateProfile = catchAsync(async (profile: Partial<IProfile>) => {
    await profilesApi.updateProfile(profile);
    runInAction(() => {
      if (profile.displayName !== this.rootStore.userStore.user!.displayName) {
        this.rootStore.userStore.user!.displayName = profile.displayName!;
      }
      this.profile = { ...this.profile!, ...profile };
    });
  });

  uploadPhoto = catchAsync(
    async (file: string) => {
      this.uploadingFile = true;
      const photo = await profilesApi.uploadPhoto(file);
      runInAction(() => {
        if (this.profile) {
          this.profile.photos.push(photo);

          if (photo.isAvatar && this.rootStore.userStore.user) {
            this.rootStore.userStore.user.image = photo.url;
            this.profile.image = photo.url;
          }
        }

        this.uploadingFile = false;
      });
    },
    () => (this.uploadingFile = false)
  );

  setAvatar = catchAsync(
    async (photo: IPhoto) => {
      this.loadingAvatar = true;
      await profilesApi.setAvatar(photo.id);

      runInAction(() => {
        this.rootStore.userStore.user!.image = photo.url;
        this.profile!.photos.find((a) => a.isAvatar)!.isAvatar = false;
        this.profile!.photos.find((a) => a.id === photo.id)!.isAvatar = true;
        this.profile!.image = photo.url;
        this.loadingAvatar = false;
      });
    },
    () => (this.loadingAvatar = false)
  );

  deletePhoto = catchAsync(
    async (photo: IPhoto) => {
      this.loadingAvatar = true;
      await profilesApi.deletePhoto(photo.id);
      runInAction(() => {
        this.profile!.photos = this.profile!.photos.filter(
          (p) => p.id !== photo.id
        );
        this.loadingAvatar = false;
      });
    },
    () => (this.loadingAvatar = false)
  );
}
