using CarRentPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarViewingController(ICarService carService) : ControllerBase
    {
        [HttpGet]
        [Route("cars/{CadId}")]
        public async Task<IActionResult> GetCar(Guid CadId, CancellationToken cancellationToken)
        {
            var car = await carService.GetCarByIdAsync(CadId, cancellationToken);
            return Ok(car);
        }
    }
}
