using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Dapper;
using Npgsql;

namespace Models
{
    public class NasabahModel
    {
        private List<Nasabah> Nasabahs = new List<Nasabah>();
        private readonly string connectionString;

        // Event for notifying views when data changes
        public event Action DataChanged;

        public NasabahModel(string connectionString)
        {
            this.connectionString = connectionString;
            LoadFromDatabase(); // Load initial data
        }

        public async Task AddNasabah(string nik, string nama, string ttl, string alamat, string rtRw, string kelurahan, string pekerjaan, string agama)
        {
            var nasabah = new Nasabah
            {
                NIK = nik,
                Nama = nama,
                TTL = ttl,
                Alamat = alamat,
                RT_RW = rtRw,
                Kelurahan = kelurahan,
                Pekerjaan = pekerjaan,
                Agama = agama
            };

            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"INSERT INTO Nasabahs (NIK, Nama, TTL, Alamat, RT_RW, Kelurahan, Pekerjaan, Agama) 
                VALUES (@NIK, @Nama, @TTL, @Alamat, @RT_RW, @Kelurahan, @Pekerjaan, @Agama) 
                RETURNING id_Nasabah";

            nasabah.id_Nasabah = await connection.ExecuteScalarAsync<int>(sql, nasabah);

            Nasabahs.Add(nasabah);
            DataChanged?.Invoke();
        }
        public List<Nasabah> GetNasabahs() => new List<Nasabah>(Nasabahs);

        private async void LoadFromDatabase()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "SELECT Id_Nasabah, NIK, Nama, TTL, Alamat, RT_RW, Kelurahan, Pekerjaan, Agama FROM Nasabahs";
            Nasabahs = (await connection.QueryAsync<Nasabah>(sql)).ToList();

