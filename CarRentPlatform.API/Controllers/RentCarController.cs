using CarRentPlatform.Application.Interfaces;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentCarController(IRentalPeriodService rentalPeriodService, ICarService carService) : ControllerBase
    {
        [HttpPost]
        [Route("cars/{CadId}")]
        public async Task<IActionResult> RentCarForPeriod(Guid cadId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken)
        {
            if (await carService.IsCarFreeForThePeriod(cadId, startDateTime, endDateTime, cancellationToken))
            {
                var PeriodPrice = ((await carService.GetCarPriceDataByIdAsync(cadId, cancellationToken)).PricePerDayBYN) * (decimal)((endDateTime - startDateTime).TotalDays);

                var userId = await GetIdFromClaimsAsync();

                var rentPeriod = new RentalPeriod(startDateTime, endDateTime, cadId, userId, PeriodPrice);

                return Ok(await rentalPeriodService.AddAsync(rentPeriod));
            }
            else
            {
                return BadRequest();
            }
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
