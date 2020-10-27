import { IPhoto, IProfile } from "../models";
import { requests } from "./baseRequests";

export const profilesApi = {
  getProfile: (username: string): Promise<IProfile> =>
    requests.get(`/profiles/${username}`),
  updateProfile: (profile: Partial<IProfile>) =>
    requests.put("/profiles", profile),
  uploadPhoto(photo: string): Promise<IPhoto> {
    return requests.postForm(`/photos`, photo);
  },
  setAvatar: (id: string) => requests.post(`/photos/${id}/setAvatar`, {}),
  deletePhoto: (id: string) => requests.delete(`/photos/${id}`),
};
