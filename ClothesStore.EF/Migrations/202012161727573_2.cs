namespace ClothesStore.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId);
            
            AddColumn("dbo.Orders", "ReservationId", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReservedItems", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.ReservedItems", new[] { "ReservationId" });
            DropColumn("dbo.Orders", "ReservationId");
            DropTable("dbo.ReservedItems");
        }
    }
}
