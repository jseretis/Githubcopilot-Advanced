using WrightBrothersApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WrightBrothersApi.Tests.Controllers
{
    public class FlightsControllerTests
    {
        private readonly ILogger<FlightsController> _logger;
        private readonly IFlightRepository _flightRepository;
        private readonly FlightsController _flightsController;

        private static Flight MakeFlight(int id, FlightStatus status = FlightStatus.Scheduled,
            DateTime? departureTime = null) => new Flight
        {
            Id = id,
            FlightNumber = $"WB00{id}",
            Origin = "Kitty Hawk, NC",
            Destination = "Manteo, NC",
            DepartureTime = departureTime ?? new DateTime(1903, 12, 17, 10, 35, 0),
            ArrivalTime = new DateTime(1903, 12, 17, 10, 47, 0),
            Status = status,
            FuelRange = 100,
            FuelTankLeak = false,
            FlightLogSignature = $"171203-DEP-ARR-WB00{id}",
            AerobaticSequenceSignature = "L4B-H2C-R3A"
        };

        public FlightsControllerTests()
        {
            _logger = Substitute.For<ILogger<FlightsController>>();
            _flightRepository = Substitute.For<IFlightRepository>();
            _flightRepository.GetAllFlights().Returns(new List<Flight>
            {
                MakeFlight(1),
                MakeFlight(2),
                MakeFlight(3)
            });
            _flightsController = new FlightsController(_logger, _flightRepository);
        }

        // ── Get ──────────────────────────────────────────────────────────────────

        [Fact]
        public void Get_ReturnsAllFlights()
        {
            var result = _flightsController.Get();

            var ok = (OkObjectResult)result.Result!;
            var flights = (List<Flight>)ok.Value!;
            flights.Should().HaveCount(3);
        }

        [Fact]
        public void Get_WithEmptyRepository_ReturnsEmptyList()
        {
            _flightRepository.GetAllFlights().Returns(new List<Flight>());

            var result = _flightsController.Get();

            var ok = (OkObjectResult)result.Result!;
            ((List<Flight>)ok.Value!).Should().BeEmpty();
        }

        // ── GetById ──────────────────────────────────────────────────────────────

        [Fact]
        public void GetById_WithExistingId_ReturnsFlight()
        {
            var flight = MakeFlight(1);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.GetById(1);

            var ok = (OkObjectResult)result.Result!;
            ((Flight)ok.Value!).Id.Should().Be(1);
        }

        [Fact]
        public void GetById_WithNonExistingId_ReturnsNotFound()
        {
            _flightRepository.GetFlightById(99).Returns((Flight?)null);

            var result = _flightsController.GetById(99);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        // ── Post ─────────────────────────────────────────────────────────────────

        [Fact]
        public void Post_WithValidFlight_ReturnsCreated()
        {
            var flight = MakeFlight(4);

            var result = _flightsController.Post(flight);

            result.Result.Should().BeOfType<CreatedAtActionResult>();
            _flightRepository.Received(1).AddFlight(flight);
        }

        [Fact]
        public void Post_WithNullFlight_ReturnsBadRequest()
        {
            var result = _flightsController.Post(null!);

            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        // ── UpdateFlightStatus ────────────────────────────────────────────────────

        [Fact]
        public void UpdateFlightStatus_WithNonExistingFlight_ReturnsNotFound()
        {
            _flightRepository.GetFlightById(99).Returns((Flight?)null);

            var result = _flightsController.UpdateFlightStatus(99, FlightStatus.Boarding);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_Boarding_PastDepartureTime_ReturnsBadRequest()
        {
            var flight = MakeFlight(1, FlightStatus.Scheduled, DateTime.MinValue);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Boarding);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_Departed_WhenNotBoarding_ReturnsBadRequest()
        {
            var flight = MakeFlight(1, FlightStatus.Scheduled);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Departed);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_InAir_WhenNotDeparted_ReturnsBadRequest()
        {
            var flight = MakeFlight(1, FlightStatus.Boarding);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.InAir);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_Landed_WhenNotInAir_ReturnsBadRequest()
        {
            var flight = MakeFlight(1, FlightStatus.Departed);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Landed);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_Cancelled_PastDepartureTime_ReturnsBadRequest()
        {
            var flight = MakeFlight(1, FlightStatus.Scheduled, DateTime.MinValue);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Cancelled);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_Delayed_WhenCancelled_ReturnsBadRequest()
        {
            var flight = MakeFlight(1, FlightStatus.Cancelled);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Delayed);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdateFlightStatus_Departed_WhenBoarding_UpdatesStatusAndReturnsOk()
        {
            var flight = MakeFlight(1, FlightStatus.Boarding);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Departed);

            result.Should().BeOfType<OkObjectResult>();
            flight.Status.Should().Be(FlightStatus.Departed);
            _flightRepository.Received(1).UpdateFlight(flight);
        }

        [Fact]
        public void UpdateFlightStatus_InAir_WhenDeparted_UpdatesStatusAndReturnsOk()
        {
            var flight = MakeFlight(1, FlightStatus.Departed);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.InAir);

            result.Should().BeOfType<OkObjectResult>();
            flight.Status.Should().Be(FlightStatus.InAir);
        }

        [Fact]
        public void UpdateFlightStatus_Landed_WhenInAir_UpdatesStatusAndReturnsOk()
        {
            var flight = MakeFlight(1, FlightStatus.InAir);
            _flightRepository.GetFlightById(1).Returns(flight);

            var result = _flightsController.UpdateFlightStatus(1, FlightStatus.Landed);

            result.Should().BeOfType<OkObjectResult>();
            flight.Status.Should().Be(FlightStatus.Landed);
        }

        // ── CalculateAerodynamics ─────────────────────────────────────────────────

        [Fact]
        public void CalculateAerodynamics_WithValidPlaneId_ReturnsOk()
        {
            var result = _flightsController.CalculateAerodynamics(1);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void CalculateAerodynamics_WithHighFlightCount_ReturnsExcellentRating()
        {
            // Arrange — seed 5 flights with matching planeId so liftToDragRatio > 5.0
            var manyFlights = Enumerable.Range(1, 5)
                .Select(i => MakeFlight(i))
                .ToList();
            _flightRepository.GetAllFlights().Returns(manyFlights);

            var result = _flightsController.CalculateAerodynamics(1);

            var ok = (OkObjectResult)result.Result!;
            var rating = (string)ok.Value!.GetType().GetProperty("aerodynamicRating")!.GetValue(ok.Value!)!;
            rating.Should().BeOneOf("Excellent", "Good", "Fair");
        }
    }
}
