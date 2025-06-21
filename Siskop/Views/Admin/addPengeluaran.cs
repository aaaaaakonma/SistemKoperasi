using Models;
using System.Text;

namespace Siskop.Views
{
    public partial class addPengeluaran : Form
    {
        private readonly PengeluaranModel _pengeluaranModel;

        public addPengeluaran(PengeluaranModel PengeluaranModel)
        {
            InitializeComponent();
            _pengeluaranModel = PengeluaranModel;
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tbNama.Text))
                {
                    MessageBox.Show("Nama pengeluaran harus diisi!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNama.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbJumlah.Text))
                {
                    MessageBox.Show("Jumlah pengeluaran harus diisi!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (!decimal.TryParse(tbJumlah.Text, out decimal jumlahPengeluaran))
                {
                    MessageBox.Show("Jumlah pengeluaran harus berupa angka yang valid!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (jumlahPengeluaran <= 0)
                {
                    MessageBox.Show("Jumlah pengeluaran harus lebih besar dari 0!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                // Disable buttons to prevent double-click
                btSave.Enabled = false;
                btCancel.Enabled = false;

                // Add pengeluaran to database
                await _pengeluaranModel.AddPengeluaran(tbNama.Text.Trim(), jumlahPengeluaran);

                MessageBox.Show("Pengeluaran berhasil ditambahkan!", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat menambah pengeluaran: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable buttons
                btSave.Enabled = true;
                btCancel.Enabled = true;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        // Format currency input as user types
        private void tbJumlah_TextChanged(object sender, EventArgs e)
        {
            // Remove event handler temporarily to prevent infinite loop
            tbJumlah.TextChanged -= tbJumlah_TextChanged;

            // Get cursor position
            int cursorPos = tbJumlah.SelectionStart;

            // Remove non-numeric characters except decimal point
            string text = tbJumlah.Text;
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
            tbJumlah.TextChanged += tbJumlah_TextChanged;
        }

        private void addPengeluaran_Load(object sender, EventArgs e)
        {
            // Subscribe to text changed event for input formatting
            tbJumlah.TextChanged += tbJumlah_TextChanged;

            // Focus on first input
            tbNama.Focus();
        }
    }
}