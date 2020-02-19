namespace Oblig_3_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        HotelRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelRooms", t => t.HotelRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HotelRoomId);
            
            AddColumn("dbo.HotelRooms", "quality", c => c.String());
            DropColumn("dbo.HotelRooms", "standard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelRooms", "standard", c => c.String());
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "HotelRoomId", "dbo.HotelRooms");
            DropIndex("dbo.Reservations", new[] { "HotelRoomId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropColumn("dbo.HotelRooms", "quality");
            DropTable("dbo.Reservations");
        }
    }
}
