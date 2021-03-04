import { UserInterface } from "../interfaces/user.interface";

export class UserModel implements UserInterface {
    idRol: number;
    id: number;
    name: string;
    lastName: string;
    userName: string;
    password: string;
    bookings: string;
}
