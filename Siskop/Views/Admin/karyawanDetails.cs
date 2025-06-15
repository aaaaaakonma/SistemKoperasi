using System;
// Replace the existing karyawanDetails.cs content with this:

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siskop.Models;
using Models;

namespace Siskop.Views
{
    public partial class karyawanDetails : UserControl
    {
        private readonly KaryawanModel _karyawanModel;
        private Karyawan _currentKaryawan;
        private bool _isEditMode = false;

        public karyawanDetails()
        {
            InitializeComponent();
            InitializeGenderComboBox();
        }

        public karyawanDetails(KaryawanModel x) : this()
        {
            _karyawanModel = x;
        }

        private void InitializeGenderComboBox()
        {
            cbKelamin.Items.Clear();
            cbKelamin.Items.Add("Laki-laki");
            cbKelamin.Items.Add("Perempuan");
        }

        public void LoadKaryawanForEdit(int karyawanId)
        {
            if (_karyawanModel == null) return;

            _currentKaryawan = _karyawanModel.GetKaryawanById(karyawanId);
            if (_currentKaryawan != null)
            {
                _isEditMode = true;
                PopulateFields();
            }
        }

        public void SetupForNewKaryawan()
        {
            _currentKaryawan = null;
            _isEditMode = false;
            ClearFields();
            SetDefaultValues();
        }

        private void PopulateFields()
        {
            if (_currentKaryawan == null) return;

            tbNama.Text = _currentKaryawan.Nama_Karyawan ?? "";
            tbjabatan.Text = _currentKaryawan.Jabatan ?? "";
            tbAlamat.Text = _currentKaryawan.Alamat ?? "";
            tbKontak.Text = _currentKaryawan.Kontak ?? "";
            dtpTanggalLahir.Value = _currentKaryawan.Tanggal_Lahir;
            cbKelamin.Text = _currentKaryawan.Jenis_Kelamin ?? "";
        }

        private void ClearFields()
        {
            tbNama.Clear();
            tbjabatan.Clear();
            tbAlamat.Clear();
            tbKontak.Clear();
            cbKelamin.SelectedIndex = -1;
        }

        private void SetDefaultValues()
        {
            dtpTanggalLahir.Value = DateTime.Now.AddYears(-25);
        }

        public async Task<bool> SaveKaryawan()
        {
            if (_karyawanModel == null) return false;

            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tbNama.Text))
                {
                    MessageBox.Show("Nama is required", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(tbjabatan.Text))
                {
                    MessageBox.Show("Jabatan is required", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cbKelamin.SelectedIndex == -1)
                {
                    MessageBox.Show("Jenis Kelamin is required", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (_isEditMode && _currentKaryawan != null)
                {
                    // Update existing karyawan
                    await _karyawanModel.UpdateKaryawan(
                        _currentKaryawan.ID_Karyawan,
                        tbNama.Text.Trim(),
                        tbjabatan.Text.Trim(),
                        dtpTanggalLahir.Value,
                        tbAlamat.Text.Trim(),
                        cbKelamin.Text,
                        tbKontak.Text.Trim(),
                        _currentKaryawan.Karyawan_Sejak, // Keep original hire date
                        _currentKaryawan.Available, // Keep original status
                        _currentKaryawan.Username,
                        _currentKaryawan.Password,
                        _currentKaryawan.Role ?? "Karyawan"
                    );

                    MessageBox.Show("Karyawan updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new karyawan
                    await _karyawanModel.AddKaryawan(
                        tbNama.Text.Trim(),
                        tbjabatan.Text.Trim(),
                        dtpTanggalLahir.Value,
                        tbAlamat.Text.Trim(),
                        cbKelamin.Text,
                        tbKontak.Text.Trim(),
                        DateTime.Now, // Current date as hire date
                        true, // Available by default
                        null, // Username
                        null, // Password
                        "Karyawan" // Default role
                    );

                    MessageBox.Show("Karyawan added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving karyawan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle gender selection change if needed
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var success = await SaveKaryawan();
            if (success)
            {
                // Navigate back or close the form
                //NavigateBack();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
                "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //NavigateBack();
            }
        }
    }
}