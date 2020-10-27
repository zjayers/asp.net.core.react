import { IPhoto, IProfile } from "../models";
import { requests } from "./baseRequests";

export const profilesApi = {
  getProfile: (username: string): Promise<IProfile> =>
    requests.get(`/profiles/${username}`),
  getFollowings: (username: string, predicate: string) =>
    requests.get(`/profiles/${username}/follow?predicate=${predicate}`),
  updateProfile: (profile: Partial<IProfile>) =>
    requests.put("/profiles", profile),
  uploadPhoto(photo: string): Promise<IPhoto> {
    return requests.postForm(`/photos`, photo);
  },
  setAvatar: (id: string) => requests.post(`/photos/${id}/setAvatar`, {}),
  deletePhoto: (id: string) => requests.delete(`/photos/${id}`),
  follow: (username: string) =>
    requests.post(`/profiles/${username}/follow`, {}),
  unfollow: (username: string) =>
    requests.delete(`/profiles/${username}/follow`),
};
