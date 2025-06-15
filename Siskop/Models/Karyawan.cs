using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Models
{
    public class Karyawan
    {
        public int ID_Karyawan { get; set; }
        public string Nama_Karyawan { get; set; }
        public string Jabatan { get; set; }
        public DateTime Tanggal_Lahir { get; set; }
        public string Alamat { get; set; }
        public string Jenis_Kelamin { get; set; }
        public string Kontak { get; set; }
        public DateTime Karyawan_Sejak { get; set; }
        public bool Available { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    // Option 1: Always reload from database after changes
    public class KaryawanModel
    {
        private List<Karyawan> Karyawans = new List<Karyawan>();
        private readonly string connectionString;

        public event Action DataChanged;

        public KaryawanModel(string connectionString)
        {
            this.connectionString = connectionString;
            LoadFromDatabase();
        }

        public async Task AddKaryawan(string namaKaryawan, string jabatan, DateTime tanggalLahir,
            string alamat, string jenisKelamin, string kontak, string username, string password, string role)
        {
            var karyawan = new Karyawan
            {
                Nama_Karyawan = namaKaryawan,
                Jabatan = jabatan,
                Tanggal_Lahir = tanggalLahir,
                Alamat = alamat,
                Jenis_Kelamin = jenisKelamin,
                Kontak = kontak,
                Karyawan_Sejak = DateTime.Now,
                Username = username,
                Password = password,
                Role = role,
                Available = true
            };

            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"INSERT INTO Karyawan (Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                        Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role) 
                    VALUES (@Nama_Karyawan, @Jabatan, @Tanggal_Lahir, @Alamat, 
                        @Jenis_Kelamin, @Kontak, @Karyawan_Sejak, @Available, @Username, @Password, @Role) 
                    RETURNING ID_Karyawan";

            await connection.ExecuteScalarAsync<int>(sql, karyawan);

            // RELOAD from database instead of manual cache update
            await LoadFromDatabase();
        }

        public async Task RemoveKaryawan(int karyawanId)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "DELETE FROM Karyawan WHERE ID_Karyawan = @ID_Karyawan";
            var rowsAffected = await connection.ExecuteAsync(sql, new { ID_Karyawan = karyawanId });

            if (rowsAffected > 0)
            {
                // RELOAD from database instead of manual cache update
                await LoadFromDatabase();
            }
        }

        public async Task UpdateKaryawan(int id, string namaKaryawan, string jabatan, DateTime tanggalLahir,
           string alamat, string jenisKelamin, string kontak, string username, string password, string role, bool available = true)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"UPDATE Karyawan SET 
                        Nama_Karyawan = @Nama_Karyawan,
                        Jabatan = @Jabatan,
                        Tanggal_Lahir = @Tanggal_Lahir,
                        Alamat = @Alamat,
                        Jenis_Kelamin = @Jenis_Kelamin,
                        Kontak = @Kontak,
                        Username = @Username,
                        Password = @Password,
                        Role = @Role,
                        Available = @Available
                    WHERE ID_Karyawan = @ID_Karyawan";

            var parameters = new
            {
                ID_Karyawan = id,
                Nama_Karyawan = namaKaryawan,
                Jabatan = jabatan,
                Tanggal_Lahir = tanggalLahir,
                Alamat = alamat,
                Jenis_Kelamin = jenisKelamin,
                Kontak = kontak,
                Username = username,
                Password = password,
                Role = role,
                Available = available
            };

            var rowsAffected = await connection.ExecuteAsync(sql, parameters);

            if (rowsAffected > 0)
            {
                // RELOAD from database instead of manual cache update
                await LoadFromDatabase();
            }
        }

        // Make this method async and public for external refresh calls
        public async Task LoadFromDatabase()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                        Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                    FROM Karyawan 
                    ORDER BY ID_Karyawan";

            Karyawans = (await connection.QueryAsync<Karyawan>(sql)).ToList();
            DataChanged?.Invoke();
        }

        public List<Karyawan> GetKaryawans() => new List<Karyawan>(Karyawans);

        public List<Karyawan> GetActiveKaryawan()
        {
            return Karyawans.Where(k => k.Available).ToList();
        }
    }

    // Option 2: No caching - always fetch from database
    public class KaryawanModelNoCaching
    {
        private readonly string connectionString;
        public event Action DataChanged;

        public KaryawanModelNoCaching(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task AddKaryawan(string namaKaryawan, string jabatan, DateTime tanggalLahir,
            string alamat, string jenisKelamin, string kontak, string username, string password, string role)
        {
            var karyawan = new Karyawan
            {
                Nama_Karyawan = namaKaryawan,
                Jabatan = jabatan,
                Tanggal_Lahir = tanggalLahir,
                Alamat = alamat,
                Jenis_Kelamin = jenisKelamin,
                Kontak = kontak,
                Karyawan_Sejak = DateTime.Now,
                Username = username,
                Password = password,
                Role = role,
                Available = true
            };

            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"INSERT INTO Karyawan (Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                        Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role) 
                    VALUES (@Nama_Karyawan, @Jabatan, @Tanggal_Lahir, @Alamat, 
                        @Jenis_Kelamin, @Kontak, @Karyawan_Sejak, @Available, @Username, @Password, @Role)";

            await connection.ExecuteAsync(sql, karyawan);
            DataChanged?.Invoke(); // Notify that data has changed
        }

        // Always fetch fresh data from database
        public async Task<List<Karyawan>> GetKaryawans()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                        Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                    FROM Karyawan 
                    ORDER BY ID_Karyawan";

            return (await connection.QueryAsync<Karyawan>(sql)).ToList();
        }

        public async Task<List<Karyawan>> GetActiveKaryawan()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                        Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                    FROM Karyawan 
                    WHERE Available = true
                    ORDER BY ID_Karyawan";

            return (await connection.QueryAsync<Karyawan>(sql)).ToList();
        }
    }

    // Option 3: Smart caching with refresh mechanism
    public class KaryawanModelSmartCache
    {
        private List<Karyawan> cachedKaryawans = new List<Karyawan>();
        private readonly string connectionString;
        private DateTime lastRefresh = DateTime.MinValue;
        private readonly TimeSpan cacheExpiry = TimeSpan.FromMinutes(5); // Cache expires after 5 minutes

        public event Action DataChanged;

        public KaryawanModelSmartCache(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private async Task<bool> EnsureFreshData()
        {
            if (DateTime.Now - lastRefresh > cacheExpiry || cachedKaryawans.Count == 0)
            {
                await RefreshFromDatabase();
                return true;
            }
            return false;
        }

        public async Task RefreshFromDatabase()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                        Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                    FROM Karyawan 
                    ORDER BY ID_Karyawan";

            cachedKaryawans = (await connection.QueryAsync<Karyawan>(sql)).ToList();
            lastRefresh = DateTime.Now;
            DataChanged?.Invoke();
        }

        public async Task<List<Karyawan>> GetKaryawans()
        {
            await EnsureFreshData();
            return new List<Karyawan>(cachedKaryawans);
        }

        public async Task<List<Karyawan>> GetActiveKaryawan()
        {
            await EnsureFreshData();
            return cachedKaryawans.Where(k => k.Available).ToList();
        }

        public async Task AddKaryawan(string namaKaryawan, string jabatan, DateTime tanggalLahir,
            string alamat, string jenisKelamin, string kontak, string username, string password, string role)
        {
            // ... database insertion code ...

            // Force refresh after modification
            await RefreshFromDatabase();
        }

        // Method to manually force refresh (useful for multi-user scenarios)
        public async Task ForceRefresh()
        {
            await RefreshFromDatabase();
        }
    }
}