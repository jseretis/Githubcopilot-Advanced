using Microsoft.AspNetCore.Mvc;
using WrightBrothersApi.Models;
using WrightBrothersApi.Repositories;

namespace WrightBrothersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;
        private readonly IPlaneRepository _planeRepository;

        public PlanesController(ILogger<PlanesController> logger, IPlaneRepository planeRepository)
        {
            _logger = logger;
            _planeRepository = planeRepository;
        }

        [HttpGet]
        public ActionResult<List<Plane>> GetAll()
        {
            _logger.LogInformation("GET all ✈✈✈ NO PARAMS ✈✈✈");

            return Ok(_planeRepository.GetAllPlanes());
        }

        [HttpGet("search")]
        public ActionResult<List<Plane>> GetByYear([FromQuery] int year)
        {
            _logger.LogInformation("GET by year ✈✈✈ {Year} ✈✈✈", year);

            var planes = _planeRepository.GetPlanesByYear(year);

            return Ok(planes);
        }

        [HttpGet("{id}")]
        public ActionResult<Plane> GetById(int id)
        {
            var plane = _planeRepository.GetPlaneById(id);

            if (plane == null)
            {
                return NotFound();
            }

            return Ok(plane);
        }

        [HttpPost]
        public ActionResult<Plane> Post(Plane plane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _planeRepository.AddPlane(plane);

            return CreatedAtAction(nameof(GetById), new { id = plane.Id }, plane);
        }

        [HttpPost("calculateFlightPath")]
        public ActionResult<object> CalculateFlightPath([FromBody] Plane plane)
        {
            if (plane == null)
            {
                return BadRequest("Plane data is required.");
            }

            _logger.LogInformation($"POST ✈✈✈ calculateFlightPath for {plane.Name} ✈✈✈");

            // Calculate flight path waypoints based on range and year of manufacture.
            // Early aircraft flew in straight lines at low altitude with limited range.
            var waypointCount = Math.Max(2, plane.RangeInKm / 10);
            var cruisingAltitudeMeters = plane.Year < 1910 ? 150 : 3000;
            var estimatedSpeedKph = plane.Year < 1910 ? 48 : 120;

            var waypoints = new List<object>();
            for (int i = 0; i < waypointCount; i++)
            {
                var progress = (double)i / (waypointCount - 1);
                waypoints.Add(new
                {
                    waypointIndex = i,
                    distanceKm = Math.Round(progress * plane.RangeInKm, 1),
                    altitudeMeters = i == 0 || i == waypointCount - 1
                        ? 0
                        : cruisingAltitudeMeters,
                    estimatedTimeMinutes = Math.Round(progress * (plane.RangeInKm / (double)estimatedSpeedKph) * 60, 0)
                });
            }

            return Ok(new
            {
                planeName = plane.Name,
                yearOfManufacture = plane.Year,
                totalRangeKm = plane.RangeInKm,
                estimatedSpeedKph,
                cruisingAltitudeMeters,
                waypoints
            });
        }
    }
}
