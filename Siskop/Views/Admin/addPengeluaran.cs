using Models;
using System.Text;
using Dapper;
using Npgsql;

namespace Siskop.Views
{
    public partial class addPengeluaran : Form
    {
        private readonly PengeluaranModel _PengeluaranModel;
        private Pengeluaran _currentPengeluaran; // For update mode
        private bool _isUpdateMode = false;

        // Constructor for Add mode
        public addPengeluaran(PengeluaranModel pengeluaranModel, PinjamanModel pinjamanModel, int idPinjaman)
        {
            InitializeComponent();
            _pengeluaranModel = pengeluaranModel;
            _isUpdateMode = false;
            SetupForAddMode();
        }

        // Constructor for Update mode
        public addPengeluaran(PengeluaranModel pengeluaranModel, Pengeluaran pengeluaran)
        {
            InitializeComponent();
            _pengeluaranModel = pengeluaranModel;
            _currentPengeluaran = pengeluaran;
            _isUpdateMode = true;
            SetupForUpdateMode();
        }

        private void SetupForAddMode()
        {
            this.Text = "Tambah Pengeluaran";
            btSave.Text = "Simpan";

            // Clear fields
            tbJumlah.Text = "";
            tbNama.Text = "";
        }

        private void SetupForUpdateMode()
        {
            this.Text = "Update Pengeluaran";
            btSave.Text = "Update";

            // Fill fields with existing data
            if (_currentPengeluaran != null)
            {
                tbJumlah.Text = _currentPengeluaran.Jumlah_Pengeluaran.ToString("N0");
                tbNama.Text = _currentPengeluaran.Keterangan ?? "";
            }
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tbJumlah.Text))
                {
                    MessageBox.Show("Jumlah pengeluaran harus diisi!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (!decimal.TryParse(tbJumlah.Text.Replace(",", ""), out decimal jumlahAngsuran))
                {
                    MessageBox.Show("Jumlah pengeluaran harus berupa angka yang valid!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (jumlahAngsuran <= 0)
                {
                    MessageBox.Show("Jumlah pengeluaran harus lebih besar dari 0!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                // Disable buttons to prevent double-click
                btSave.Enabled = false;
                btCancel.Enabled = false;

                if (_isUpdateMode)
                {
                    // Update existing pengeluaran
                    await UpdatePengeluaran(jumlahAngsuran, tbNama.Text.Trim());
                    MessageBox.Show("Angsuran berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new pengeluaran
                    await _pengeluaranModel.AddAngsuran(jumlahPengeluaran, tbNama.Text.Trim());

                    MessageBox.Show("Angsuran berhasil ditambahkan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Close form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat {(_isUpdateMode ? "mengupdate" : "menambah")} pengeluaran: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable buttons
                btSave.Enabled = true;
                btCancel.Enabled = true;
            }
        }

        private async Task UpdatePengeluaran(decimal jumlahPengeluaran, string keterangan)
        {
            // Use the UpdateAngsuran method from AngsuranModel
            await _pengeluaranModel.UpdatePengeluaran(jumlahPengeluaran, keterangan);

            // If the pengeluaran amount changed, we need to adjust the loan balance
            decimal difference = jumlahAngsuran - _currentAngsuran.Jumlah_Angsuran;
            if (difference != 0)
            {
                await UpdateSaldoPinjamanForUpdate(difference);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Format currency input as user types
        private void tbJumlahAngsuran_TextChanged(object sender, EventArgs e)
        {
            // Remove event handler temporarily to prevent infinite loop
            tbJumlahPengeluaran.TextChanged -= tbJumlahAngsuran_TextChanged;

            // Get cursor position
            int cursorPos = tbJumlahPengeluaran.SelectionStart;

            // Remove non-numeric characters except decimal point
            string text = tbJumlahPengeluaran.Text;
            StringBuilder sb = new StringBuilder();
            bool hasDecimal = false;

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
                else if (c == '.' && !hasDecimal)
                {
                    sb.Append(c);
                    hasDecimal = true;
                }
            }

            // Update text
            string newText = sb.ToString();
            if (newText != text)
            {
                tbJumlah.Text = newText;
                tbJumlah.SelectionStart = Math.Min(cursorPos, newText.Length);
            }

            // Restore event handler
            tbJumlah.TextChanged += tbJumlahPengeluaran_TextChanged;
        }

        private void addAngsuran_Load(object sender, EventArgs e)
        {
            // Subscribe to text changed event for input formatting
            tbJumlah.TextChanged += tbJumlahAngsuran_TextChanged;

            // Focus on first input
            tbJumlah.Focus();
        }
    }
}