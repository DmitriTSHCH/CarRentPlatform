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
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized("недоступно");
            }

            var userInfo = await userService.GetPersonalInfoByIdAsync(userId, cancellationToken);

            return Ok(userInfo);
        }
    }
}
