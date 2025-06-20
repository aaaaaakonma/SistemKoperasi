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
    public partial class AdminPengeluaran : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly KaryawanModel _karyawanModel;
        private List<Karyawan> allKaryawan;

        // Controls that need to be created in designer
        private TextBox textBoxSearch;
        private Label labelTotalKaryawan;
        private Label labelActiveKaryawan;

        public AdminPengeluaran(MainForm main, KaryawanModel karyawan)
        {
            _karyawanModel = karyawan;
            _mainForm = main;
            InitializeComponent();
            // Subscribe to data changes
            _karyawanModel.DataChanged += LoadKaryawanData;

            // Initial load
            LoadKaryawanData();
        }

        private void LoadKaryawanData()
        {
            try
            {
                allKaryawan = _karyawanModel.GetKaryawans();
                PopulateKaryawanLayout(allKaryawan);
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading karyawan data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateKaryawanLayout(List<Karyawan> karyawanList)
        {
            if (flowLayoutPanel2 == null) return;

            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.SuspendLayout();

            try
            {
                foreach (var karyawan in karyawanList)
                {
                    var panel = new panelKaryawan(_mainForm, karyawan)
                    {
                        Margin = new Padding(3),
                    };
                    flowLayoutPanel2.Controls.Add(panel);
                }
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout(true);
            }
        }

        private void UpdateStatistics()
        {
            if (labelTotalKaryawan != null)
                labelTotalKaryawan.Text = $"Total Karyawan: {allKaryawan.Count}";

            if (labelActiveKaryawan != null)
            {
                var activeCount = allKaryawan.Count(k => k.Available);
                labelActiveKaryawan.Text = $"Active: {activeCount}";
            }
        }

        // Local search method that filters from allKaryawan list
        private List<Karyawan> FilterKaryawan(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return allKaryawan;

            searchQuery = searchQuery.ToLower();
            return allKaryawan.Where(k =>
                k.Nama_Karyawan.ToLower().Contains(searchQuery) ||
                k.Jabatan.ToLower().Contains(searchQuery) ||
                k.Alamat.ToLower().Contains(searchQuery) ||
                k.Role.ToLower().Contains(searchQuery) ||
                k.Kontak.ToLower().Contains(searchQuery)
            ).ToList();
        }

        private void SearchKaryawan(string searchQuery)
        {
            try
            {
                var filteredKaryawan = FilterKaryawan(searchQuery);
                PopulateKaryawanLayout(filteredKaryawan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching karyawan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event Handlers
        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchKaryawan(textBoxSearch.Text);
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadKaryawanData();
        }

        // Public methods for external access
        public void RefreshData()
        {
            LoadKaryawanData();
        }

        public int GetTotalKaryawanCount()
        {
            return allKaryawan?.Count ?? 0;
        }

        public int GetActiveKaryawanCount()
        {
            return allKaryawan?.Count(k => k.Available) ?? 0;
        }

        public List<Karyawan> GetActiveKaryawan()
        {
            return _karyawanModel.GetActiveKaryawan();
        }

        // Method to show only active karyawan
        public void ShowActiveOnly()
        {
            var activeKaryawan = allKaryawan.Where(k => k.Available).ToList();
            PopulateKaryawanLayout(activeKaryawan);
        }

        // Method to show all karyawan
        public void ShowAll()
        {
            PopulateKaryawanLayout(allKaryawan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.addKaryawan);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            _mainForm.SetRole("");
            _mainForm.ShowPage(_mainForm.login);

        }

        private void btNasabah_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.adminNasabah);
        }

        private void btKaryawan_Click(object sender, EventArgs e)
        {

        }
    }
}