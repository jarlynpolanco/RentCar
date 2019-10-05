using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Data.Entities
{
    public class Rent: AbstractEntity
    {
        [Required]
        public int VehicleID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public double AmountPerDay { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public string Comment { get; set; }
        public Vehicle Vehicle { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
