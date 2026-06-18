using WrightBrothersApi.Controllers;
using WrightBrothersApi.Models;
using WrightBrothersApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WrightBrothersApi.Tests.Controllers
{
    public class PlanesControllerTests
    {
        private readonly ILogger<PlanesController> _logger;
        private readonly IPlaneRepository _planeRepository;
        private readonly PlanesController _planesController;

        public PlanesControllerTests()
        {
            _logger = Substitute.For<ILogger<PlanesController>>();
            _planeRepository = Substitute.For<IPlaneRepository>();
            _planeRepository.GetAllPlanes().Returns(new List<Plane>
            {
                new Plane { Id = 1, Name = "Wright Flyer", Year = 1903, Description = "First powered aircraft.", RangeInKm = 12 },
                new Plane { Id = 2, Name = "Wright Flyer II", Year = 1904, Description = "Refined Flyer.", RangeInKm = 24 },
                new Plane { Id = 3, Name = "Wright Model A", Year = 1908, Description = "First commercial airplane.", RangeInKm = 40 }
            });
            _planesController = new PlanesController(_logger, _planeRepository);
        }

        [Fact]
        public void GetAll_ReturnsListOfPlanes()
        {
            // Act
            var result = _planesController.GetAll();

            // Assert
            var okObjectResult = (OkObjectResult)result.Result!;
            var returnedPlanes = (List<Plane>)okObjectResult.Value!;
            returnedPlanes.Should().NotBeEmpty();
            returnedPlanes.Should().HaveCount(3);
        }

        [Fact]
        public void GetByYear_WithMatchingYear_ReturnsMatchingPlanes()
        {
            // Arrange
            var year = 1903;
            _planeRepository.GetPlanesByYear(year).Returns(new List<Plane>
            {
                new Plane { Id = 1, Name = "Wright Flyer", Year = 1903, Description = "First powered aircraft.", RangeInKm = 12 }
            });

            // Act
            var result = _planesController.GetByYear(year);

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            var planes = (List<Plane>)okResult.Value!;
            planes.Should().HaveCount(1);
            planes[0].Year.Should().Be(year);
        }

        [Fact]
        public void GetByYear_WithNoMatch_ReturnsEmptyList()
        {
            // Arrange
            var year = 1999;
            _planeRepository.GetPlanesByYear(year).Returns(new List<Plane>());

            // Act
            var result = _planesController.GetByYear(year);

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            var planes = (List<Plane>)okResult.Value!;
            planes.Should().BeEmpty();
        }

        [Fact]
        public void Post_WithValidPlane_ReturnsCreated()
        {
            // Arrange
            var plane = new Plane { Id = 4, Name = "Wright Model B", Year = 1910, Description = "Improved model.", RangeInKm = 80 };
            _planeRepository.AddPlane(plane).Returns(plane);

            // Act
            var result = _planesController.Post(plane);

            // Assert
            result.Result.Should().BeOfType<CreatedAtActionResult>();
        }

        [Fact]
        public void Post_WithMissingName_ReturnsBadRequest()
        {
            // Arrange — simulate [Required] validation failure for Name
            var plane = new Plane { Id = 5, Name = null!, Year = 1910, RangeInKm = 50 };
            _planesController.ModelState.AddModelError("Name", "Name is required.");

            // Act
            var result = _planesController.Post(plane);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Post_WithYearOutOfRange_ReturnsBadRequest()
        {
            // Arrange — simulate [Range(1900, 2030)] validation failure for Year
            var plane = new Plane { Id = 6, Name = "Future Plane", Year = 2099, RangeInKm = 100 };
            _planesController.ModelState.AddModelError("Year", "Year must be between 1900 and 2030.");

            // Act
            var result = _planesController.Post(plane);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Post_WithZeroRangeInKm_ReturnsBadRequest()
        {
            // Arrange — simulate [Range(1, int.MaxValue)] validation failure for RangeInKm
            var plane = new Plane { Id = 7, Name = "Grounded Plane", Year = 1920, RangeInKm = 0 };
            _planesController.ModelState.AddModelError("RangeInKm", "RangeInKm must be greater than zero.");

            // Act
            var result = _planesController.Post(plane);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        //GetById
        [Fact]
        public void GetById_WithExistingId_ReturnsPlane()
        {
            // Arrange
            var plane = new Plane { Id = 1, Name = "Wright Flyer", Year = 1903, Description = "First powered aircraft.", RangeInKm = 12 };
            _planeRepository.GetPlaneById(1).Returns(plane);

            // Act
            var result = _planesController.GetById(1);

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            var returnedPlane = (Plane)okResult.Value!;
            returnedPlane.Id.Should().Be(1);
            returnedPlane.Name.Should().Be("Wright Flyer");
        }

        //GetById_NotFound
        [Fact]
        public void GetById_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            _planeRepository.GetPlaneById(99).Returns((Plane?)null);

            // Act
            var result = _planesController.GetById(99);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetAll_WithEmptyRepository_ReturnsEmptyList()
        {
            // Arrange
            _planeRepository.GetAllPlanes().Returns(new List<Plane>());

            // Act
            var result = _planesController.GetAll();

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            var planes = (List<Plane>)okResult.Value!;
            planes.Should().BeEmpty();
        }

        [Fact]
        public void Post_WithNegativeRangeInKm_ReturnsBadRequest()
        {
            // Arrange — simulate [Range(1, int.MaxValue)] validation failure for negative RangeInKm
            var plane = new Plane { Id = 8, Name = "Invalid Plane", Year = 1920, RangeInKm = -500 };
            _planesController.ModelState.AddModelError("RangeInKm", "RangeInKm must be greater than zero.");

            // Act
            var result = _planesController.Post(plane);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void CalculateFlightPath_WithNullPlane_ReturnsBadRequest()
        {
            // Act
            var result = _planesController.CalculateFlightPath(null!);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void CalculateFlightPath_WithEarlyPlane_ReturnsLowAltitudeFlightPath()
        {
            // Arrange — pre-1910 aircraft: altitude 150 m, speed 48 kph
            var plane = new Plane { Id = 1, Name = "Wright Flyer", Year = 1903, Description = "First powered aircraft.", RangeInKm = 12 };

            // Act
            var result = _planesController.CalculateFlightPath(plane);

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            okResult.Value.Should().NotBeNull();
            var value = okResult.Value!;
            var cruisingAltitude = (int)value.GetType().GetProperty("cruisingAltitudeMeters")!.GetValue(value)!;
            var estimatedSpeed = (int)value.GetType().GetProperty("estimatedSpeedKph")!.GetValue(value)!;
            cruisingAltitude.Should().Be(150);
            estimatedSpeed.Should().Be(48);
        }

        [Fact]
        public void CalculateFlightPath_WithModernPlane_ReturnsHighAltitudeFlightPath()
        {
            // Arrange — post-1910 aircraft: altitude 3000 m, speed 120 kph
            var plane = new Plane { Id = 3, Name = "Wright Model A", Year = 1910, Description = "First commercial airplane.", RangeInKm = 40 };

            // Act
            var result = _planesController.CalculateFlightPath(plane);

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            okResult.Value.Should().NotBeNull();
            var value = okResult.Value!;
            var cruisingAltitude = (int)value.GetType().GetProperty("cruisingAltitudeMeters")!.GetValue(value)!;
            var estimatedSpeed = (int)value.GetType().GetProperty("estimatedSpeedKph")!.GetValue(value)!;
            cruisingAltitude.Should().Be(3000);
            estimatedSpeed.Should().Be(120);
        }

        [Fact]
        public void CalculateFlightPath_WithValidPlane_ReturnsWaypointsStartAndEndAtZeroAltitude()
        {
            // Arrange
            var plane = new Plane { Id = 2, Name = "Wright Flyer II", Year = 1904, Description = "Refined Flyer.", RangeInKm = 20 };

            // Act
            var result = _planesController.CalculateFlightPath(plane);

            // Assert
            var okResult = (OkObjectResult)result.Result!;
            var value = okResult.Value!;
            var waypoints = (System.Collections.IList)value.GetType().GetProperty("waypoints")!.GetValue(value)!;
            waypoints.Count.Should().BeGreaterThan(0);

            // First waypoint altitude should be 0 (on the ground at departure)
            var firstWaypoint = waypoints[0]!;
            var firstAlt = (int)firstWaypoint.GetType().GetProperty("altitudeMeters")!.GetValue(firstWaypoint)!;
            firstAlt.Should().Be(0);

            // Last waypoint altitude should be 0 (on the ground at arrival)
            var lastWaypoint = waypoints[waypoints.Count - 1]!;
            var lastAlt = (int)lastWaypoint.GetType().GetProperty("altitudeMeters")!.GetValue(lastWaypoint)!;
            lastAlt.Should().Be(0);
        }
    }
}