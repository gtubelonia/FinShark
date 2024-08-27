import { createContext, useEffect, useState } from "react";
import { UserProfile } from "../Models/User";
import { useNavigate } from "react-router";
import axios from "axios";
import React from "react";
import { toast } from "react-toastify";
import { registerAPI, loginAPI } from "../services/AuthService";

type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser: (email: string, username: string, password: string) => void;
    loginUser: (username: string, password: string) => void;
    logout: () => void;
    isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {

    const navigate = useNavigate();
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<UserProfile | null>(null);
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");

        if (user && token) {
            setUser(JSON.parse(user));
            setToken(token);
            axios.defaults.headers.common["Authorization"] = "Bearer " + token;
        }
        setIsReady(true);
    }, []);

    const registerUser = async (email: string, username: string, password: string) => {
        await registerAPI(email, username, password)
            .then((response) => {
                if (response) {
                    localStorage.setItem("token", response?.data.token);
                    const userObj = {
                        userName: response?.data.userName,
                        email: response?.data.email
                    };
                    localStorage.setItem("user", JSON.stringify(userObj));
                    // eslint-disable-next-line @typescript-eslint/no-non-null-asserted-optional-chain
                    setToken((response?.data.token)!);
                    setUser(userObj!);
                    toast.success("Registered and Logged in");
                    navigate("/search");
                }
            }).catch((e) => toast.warning("Server error occured"));
    };

    const loginUser = async (
        username: string,
        password: string) => {
        await loginAPI(username, password)
            .then((response) => {
                if (response) {
                    localStorage.setItem("token", response?.data.token);
                    const userObj = {
                        userName: response?.data.userName,
                        email: response?.data.email
                    };
                    localStorage.setItem("user", JSON.stringify(userObj));
                    // eslint-disable-next-line @typescript-eslint/no-non-null-asserted-optional-chain
                    setToken((response?.data.token)!);
                    setUser(userObj!);
                    toast.success("Logged in");
                    navigate("/search");
                }
            }).catch((e) => toast.warning("Server error occured"));
    };

    const isLoggedIn = () => {
        return !!user;
    };

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        setUser(null);
        setToken("");
        navigate("/");
    }

    return (
        <UserContext.Provider value={{ loginUser, user, token, logout, isLoggedIn, registerUser }}>
            {isReady ? children : null}
        </UserContext.Provider>
    );
};

export const useAuth = () => React.useContext(UserContext);