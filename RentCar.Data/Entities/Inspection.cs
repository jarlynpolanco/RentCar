using RentCar.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class Inspection: AbstractEntity
    {
        [Required]
        public int VehicleID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public bool HasScratches { get; set; }
        [Required]
        public FuelQuantity FuelQuantity { get; set; }
        [Required]
        public bool HasReplacementTire { get; set; }
        [Required]
        public bool HasJack { get; set; }
        [Required]
        public bool HasBrokenGlasses { get; set; }
        [Required]
        public string TiresStatus { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Vehicle Vehicle { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
