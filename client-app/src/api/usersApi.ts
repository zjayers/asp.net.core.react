import { IUser, IUserFormValues } from '../models';

import { requests } from './baseRequests';

export const usersApi = {
  getCurrentUser: (): Promise<IUser> => requests.get('/user'),
  login: (user: IUserFormValues): Promise<IUser> =>
    requests.post('/user/login', user),
  register: (user: IUserFormValues): Promise<IUser> =>
    requests.post('/user/register', user),
  fbLogin: (accessToken: string) =>
    requests.post(`/user/facebook`, { accessToken }),
};
