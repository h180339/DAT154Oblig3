using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig_3_Web.Model
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int numberOfBeds { get; set; }
        public int roomSize { get; set; } // in m^2
        public string standard { get; set; }

    }
}