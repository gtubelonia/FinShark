import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from 'react'
import { searchCompanies } from '../../api';
import { CompanySearch } from '../../company.d';
import CardList from '../../Components/CardList/CardList';
import ListPortfolio from '../../Components/Portfolio/ListPortfolio/ListPortfolio';
import SearchBar from '../../Components/SearchBar/SearchBar';
import { PortfolioGet } from '../../Models/portfolio';
import { toast } from 'react-toastify';
import { portfolioAddAPI, portfolioDeleteAPI, portfolioGetAPI } from '../../Services/PortfolioService';

type Props = {}

const SearchPage = (props: Props) => {

    const [searchBarValue, setSearchBarValue] = useState<string>("");
    const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
    const [serverError, setServerError] = useState<string | null>(null);
    const [portfolioValues, setPortfolioValues] = useState<PortfolioGet[] | null>([]);

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearchBarValue(e.target.value);
        console.log(e);
    };

    const onSearchSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const result = await searchCompanies(searchBarValue);
        if (typeof result === "string") {
            setServerError(result);
        } else if (Array.isArray(result.data)) {
            setSearchResult(result.data);
        }
        console.log(searchResult);
    };

    useEffect(()=>{
        getPortfolio();
    },[])

    const getPortfolio = () => {
        portfolioGetAPI()
            .then((res) => {
                if (res?.data) {
                    setPortfolioValues(res?.data);
                }
            }).catch((e) => {
                toast.warning("Could not get portfolio values!");
            })
    }

    const onPortfolioCreate = (e: any) => {
        e.preventDefault();
        portfolioAddAPI(e.target[0].value)
            .then((res) => {
                if (res?.status === 204) {
                    toast.success("Stock added to portfolio");
                    getPortfolio();
                }
            }).catch((e) => {
                toast.warning("Could not create portfolio item!");
            })
    };

    const onPortfolioDelete = (e: any) => {
        e.preventDefault();
        portfolioDeleteAPI(e.target[0].value)
            .then((res) => {
                if (res?.status === 200) {
                    toast.success("Stock deleted from portfolio");
                    getPortfolio();
                }
            })
    }

    return (
        <>
            {serverError && <h1>{serverError}</h1>}
            <div className="App">
                <SearchBar
                    onSearchSubmit={onSearchSubmit}
                    search={searchBarValue}
                    handleSearchChange={handleSearchChange}
                />
                <ListPortfolio portfolioValues={portfolioValues} onPortfolioDelete={onPortfolioDelete} />
                <CardList
                    searchResults={searchResult}
                    onPortfolioCreate={onPortfolioCreate}
                />
            </div>
        </>
    )
}

export default SearchPage