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
    public partial class AdminKaryawan : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly KaryawanModel _karyawanModel;
        private List<Karyawan> allKaryawan;

        // Controls that need to be created in designer
        private FlowLayoutPanel flowLayoutPanelKaryawan;
        private TextBox textBoxSearch;
        private Label labelTotalKaryawan;
        private Label labelActiveKaryawan;
       
        public AdminKaryawan(string connectionString)
        {
            InitializeComponent();

            _karyawanModel = new KaryawanModel(connectionString);
            allKaryawan = new List<Karyawan>();

            // Subscribe to data changes
            _karyawanModel.DataChanged += LoadKaryawanData;

            // Initial load
            LoadKaryawanData();
        }

        private void LoadKaryawanData()
        {
            try
            {
                allKaryawan = _karyawanModel.GetAllKaryawan();
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
            if (flowLayoutPanelKaryawan == null) return;

            flowLayoutPanelKaryawan.Controls.Clear();
            flowLayoutPanelKaryawan.SuspendLayout();

            try
            {
                foreach (var karyawan in karyawanList)
                {
                    var panel = new panelKaryawan(_mainForm, karyawan)
                    {
                        Margin = new Padding(5),
                    };
                    flowLayoutPanelKaryawan.Controls.Add(panel);
                }
            }
            finally
            {
                flowLayoutPanelKaryawan.ResumeLayout(true);
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


        // Event Handlers
        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchKaryawan(textBoxSearch.Text);
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadKaryawanData();
        }


       


        private void SearchKaryawan(string searchQuery)
        {
            try
            {
                var filteredKaryawan = _karyawanModel.SearchKaryawan(searchQuery);
                PopulateKaryawanLayout(filteredKaryawan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching karyawan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
