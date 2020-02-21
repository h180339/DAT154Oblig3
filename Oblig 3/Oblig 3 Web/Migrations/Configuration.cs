namespace Oblig_3_Web.Migrations
{
    using Oblig_3_Web.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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


            BookingDbContext dbContext = new BookingDbContext();
            DbSet<HotelRoom> hotelRooms = dbContext.HotelRooms;
            List<HotelRoom> rooms = new List<HotelRoom>()
            {
                new HotelRoom
                {
                    Id = 1,
                    numberOfBeds = 2,
                    roomSize = 20,
                    quality = "Economy",
                },
                new HotelRoom
                {
                    Id = 2,
                    numberOfBeds = 4,
                    roomSize = 100,
                    quality = "Suite",
                },
                new HotelRoom
                {
                    Id = 3,
                    numberOfBeds = 3,
                    roomSize = 70,
                    quality = "Economy",
                },

            };
            foreach (HotelRoom r in rooms)
            {
                hotelRooms.AddOrUpdate(hr => hr.Id, r);
            }
            dbContext.SaveChanges();
        }
    }
}
