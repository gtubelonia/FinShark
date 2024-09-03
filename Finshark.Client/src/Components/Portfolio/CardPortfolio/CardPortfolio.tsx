import React, { SyntheticEvent } from 'react'
import DeletePortfolio from '../DeletePortfolio/DeletePortfolio';
import { Link } from 'react-router-dom';
import { PortfolioGet } from '../../../Models/portfolio';

type Props = {
    portfolioValue: PortfolioGet;
    onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
    return (
        <div className="p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/2">
            <Link to={`/company/${portfolioValue.symbol}/company-profile`} className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded">
                {portfolioValue.symbol}
            </Link>
            <p>Price: ${portfolioValue.purchase}</p>
            <p>Industry: {portfolioValue.industry}</p>
            <DeletePortfolio
                portfolioValue={portfolioValue.symbol}
                onPortfolioDelete={onPortfolioDelete}
            />
        </div>
    )
}

export default CardPortfolio