using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class VehicleType: AbstractEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
