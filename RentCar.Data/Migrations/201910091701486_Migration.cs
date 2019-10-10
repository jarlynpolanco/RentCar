namespace RentCar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DocumentNumber = c.String(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                        CreditLimit = c.Double(nullable: false),
                        PersonType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DocumentNumber = c.String(nullable: false),
                        Shift = c.Int(nullable: false),
                        ComissionPorcent = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        HasScratches = c.Boolean(nullable: false),
                        FuelQuantity = c.Int(nullable: false),
                        HasReplacementTire = c.Boolean(nullable: false),
                        HasJack = c.Boolean(nullable: false),
                        HasBrokenGlasses = c.Boolean(nullable: false),
                        TiresStatus = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.ClientID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ModelID = c.Int(nullable: false),
                        FuelTypeID = c.Int(nullable: false),
                        VehicleTypeID = c.Int(nullable: false),
                        Chasis = c.String(nullable: false),
                        MotorNumber = c.String(nullable: false),
                        Plate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.ModelID)
                .Index(t => t.FuelTypeID)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrandID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        AmountPerDay = c.Double(nullable: false),
                        Days = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.ClientID)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Rents", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Rents", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Inspections", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "ModelID", "dbo.Models");
            DropForeignKey("dbo.Models", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Vehicles", "FuelTypeID", "dbo.FuelTypes");
            DropForeignKey("dbo.Inspections", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Inspections", "ClientID", "dbo.Clients");
            DropIndex("dbo.Rents", new[] { "EmployeeID" });
            DropIndex("dbo.Rents", new[] { "ClientID" });
            DropIndex("dbo.Rents", new[] { "VehicleID" });
            DropIndex("dbo.Models", new[] { "BrandID" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeID" });
            DropIndex("dbo.Vehicles", new[] { "FuelTypeID" });
            DropIndex("dbo.Vehicles", new[] { "ModelID" });
            DropIndex("dbo.Inspections", new[] { "EmployeeID" });
            DropIndex("dbo.Inspections", new[] { "ClientID" });
            DropIndex("dbo.Inspections", new[] { "VehicleID" });
            DropTable("dbo.Rents");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Models");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Inspections");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Brands");
        }
    }
}
