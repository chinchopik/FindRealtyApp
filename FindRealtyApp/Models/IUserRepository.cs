using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Models
{
    interface IUserRepository
    {

        bool AuthenticateUser(string login, string password);
        void AddLoggingHistory(string login);
    }
}
