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

        // Logout method
        public void Logout()
        {
            currentUser = null;
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

        // Change password for current user
        public async Task<AuthResult> ChangePasswordAsync(string currentPassword, string newPassword)
        {
            if (!IsLoggedIn)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Belum login"
                };
            }

            if (currentUser.Password != currentPassword)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Password lama salah"
                };
            }

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 4)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Password baru harus minimal 4 karakter"
                };
            }

            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = "UPDATE Karyawan SET Password = @NewPassword WHERE ID_Karyawan = @ID_Karyawan";

                var rowsAffected = await connection.ExecuteAsync(sql, new
                {
                    NewPassword = newPassword,
                    ID_Karyawan = currentUser.ID_Karyawan
                });

                if (rowsAffected > 0)
                {
                    // Update current user's password in memory
                    currentUser.Password = newPassword;

                    return new AuthResult
                    {
                        IsSuccess = true,
                        Message = "Password berhasil diubah"
                    };
                }
                else
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Gagal mengubah password"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = $"Error saat mengubah password: {ex.Message}"
                };
            }
        }

        // Change username for current user
        public async Task<AuthResult> ChangeUsernameAsync(string newUsername)
        {
            if (!IsLoggedIn)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Belum login"
                };
            }

            if (string.IsNullOrWhiteSpace(newUsername) || newUsername.Length < 3)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Username baru harus minimal 3 karakter"
                };
            }

            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                // Check if username already exists
                var checkSql = "SELECT COUNT(*) FROM Karyawan WHERE Username = @Username AND ID_Karyawan != @ID_Karyawan";
                var existingCount = await connection.QuerySingleAsync<int>(checkSql, new
                {
                    Username = newUsername,
                    ID_Karyawan = currentUser.ID_Karyawan
                });

                if (existingCount > 0)
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Username sudah digunakan"
                    };
                }

                var sql = "UPDATE Karyawan SET Username = @NewUsername WHERE ID_Karyawan = @ID_Karyawan";

                var rowsAffected = await connection.ExecuteAsync(sql, new
                {
                    NewUsername = newUsername,
                    ID_Karyawan = currentUser.ID_Karyawan
                });

                if (rowsAffected > 0)
                {
                    // Update current user's username in memory
                    currentUser.Username = newUsername;

                    return new AuthResult
                    {
                        IsSuccess = true,
                        Message = "Username berhasil diubah"
                    };
                }
                else
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Gagal mengubah username"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = $"Error saat mengubah username: {ex.Message}"
                };
            }
        }

        // Validate current session (useful for checking if user is still valid)
        public async Task<bool> ValidateSessionAsync()
        {
            if (!IsLoggedIn)
                return false;

            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = @"SELECT COUNT(*) FROM Karyawan 
                           WHERE ID_Karyawan = @ID_Karyawan AND Available = true";

                var count = await connection.QuerySingleAsync<int>(sql, new { ID_Karyawan = currentUser.ID_Karyawan });

                if (count == 0)
                {
                    // User no longer exists or is not available, logout
                    Logout();
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Admin method to reset password for any user
        public async Task<AuthResult> ResetUserPasswordAsync(int karyawanId, string newPassword)
        {
            if (!IsAdmin())
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Hanya admin yang dapat mereset password"
                };
            }

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 4)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "Password baru harus minimal 4 karakter"
                };
            }

            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = "UPDATE Karyawan SET Password = @NewPassword WHERE ID_Karyawan = @ID_Karyawan";

                var rowsAffected = await connection.ExecuteAsync(sql, new
                {
                    NewPassword = newPassword,
                    ID_Karyawan = karyawanId
                });

                if (rowsAffected > 0)
                {
                    return new AuthResult
                    {
                        IsSuccess = true,
                        Message = "Password berhasil direset"
                    };
                }
                else
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Karyawan tidak ditemukan"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = $"Error saat mereset password: {ex.Message}"
                };
            }
        }
    }

    // Helper class for password hashing (optional - for production use)
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            var passwordHash = HashPassword(password);
            return passwordHash == hash;
        }
    }
}