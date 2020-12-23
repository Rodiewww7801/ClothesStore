namespace ClothesStore.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "OrderId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "OrderId");
        }
    }
}
