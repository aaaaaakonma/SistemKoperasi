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
using Siskop;

namespace Siskop.Views
{
    public partial class PinjamanControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly PinjamanModel _pinjamanModel;
        private readonly Nasabah _nasabah;
        private readonly KoperasiModel _koperasiModel;
        private readonly AngsuranModel _angsuranModel;
        private List<Pinjaman> filteredpinjaman; // Store filtered pinjaman data for specific nasabah
        private int _selectedPinjamanId = -1; // Track currently selected pinjaman

        public PinjamanControl(MainForm mainForm, PinjamanModel pinjamanModel, Nasabah nasabah, AngsuranModel angsuranModel, KoperasiModel koperasiModel)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _pinjamanModel = pinjamanModel;
            _nasabah = nasabah;
            _angsuranModel = angsuranModel;
            _koperasiModel = koperasiModel; // Store the koperasi model

            // Initialize the list
            filteredpinjaman = new List<Pinjaman>();

            // Subscribe to data changes
            _pinjamanModel.DataChanged += LoadPinjamanPanels;
            _angsuranModel.DataChanged += OnAngsuranDataChanged;

            // Initial load
            LoadPinjamanPanels();
        }

        private async void LoadPinjamanPanels()
        {
            try
            {
                // Get pinjaman list for specific nasabah only
                filteredpinjaman = await _pinjamanModel.GetPinjamansByNasabah(_nasabah.id_Nasabah);

                // Populate with filtered data
                PopulatepinjamanLayout(filteredpinjaman);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pinjaman panels: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to populate FlowLayout with pinjaman list
        private void PopulatepinjamanLayout(List<Pinjaman> pinjamanList)
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Suspend layout for better performance
            flowLayoutPanel1.SuspendLayout();

            try
            {
                foreach (var pinjaman in pinjamanList)
                {
                    var panel = new panelPinjaman(pinjaman)
                    {
                        Margin = new Padding(5),
                    };

                    // Subscribe to the panel click event
                    panel.PinjamanClicked += OnPinjamanPanelClicked;

                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            finally
            {
                // Resume layout
                flowLayoutPanel1.ResumeLayout(true);
            }
        }

        // Event handler for when a pinjaman panel is clicked
        private async void OnPinjamanPanelClicked(object sender, PinjamanClickedEventArgs e)
        {
            _selectedPinjamanId = e.PinjamanId;
            await LoadAngsuranForPinjaman(e.PinjamanId);
        }

        // Load angsuran data for the selected pinjaman
        private async Task LoadAngsuranForPinjaman(int pinjamanId)
        {
            try
            {
                var angsuranList = await _angsuranModel.GetPembayaranByPinjaman(pinjamanId);
                PopulateAngsuranLayout(angsuranList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading angsuran data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to populate the second FlowLayoutPanel with angsuran data
        private void PopulateAngsuranLayout(List<Angsuran> angsuranList)
        {
            // Clear existing controls
            flowLayoutPanel2.Controls.Clear();

            // Suspend layout for better performance
            flowLayoutPanel2.SuspendLayout();

            try
            {
                foreach (var angsuran in angsuranList)
                {
                    var panel = new panelAngsuran(angsuran)
                    {
                        Margin = new Padding(5),
                    };
                    flowLayoutPanel2.Controls.Add(panel);
                }

                // If no angsuran data, show a message
                if (angsuranList.Count == 0)
                {
                    var noDataLabel = new Label
                    {
                        Text = "Belum ada angsuran untuk pinjaman ini",
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    flowLayoutPanel2.Controls.Add(noDataLabel);
                }
            }
            finally
            {
                // Resume layout
                flowLayoutPanel2.ResumeLayout(true);
            }
        }

        // Event handler for when angsuran data changes
        private async void OnAngsuranDataChanged()
        {
            // Reload angsuran for currently selected pinjaman
            if (_selectedPinjamanId > 0)
            {
                await LoadAngsuranForPinjaman(_selectedPinjamanId);
            }
        }

        private void btAddNasabah_Click(object sender, EventArgs e)
        {
            try
            {
                if (_nasabah != null)
                {

                    _mainForm.ShowAddPinjamanForNasabah(_nasabah);
                }
                else
                {
                    MessageBox.Show("Nasabah information is missing. Cannot add pinjaman.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Pinjaman form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_mainForm.role == "admin")
            {
                _mainForm.ShowPage(_mainForm.adminNasabah);
            }
            else
            {
                _mainForm.ShowPage(_mainForm.NasabahDash);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a pinjaman is selected
                if (_selectedPinjamanId <= 0)
                {
                    MessageBox.Show("Silakan pilih pinjaman terlebih dahulu!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Find the selected pinjaman to get its current saldo
                var selectedPinjaman = filteredpinjaman.FirstOrDefault(p => p.id_Pinjaman == _selectedPinjamanId);
                if (selectedPinjaman == null)
                {
                    MessageBox.Show("Pinjaman yang dipilih tidak ditemukan!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create and show the add angsuran form
                using (var addAngsuranForm = new Siskop.Views.Karyawan_views.addAngsuran(
                    _angsuranModel,
                    _pinjamanModel,
                    _koperasiModel, // Use the stored koperasi model
                    _selectedPinjamanId,
                    selectedPinjaman.Saldo_pinjaman))
                {
                    var result = addAngsuranForm.ShowDialog(this);

                    if (result == DialogResult.OK)
                    {
                        // Refresh the pinjaman panels to show updated saldo
                        LoadPinjamanPanels();

                        // Refresh angsuran list for the selected pinjaman
                        await LoadAngsuranForPinjaman(_selectedPinjamanId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Angsuran form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    // Event args for pinjaman click
    public class PinjamanClickedEventArgs : EventArgs
    {
        public int PinjamanId { get; set; }
        public string PinjamanKeterangan { get; set; }
        public decimal SaldoPinjaman { get; set; }

        public PinjamanClickedEventArgs(int pinjamanId, string keterangan, decimal saldoPinjaman)
        {
            PinjamanId = pinjamanId;
            PinjamanKeterangan = keterangan;
            SaldoPinjaman = saldoPinjaman;
        }
    }
}