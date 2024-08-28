import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css'
import CardList from './Components/CardList/CardList'
import SearchBar from './Components/SearchBar/SearchBar'
import { CompanySearch } from './company.d';
import { searchCompanies } from './api';
import ListPortfolio from './Components/Portfolio/ListPortfolio/ListPortfolio';

function App() {
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
    if (exists){
      return;
    }
    const updatedPortfolio = [...portfolioValues, e.target[0].value];
    setPortfolioValues(updatedPortfolio);
    console.log(e);
  };

  return (
    <>
      {serverError && <h1>{serverError}</h1>}
      <div className="App">
        <SearchBar
          onSearchSubmit={onSearchSubmit}
          search={searchBarValue}
          handleSearchChange={handleSearchChange}
        />
        <ListPortfolio portfolioValues={portfolioValues} />
        <CardList
          searchResults={searchResult}
          onPortfolioCreate={onPortfolioCreate}
        />
      </div>
    </>
  )
}

export default App
