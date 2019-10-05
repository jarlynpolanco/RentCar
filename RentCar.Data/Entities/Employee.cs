using RentCar.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Entities
{
    public class Employee: AbstractEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public Shift Shift { get; set; }
        [Required]
        public double ComissionPorcent { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
