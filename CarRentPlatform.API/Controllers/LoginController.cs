using CarRentPlatform.Application.Intefaces;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(string phoneNumber, string password, CancellationToken cancellationToken)
        { 
            return Ok(await userService.Login(phoneNumber, password, cancellationToken, HttpContext));
        }
    }
}
