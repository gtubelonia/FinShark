using FinShark.Data;
using FinShark.Dtos.Comment;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

public class UserProfileRepository : IUserProfileRepository
{

    private readonly ApplicationDBContext _context;
    public UserProfileRepository(ApplicationDBContext context)
    {
        _context = context;

    }
    public async Task<UserProfile> CreateAsync(UserProfile userProfile)
    {
        await _context.UserProfiles.AddAsync(userProfile);
        await _context.SaveChangesAsync();
        return userProfile;
    }

    public async Task<UserProfile?> DeleteAsync(AppUser appUser)
    {
        var userProfileModel = await _context.UserProfiles.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id);

        if (userProfileModel == null)
        {
            return null;
        }

        _context.UserProfiles.Remove(userProfileModel);
        await _context.SaveChangesAsync();
        return userProfileModel;
    }

    public async Task<UserProfile?> GetByUserAsync(AppUser appUser)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id);
    }

    public async Task<UserProfile?> UpdateAsync(AppUser appUser, ProfileDto updateUserProfile)
    {
        var existingUserProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id);

        if (existingUserProfile == null)
        {
            return null;
        }

        existingUserProfile.FirstName = updateUserProfile.FirstName;
        existingUserProfile.MiddleName = updateUserProfile.MiddleName;
        existingUserProfile.LastName = updateUserProfile.LastName;

        await _context.SaveChangesAsync();

        return existingUserProfile;
    }
}

