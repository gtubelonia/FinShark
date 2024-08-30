import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";
import axios from "axios";

const api = "http://localhost:5097/api/";

export const loginUserAPI = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/login", {
            username: username,
            password: password,
        });

        return data;
    } catch (error) {
        handleError(error);
    }
};

export const registerUserAPI = async (username: string, password: string, email: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/register", {
            username: username,
            password: password,
            email: email,
        });
        return (data);
    } catch (error) {
        handleError(error);
    }
};