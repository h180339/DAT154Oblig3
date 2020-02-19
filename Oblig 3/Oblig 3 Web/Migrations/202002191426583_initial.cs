namespace Oblig_3_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
            DropTable("dbo.Users");
            DropTable("dbo.HotelRooms");
        }
    }
}
