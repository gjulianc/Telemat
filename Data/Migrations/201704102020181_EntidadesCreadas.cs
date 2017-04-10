namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadesCreadas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transacciones", "BaseRepostaje_Id", "dbo.Bases");
            DropForeignKey("dbo.TramaGPS", "VehiculoID", "dbo.Vehiculos");
            DropIndex("dbo.Transacciones", new[] { "BaseRepostaje_Id" });
            DropIndex("dbo.TramaGPS", new[] { "VehiculoID" });
            RenameColumn(table: "dbo.TramaGPS", name: "VehiculoID", newName: "Vehiculo_Id");
            RenameColumn(table: "dbo.Transacciones", name: "IdVehiculo_Id", newName: "vehiculo_Id");
            RenameIndex(table: "dbo.Transacciones", name: "IX_IdVehiculo_Id", newName: "IX_vehiculo_Id");
            CreateTable(
                "dbo.Mangueras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        FechaCreacion = c.String(),
                        FechaUltimaActualizacion = c.String(),
                        Deposito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depositos", t => t.Deposito_Id)
                .Index(t => t.Deposito_Id);
            
            AddColumn("dbo.Bases", "Scu", c => c.Int(nullable: false));
            AddColumn("dbo.Bases", "Nombre", c => c.String());
            AddColumn("dbo.Bases", "Direccion", c => c.String());
            AddColumn("dbo.Bases", "Poblacion", c => c.String());
            AddColumn("dbo.Bases", "CodigoPostal", c => c.String());
            AddColumn("dbo.Bases", "Delegacion", c => c.String());
            AddColumn("dbo.Bases", "ZonaHoraria", c => c.Int(nullable: false));
            AddColumn("dbo.Bases", "Telefono", c => c.String());
            AddColumn("dbo.Bases", "PuertoComunicacion", c => c.String());
            AddColumn("dbo.Bases", "Baudios", c => c.String());
            AddColumn("dbo.Bases", "CodigoFlota", c => c.String());
            AddColumn("dbo.Bases", "CodigoControl", c => c.String());
            AddColumn("dbo.Bases", "CAE", c => c.String());
            AddColumn("dbo.Transacciones", "Manguera_Id", c => c.Int());
            AlterColumn("dbo.TramaGPS", "Fecha", c => c.String());
            AlterColumn("dbo.TramaGPS", "Latitud", c => c.Double(nullable: false));
            AlterColumn("dbo.TramaGPS", "Longitud", c => c.Double(nullable: false));
            AlterColumn("dbo.TramaGPS", "Vehiculo_Id", c => c.Int());
            CreateIndex("dbo.Transacciones", "Manguera_Id");
            CreateIndex("dbo.TramaGPS", "Vehiculo_Id");
            AddForeignKey("dbo.Transacciones", "Manguera_Id", "dbo.Mangueras", "Id");
            AddForeignKey("dbo.TramaGPS", "Vehiculo_Id", "dbo.Vehiculos", "Id");
            DropColumn("dbo.Transacciones", "BaseRepostaje_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transacciones", "BaseRepostaje_Id", c => c.Int());
            DropForeignKey("dbo.TramaGPS", "Vehiculo_Id", "dbo.Vehiculos");
            DropForeignKey("dbo.Transacciones", "Manguera_Id", "dbo.Mangueras");
            DropForeignKey("dbo.Mangueras", "Deposito_Id", "dbo.Depositos");
            DropIndex("dbo.TramaGPS", new[] { "Vehiculo_Id" });
            DropIndex("dbo.Transacciones", new[] { "Manguera_Id" });
            DropIndex("dbo.Mangueras", new[] { "Deposito_Id" });
            AlterColumn("dbo.TramaGPS", "Vehiculo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TramaGPS", "Longitud", c => c.String());
            AlterColumn("dbo.TramaGPS", "Latitud", c => c.String());
            AlterColumn("dbo.TramaGPS", "Fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transacciones", "Manguera_Id");
            DropColumn("dbo.Bases", "CAE");
            DropColumn("dbo.Bases", "CodigoControl");
            DropColumn("dbo.Bases", "CodigoFlota");
            DropColumn("dbo.Bases", "Baudios");
            DropColumn("dbo.Bases", "PuertoComunicacion");
            DropColumn("dbo.Bases", "Telefono");
            DropColumn("dbo.Bases", "ZonaHoraria");
            DropColumn("dbo.Bases", "Delegacion");
            DropColumn("dbo.Bases", "CodigoPostal");
            DropColumn("dbo.Bases", "Poblacion");
            DropColumn("dbo.Bases", "Direccion");
            DropColumn("dbo.Bases", "Nombre");
            DropColumn("dbo.Bases", "Scu");
            DropTable("dbo.Mangueras");
            RenameIndex(table: "dbo.Transacciones", name: "IX_vehiculo_Id", newName: "IX_IdVehiculo_Id");
            RenameColumn(table: "dbo.Transacciones", name: "vehiculo_Id", newName: "IdVehiculo_Id");
            RenameColumn(table: "dbo.TramaGPS", name: "Vehiculo_Id", newName: "VehiculoID");
            CreateIndex("dbo.TramaGPS", "VehiculoID");
            CreateIndex("dbo.Transacciones", "BaseRepostaje_Id");
            AddForeignKey("dbo.TramaGPS", "VehiculoID", "dbo.Vehiculos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transacciones", "BaseRepostaje_Id", "dbo.Bases", "Id");
        }
    }
}
