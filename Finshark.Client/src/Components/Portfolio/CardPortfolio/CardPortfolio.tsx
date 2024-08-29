import React, { SyntheticEvent } from 'react'
import DeletePortfolio from '../DeletePortfolio/DeletePortfolio';

type Props = {
    portfolioValue: string;
    onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
    return (
        <>
            <h4>{portfolioValue}</h4>
            <DeletePortfolio onPortfolioDelete={onPortfolioDelete} portfolioValue={portfolioValue}></ DeletePortfolio>
        </>
    )
}

export default CardPortfolio