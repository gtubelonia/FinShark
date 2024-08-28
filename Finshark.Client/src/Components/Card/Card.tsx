
import { SyntheticEvent } from 'react';
import reactLogo from '../../assets/react.svg'
import { CompanySearch } from '../../company.d';
import AddPortfolio from '../Portfolio/AddPortfolio/AddPortfolio';

type Props = {
    id: string;
    searchResult: CompanySearch;
    onPortfolioCreate: (e: SyntheticEvent) => void;
}

const Card = ({ id, searchResult, onPortfolioCreate }: Props): JSX.Element => {
    return <div className="card" key={id} id={id}>
        <img
            src={reactLogo}
            alt="This is a placeholder image"
        />
        <div className="details">
            <h2>{searchResult.name} : ({searchResult.symbol})</h2>
            <p>{searchResult.currency}</p>
        </div>
        <p className="info">{searchResult.exchangeShortName} - {searchResult.stockExchange}
        </p>
        <AddPortfolio onPortfolioCreate={onPortfolioCreate} symbol={searchResult.symbol} />
    </div>
}

export default Card;