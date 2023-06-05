using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    class Apartment :RealEstate
    {
        public int Id { get; set; }
        public int TotalFloors { get; set; }
        public float TotalArea { get; set; }
        public int NubmerOfRooms { get; set; }
    }
}
