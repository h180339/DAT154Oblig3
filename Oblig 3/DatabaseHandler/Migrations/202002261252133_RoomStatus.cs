namespace DatabaseHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotelRooms", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HotelRooms", "status");
        }
    }
}
