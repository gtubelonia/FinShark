using FinShark.Dtos.Stock;
using FinShark.Models;
using System.Runtime.CompilerServices;

namespace FinShark.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto CreateStockRequestDto)
        {
            return new Stock
            {
                Symbol = CreateStockRequestDto.Symbol,
                CompanyName = CreateStockRequestDto.CompanyName,
                Purchase = CreateStockRequestDto.Purchase,
                LastDiv = CreateStockRequestDto.LastDiv,
                Industry = CreateStockRequestDto.Industry,
                MarketCap = CreateStockRequestDto.MarketCap
            };
        }

        public static Stock ToStockFromFmp(this FMPStock fmpStock)
        {
            return new Stock
            {
                Symbol = fmpStock.symbol,
                CompanyName = fmpStock.companyName,
                Purchase = (decimal)fmpStock.price,
                LastDiv = (decimal)fmpStock.lastDiv,
                Industry = fmpStock.industry,
                MarketCap = fmpStock.mktCap
            };
        }
    }
}
