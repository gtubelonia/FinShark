import React, { SyntheticEvent } from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';
import { v4 as uudiv4 } from "uuid";

type Props = {
    portfolioValues: string[];
    onPortfolioDelete: (e: SyntheticEvent) => void;
}

const ListPortfolio = ({ portfolioValues, onPortfolioDelete }: Props) => {
    return (
        <>
            <h3>My Portfolio</h3>
            <ul>
                {portfolioValues &&
                    portfolioValues.map((portfolioValue) => {
                        return <CardPortfolio portfolioValue={portfolioValue} onPortfolioDelete={onPortfolioDelete} key={uudiv4()} />
                    })}
            </ul>
        </>
    )
}

export default ListPortfolio