            DataChanged?.Invoke();
        }
    }

        public class Nasabah
        {
            public int id_Nasabah { get; set; }
            public string NIK { get; set; }
            public required string Nama { get; set; }
            public string TTL { get; set; }
            public required string Alamat { get; set; }
            public string RT_RW { get; set; }
            public string Kelurahan { get; set; }
            public string Pekerjaan { get; set; }
            public string Agama { get; set; }
        }


        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string Role { get; set; }
            public DateTime CreatedAt { get; set; }

            public User() { }

            public User(string username, string role, string password)
            {
                Username = username;
                Role = role;
                PasswordHash = HashPassword(password);
                CreatedAt = DateTime.Now;
            }

            public bool VerifyPassword(string password)
            {
                return PasswordHash == HashPassword(password);
            }

            private static string HashPassword(string password)
            {
                using var sha256 = SHA256.Create();
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "Nigger"));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // AUTHENTICATION MODEL - Handles login/logout state and user management
        public class AuthModel
        {
            private readonly string connectionString;
            private User currentUser;

            // Events for notifying views about authentication state changes
            public event Action<User> UserLoggedIn;
            public event Action UserLoggedOut;
            public event Action<string> LoginFailed;
            public event Action<string> RegistrationFailed;
            public event Action<User> UserRegistered;

            public AuthModel(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public User CurrentUser => currentUser;
            public bool IsLoggedIn => currentUser != null;

            public async Task<bool> LoginAsync(string username, string password)
            {
                try
                {
                    using var connection = new NpgsqlConnection(connectionString);

                    var user = await connection.QuerySingleOrDefaultAsync<User>(
                        "SELECT id_Nasabah, username, password, role  FROM Users WHERE Username = @Username",
                        new { Username = username });

                    if (user == null)
                    {
                        LoginFailed?.Invoke("Username not found");
                        return false;
                    }

                    //if (!user.VerifyPassword(password))
                    //{
                    //    LoginFailed?.Invoke("Invalid password");
                    //    return false;
                    //}

                    currentUser = user;
                    UserLoggedIn?.Invoke(user);
                    return true;
                }
                catch (Exception ex)
                {
                    LoginFailed?.Invoke($"Login error: {ex.Message}");
                    return false;
                }
            }

            public async Task<bool> RegisterAsync(string username, string role, string password)
            {
                try
                {
                    using var connection = new NpgsqlConnection(connectionString);

                    // Check if username already exists
                    var existingUser = await connection.QuerySingleOrDefaultAsync<User>(
                        "SELECT Id FROM Users WHERE Username = @Username",
                        new { Username = username });

                    if (existingUser != null)
                    {
                        RegistrationFailed?.Invoke("Username already exists");
                        return false;
                    }

                    // Create new user
                    var user = new User(username, role, password);

                    var sql = @"INSERT INTO Users (Username, PasswordHash, Role, CreatedAt) 
                           OUTPUT INSERTED.Id 
                           VALUES (@Username, @PasswordHash, @Role, @CreatedAt)";

                    user.Id = await connection.QuerySingleAsync<int>(sql, user);

                    UserRegistered?.Invoke(user);
                    return true;
                }
                catch (Exception ex)
                {
                    RegistrationFailed?.Invoke($"Registration error: {ex.Message}");
                    return false;
                }
            }

            public void Logout()
            {
                currentUser = null;
                UserLoggedOut?.Invoke();
            }
        }
    }

    public class PinjamanModel
    {
        private List<Pinjaman> Pinjamans = new List<Pinjaman>();
        private readonly string connectionString;

        // Event for notifying views when data changes
        public event Action DataChanged;

        public PinjamanModel(string connectionString)
        {
            this.connectionString = connectionString;
            LoadFromDatabase(); // Load initial data
        }

        public async Task AddPinjaman(int idNasabah, decimal jumlahPinjaman, string keterangan, decimal bunga, int durasi)
        {
            // Calculate total loan amount (principal + total interest)
            decimal totalPinjaman = jumlahPinjaman * (1 + (bunga / 100m) * durasi);

            var pinjaman = new Pinjaman
            {
                id_Nasabah = idNasabah,
                Jumlah_pinjaman = jumlahPinjaman,
                Keterangan = keterangan,
                Durasi = durasi,
                Bunga = bunga,
                Saldo_pinjaman = totalPinjaman, // Initial balance = total amount due
                CreatedAt = DateTime.Now
            };

            using var connection = new NpgsqlConnection(connectionString);

            // Fixed SQL: Added missing @Durasi parameter
            var sql = @"INSERT INTO Pinjamans (id_Nasabah, Jumlah_pinjaman, Keterangan, Durasi, Bunga, Saldo_pinjaman, CreatedAt) 
                    VALUES (@id_Nasabah, @Jumlah_pinjaman, @Keterangan, @Durasi, @Bunga, @Saldo_pinjaman, @CreatedAt) 
                    RETURNING id_Pinjaman";

            pinjaman.id_Pinjaman = await connection.ExecuteScalarAsync<int>(sql, pinjaman);

            Pinjamans.Add(pinjaman);
            DataChanged?.Invoke();
        }


        public async Task RemovePinjaman(int pinjamanId)
        {
            var pinjaman = Pinjamans.FirstOrDefault(p => p.id_Pinjaman == pinjamanId);
            if (pinjaman == null) return;

            using var connection = new NpgsqlConnection(connectionString);

            var sql = "DELETE FROM Pinjamans WHERE ID_Pinjaman = @ID_Pinjaman";
            await connection.ExecuteAsync(sql, new { ID_Pinjaman = pinjamanId });

            // Update in-memory cache
            Pinjamans.Remove(pinjaman);
            DataChanged?.Invoke();
        }

        public async Task UpdateSaldoPinjaman(int idPinjaman, decimal newSaldo)
        {
            var pinjaman = Pinjamans.FirstOrDefault(p => p.id_Pinjaman == idPinjaman);
            if (pinjaman == null) return;

            using var connection = new NpgsqlConnection(connectionString);

            var sql = "UPDATE Pinjamans SET Saldo_pinjaman = @Saldo WHERE id_Pinjaman = @id_Pinjaman";
            await connection.ExecuteAsync(sql, new { Saldo = newSaldo, id_Pinjaman = idPinjaman });

            // Update in-memory cache
            pinjaman.Saldo_pinjaman = newSaldo;
            DataChanged?.Invoke();
        }

        public async Task MakePayment(int idPinjaman, decimal paymentAmount)
        {
            var pinjaman = Pinjamans.FirstOrDefault(p => p.id_Pinjaman == idPinjaman);
            if (pinjaman == null) return;

            if (paymentAmount <= 0 || paymentAmount > pinjaman.Saldo_pinjaman)
                throw new ArgumentException("Invalid payment amount");

            var newSaldo = pinjaman.Saldo_pinjaman - paymentAmount;
            await UpdateSaldoPinjaman(idPinjaman, newSaldo);
        }

        public async Task<List<Pinjaman>> GetPinjamansByNasabah(int idNasabah)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Pinjaman, Id_Nasabah, Jumlah_pinjaman, Keterangan, 
                       Durasi, Bunga, Saldo_pinjaman, CreatedAt 
                FROM Pinjamans 
                WHERE Id_Nasabah = @Id_Nasabah 
                ORDER BY CreatedAt DESC";

            var pinjamans = await connection.QueryAsync<Pinjaman>(sql, new { Id_Nasabah = idNasabah });
            return pinjamans.ToList();
        }

        public async Task<decimal> GetTotalOutstandingDebt(int idNasabah)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT COALESCE(SUM(Saldo_pinjaman), 0) 
                    FROM Pinjamans 
                    WHERE id_Nasabah = @id_Nasabah AND Saldo_pinjaman > 0";

            return await connection.ExecuteScalarAsync<decimal>(sql, new { id_Nasabah = idNasabah });
        }

        public List<Pinjaman> GetActivePinjamans()
        {
            return Pinjamans.Where(p => p.Saldo_pinjaman > 0).ToList();
        }

        public List<Pinjaman> GetPaidOffPinjamans()
        {
            return Pinjamans.Where(p => p.Saldo_pinjaman == 0).ToList();
        }

        private async void LoadFromDatabase()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Pinjaman, Id_Nasabah, Jumlah_pinjaman, Keterangan, 
                       Durasi, Bunga, Saldo_pinjaman, CreatedAt 
                FROM Pinjamans 
                ORDER BY CreatedAt DESC";

            Pinjamans = (await connection.QueryAsync<Pinjaman>(sql)).ToList();
            DataChanged?.Invoke(); // Notify views after initial load
        }
    }
    public class Pinjaman
    {
        public int id_Pinjaman { get; set; }
        public int id_Nasabah { get; set; }
        public decimal Jumlah_pinjaman { get; set; }
        public string Keterangan { get; set; }
        public int Durasi { get; set; }
        public decimal Bunga { get; set; }
        public decimal Saldo_pinjaman { get; set; }
        public DateTime CreatedAt { get; set; }

        // Constructor for creating new pinjaman
        public Pinjaman() { }

        public Pinjaman(int idNasabah, decimal jumlahPinjaman, string keterangan, decimal bunga)
        {
            id_Nasabah = idNasabah;
            Jumlah_pinjaman = jumlahPinjaman;
            Keterangan = keterangan ?? "";
            Bunga = bunga;
            Saldo_pinjaman = jumlahPinjaman; // Initially full amount
            CreatedAt = DateTime.Now;
        }
    }