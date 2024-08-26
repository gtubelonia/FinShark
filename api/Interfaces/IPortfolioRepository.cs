using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<StockPortfolio> CreateAsync(StockPortfolio portfolio);
        Task<StockPortfolio> DeleteAsync(AppUser appUser, string symbol);
    }
}
