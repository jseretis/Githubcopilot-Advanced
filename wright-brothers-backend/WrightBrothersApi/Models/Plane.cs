using System.ComponentModel.DataAnnotations;

namespace WrightBrothersApi.Models
{
    public class Plane
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Range(1900, 2030, ErrorMessage = "Year must be between 1900 and 2030.")]
        public int Year { get; set; }

        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "RangeInKm must be greater than zero.")]
        public int RangeInKm { get; set; }

        public DateTime LastUpdated { get; set; } // New property
    }
}
