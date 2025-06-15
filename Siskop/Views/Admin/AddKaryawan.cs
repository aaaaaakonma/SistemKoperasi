using System;
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
    public partial class AddKaryawan : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly KaryawanModel _karyawanModel;
        private Karyawan _currentKaryawan;
        private bool _isEditMode = false;

        public AddKaryawan()
        {
            InitializeComponent();
            InitializeGenderComboBox();
            InitializeRolerComboBox();

        }

        public AddKaryawan(KaryawanModel x) : this()
        {
            _karyawanModel = x;
        }

        private void InitializeGenderComboBox()
        {
            cbKelamin.Items.Clear();
            cbKelamin.Items.Add("Laki-laki");
            cbKelamin.Items.Add("Perempuan");
        }
        private void InitializeRolerComboBox()
        {
            cbRole.Items.Clear();
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Perempuan");
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

                else
                {
                    // Update existing karyawan
                    await _karyawanModel.AddKaryawan(
                        tbNama.Text.Trim(),
                        tbjabatan.Text.Trim(),
                        dtpTanggalLahir.Value,
                        tbAlamat.Text.Trim(),
                        cbKelamin.Text,
                        tbKontak.Text.Trim(),
                        tbUsername.Text.Trim(),
                        tbPassword.Text.Trim(),
                        cbRole.Text

                    );

                    MessageBox.Show("Karyawan updated successfully!", "Success",
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
                _mainForm.ShowPage(_mainForm.adminKaryawan);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddKaryawan_Load(object sender, EventArgs e)
        {

        }
    }
}