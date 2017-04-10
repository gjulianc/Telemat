namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        FechaCreacion = c.String(),
                        FechaUltimaActualizacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Depositos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaCreacion = c.String(),
                        FechaUltimaActualizacion = c.String(),
                        BaseRepostaje_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bases", t => t.BaseRepostaje_Id)
                .Index(t => t.BaseRepostaje_Id);
            
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodCuentaKms = c.Int(nullable: false),
                        Fecha = c.String(),
                        HorasMotor = c.Int(nullable: false),
                        IdEstacion = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdManguera = c.Int(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kms = c.Int(nullable: false),
                        Litros = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ModoUso = c.Int(nullable: false),
                        PPV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumRegistro = c.Int(nullable: false),
                        SCU = c.Int(nullable: false),
                        TipoCarburante = c.Int(nullable: false),
                        TipoTransaccion = c.Int(nullable: false),
                        FechaCreacion = c.String(),
                        FechaUltimaActualizacion = c.String(),
                        IdVehiculo_Id = c.Int(),
                        BaseRepostaje_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehiculos", t => t.IdVehiculo_Id)
                .ForeignKey("dbo.Bases", t => t.BaseRepostaje_Id)
                .Index(t => t.IdVehiculo_Id)
                .Index(t => t.BaseRepostaje_Id);
            
            CreateTable(
                "dbo.Vehiculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        FechaCreacion = c.String(),
                        FechaUltimaActualizacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TramaGPS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imei = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Latitud = c.String(),
                        Longitud = c.String(),
                        Velocidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rumbo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Distancia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehiculoID = c.Int(nullable: false),
                        FechaCreacion = c.String(),
                        FechaUltimaActualizacion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehiculos", t => t.VehiculoID, cascadeDelete: true)
                .Index(t => t.VehiculoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacciones", "BaseRepostaje_Id", "dbo.Bases");
            DropForeignKey("dbo.Transacciones", "IdVehiculo_Id", "dbo.Vehiculos");
            DropForeignKey("dbo.TramaGPS", "VehiculoID", "dbo.Vehiculos");
            DropForeignKey("dbo.Depositos", "BaseRepostaje_Id", "dbo.Bases");
            DropIndex("dbo.TramaGPS", new[] { "VehiculoID" });
            DropIndex("dbo.Transacciones", new[] { "BaseRepostaje_Id" });
            DropIndex("dbo.Transacciones", new[] { "IdVehiculo_Id" });
            DropIndex("dbo.Depositos", new[] { "BaseRepostaje_Id" });
            DropTable("dbo.TramaGPS");
            DropTable("dbo.Vehiculos");
            DropTable("dbo.Transacciones");
            DropTable("dbo.Depositos");
            DropTable("dbo.Bases");
        }
    }
}
