import React, { SyntheticEvent } from 'react'
import Card from '../Card/Card'
import { CompanySearch } from '../../company.d';
import { v4 as uudiv4 } from "uuid";
type Props = {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const CardList = ({ searchResults, onPortfolioCreate }: Props): JSX.Element => {
  return (
    <>
      <div className ="container max-w-full mx-auto">
        {searchResults.length > 0 ? (

          searchResults.map((result) => {
            return <Card
              onPortfolioCreate={onPortfolioCreate}
              id={result.symbol}
              searchResult={result}
              key={uudiv4()} />
          })

        ) :
          (
            <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
              No Results
            </p>
          )}
      </div>
    </>
  )
}

export default CardList