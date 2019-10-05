using RentCar.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class Client: AbstractEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public double CreditLimit{ get; set; }
        [Required]
        public PersonType PersonType { get; set; }
    }
}
