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
    public partial class AddNasabah : UserControl
    {
        private readonly NasabahModel _nasabahModel;
        private readonly Action _onSaveCallback;

        public AddNasabah(NasabahModel nasabahModel, Action onSaveCallback = null)
        {
            InitializeComponent();
            _nasabahModel = nasabahModel;
            _onSaveCallback = onSaveCallback;

            // Wire up button events
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(tbNama.Text))
                {
                    MessageBox.Show("Nama is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNama.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbAlamat.Text))
                {
                    MessageBox.Show("Alamat is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbAlamat.Focus();
                    return;
                }

                // Disable save button to prevent double submission
                btnSave.Enabled = false;
                btnSave.Text = "Saving...";

                // Add nasabah to database
                await _nasabahModel.AddNasabah(
                    tbNIK.Text.Trim(),
                    tbNama.Text.Trim(),
                    tbTTL.Text.Trim(),
                    tbAlamat.Text.Trim(),
                    tbRTRW.Text.Trim(),
                    tbKelurahan.Text.Trim(),
                    tbPekerjaan.Text.Trim(),
                    tbAgama.Text.Trim()
                );

                MessageBox.Show("Nasabah added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form
                ClearForm();

                // Invoke callback if provided (to navigate back or refresh parent)
                _onSaveCallback?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving nasabah: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Navigate back to nasabah dashboard
            _onSaveCallback?.Invoke();
        }

        private void ClearForm()
        {
            tbNIK.Clear();
            tbNama.Clear();
            tbTTL.Clear();
            tbAlamat.Clear();
            tbRTRW.Clear();
            tbKelurahan.Clear();
            tbPekerjaan.Clear();
            tbAgama.Clear();
        }

        private void AddNasabah_Load(object sender, EventArgs e)
        {
            // Focus on first field
            tbNIK.Focus();
        }
    }
}