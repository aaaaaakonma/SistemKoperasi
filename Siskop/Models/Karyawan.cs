using Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Windows.Forms;

namespace Siskop.Models
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

    public class KaryawanModel
    {
        private List<Karyawan> Karyawans = new List<Karyawan>();
        private readonly string connectionString;

        // Event for notifying views when data changes
        public event Action DataChanged;

        public KaryawanModel(string connectionString)
        {
            this.connectionString = connectionString;
            LoadFromDatabase(); // Load initial data
        }

        // Method untuk menambah karyawan dengan parameter lengkap
        public async Task AddKaryawan(string namaKaryawan, string jabatan, DateTime tanggalLahir,
            string alamat, string jenisKelamin, string kontak, DateTime karyawanSejak,
            bool available = true, string username = null, string password = null, string role = "Karyawan")
        {
            var karyawan = new Karyawan
            {
                Nama_Karyawan = namaKaryawan,
                Jabatan = jabatan,
                Tanggal_Lahir = tanggalLahir,
                Alamat = alamat,
                Jenis_Kelamin = jenisKelamin,
                Kontak = kontak,
                Karyawan_Sejak = karyawanSejak,
                Available = available,
                Username = username,
                Password = password,
                Role = role
            };

            using var connection = new NpgsqlConnection(connectionString);

            // SQL INSERT yang sesuai dengan struktur tabel Karyawan
            var sql = @"INSERT INTO Karyawan (Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                            Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role) 
                        VALUES (@Nama_Karyawan, @Jabatan, @Tanggal_Lahir, @Alamat, 
                            @Jenis_Kelamin, @Kontak, @Karyawan_Sejak, @Available, @Username, @Password, @Role) 
                        RETURNING ID_Karyawan";

            karyawan.ID_Karyawan = await connection.ExecuteScalarAsync<int>(sql, karyawan);

            // Update in-memory cache
            Karyawans.Add(karyawan);
            DataChanged?.Invoke();
        }

        // Method overload untuk kemudahan penggunaan dengan parameter minimal
        public async Task AddKaryawan(string namaKaryawan, string jabatan, string alamat, string jenisKelamin)
        {
            await AddKaryawan(namaKaryawan, jabatan, DateTime.Now.AddYears(-25), alamat,
                jenisKelamin, "", DateTime.Now, true);
        }

        // Method untuk update karyawan
        public async Task UpdateKaryawan(int id, string namaKaryawan, string jabatan, DateTime tanggalLahir,
            string alamat, string jenisKelamin, string kontak, DateTime karyawanSejak, bool available,
            string username = null, string password = null, string role = "Karyawan")
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"UPDATE Karyawan SET 
                            Nama_Karyawan = @Nama_Karyawan,
                            Jabatan = @Jabatan,
                            Tanggal_Lahir = @Tanggal_Lahir,
                            Alamat = @Alamat,
                            Jenis_Kelamin = @Jenis_Kelamin,
                            Kontak = @Kontak,
                            Karyawan_Sejak = @Karyawan_Sejak,
                            Available = @Available,
                            Username = @Username,
                            Password = @Password,
                            Role = @Role
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
                Karyawan_Sejak = karyawanSejak,
                Available = available,
                Username = username,
                Password = password,
                Role = role
            };

            await connection.ExecuteAsync(sql, parameters);

            // Update in-memory cache
            var existingKaryawan = Karyawans.FirstOrDefault(k => k.ID_Karyawan == id);
            if (existingKaryawan != null)
            {
                existingKaryawan.Nama_Karyawan = namaKaryawan;
                existingKaryawan.Jabatan = jabatan;
                existingKaryawan.Tanggal_Lahir = tanggalLahir;
                existingKaryawan.Alamat = alamat;
                existingKaryawan.Jenis_Kelamin = jenisKelamin;
                existingKaryawan.Kontak = kontak;
                existingKaryawan.Karyawan_Sejak = karyawanSejak;
                existingKaryawan.Available = available;
                existingKaryawan.Username = username;
                existingKaryawan.Password = password;
                existingKaryawan.Role = role;
            }

            DataChanged?.Invoke();
        }

        // Method untuk menghapus karyawan berdasarkan ID
        public async Task RemoveKaryawan(int id)
        {
            using var connection = new NpgsqlConnection(connectionString);

            // SQL DELETE yang benar
            var sql = "DELETE FROM Karyawan WHERE ID_Karyawan = @ID_Karyawan";
            await connection.ExecuteAsync(sql, new { ID_Karyawan = id });

            // Update in-memory cache
            Karyawans.RemoveAll(k => k.ID_Karyawan == id);
            DataChanged?.Invoke();
        }

        // Method untuk menghapus karyawan berdasarkan index
        public async Task RemoveKaryawanByIndex(int index)
        {
            if (index < 0 || index >= Karyawans.Count) return;

            var karyawan = Karyawans[index];
            await RemoveKaryawan(karyawan.ID_Karyawan);
        }

        // Method untuk mendapatkan karyawan berdasarkan ID
        public Karyawan GetKaryawanById(int id)
        {
            return Karyawans.FirstOrDefault(k => k.ID_Karyawan == id);
        }

        // Method untuk mendapatkan semua karyawan
        public List<Karyawan> GetAllKaryawan()
        {
            return new List<Karyawan>(Karyawans);
        }

        // Method untuk mendapatkan karyawan aktif saja
        public List<Karyawan> GetActiveKaryawan()
        {
            return Karyawans.Where(k => k.Available).ToList();
        }

        // Method untuk login karyawan
        public async Task<Karyawan> AuthenticateKaryawan(string username, string password)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                            Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                        FROM Karyawan 
                        WHERE Username = @Username AND Password = @Password AND Available = true";

            return await connection.QueryFirstOrDefaultAsync<Karyawan>(sql, new { Username = username, Password = password });
        }

        // Method untuk mengubah status available karyawan
        public async Task SetKaryawanStatus(int id, bool status)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "UPDATE Karyawan SET Available = @Available WHERE ID_Karyawan = @ID_Karyawan";
            await connection.ExecuteAsync(sql, new { Available = status, ID_Karyawan = id });

            // Update in-memory cache
            var karyawan = Karyawans.FirstOrDefault(k => k.ID_Karyawan == id);
            if (karyawan != null)
            {
                karyawan.Available = status;
            }

            DataChanged?.Invoke();
        }

        // Method untuk load data dari database
        private async void LoadFromDatabase()
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                // SQL SELECT yang benar untuk tabel Karyawan
                var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                                Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                            FROM Karyawan 
                            ORDER BY ID_Karyawan";

                Karyawans = (await connection.QueryAsync<Karyawan>(sql)).ToList();
                DataChanged?.Invoke(); // Notify views after initial load
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading karyawan data: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Karyawans = new List<Karyawan>();
            }
        }

        // Method untuk refresh data dari database
        public async Task RefreshData()
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                                Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                            FROM Karyawan 
                            ORDER BY ID_Karyawan";

                Karyawans = (await connection.QueryAsync<Karyawan>(sql)).ToList();
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing karyawan data: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method untuk pencarian karyawan
        public List<Karyawan> SearchKaryawan(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllKaryawan();

            searchTerm = searchTerm.ToLower();
            return Karyawans.Where(k =>
                k.Nama_Karyawan.ToLower().Contains(searchTerm) ||
                k.Jabatan.ToLower().Contains(searchTerm) ||
                k.Alamat.ToLower().Contains(searchTerm) ||
                k.Role.ToLower().Contains(searchTerm)
            ).ToList();
        }
    }
}