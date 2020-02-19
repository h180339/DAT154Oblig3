using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Oblig_3_Web.Model;

namespace Oblig_3_Web
{
    public class BookingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}