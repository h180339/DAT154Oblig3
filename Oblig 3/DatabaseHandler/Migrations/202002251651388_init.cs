namespace DatabaseHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numberOfBeds = c.Int(nullable: false),
                        roomSize = c.Int(nullable: false),
                        quality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        startDate = c.DateTime(),
                        endDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        HotelRoomId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelRooms", t => t.HotelRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HotelRoomId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "HotelRoomId", "dbo.HotelRooms");
            DropIndex("dbo.Reservations", new[] { "HotelRoomId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.HotelRooms");
        }
    }
}
