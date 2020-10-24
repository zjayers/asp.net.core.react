import { toast } from "react-toastify";
// Catch all function for wrapping async api calls
export const catchAsync = (fn: Function) => {
  return async (...args: any) => {
    try {
      return await fn(...args);
    } catch (e) {
      toast.error(e.message);
      throw e;
    }
  };
};
