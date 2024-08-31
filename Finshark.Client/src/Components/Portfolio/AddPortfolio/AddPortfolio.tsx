import React, { SyntheticEvent } from 'react'

type Props = {
    onPortfolioCreate: (e: SyntheticEvent) => void;
    symbol: string;
}

//Categorize stocks by industry and by top performers somehow?
const AddPortfolio = (
    { onPortfolioCreate, symbol }: Props) => {
    return (
        <div className="flex flex-col items-center justify-end flex-1 space-x-4 space-y-2 md:flex-row md:space-y-0">
            <form onSubmit={onPortfolioCreate}>
                <input readOnly={true} hidden={true} value={symbol} />
                <button
                    type="submit"
                    className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded-lg focus:outline-none"
                >
                    Add
                </button>
            </form>
        </div>
    );
};

export default AddPortfolio