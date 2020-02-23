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
            //Users
            DbSet<User> userSet = dbContext.Users;
            List<User> users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    username = "Eirik",
                    password = "passord",
                }
            };
            foreach(User u in users)
            {
                userSet.AddOrUpdate(user => user.Id, u);
            }

            //HotelRooms: 
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
                new HotelRoom
                {
                    Id = 4,
                    numberOfBeds = 3,
                    roomSize = 50,
                    quality = "High",
                },
                new HotelRoom
                {
                    Id = 5,
                    numberOfBeds = 1,
                    roomSize = 10,
                    quality = "Low",
                },
                new HotelRoom
                {
                    Id = 6,
                    numberOfBeds = 3,
                    roomSize = 60,
                    quality = "Medium",
                }

            };
            foreach (HotelRoom r in rooms)
            {
                hotelRooms.AddOrUpdate(hr => hr.Id, r);
            }
            //Reservations: 
            DbSet<Reservation> resSet = dbContext.Reservations;
            List<Reservation> reservations = new List<Reservation>()
            {
                new Reservation
                {
                    Id = 1,
                    startDate = new DateTime(2020, 2, 3),
                    endDate = new DateTime(2020, 2, 10),
                    UserId = 1,
                    User = users[0],
                    HotelRoomId = 6,
                    HotelRoom = rooms.Find(x => x.Id == 6)
                }
            };
            foreach(Reservation r in reservations)
            {
                resSet.AddOrUpdate(res => res.Id, r);
            }

            dbContext.SaveChanges();
        }
    }
}
