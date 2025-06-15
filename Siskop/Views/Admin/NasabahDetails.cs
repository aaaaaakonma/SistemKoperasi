using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siskop.Views.Admin
{
    public partial class NasabahDetails: UserControl
    {
        //private async void ButtonDeleteKaryawan_Click(object sender, EventArgs e)
        //{
        //    if (_selectedKaryawan == null) return;

        //    var result = MessageBox.Show(
        //        $"Are you sure you want to delete {_selectedKaryawan.Nama_Karyawan}?",
        //        "Confirm Delete",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question);

        //    if (result == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            await _karyawanModel.RemoveKaryawan(_selectedKaryawan.ID_Karyawan);
        //            MessageBox.Show("Karyawan deleted successfully!", "Success",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            ClearDetailsForm();
        //            if (panelKaryawanDetails != null)
        //                panelKaryawanDetails.Visible = false;

        //            _selectedKaryawan = null;
        //            _isEditMode = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error deleting karyawan: {ex.Message}", "Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private async void ButtonSaveKaryawan_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Validation
        //        if (string.IsNullOrWhiteSpace(textBoxNama?.Text))
        //        {
        //            MessageBox.Show("Nama is required", "Validation Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (string.IsNullOrWhiteSpace(textBoxJabatan?.Text))
        //        {
        //            MessageBox.Show("Jabatan is required", "Validation Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (comboBoxJenisKelamin?.SelectedItem == null)
        //        {
        //            MessageBox.Show("Jenis Kelamin is required", "Validation Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (_isEditMode && _selectedKaryawan != null)
        //        {
        //            // Update existing karyawan
        //            await _karyawanModel.UpdateKaryawan(
        //                _selectedKaryawan.ID_Karyawan,
        //                textBoxNama.Text.Trim(),
        //                textBoxJabatan.Text.Trim(),
        //                dateTimePickerTanggalLahir.Value,
        //                textBoxAlamat?.Text?.Trim() ?? "",
        //                comboBoxJenisKelamin.SelectedItem.ToString(),
        //                textBoxKontak?.Text?.Trim() ?? "",
        //                dateTimePickerKaryawanSejak.Value,
        //                checkBoxAvailable.Checked,
        //                textBoxUsername?.Text?.Trim(),
        //                textBoxPassword?.Text?.Trim(),
        //                comboBoxRole?.SelectedItem?.ToString() ?? "Karyawan"
        //            );

        //            MessageBox.Show("Karyawan updated successfully!", "Success",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            // Add new karyawan
        //            await _karyawanModel.AddKaryawan(
        //                textBoxNama.Text.Trim(),
        //                textBoxJabatan.Text.Trim(),
        //                dateTimePickerTanggalLahir.Value,
        //                textBoxAlamat?.Text?.Trim() ?? "",
        //                comboBoxJenisKelamin.SelectedItem.ToString(),
        //                textBoxKontak?.Text?.Trim() ?? "",
        //                dateTimePickerKaryawanSejak.Value,
        //                checkBoxAvailable.Checked,
        //                textBoxUsername?.Text?.Trim(),
        //                textBoxPassword?.Text?.Trim(),
        //                comboBoxRole?.SelectedItem?.ToString() ?? "Karyawan"
        //            );

        //            MessageBox.Show("Karyawan added successfully!", "Success",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        ClearDetailsForm();
        //        if (panelKaryawanDetails != null)
        //            panelKaryawanDetails.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error saving karyawan: {ex.Message}", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void ButtonAddKaryawan_Click(object sender, EventArgs e)
        //{
        //    ClearDetailsForm();
        //    _selectedKaryawan = null;
        //    _isEditMode = false;

        //    if (panelKaryawanDetails != null)
        //        panelKaryawanDetails.Visible = true;

        //    // Set default values
        //    if (dateTimePickerTanggalLahir != null)
        //        dateTimePickerTanggalLahir.Value = DateTime.Now.AddYears(-25);

        //    if (dateTimePickerKaryawanSejak != null)
        //        dateTimePickerKaryawanSejak.Value = DateTime.Now;

        //    if (checkBoxAvailable != null)
        //        checkBoxAvailable.Checked = true;

        //    if (comboBoxRole != null)
        //        comboBoxRole.SelectedItem = "Karyawan";

        //    UpdateButtonStates();
        //}
        public NasabahDetails()
        {
            InitializeComponent();
        }
    }
}
