using FinShark.Extension;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace FinShark.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;

        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepo, IPortfolioRepository portfolioRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserStockPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                return BadRequest("Symbol not found");
            }

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            if (userPortfolio.Any(s => s.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Cannot add same stock to portfolio");
            }

            var portfolioModel = new StockPortfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id,
            };

            await _portfolioRepo.CreateAsync(portfolioModel);

            if (portfolioModel == null)
            {
                return StatusCode(500, "Could Not Create");
            }

            return Ok("Created");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();

            if(filteredStock.Count() == 1)
            {
                await _portfolioRepo.DeleteAsync(appUser, symbol);
            }
            else
            {
                return BadRequest("Stock Not in you portfolio");
            }

            return Ok("Deleted");
        }
    }
}
