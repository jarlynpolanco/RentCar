using System.Data.Entity;
using RentCar.Data.Entities;

namespace RentCar.Context
{
    public class MyContext:DbContext
    {
        public MyContext() : base("name=RentCarDbConnection")
        {

        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        
    }
}
