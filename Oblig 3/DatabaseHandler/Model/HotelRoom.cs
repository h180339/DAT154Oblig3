using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseHandler.Model
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int numberOfBeds { get; set; }
        public int roomSize { get; set; } // in m^2
        public string quality { get; set; }
        public string status { get; set; } 

    }
}