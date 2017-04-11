namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_IdManguera : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transacciones", "IdManguera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transacciones", "IdManguera", c => c.Int(nullable: false));
        }
    }
}
