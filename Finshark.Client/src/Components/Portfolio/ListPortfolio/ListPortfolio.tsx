import React from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';
import { v4 as uudiv4 } from "uuid";

type Props = {
    portfolioValues: string[];
}

const ListPortfolio = ({ portfolioValues }: Props) => {
    return (
        <>
            <h3>My Portfolio</h3>
            <ul>
                {portfolioValues &&
                    portfolioValues.map((portfolioValue) => {
                        return <CardPortfolio portfolioValue={portfolioValue} key={uudiv4()}/>
                    })}
            </ul>
        </>
    )
}

export default ListPortfolio