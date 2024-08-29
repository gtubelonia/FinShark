import React, { SyntheticEvent } from 'react'

type Props = {
    onPortfolioDelete: (e: SyntheticEvent) => void;
    portfolioValue: string;
}

const DeletePortfolio = ({ onPortfolioDelete, portfolioValue }: Props) => {
    return (
        <div>
            <form onSubmit={onPortfolioDelete}>
                <input
                    hidden={true}
                    value={portfolioValue}
                />
                <button type="submit">X</button>
            </form>
        </div>
    );
}

export default DeletePortfolio