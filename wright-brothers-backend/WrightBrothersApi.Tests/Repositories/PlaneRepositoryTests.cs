using WrightBrothersApi.Models;
using WrightBrothersApi.Repositories;

namespace WrightBrothersApi.Tests.Repositories
{
    public class PlaneRepositoryTests
    {
        private readonly PlaneRepository _repository;

        public PlaneRepositoryTests()
        {
            _repository = new PlaneRepository();
        }

        [Fact]
        public void GetAllPlanes_ReturnsAllPlanes()
        {
            var planes = _repository.GetAllPlanes();
            planes.Should().HaveCount(3);
        }

        [Fact]
        public void GetPlanesByYear_WithMatchingYear_ReturnsPlanes()
        {
            var planes = _repository.GetPlanesByYear(1903);
            planes.Should().ContainSingle(p => p.Name == "Wright Flyer");
        }

        [Fact]
        public void GetPlanesByYear_WithNoMatch_ReturnsEmptyList()
        {
            var planes = _repository.GetPlanesByYear(1999);
            planes.Should().BeEmpty();
        }

        [Fact]
        public void AddPlane_AddsPlaneToRepository()
        {
            var newPlane = new Plane { Id = 4, Name = "Wright Model B", Year = 1910,
                Description = "Improved model.", RangeInKm = 80 };

            _repository.AddPlane(newPlane);

            _repository.GetAllPlanes().Should().HaveCount(4);
            _repository.GetAllPlanes().Should().ContainSingle(p => p.Id == 4);
        }

        [Fact]
        public void UpdatePlane_WithExistingPlane_UpdatesFields()
        {
            var existing = _repository.GetAllPlanes().First(p => p.Id == 1);
            existing.Name = "Wright Flyer (Updated)";
            existing.RangeInKm = 999;

            _repository.UpdatePlane(existing);

            var updated = _repository.GetAllPlanes().First(p => p.Id == 1);
            updated.Name.Should().Be("Wright Flyer (Updated)");
            updated.RangeInKm.Should().Be(999);
        }

        [Fact]
        public void UpdatePlane_WithNonExistingPlane_ReturnsNull()
        {
            var ghost = new Plane { Id = 999, Name = "Ghost", Year = 2000, Description = "x", RangeInKm = 1 };

            var result = _repository.UpdatePlane(ghost);

            result.Should().BeNull();
        }
    }
}
