using FinShark.Dtos.Comment;
using FinShark.Helpers;
using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<Models.UserProfile?> GetByUserAsync(AppUser appUser);
        Task<Models.UserProfile> CreateAsync(UserProfile userProfile);
        Task<Models.UserProfile?> UpdateAsync(AppUser appUser, ProfileDto updateUserProfile);
        Task<Models.UserProfile?> DeleteAsync(AppUser appUser);
    }
}
