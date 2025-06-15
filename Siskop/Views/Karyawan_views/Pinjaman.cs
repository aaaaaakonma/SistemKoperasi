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
        private readonly FlowLayoutPanel flowLayoutPanel;
        private readonly Nasabah _nasabah;
        private readonly AngsuranModel _angsuranModel;
        private List<Pinjaman> filteredpinjaman; // Store filtered pinjaman data for specific nasabah
        private int _nasabahId; // Store the specific nasabah ID

        public PinjamanControl(MainForm mainForm, PinjamanModel pinjamanModel, Nasabah nasabah, AngsuranModel angsuranModel)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _pinjamanModel = pinjamanModel; // Use the shared model instance
            _nasabahId = nasabah.id_Nasabah;
            _angsuranModel = angsuranModel;

            // Initialize the list
            filteredpinjaman = new List<Pinjaman>();

            // Subscribe to data changes
            _pinjamanModel.DataChanged += LoadPinjamanPanels;

            // Initial load
            LoadPinjamanPanels();
            _angsuranModel = angsuranModel;
        }

        private async void LoadPinjamanPanels()
        {
            try
            {
                // Get pinjaman list for specific nasabah only
                filteredpinjaman = await _pinjamanModel.GetPinjamansByNasabah(_nasabahId);

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
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            finally
            {
                // Resume layout
                flowLayoutPanel1.ResumeLayout(true);
            }
        }


        public int GetTotalpinjamanCount()
        {
            return filteredpinjaman?.Count ?? 0;
        }

        // Method to get total outstanding debt for this nasabah
        public async Task<decimal> GetTotalOutstandingDebt()
        {
            return await _pinjamanModel.GetTotalOutstandingDebt(_nasabahId);
        }

        // Method to get only active pinjamans for this nasabah
        public Pinjaman GetPinjamanById(int pinjamanId)
        {
            return filteredpinjaman?.FirstOrDefault(p => p.id_Pinjaman == pinjamanId);
        }

        private void btAddNasabah_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.addPinjaman);
        }


        // Cleanup on disposal
    }
}