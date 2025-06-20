using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Siskop.Views.Karyawan_views
{
    public partial class addAngsuran : Form
    {
        private readonly AngsuranModel _angsuranModel;
        private readonly PinjamanModel _pinjamanModel;
        private readonly int _pinjamanId;
        private readonly decimal _currentSaldo;

        public addAngsuran(AngsuranModel angsuranModel, PinjamanModel pinjamanModel, int pinjamanId, decimal currentSaldo)
        {
            InitializeComponent();
            _angsuranModel = angsuranModel;
            _pinjamanModel = pinjamanModel;
            _pinjamanId = pinjamanId;
            _currentSaldo = currentSaldo;

            // Set form title
            this.Text = $"Tambah Angsuran - Saldo: {_currentSaldo:C}";

            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tbJumlah.Text))
                {
                    MessageBox.Show("Jumlah angsuran harus diisi!", "Validasi Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (!decimal.TryParse(tbJumlah.Text, out decimal jumlahAngsuran))
                {
                    MessageBox.Show("Jumlah angsuran harus berupa angka yang valid!", "Validasi Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (jumlahAngsuran <= 0)
                {
                    MessageBox.Show("Jumlah angsuran harus lebih besar dari 0!", "Validasi Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                if (jumlahAngsuran > _currentSaldo)
                {
                    var result = MessageBox.Show(
                        $"Jumlah angsuran ({jumlahAngsuran:C}) melebihi saldo pinjaman ({_currentSaldo:C}).\n" +
                        "Apakah Anda yakin ingin melanjutkan?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                // Disable buttons to prevent double-click
                btSave.Enabled = false;
                btCancel.Enabled = false;
                // Add angsuran to database
                await _angsuranModel.AddAngsuran(_pinjamanId, jumlahAngsuran, tbKet.Text.Trim());

                // Calculate new saldo
                decimal newSaldo = Math.Max(0, _currentSaldo - jumlahAngsuran);

                // Update pinjaman saldo
                await _pinjamanModel.UpdateSaldoPinjaman(_pinjamanId, newSaldo);

                MessageBox.Show("Angsuran berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat menambah angsuran: {ex.Message}", "Error",
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

        // Override ProcessCmdKey to handle Enter and Escape keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btSave_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btCancel_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void addAngsuran_Load(object sender, EventArgs e)
        {
            // Subscribe to text changed event for input formatting
            tbJumlah.TextChanged += tbJumlah_TextChanged;

            // Focus on first input
            tbJumlah.Focus();
        }
    }
}