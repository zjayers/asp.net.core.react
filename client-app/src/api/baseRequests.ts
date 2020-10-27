/* Generic Requests */
import axios, { AxiosResponse } from "axios";

/* Utility function to extract the data property from axios responses*/
const responseBody = (response: AxiosResponse) => response.data;

export const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  postForm: async (url: string, file: string) => {
    const formData = new FormData();
    const blob = await fetch(file).then((res) => res.blob());

    formData.append("File", blob);

    return axios
      .post(url, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then(responseBody);
  },
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};
