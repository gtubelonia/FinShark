using Microsoft.AspNetCore.Identity;

namespace FinShark.Models
{
    //handles password behind the scene?
    public class AppUser : IdentityUser
    {
        public List<StockPortfolio> StockPortfolios { get; set; } = new List<StockPortfolio>();

        public UserProfile? userProfile { get; set; }

    }
}
