using WrightBrothersApi.Models;

namespace WrightBrothersApi.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly List<Plane> Planes = new List<Plane>
        {
            new Plane
            {
                Id = 1,
                Name = "Wright Flyer",
                Year = 1903,
                Description = "The first successful heavier-than-air powered aircraft.",
                RangeInKm = 12,
                LastUpdated = new DateTime(1903, 12, 17)
            },
            new Plane
            {
                Id = 2,
                Name = "Wright Flyer II",
                Year = 1904,
                Description = "A refinement of the original Flyer with better performance.",
                RangeInKm = 24,
                LastUpdated = new DateTime(1904, 9, 20)
            },
            new Plane
            {
                Id = 3,
                Name = "Wright Model A",
                Year = 1908,
                Description = "The first commercially successful airplane.",
                RangeInKm = 40,
                LastUpdated = new DateTime(1908, 8, 8)
            }
        };

        public List<Plane> GetAllPlanes()
        {
            return Planes;
        }

        public Plane GetPlaneById(int id)
        {
            return Planes.FirstOrDefault(p => p.Id == id);
        }

        public List<Plane> GetPlanesByYear(int year)
        {
            return Planes.Where(p => p.Year == year).ToList();
        }

        public Plane AddPlane(Plane plane)
        {
            plane.Id = Planes.Count > 0 ? Planes.Max(p => p.Id) + 1 : 1;
            Planes.Add(plane);
            return plane;
        }

        public Plane UpdatePlane(Plane updatedPlane)
        {
            var plane = Planes.FirstOrDefault(p => p.Id == updatedPlane.Id);
            if (plane != null)
            {
                plane.Name = updatedPlane.Name;
                plane.Year = updatedPlane.Year;
                plane.Description = updatedPlane.Description;
                plane.RangeInKm = updatedPlane.RangeInKm;
                plane.LastUpdated = DateTime.UtcNow;
            }
            return plane;
        }
    }
}
