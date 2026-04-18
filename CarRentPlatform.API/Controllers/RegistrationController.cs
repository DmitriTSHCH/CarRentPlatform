using CarRentPlatform.Application.Intefaces;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(string phoneNumber, string email, string password, string firstName, string lastName,
                         string passportNumber, string driverLicenseNumber,
                         DriverLicenseCategoryFlags driverLicenseCategory, DateOnly licenseExpirationDate,
                         CancellationToken cancellationToken)
        {
            var isRegistrationSuccess = await userService.Registration(phoneNumber, email, password, firstName, lastName, passportNumber, driverLicenseNumber, driverLicenseCategory, licenseExpirationDate, cancellationToken);
            if (isRegistrationSuccess == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
