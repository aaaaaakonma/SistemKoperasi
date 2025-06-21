using Models;
using System.Text;
using Dapper;
using Npgsql;

namespace Siskop.Views
{
    public partial class addPengeluaran : Form
    {

        {
            InitializeComponent();
        }

        {
        {
        {
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

                {
                    MessageBox.Show("Jumlah pengeluaran harus berupa angka yang valid!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                {
                    MessageBox.Show("Jumlah pengeluaran harus lebih besar dari 0!", "Validasi Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbJumlah.Focus();
                    return;
                }

                // Disable buttons to prevent double-click
                btSave.Enabled = false;
                btCancel.Enabled = false;


                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Close form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
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
        {
            // Remove event handler temporarily to prevent infinite loop

            // Get cursor position

            // Remove non-numeric characters except decimal point
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
        }

        {
            // Subscribe to text changed event for input formatting

            // Focus on first input
        }
    }
}