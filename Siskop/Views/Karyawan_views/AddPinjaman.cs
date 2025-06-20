using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Siskop.Views
{
    public partial class AddPinjaman : UserControl
    {
        private readonly PinjamanModel _pinjamanModel;
        private readonly MainForm _mainForm;
        private readonly Nasabah _nasabah;
        private int _selectedNasabahId;

        public AddPinjaman(MainForm mainForm, PinjamanModel pinjamanModel, Nasabah nasabah)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _pinjamanModel = pinjamanModel;
            _nasabah = nasabah;

            InitializeFormLabels();
            SetupEventHandlers();
            LoadNasabahOptions();
        }

        private void InitializeFormLabels()
        {
            // Update labels to match the pinjaman fields
            label7.Text = "Jumlah Pinjaman";
            label1.Text = "Keterangan";
            label2.Text = "Bunga (%)";
            label3.Text = "Durasi (bulan)";

            // Add placeholder text
            tbNiK.PlaceholderText = "Masukkan jumlah pinjaman...";
            textBox1.PlaceholderText = "Masukkan keterangan pinjaman...";
            textBox3.PlaceholderText = "Masukkan bunga (%)...";
            textBox2.PlaceholderText = "Masukkan durasi dalam bulan...";
        }

        private void SetupEventHandlers()
        {
            // Add validation events
            tbNiK.KeyPress += NumericTextBox_KeyPress;
            textBox3.KeyPress += DecimalTextBox_KeyPress;
            textBox2.KeyPress += NumericTextBox_KeyPress;
        }

        private async void LoadNasabahOptions()
        {
            try
            {
                // If you have a ComboBox for selecting nasabah, populate it here
                // For now, we'll assume the nasabah ID is set externally
                // You might want to add a ComboBox to select from available nasabah
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading nasabah data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to set the nasabah ID externally
        public void SetNasabahId(Nasabah na)
        {
            _selectedNasabahId = na.id_Nasabah;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClearForm();
            // Navigate back or close the form
            _mainForm?.ShowPinjamanForNasabah(_nasabah);
        }

        private async Task SavePinjaman()
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                    return;

                // Parse input values
                decimal jumlahPinjaman = decimal.Parse(tbNiK.Text);
                string keterangan = textBox1.Text.Trim();
                decimal bunga = decimal.Parse(textBox3.Text);
                int durasi = int.Parse(textBox2.Text);

                // Validate nasabah ID
                if (_selectedNasabahId <= 0)
                {
                    MessageBox.Show("Please select a valid nasabah.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show confirmation dialog
                var result = MessageBox.Show(
                    $"Konfirmasi Penambahan Pinjaman:\n\n" +
                    $"Jumlah Pinjaman: Rp {jumlahPinjaman:N0}\n" +
                    $"Keterangan: {keterangan}\n" +
                    $"Bunga: {bunga}%\n" +
                    $"Durasi: {durasi} bulan\n" +
                    $"Total yang harus dibayar: Rp {CalculateTotalAmount(jumlahPinjaman, bunga, durasi):N0}\n\n" +
                    $"Apakah Anda yakin ingin menambahkan pinjaman ini?",
                    "Konfirmasi Pinjaman",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    _mainForm.ShowPinjamanForNasabah(_nasabah);
                    return;
                }



                // Disable form during save
                SetFormEnabled(false);

                // Add pinjaman to database
                await _pinjamanModel.AddPinjaman(_selectedNasabahId, jumlahPinjaman,
                    keterangan, bunga, durasi);

                MessageBox.Show("Pinjaman berhasil ditambahkan!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form after successful save
                ClearForm();

                // Navigate back or refresh the parent view
                _mainForm.ShowPinjamanForNasabah(_nasabah);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving pinjaman: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetFormEnabled(true);
            }
        }

        private bool ValidateInputs()
        {
            // Validate jumlah pinjaman
            if (string.IsNullOrWhiteSpace(tbNiK.Text) || !decimal.TryParse(tbNiK.Text, out decimal jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Jumlah pinjaman harus berupa angka yang valid dan lebih besar dari 0.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNiK.Focus();
                return false;
            }

            // Validate keterangan (optional but should not be just whitespace)
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Pinjaman Umum"; // Default value
            }

            // Validate bunga
            if (string.IsNullOrWhiteSpace(textBox3.Text) || !decimal.TryParse(textBox3.Text, out decimal bunga) || bunga < 0 || bunga > 100)
            {
                MessageBox.Show("Bunga harus berupa angka antara 0 dan 100.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            // Validate durasi
            if (string.IsNullOrWhiteSpace(textBox2.Text) || !int.TryParse(textBox2.Text, out int durasi) || durasi <= 0 || durasi > 120)
            {
                MessageBox.Show("Durasi harus berupa angka antara 1 dan 120 bulan.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            return true;
        }

        private decimal CalculateTotalAmount(decimal principal, decimal interestRate, int durationMonths)
        {
            return principal * (1 + (interestRate / 100m) * durationMonths);
        }

        private void ClearForm()
        {
            tbNiK.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
            _selectedNasabahId = 0;
        }

        private void SetFormEnabled(bool enabled)
        {
            tbNiK.Enabled = enabled;
            textBox1.Enabled = enabled;
            textBox2.Enabled = enabled;
            textBox3.Enabled = enabled;
            button1.Enabled = enabled;
            button2.Enabled = enabled;
        }

        // Event handlers for input validation
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }

        private void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, delete, and decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            _mainForm.ShowPinjamanForNasabah(_nasabah);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SavePinjaman();
        }
    }
}