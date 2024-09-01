import { handleError } from "../Helpers/ErrorHandler";
import axios from "axios";
import { PortfolioGet, PortfolioPost } from "../Models/portfolio";

const api = `${import.meta.env.VITE_APP_API_URL}/portfolio/`;

export const portfolioAddAPI = async (symbol: string) => {
    try {
        const data = await axios.post<PortfolioPost>(api + `${symbol}`, {
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const portfolioDeleteAPI = async (symbol: string) => {
    try {
        const data = await axios.delete<PortfolioPost>(api + `?symbol=${symbol}`, {
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const portfolioGetAPI = async () => {
    try {
        const data = await axios.get<PortfolioGet[]>(api);
        return data;
    } catch (error) {
        handleError(error);
    }
};