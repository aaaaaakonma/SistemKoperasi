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
        private readonly MainForm _mainForm;
        private Nasabah _currentNasabah;

        public NasabahDetails()
        {
            InitializeComponent();
        }

        public NasabahDetails(MainForm mainform, NasabahModel nasabahModel, Nasabah nasabah) : this()
        {
            _nasabahModel = nasabahModel;
            _mainForm = mainform;
            _currentNasabah = nasabah;
            PopulateFields();
        }

        private void PopulateFields()
        {
            if (_currentNasabah == null) return;

            tbNIK.Text = _currentNasabah.NIK ?? "";
            tbNama.Text = _currentNasabah.Nama ?? "";
            dateTimePicker1.Value = _currentNasabah.TTL;
            tbAlamat.Text = _currentNasabah.Alamat ?? "";
            tbRTRW.Text = _currentNasabah.RT_RW ?? "";
            tbKelurahan.Text = _currentNasabah.Kelurahan ?? "";
            tbPekerjaan.Text = _currentNasabah.Pekerjaan ?? "";
            tbAgama.Text = _currentNasabah.Agama ?? "";
        }

        public bool SaveNasabah()
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
                _nasabahModel.UpdateNasabah(
                    _currentNasabah.id_Nasabah,
                    tbNIK.Text.Trim(),
                    tbNama.Text.Trim(),
                    dateTimePicker1.Value,
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

        private void NasabahDetails_Load(object sender, EventArgs e)
        {
            tbNIK.Focus();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
            "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _mainForm.ShowPage(_mainForm.adminNasabah);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Text = "Saving...";

            try
            {
                var success = SaveNasabah();
                if (success)
                {
                    _mainForm.ShowPage(_mainForm.adminNasabah);
                }
            }
            finally
            {
                // Re-enable save button
                btnSave.Enabled = true;
                btnSave.Text = "Save";
            }

        }
    }
}
    
