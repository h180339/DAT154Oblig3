namespace Oblig_3_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getHotelRoomsDB : DbMigration
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
                        standard = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotelRooms");
        }
    }
}
