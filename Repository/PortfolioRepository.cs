using FinShark.Data;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.StockPortfolios.Where(p => p.AppUserId == user.Id)
                .Select(stockPortfolio => new Stock
                {
                    Id = stockPortfolio.StockId,
                    Symbol = stockPortfolio.Stock.Symbol,
                    CompanyName = stockPortfolio.Stock.CompanyName,
                    Purchase = stockPortfolio.Stock.Purchase,
                    LastDiv = stockPortfolio.Stock.LastDiv,
                    Industry = stockPortfolio.Stock.Industry,
                    MarketCap = stockPortfolio.Stock.MarketCap

                }).ToListAsync();
        }

        public async Task<StockPortfolio> CreateAsync(StockPortfolio portfolio)
        {
            await _context.StockPortfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<StockPortfolio> DeleteAsync(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.StockPortfolios.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());
            if (portfolioModel == null)
            {
                return null;
            }

            _context.StockPortfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();

            return portfolioModel;
        }
    }
}
