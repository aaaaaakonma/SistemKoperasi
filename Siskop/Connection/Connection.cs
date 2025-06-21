using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siskop.Connection
{
    class Connection
    {
        private static string connectionString;
        public static string GetConnectionString()
        {
            connectionString = "Host=localhost;Username=postgres;Password=oranggilatau;Database=SistemKoperasi";
            return connectionString;
        }
    }
}
