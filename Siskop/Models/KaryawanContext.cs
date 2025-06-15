using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Siskop.Models
{
    internal class PenyuplaiContext
    {
        public readonly string connStr;
        public PenyuplaiContext()
        {
            connStr = Connection.Connection.GetConnectionString();
        }
        public bool LoginPenyuplai(string username, string password, out int idPenyuplai)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                try
                {


                    conn.Open();
                    string query = "SELECT * FROM Karyawan WHERE username = @username AND password = @password AND Available = true";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idPenyuplai = reader.GetInt32(reader.GetOrdinal("ID_Karyawan"));
                                return true;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }

            idPenyuplai = 0;
            return false;
        }
    }
}