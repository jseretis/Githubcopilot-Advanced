using WrightBrothersApi.Models;

namespace WrightBrothersApi.Repositories
{
    public interface IPlaneRepository
    {
        List<Plane> GetAllPlanes();

        Plane GetPlaneById(int id);

        /// <summary>Returns all planes matching the given year of manufacture.</summary>
        List<Plane> GetPlanesByYear(int year);

        Plane AddPlane(Plane plane);

        Plane UpdatePlane(Plane plane);
    }
}
