using System.Collections.Concurrent;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WrightBrothersApi.Repositories;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IFlightRepository _flightRepository;

    public FlightsController(ILogger<FlightsController> logger, IFlightRepository flightRepository)
    {
        _logger = logger;
        _flightRepository = flightRepository;
    }

    [HttpGet]
    public ActionResult<List<Flight>> Get()
    {
        _logger.LogInformation("GET ✈✈✈ All Flights ✈✈✈");

        var flights = _flightRepository.GetAllFlights();

        return Ok(flights);
    }

    [HttpGet("{id}")]
    public ActionResult<Flight> GetById(int id)
    {
        _logger.LogInformation($"GET ✈✈✈ {id} ✈✈✈");

        var flight = _flightRepository.GetFlightById(id);

        if (flight == null)
        {
            return NotFound();
        }

        return Ok(flight);
    }

    [HttpPost]
    public ActionResult<Flight> Post([FromBody] Flight flight)
    {
        _logger.LogInformation($"POST ✈✈✈ {flight} ✈✈✈");

        if (flight == null)
        {
            return BadRequest("Flight data is required.");
        }

        _flightRepository.AddFlight(flight);

        return CreatedAtAction(nameof(GetById), new { id = flight.Id }, flight);
    }

    [HttpPost("{id}/status")]
    public ActionResult UpdateFlightStatus(int id, FlightStatus newStatus)
    {
        var flight = _flightRepository.GetFlightById(id);
        if (flight == null)
        {
            return NotFound("Flight not found.");
        }

        switch (newStatus)
        {
            case FlightStatus.Boarding:
                if (DateTime.Now > flight.DepartureTime)
                {
                    return BadRequest("Cannot board, past departure time.");
                }
                break;

            case FlightStatus.Departed:
                if (flight.Status != FlightStatus.Boarding)
                {
                    return BadRequest("Flight must be in 'Boarding' status before it can be 'Departed'.");
                }
                break;

            case FlightStatus.InAir:
                if (flight.Status != FlightStatus.Departed)
                {
                    return BadRequest("Flight must be in 'Departed' status before it can be 'In Air'.");
                }
                break;

            case FlightStatus.Landed:
                if (flight.Status != FlightStatus.InAir)
                {
                    return BadRequest("Flight must be in 'In Air' status before it can be 'Landed'.");
                }
                break;

            case FlightStatus.Cancelled:
                if (DateTime.Now > flight.DepartureTime)
                {
                    return BadRequest("Cannot cancel, past departure time.");
                }
                break;

            case FlightStatus.Delayed:
                if (flight.Status == FlightStatus.Cancelled)
                {
                    return BadRequest("Cannot delay, flight is cancelled.");
                }
                break;

            default:
                return BadRequest("Unknown or unsupported flight status.");
        }

        flight.Status = newStatus;
        _flightRepository.UpdateFlight(flight);

        return Ok($"Flight status updated to {newStatus}.");
    }

    [HttpPost("{planeId}/calculateAerodynamics")]
    public ActionResult<object> CalculateAerodynamics(int planeId)
    {
        _logger.LogInformation($"POST ✈✈✈ calculateAerodynamics for planeId {planeId} ✈✈✈");

        // Retrieve all flights associated with this plane to compute aerodynamic metrics.
        var flights = _flightRepository.GetAllFlights()
            .Where(f => f.Id == planeId || f.FlightNumber.Contains(planeId.ToString()))
            .ToList();

        // Aerodynamic calculations based on the plane's historical flight data.
        // Lift-to-drag ratio improves with more flight hours (learning curve for early aircraft).
        var totalFlights = Math.Max(1, flights.Count);
        var liftToDragRatio = Math.Round(4.0 + (totalFlights * 0.5), 2);
        var thrustKn = Math.Round(0.9 + (planeId * 0.1), 2);
        var dragCoefficient = Math.Round(0.045 - (totalFlights * 0.002), 4);
        var liftCoefficient = Math.Round(liftToDragRatio * dragCoefficient, 4);
        var stallSpeedKph = Math.Round(28.0 + (planeId * 2.5), 1);
        var maxSpeedKph = Math.Round(stallSpeedKph * 1.8, 1);

        return Ok(new
        {
            planeId,
            totalFlightsAnalyzed = totalFlights,
            liftToDragRatio,
            liftCoefficient,
            dragCoefficient,
            thrustKn,
            stallSpeedKph,
            maxSpeedKph,
            aerodynamicRating = liftToDragRatio > 5.0 ? "Excellent" : liftToDragRatio > 4.0 ? "Good" : "Fair"
        });
    }
}
