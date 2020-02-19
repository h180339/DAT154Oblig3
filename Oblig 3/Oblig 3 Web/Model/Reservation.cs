using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig_3_Web.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}