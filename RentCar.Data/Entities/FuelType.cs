using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class FuelType:AbstractEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
