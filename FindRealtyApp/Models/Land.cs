﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    class Land :RealEstate
    {
        public int Id { get; set; }
        public float TotalArea { get; set; }

    }
}