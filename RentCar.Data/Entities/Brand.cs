using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class Brand: AbstractEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
