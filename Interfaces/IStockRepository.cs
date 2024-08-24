using FinShark.Dtos.Stock;
using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockmodel);
        Task<Stock?> UpdateAsync(int idk, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
    }
}
