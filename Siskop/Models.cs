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
using System.Linq;
using System.Diagnostics.Contracts;

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
            _ = LoadFromDatabaseAsync(); // Load initial data
        }

        public async Task UpdateNasabah(int idNasabah, string nik, string nama, DateTime ttl, string alamat, string rtRw, string kelurahan, string pekerjaan, string agama)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"UPDATE Nasabahs SET 
                NIK = @NIK, 
                Nama = @Nama, 
                TTL = @TTL, 
                Alamat = @Alamat, 
                RT_RW = @RT_RW, 
                Kelurahan = @Kelurahan, 
                Pekerjaan = @Pekerjaan, 
                Agama = @Agama 
                WHERE id_Nasabah = @id_Nasabah";

            await connection.ExecuteAsync(sql, new
            {
                id_Nasabah = idNasabah,
                NIK = nik,
                Nama = nama,
                TTL = ttl,
                Alamat = alamat,
                RT_RW = rtRw,
                Kelurahan = kelurahan,
                Pekerjaan = pekerjaan,
                Agama = agama
            });

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public async Task AddNasabah(string nik, string nama, DateTime ttl, string alamat, string rtRw, string kelurahan, string pekerjaan, string agama)
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

            await connection.ExecuteScalarAsync<int>(sql, nasabah);

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public async Task DeleteNasabah(int idNasabah)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "DELETE FROM Nasabahs WHERE id_Nasabah = @id_Nasabah";
            await connection.ExecuteAsync(sql, new { id_Nasabah = idNasabah });

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public List<Nasabah> GetNasabahs() => new List<Nasabah>(Nasabahs);


        private async Task LoadFromDatabaseAsync()
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = "SELECT Id_Nasabah, NIK, Nama, TTL, Alamat, RT_RW, Kelurahan, Pekerjaan, Agama FROM Nasabahs";
                Nasabahs = (await connection.QueryAsync<Nasabah>(sql)).ToList();

                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately - could log or throw
                MessageBox.Show($"Error loading Nasabah data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Nasabah
    {
        public int id_Nasabah { get; set; }
        public string NIK { get; set; }
        public required string Nama { get; set; }
        public DateTime TTL { get; set; }
        public required string Alamat { get; set; }
        public string RT_RW { get; set; }
        public string Kelurahan { get; set; }
        public string Pekerjaan { get; set; }
        public string Agama { get; set; }
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
            _ = LoadFromDatabaseAsync(); // Load initial data
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

            var sql = @"INSERT INTO Pinjamans (id_Nasabah, Jumlah_pinjaman, Keterangan, Durasi, Bunga, Saldo_pinjaman, CreatedAt) 
                    VALUES (@id_Nasabah, @Jumlah_pinjaman, @Keterangan, @Durasi, @Bunga, @Saldo_pinjaman, @CreatedAt) 
                    RETURNING id_Pinjaman";

            await connection.ExecuteScalarAsync<int>(sql, pinjaman);

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public async Task RemovePinjaman(int pinjamanId)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "DELETE FROM Pinjamans WHERE ID_Pinjaman = @ID_Pinjaman";
            await connection.ExecuteAsync(sql, new { ID_Pinjaman = pinjamanId });

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public async Task UpdateSaldoPinjaman(int idPinjaman, decimal newSaldo)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "UPDATE Pinjamans SET Saldo_pinjaman = @Saldo WHERE id_Pinjaman = @id_Pinjaman";
            await connection.ExecuteAsync(sql, new { Saldo = newSaldo, id_Pinjaman = idPinjaman });

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public async Task UpdatePinjaman(int idPinjaman, int idNasabah, decimal jumlahPinjaman, string keterangan, decimal bunga, int durasi)
        {
            // Calculate total loan amount (principal + total interest)
            decimal totalPinjaman = jumlahPinjaman * (1 + (bunga / 100m) * durasi);

            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"UPDATE Pinjamans SET 
                       id_Nasabah = @id_Nasabah,
                       Jumlah_pinjaman = @Jumlah_pinjaman,
                       Keterangan = @Keterangan,
                       Durasi = @Durasi,
                       Bunga = @Bunga,
                       Saldo_pinjaman = @Saldo_pinjaman
                       WHERE id_Pinjaman = @id_Pinjaman";

            await connection.ExecuteAsync(sql, new
            {
                id_Pinjaman = idPinjaman,
                id_Nasabah = idNasabah,
                Jumlah_pinjaman = jumlahPinjaman,
                Keterangan = keterangan,
                Durasi = durasi,
                Bunga = bunga,
                Saldo_pinjaman = totalPinjaman
            });

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
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


        private async Task LoadFromDatabaseAsync()
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = @"SELECT ID_Pinjaman, Id_Nasabah, Jumlah_pinjaman, Keterangan, 
                           Durasi, Bunga, Saldo_pinjaman, CreatedAt 
                    FROM Pinjamans 
                    ORDER BY CreatedAt DESC";

                Pinjamans = (await connection.QueryAsync<Pinjaman>(sql)).ToList();
                DataChanged?.Invoke(); // Notify views after initial load
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pinjaman data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Constructor for cr
    }

    public class AngsuranModel
    {
        public List<Angsuran> Angsurans = new List<Angsuran>();
        private readonly string connectionString;

        // Event for notifying views when data changes
        public event Action DataChanged;

        public AngsuranModel(string connectionString)
        {
            this.connectionString = connectionString;
            _ = LoadFromDatabaseAsync(); // Load initial data
        }

        // Updated AddAngsuran method in AngsuranModel class
        public async Task AddAngsuran(int id, decimal jumlahAngsuran, string keterangan = "")
        {
            var pembayaran = new Angsuran
            {
                ID_Pinjaman = id,
                Jumlah_Angsuran = jumlahAngsuran,
                Tanggal_Pembayaran = DateTime.Now,
                Keterangan = keterangan ?? ""
            }; ;

            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"INSERT INTO Angsurans (ID_Pinjaman, Jumlah_Angsuran, Tanggal_Pembayaran, Keterangan) 
                VALUES (@ID_Pinjaman, @Jumlah_Angsuran, @Tanggal_Pembayaran, @Keterangan) 
                RETURNING ID_Pembayaran";

            await connection.ExecuteScalarAsync<int>(sql, pembayaran);

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public async Task<List<Angsuran>> GetPembayaranByPinjaman(int idPinjaman)
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"SELECT ID_Pembayaran, ID_Pinjaman, Jumlah_Angsuran, Tanggal_Pembayaran, Keterangan 
                        FROM Angsurans 
                        WHERE ID_Pinjaman = @ID_Pinjaman 
                        ORDER BY Tanggal_Pembayaran DESC";

            var pembayarans = await connection.QueryAsync<Angsuran>(sql, new { ID_Pinjaman = idPinjaman });
            return pembayarans.ToList();
        }

        private async Task LoadFromDatabaseAsync()
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = @"SELECT ID_Pembayaran, ID_Pinjaman, Jumlah_Angsuran, Tanggal_Pembayaran, Keterangan 
                            FROM Angsurans 
                            ORDER BY Tanggal_Pembayaran DESC";

                Angsurans = (await connection.QueryAsync<Angsuran>(sql)).ToList();
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Angsuran data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Angsuran
    {
        public int ID_Pembayaran { get; set; }
        public int ID_Pinjaman { get; set; }
        public decimal Jumlah_Angsuran { get; set; }
        public DateTime Tanggal_Pembayaran { get; set; }
        public string Keterangan { get; set; }

        public Angsuran() { }

        public Angsuran(int idPinjaman, decimal jumlahAngsuran, string keterangan = "")
        {
            ID_Pinjaman = idPinjaman;
            Jumlah_Angsuran = jumlahAngsuran;
            Tanggal_Pembayaran = DateTime.Now;
            Keterangan = keterangan ?? "";
        }
    }

    public class PengeluaranModel
    {
        private List<Pengeluaran> Pengeluarans = new List<Pengeluaran>();
        private readonly string connectionString;

        // Event for notifying views when data changes
        public event Action DataChanged;

        public PengeluaranModel(string connectionString)
        {
            this.connectionString = connectionString;
            _ = LoadFromDatabaseAsync(); // Load initial data
        }

        public async Task AddPengeluaran(string namaPengeluaran, decimal totalPengeluaran)
        {
            var pengeluaran = new Pengeluaran
            {
                Nama_Pengeluaran = namaPengeluaran,
                Tanggal_Pengeluaran = DateTime.Now,
                Total_Pengeluaran = totalPengeluaran
            };

            using var connection = new NpgsqlConnection(connectionString);

            var sql = @"INSERT INTO Pengeluarans (Nama_Pengeluaran, Tanggal_Pengeluaran, Total_Pengeluaran) 
                    VALUES (@Nama_Pengeluaran, @Tanggal_Pengeluaran, @Total_Pengeluaran) 
                    RETURNING ID_Pengeluaran";

            await connection.ExecuteScalarAsync<int>(sql, pengeluaran);

            // Reload data from database to ensure consistency
            await LoadFromDatabaseAsync();
        }

        public List<Pengeluaran> GetPengeluarans() => new List<Pengeluaran>(Pengeluarans);

        public async Task<decimal> GetTotalPengeluaran()
        {
            using var connection = new NpgsqlConnection(connectionString);

            var sql = "SELECT COALESCE(SUM(Total_Pengeluaran), 0) FROM Pengeluarans";
            return await connection.ExecuteScalarAsync<decimal>(sql);
        }
        private async Task LoadFromDatabaseAsync()
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var sql = @"SELECT ID_Pengeluaran, Nama_Pengeluaran, Tanggal_Pengeluaran, Total_Pengeluaran 
                        FROM Pengeluarans 
                        ORDER BY Tanggal_Pengeluaran DESC";

                Pengeluarans = (await connection.QueryAsync<Pengeluaran>(sql)).ToList();
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pengeluaran data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Pengeluaran
    {
        public int ID_Pengeluaran { get; set; }
        public required string Nama_Pengeluaran { get; set; }
        public DateTime Tanggal_Pengeluaran { get; set; }
        public decimal Total_Pengeluaran { get; set; }

        public Pengeluaran() { }

        public Pengeluaran(string namaPengeluaran, decimal totalPengeluaran)
        {
            Nama_Pengeluaran = namaPengeluaran;
            Tanggal_Pengeluaran = DateTime.Now;
            Total_Pengeluaran = totalPengeluaran;
        }
    }
}

 