namespace ClothesStore.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ReservedQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservedItems", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.ReservedItems", new[] { "ReservationId" });
            DropTable("dbo.ReservedItems");
        }
    }
}
