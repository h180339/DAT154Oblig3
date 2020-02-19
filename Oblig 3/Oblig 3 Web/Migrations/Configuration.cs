namespace Oblig_3_Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Oblig_3_Web.Model;
    using System.Collections.Generic;


    internal sealed class Configuration : DbMigrationsConfiguration<Oblig_3_Web.BookingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Oblig_3_Web.BookingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //TODO: put in inital data about all hotelrooms here
            /*
            BookingDbContext dbContext = new BookingDbContext();
            DbSet<HotelRoom> hotelRooms = dbContext.HotelRooms;
            hotelRooms.AddRange(new List<HotelRoom>(){
                new HotelRoom
                {
                    numberOfBeds = 2,
                    roomSize = 20,
                    standard = "Economy"
                },

            });
            */
        }
    }
}
