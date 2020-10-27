import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
} from "@microsoft/signalr";
import { makeAutoObservable, observable, runInAction } from "mobx";
import { toast } from "react-toastify";
import { catchAsync } from "../../util/catch-async";
import { RootStore } from "../index";

export default class CommentStore {
  rootStore: RootStore;
  public hubConnection: HubConnection | null = null;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this, { hubConnection: observable.ref });
  }

  public addComment = catchAsync(async (values: any) => {
    values.eventId = this.rootStore.eventStore.selectedEvent.id;
    await this.hubConnection!.invoke("SendComment", values);
  });

  public createHubConnection = (eventId: string) => {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:5000/chat", {
        accessTokenFactory: () => this.rootStore.userStore.token!,
      })
      .configureLogging(LogLevel.Critical)
      .build();

    this.hubConnection
      .start()
      .then(() => {
        this.hubConnection?.invoke("AddToGroup", eventId);
      })
      .catch((e) => console.log("Error establishing hub connection: ", e));

    this.hubConnection.on("ReceiveComment", (comment) => {
      runInAction(() => {
        return this.rootStore.eventStore.selectedEvent!.comments.push(comment);
      });
    });
  };

  public stopHubConnection = () => {
    this.hubConnection
      ?.invoke("RemoveFromGroup", this.rootStore.eventStore.selectedEvent.id)
      .then(() => this.hubConnection!.stop())
      .catch((e) => console.log("Error removing hub connection: ", e));
  };
}
