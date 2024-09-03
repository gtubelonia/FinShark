using FinShark.Dtos.Comment;
using FinShark.Models;

public static class UserProfileMapper
{
    public static UserProfile ToProfile(this ProfileDto profileDto, AppUser appUser)
    {
        return new UserProfile
        {
            FirstName = profileDto.FirstName,
            MiddleName = profileDto.MiddleName,
            LastName = profileDto.LastName,
            AppUserId = appUser.Id,
        };
    }

    public static ProfileDto ToDto(this UserProfile userProfile)
    {


        return new ProfileDto
        {
            FirstName = userProfile.FirstName,
            MiddleName = userProfile.MiddleName,
            LastName = userProfile.LastName,
        };
    }
}