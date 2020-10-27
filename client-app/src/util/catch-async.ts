import { runInAction } from "mobx";
import { toast } from "react-toastify";
// Catch all function for wrapping async api calls
export const catchAsync = (fn: Function, cleanup?: Function) => {
  return async (...args: any) => {
    try {
      return await fn(...args);
    } catch (e) {
      runInAction(() => {
        toast.error(e.message);
        cleanup && cleanup();
        throw e;
      });
    }
  };
};
