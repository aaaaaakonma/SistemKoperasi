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
        private readonly MainForm _mainForm;
        private readonly Action _onSaveCallback;

        public AddNasabah(NasabahModel nasabahModel, MainForm x, Action onSaveCallback = null)
        {
            InitializeComponent();
            _mainForm =  x;
            _nasabahModel = nasabahModel;
            _onSaveCallback = onSaveCallback;

            // Ensure proper layout
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Size = new Size(1366, 768);

            // Ensure all controls are properly visible
            EnsureControlsVisible();
        }

        private void EnsureControlsVisible()
        {
            // Make sure all controls are visible and properly positioned
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }

            // Force layout
            this.PerformLayout();
            this.Invalidate();
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

            // Ensure layout is correct
            EnsureControlsVisible();
        }

        // Override SetVisibleCore to ensure proper visibility
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
            if (value && this.IsHandleCreated)
            {
                EnsureControlsVisible();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
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
                _nasabahModel.AddNasabah(
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.NasabahDash);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}