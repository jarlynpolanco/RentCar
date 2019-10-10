using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class Vehicle: AbstractEntity
    {
        [Required]
        public int ModelID { get; set; }
        [Required]
        public int FuelTypeID { get; set; }
        [Required]
        public int VehicleTypeID { get; set; }
        [Required]
        public string Chasis { get; set; }
        [Required]
        public string MotorNumber { get; set; }
        [Required]
        public string Plate { get; set; }
        [Required]
        public bool StateRent { get; set; }

        public Model Model { get; set; }
        public FuelType FuelType { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
