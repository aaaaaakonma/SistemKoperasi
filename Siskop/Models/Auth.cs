using System;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using System.Security.Cryptography;
using System.Text;

namespace Models
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Karyawan User { get; set; }
    }

    public class AuthModel
    {
        private readonly string connectionString;
        private Karyawan currentUser;

        public AuthModel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Property to get current logged-in user
        public Karyawan CurrentUser => currentUser;
        public bool IsLoggedIn => currentUser != null;

        // Login method
        public async Task<AuthResult> LoginAsync(string username, string password)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                           Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                           FROM Karyawan 
                           WHERE Username = @Username AND Available = true";

                var user = await connection.QueryFirstOrDefaultAsync<Karyawan>(sql, new { Username = username });

                if (user == null)
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Username tidak ditemukan atau akun tidak aktif"
                    };
                }

                // Simple password comparison (in production, use hashed passwords)
                if (user.Password != password)
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Password salah"
                    };
                }

                // Set current user
                currentUser = user;

                return new AuthResult
                {
                    IsSuccess = true,
                    Message = "Login berhasil",
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = $"Error saat login: {ex.Message}"
                };
            }
        }


        // Check if user has specific role
        public bool HasRole(string role)
        {
            return IsLoggedIn && currentUser.Role.Equals(role, StringComparison.OrdinalIgnoreCase);
        }

        // Check if user is admin
        public bool IsAdmin()
        {
            return HasRole("Admin");
        }
            
        
        
    }
}