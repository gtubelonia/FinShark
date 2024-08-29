import React, { ChangeEvent, SyntheticEvent, useState } from 'react'
import { searchCompanies } from '../../api';
import { CompanySearch } from '../../company.d';
import CardList from '../../Components/CardList/CardList';
import Navbar from '../../Components/Navbar/Navbar';
import ListPortfolio from '../../Components/Portfolio/ListPortfolio/ListPortfolio';
import SearchBar from '../../Components/SearchBar/SearchBar';

type Props = {}

const SearchPage = (props: Props) => {

    const [searchBarValue, setSearchBarValue] = useState<string>("");
    const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
    const [serverError, setServerError] = useState<string | null>(null);
    const [portfolioValues, setPortfolioValues] = useState<string[]>([]);

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

    const onPortfolioCreate = (e: any) => {
        e.preventDefault();
        const exists = portfolioValues.find((value) => value === e.target[0].value);
        if (exists) {
            return;
        }
        const updatedPortfolio = [...portfolioValues, e.target[0].value];
        setPortfolioValues(updatedPortfolio);
        console.log(e);
    };

    const onPortfolioDelete = (e: any) => {
        e.preventDefault();
        const removed = portfolioValues.filter((value) => {
            return value !== e.target[0].value;
        });
        setPortfolioValues(removed);
    }

    return (
        <>
            {serverError && <h1>{serverError}</h1>}
            <div className="App">
                {/* <Hero /> */}
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