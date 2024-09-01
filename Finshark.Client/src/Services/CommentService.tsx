import { handleError } from "../Helpers/ErrorHandler";
import { CommentGet, CommentPost } from "../Models/Comment";
import axios from "axios";

const api = `${import.meta.env.VITE_APP_API_URL}/comment/`;

export const commentPostAPI = async (title: string, content: string, symbol: string) => {
    try {
        const data = await axios.post<CommentPost>(api + `${symbol}`, {
            title: title,
            content: content,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
}

export const commentGetAPI = async (symbol: string) => {
    try {
        const data = await axios.get<CommentGet[]>(api + `?Symbol=${symbol}`);
        return data;
    } catch (error) {
        handleError(error);
    }
} 