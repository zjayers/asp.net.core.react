import { IPhoto } from "./IPhoto";

export interface IProfile {
  displayName: string;
  userName: string;
  bio: string;
  image: string;
  photos: IPhoto[];
}
