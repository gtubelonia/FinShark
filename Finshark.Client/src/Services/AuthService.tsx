import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";
import axios from "axios";

const api = `${import.meta.env.VITE_APP_API_URL}/account/`;

export const loginUserAPI = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "login", {
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
        const data = await axios.post<UserProfileToken>(api + "register", {
            username: username,
            password: password,
            email: email,
        });
        return (data);
    } catch (error) {
        handleError(error);
    }
};