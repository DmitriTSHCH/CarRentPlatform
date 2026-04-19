using CarRentPlatform.API.Policy;
using CarRentPlatform.Application.DtoModels;
using CarRentPlatform.Application.Intefaces;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonalAccountController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = PolicyNames.ReadSelf)]
        public async Task<IActionResult> GetSelfInfo(CancellationToken cancellationToken)
        {
            var userId = await GetIdFromClaimsAsync();

            var userInfo = await userService.GetPersonalInfoByIdAsync(userId, cancellationToken);

            return Ok(userInfo);
        }

        [HttpPut("UpdatePhoneNumber")]
        [Authorize(Policy = PolicyNames.UpdateSelf)]
        public async Task<IActionResult> UpdateSelfPhoneNumber(string newPhoneNumber, string password, CancellationToken cancellationToken)
        {
            var userId = await GetIdFromClaimsAsync();

            if (await userService.CheckPasswordAsync(userId, password, cancellationToken))
            {
                userService.UpdatePhoneNumberAsync(userId, newPhoneNumber, cancellationToken);
                return Ok();
            }
            return Unauthorized("недоступно");
        }

        [HttpPut("UpdateEmail")]
        [Authorize(Policy = PolicyNames.UpdateSelf)]
        public async Task<IActionResult> UpdateSelfEmail(string newEmail, string password, CancellationToken cancellationToken)
        {
            var userId = await GetIdFromClaimsAsync();

            if (await userService.CheckPasswordAsync(userId, password, cancellationToken))
            {
                userService.UpdateEmailAsync(userId, newEmail, cancellationToken);
                return Ok();
            }
            return Unauthorized("недоступно");
        }

        [HttpPut("UpdatePassword")]
        [Authorize(Policy = PolicyNames.UpdateSelf)]
        public async Task<IActionResult> UpdateSelfPassword(string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            var userId = await GetIdFromClaimsAsync();

            if (await userService.CheckPasswordAsync(userId, oldPassword, cancellationToken))
            {
                userService.UpdatePasswordAsync(userId, newPassword, cancellationToken);
                return Ok();
            }
            return Unauthorized("недоступно");
        }


        private async Task<Guid> GetIdFromClaimsAsync()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Guid.Empty;
            }
            return userId;
        }
    }
}
