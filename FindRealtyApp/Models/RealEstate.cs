using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    class RealEstate
    {
        public int Id { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouse { get; set; }
        public string AddressNumber { get; set; }
        public double LatitudeCoordinate { get; set; }
        public double LongitudeCoordinate { get; set; }
    }
}
