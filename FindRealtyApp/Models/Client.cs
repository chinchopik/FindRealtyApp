﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    public class Client : Person
    {
        public new int Id { get; set; }
        public new string FirstName { get; set; }
        public new string LastName { get; set; }
        public new string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

}
