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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Siskop.Views
{
    public partial class UserControl1 : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly NasabahModel _nasabahModel;
        private readonly FlowLayoutPanel flowLayoutPanel;
        private List<Nasabah> allNasabah; // Store all nasabah data for searching

        public UserControl1(MainForm mainForm, NasabahModel nasabahModel)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _nasabahModel = nasabahModel; // Use the shared model instance

            // Initialize the list
            allNasabah = new List<Nasabah>();

            // Subscribe to data changes
            _nasabahModel.DataChanged += LoadNasabahPanels;

            // Initial load
            LoadNasabahPanels();
        }

        public void LoadNasabahPanels()
        {
            try
            {
                // Get current nasabah list and store it
                allNasabah = _nasabahModel.GetNasabahs();

                // Populate with all data
                PopulateNasabahLayout(allNasabah);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading nasabah panels: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to populate FlowLayout with nasabah list
        private void PopulateNasabahLayout(List<Nasabah> nasabahList)
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Suspend layout for better performance
            flowLayoutPanel1.SuspendLayout();

            try
            {
                foreach (var nasabah in nasabahList)
                {
                    var panel = new panelNasabah(_mainForm, nasabah)
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

        //Search method - call this from your search textbox TextChanged event
        public void SearchNasabah(string searchQuery)
        {
            try
            {
                string query = searchQuery?.Trim().ToLower() ?? string.Empty;

                if (string.IsNullOrEmpty(query))
                {
                    // Show all nasabah if search is empty
                    PopulateNasabahLayout(allNasabah);
                }
                else
                {
                    // Filter nasabah based on search query (Id only)
                    var filteredNasabah = allNasabah
                        .Where(n => n.id_Nasabah.ToString().Contains(query))
                        .ToList();

                    PopulateNasabahLayout(filteredNasabah);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching nasabah: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to clear search and show all
        public void ClearSearch()
        {
            PopulateNasabahLayout(allNasabah);
        }

        // Method to refresh the panels manually if needed
        public void RefreshPanels()
        {
            LoadNasabahPanels();
        }

        // Method to get current nasabah count (useful for status display)
        public int GetCurrentNasabahCount()
        {
            return flowLayoutPanel1.Controls.Count;
        }

        // Method to get total nasabah count
        public int GetTotalNasabahCount()
        {
            return allNasabah?.Count ?? 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchNasabah(textBox1.Text);
        }

        private void btAddNasabah_Click_1(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.addNasabah);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        // Cleanup on disposal
    }
}