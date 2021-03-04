import { UserModel } from "./user.model";

export class SessionModel {
  public user: UserModel;
  public token: string;
}
