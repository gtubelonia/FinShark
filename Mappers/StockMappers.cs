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
                MarketCap = stockModel.MarketCap
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
    }
}
