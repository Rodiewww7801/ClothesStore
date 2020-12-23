namespace ClothesStore.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservedItems", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.ReservedItems", new[] { "ReservationId" });
            AlterColumn("dbo.OrderDetails", "Name", c => c.String());
            AlterColumn("dbo.OrderDetails", "Email", c => c.String());
            AlterColumn("dbo.OrderDetails", "Address", c => c.String());
            AlterColumn("dbo.OrderDetails", "City", c => c.String());
            AlterColumn("dbo.OrderDetails", "Country", c => c.String());
            DropTable("dbo.ReservedItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReservedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.OrderDetails", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "City", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.ReservedItems", "ReservationId");
            AddForeignKey("dbo.ReservedItems", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
        }
    }
}
