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

        public async Task AddKaryawan(string namaKaryawan, string jabatan, DateTime tanggalLahir, string alamat,
            string jenisKelamin, string kontak, string username, string password, string role)
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

            karyawan.ID_Karyawan = await connection.ExecuteScalarAsync<int>(sql, karyawan);

            Karyawans.Add(karyawan);
            DataChanged?.Invoke();
        }

        public async Task RemoveKaryawan(int karyawanId)
        {
            var karyawan = Karyawans.FirstOrDefault(k => k.ID_Karyawan == karyawanId);
            if (karyawan == null) return;

            using var connection = new NpgsqlConnection(connectionString);

            var sql = "DELETE FROM Karyawan WHERE ID_Karyawan = @ID_Karyawan";
            await connection.ExecuteAsync(sql, new { ID_Karyawan = karyawanId });

            Karyawans.Remove(karyawan);
            DataChanged?.Invoke();
        }

        public async Task UpdateKaryawan(int id, string namaKaryawan, string jabatan, DateTime tanggalLahir,
           string alamat, string jenisKelamin, string kontak, string username, string password, string role, bool available = true)
        {
            var karyawan = Karyawans.FirstOrDefault(k => k.ID_Karyawan == id);
            if (karyawan == null) return;

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

            await connection.ExecuteAsync(sql, parameters);

            // Update in-memory cache
            karyawan.Nama_Karyawan = namaKaryawan;
            karyawan.Jabatan = jabatan;
            karyawan.Tanggal_Lahir = tanggalLahir;
            karyawan.Alamat = alamat;
            karyawan.Jenis_Kelamin = jenisKelamin;
            karyawan.Kontak = kontak;
            karyawan.Username = username;
            karyawan.Password = password;
            karyawan.Role = role;
            karyawan.Available = available;

            DataChanged?.Invoke();
        }

        public async Task<Karyawan> AuthenticateKaryawan(string username, string password)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                            Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                        FROM Karyawan 
                        WHERE Username = @Username AND Password = @Password AND Available = true";

            return await connection.QueryFirstOrDefaultAsync<Karyawan>(sql, new { Username = username, Password = password });
        }

        public async Task SetKaryawanStatus(int id, bool status)
        {
            var karyawan = Karyawans.FirstOrDefault(k => k.ID_Karyawan == id);
            if (karyawan == null) return;

            using var connection = new NpgsqlConnection(connectionString);

            var sql = "UPDATE Karyawan SET Available = @Available WHERE ID_Karyawan = @ID_Karyawan";
            await connection.ExecuteAsync(sql, new { Available = status, ID_Karyawan = id });

            karyawan.Available = status;
            DataChanged?.Invoke();
        }

        public List<Karyawan> GetKaryawans() => new List<Karyawan>(Karyawans);

        public List<Karyawan> GetActiveKaryawan()
        {
            return Karyawans.Where(k => k.Available).ToList();
        }

        private async void LoadFromDatabase()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Karyawan, Nama_Karyawan, Jabatan, Tanggal_Lahir, Alamat, 
                            Jenis_Kelamin, Kontak, Karyawan_Sejak, Available, Username, Password, Role 
                        FROM Karyawan 
                        ORDER BY ID_Karyawan";

            Karyawans = (await connection.QueryAsync<Karyawan>(sql)).ToList();
            DataChanged?.Invoke();
        }
    }
}