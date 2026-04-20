using CarRentPlatform.Application.Interfaces;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSelectionController(ICarService carService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetByFilter([FromQuery] List<string>? brands,
                                                     [FromQuery] List<string>? models,
                                                     [FromQuery] List<CarColor>? carColors,
                                                     [FromQuery] List<CarType>? carTypes,
                                                     [FromQuery] List<Fuel>? fuels,
                                                     int? minNumberOfSeatsWithDriver,
                                                     float? minTrunkVoluem,
                                                     float? minTankCapacity,
                                                     float? maxCityConsumptionPer100km,
                                                     float? maxHighwayConsumptionPer100km,
                                                     float? minCityRangeKm,
                                                     float? minHighwayRangeKm,
                                                     bool? IsAutomaticTransmission,
                                                     decimal? maxPricePerDayBYN,
                                                     DateTime? dateTimeStartNewPeriod,
                                                     DateTime? dateTimeEndNewPeriod,
                                                     CancellationToken cancellationToken)
        { 
            return Ok(await carService.GetCarByFilterAsync(brands, models, carColors, carTypes, fuels, minNumberOfSeatsWithDriver,
                                                            minTrunkVoluem, minTankCapacity, maxCityConsumptionPer100km, maxHighwayConsumptionPer100km,
                                                            minCityRangeKm, minHighwayRangeKm, IsAutomaticTransmission, maxPricePerDayBYN,
                                                            dateTimeStartNewPeriod, dateTimeEndNewPeriod, cancellationToken));
        }
    }
}
