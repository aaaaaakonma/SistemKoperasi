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
    public partial class NasabahDetails : UserControl
    {
        private readonly NasabahModel _nasabahModel;
        private Nasabah _currentNasabah;

        public NasabahDetails()
        {
            InitializeComponent();
        }

        public NasabahDetails(NasabahModel nasabahModel, Nasabah nasabah) : this()
        {
            _nasabahModel = nasabahModel;
            _currentNasabah = nasabah;
            PopulateFields();
        }

        private void PopulateFields()
        {
            if (_currentNasabah == null) return;

            tbNIK.Text = _currentNasabah.NIK ?? "";
            tbNama.Text = _currentNasabah.Nama ?? "";
            tbTTL.Text = _currentNasabah.TTL ?? "";
            tbAlamat.Text = _currentNasabah.Alamat ?? "";
            tbRTRW.Text = _currentNasabah.RT_RW ?? "";
            tbKelurahan.Text = _currentNasabah.Kelurahan ?? "";
            tbPekerjaan.Text = _currentNasabah.Pekerjaan ?? "";
            tbAgama.Text = _currentNasabah.Agama ?? "";
        }

        public async Task<bool> SaveNasabah()
        {
            if (_nasabahModel == null) return false;

            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tbNama.Text))
                {
                    MessageBox.Show("Nama is required", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNama.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(tbAlamat.Text))
                {
                    MessageBox.Show("Alamat is required", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbAlamat.Focus();
                    return false;
                }

                // Update existing nasabah
                await _nasabahModel.UpdateNasabah(
                    _currentNasabah.id_Nasabah,
                    tbNIK.Text.Trim(),
                    tbNama.Text.Trim(),
                    tbTTL.Text.Trim(),
                    tbAlamat.Text.Trim(),
                    tbRTRW.Text.Trim(),
                    tbKelurahan.Text.Trim(),
                    tbPekerjaan.Text.Trim(),
                    tbAgama.Text.Trim()
                );

                MessageBox.Show("Nasabah updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving nasabah: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // Disable save button to prevent double submission
            btnSave.Enabled = false;
            btnSave.Text = "Saving...";

            try
            {
                var success = await SaveNasabah();
                if (success)
                {
                    // Navigate back or close the form
                    // You can add navigation logic here
                }
            }
            finally
            {
                // Re-enable save button
                btnSave.Enabled = true;
                btnSave.Text = "Save";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
                "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Navigate back or close the form
                // You can add navigation logic here
            }
        }

        private void NasabahDetails_Load(object sender, EventArgs e)
        {
            // Focus on first field
            tbNIK.Focus();
        }
    }
}