import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";

const api = "http://localhost:5097"

export const loginAPI = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/login", {
            username: username,
            password: password,
        });
        return (data);
    } catch (error) {
        handleError();
    }
}

export const registerAPI = async (username: string, password: string, email: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/register", {
            username: username,
            password: password,
            email: email,
        });
        return (data);
    } catch (error) {
        handleError();
    }
}