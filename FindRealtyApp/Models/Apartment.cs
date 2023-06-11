using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    class Apartment :RealEstate
    {
        public new int Id { get; set; }
        public int TotalFloors { get; set; }
        public double TotalArea { get; set; }
        public int NumberOfRooms { get; set; }
        public new int Price { get; set; }
    }
}
