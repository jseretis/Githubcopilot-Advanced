using WrightBrothersApi.Repositories;

namespace WrightBrothersApi.Tests.Repositories
{
    public class FlightRepositoryTests
    {
        private readonly FlightRepository _repository;

        public FlightRepositoryTests()
        {
            _repository = new FlightRepository();
        }

        [Fact]
        public void GetAllFlights_ReturnsAllFlights()
        {
            var flights = _repository.GetAllFlights();
            flights.Should().HaveCount(3);
        }

        [Fact]
        public void GetFlightById_WithExistingId_ReturnsFlight()
        {
            var flight = _repository.GetFlightById(1);
            flight.Should().NotBeNull();
            flight!.Id.Should().Be(1);
        }

        [Fact]
        public void GetFlightById_WithNonExistingId_ReturnsNull()
        {
            var flight = _repository.GetFlightById(99);
            flight.Should().BeNull();
        }

        [Fact]
        public void AddFlight_AddsFlightToRepository()
        {
            var newFlight = new Flight
            {
                Id = 4,
                FlightNumber = "WB004",
                Origin = "Kitty Hawk, NC",
                Destination = "Kill Devil Hills, NC",
                DepartureTime = new DateTime(1910, 1, 1, 8, 0, 0),
                ArrivalTime = new DateTime(1910, 1, 1, 8, 30, 0),
                Status = FlightStatus.Scheduled,
                FuelRange = 150,
                FuelTankLeak = false,
                FlightLogSignature = "010110-DEP-ARR-WB004",
                AerobaticSequenceSignature = "L1A-H1B"
            };

            _repository.AddFlight(newFlight);

            var all = _repository.GetAllFlights();
            all.Should().HaveCount(4);
            all.Should().ContainSingle(f => f.Id == 4);
        }

        [Fact]
        public void UpdateFlight_WithExistingFlight_UpdatesFields()
        {
            var existing = _repository.GetFlightById(1)!;
            existing.FlightNumber = "WB001-UPDATED";
            existing.Status = FlightStatus.Departed;

            _repository.UpdateFlight(existing);

            var updated = _repository.GetFlightById(1)!;
            updated.FlightNumber.Should().Be("WB001-UPDATED");
            updated.Status.Should().Be(FlightStatus.Departed);
        }

        [Fact]
        public void UpdateFlight_WithNonExistingFlight_ReturnsNull()
        {
            var ghost = new Flight { Id = 999, FlightNumber = "GHOST", Origin = "X", Destination = "Y",
                FlightLogSignature = "x", AerobaticSequenceSignature = "x" };

            var result = _repository.UpdateFlight(ghost);

            result.Should().BeNull();
        }
    }
}
