using FinShark.Dtos.Stock;
using FinShark.Helpers;
using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetBySymbolAsync(string symbol);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockmodel);
        Task<Stock?> UpdateAsync(int idk, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);

        Task<bool> Exists(int id);
    }
}
