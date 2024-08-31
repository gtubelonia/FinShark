
import { SyntheticEvent } from 'react';
import { CompanySearch } from '../../company.d';
import AddPortfolio from '../Portfolio/AddPortfolio/AddPortfolio';
import { Link } from 'react-router-dom';

type Props = {
    id: string;
    searchResult: CompanySearch;
    onPortfolioCreate: (e: SyntheticEvent) => void;
}

const Card = ({ id, searchResult, onPortfolioCreate }: Props): JSX.Element => {
    return (
        <>
            <div className="grid grid-cols-2 bg-slate-100 border-2">
                <div
                    className=" justify-evenly p-6 rounded-lg "
                    key={id}
                    id={id}
                >
                    <Link to={`/company/${searchResult.symbol}/company-profile`}
                        className="font-bold btn text-center text-black md:text-left"
                    >
                        <button className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded">
                            {searchResult.name} ({searchResult.symbol})
                        </button>
                    </Link>
                    <p className="text-black p-2"> {searchResult.currency} </p>
                    <p className="font-bold text-black">
                        {searchResult.exchangeShortName} - {searchResult.stockExchange}
                    </p>
                </div>
                <div className="content-center p-6">
                    <AddPortfolio
                        onPortfolioCreate={onPortfolioCreate}
                        symbol={searchResult.symbol}
                    />
                </div>
            </div>
        </>

    );
};

export default Card;