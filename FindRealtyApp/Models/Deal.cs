﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    class Deal
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public string Client { get; set; }
        public string Agent { get; set; }
    }
}