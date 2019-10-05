using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public abstract class AbstractEntity
    {
        [Required,Key]
        public int ID { get; set; }
    }
}
