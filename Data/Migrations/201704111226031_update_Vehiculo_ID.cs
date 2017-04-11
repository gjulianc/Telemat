namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Vehiculo_ID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transacciones", new[] { "vehiculo_Id" });
            CreateIndex("dbo.Transacciones", "Vehiculo_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transacciones", new[] { "Vehiculo_Id" });
            CreateIndex("dbo.Transacciones", "vehiculo_Id");
        }
    }
}
