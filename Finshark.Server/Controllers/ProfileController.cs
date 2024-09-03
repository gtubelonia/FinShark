
using FinShark.Data;
using FinShark.Dtos.Comment;
using FinShark.Extension;
using FinShark.Interfaces;
using FinShark.Models;
using FinShark.Repository;
using FinShark.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
namespace FinShark.Controllers
{
    [Route("api/userProfile")]
    [Authorize]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProfileRepository _userProfileRepo;

        public ProfileController(UserManager<AppUser> userManager, IUserProfileRepository userProfileRepo)
        {
            _userManager = userManager;
            _userProfileRepo = userProfileRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userProfile = await _userProfileRepo.GetByUserAsync(appUser);

            if (userProfile == null)
            {
                return Ok(new UserProfile().ToDto());
            }
            else
            {
                return Ok(userProfile.ToDto());
            }
        }

        [HttpPost]

        public async Task<IActionResult> CreateUserProfile([FromBody] ProfileDto createProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var createProfileModel = createProfileDto.ToProfile(appUser);

            await _userProfileRepo.CreateAsync(createProfileModel);

            return CreatedAtAction(nameof(GetUserProfile), createProfileModel.ToDto());

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromBody] ProfileDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userProfileModel = await _userProfileRepo.UpdateAsync(appUser, updateDto);

            if (userProfileModel == null)
            {
                return NotFound("Profile Not Found");
            }

            return Ok(userProfileModel.ToDto());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userProfileModel = await _userProfileRepo.DeleteAsync(appUser);

            if (userProfileModel == null)
            {
                return NotFound("Profile Not Found");
            }

            return NoContent();
        }
    }
}