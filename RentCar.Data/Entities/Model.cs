using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class Model:AbstractEntity
    {
        [Required]
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
