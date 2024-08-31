import axios from "axios";
import { CompanyBalanceSheet, CompanyCashFlow, CompanyIncomeStatement, CompanyKeyMetrics, CompanyProfile, CompanySearch } from "./company.d";
import { handleError } from "./Helpers/ErrorHandler";

interface SearchResponse {
    data: CompanySearch[];
}

export const searchCompanies = async (query: string) => {
    try {
        const data = await axios.get<SearchResponse>(
            `https://financialmodelingprep.com/api/v3/search-ticker?query=${query}&limit=10&exchange=NASDAQ&apikey=${import.meta.env.VITE_APP_API_KEY}`
        );

        return data;
    } catch (error: any) {
        if (error.response) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error has occured."
        }
    }
};

export const getCompanyProfile = async (query: string) => {
    try {
        const data = await axios.get<CompanyProfile[]>(
            `https://financialmodelingprep.com/api/v3/profile/${query}?apikey=${import.meta.env.VITE_APP_API_KEY}`
        )

        return data;
    } catch (error: any) {
        handleError(error);
    }
}

export const getKeyMetrics = async (query: string) => {
    try {
        const data = await axios.get<CompanyKeyMetrics>(
            `https://financialmodelingprep.com/api/v3/key-metrics-ttm/${query}?apikey=${import.meta.env.VITE_APP_API_KEY}`
        )

        return data;
    } catch (error: any) {
        handleError(error);
    }
}

export const getIncomeStatement = async (query: string) => {
    try {
        const data = await axios.get<CompanyIncomeStatement[]>(
            `https://financialmodelingprep.com/api/v3/income-statement/${query}?limit=40&apikey=${import.meta.env.VITE_APP_API_KEY}`
        )

        return data;
    } catch (error: any) {
        handleError(error);
    }
}

export const getBalanceSheet = async (query: string) => {
    try {
        const data = await axios.get<CompanyBalanceSheet[]>(
            `https://financialmodelingprep.com/api/v3/balance-sheet-statement/${query}?limit=40&apikey=${import.meta.env.VITE_APP_API_KEY}`
        )

        return data;
    } catch (error: any) {
        handleError(error);
    }
}

export const getCashFlowStatement = async (query: string) => {
    try {
        const data = await axios.get<CompanyCashFlow[]>(
            `https://financialmodelingprep.com/api/v3/cash-flow-statement/${query}?limit=40&apikey=${import.meta.env.VITE_APP_API_KEY}`
        )

        return data;
    } catch (error: any) {
        handleError(error);
    }
}