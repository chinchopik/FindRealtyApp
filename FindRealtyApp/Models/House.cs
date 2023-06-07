using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    class House : RealEstate
    {
        public int Id { get; set; }
        public int TotalFloors { get; set; }
        public double TotalArea { get; set; }

    }
}
