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
    public partial class AdminNasabah : UserControl
    {
        private MainForm _mainForm;
        private NasabahModel _nasabahModel;
        private List<Nasabah> allNasabah; // Store all nasabah data for searching

        public AdminNasabah()
        {
            InitializeComponent();
        }

        // Constructor with dependencies - call this after InitializeComponent
        public AdminNasabah(MainForm mainForm, NasabahModel nasabahModel)
        {
            _mainForm = mainForm;
            _nasabahModel = nasabahModel;

            // Initialize the list
            allNasabah = new List<Nasabah>();

            // Subscribe to data changes BEFORE initializing the model
            _nasabahModel.DataChanged += LoadNasabahPanels;
            InitializeComponent();

        }


        public void LoadNasabahPanels()
        {
            try
            {
                // Ensure we're on the UI thread
                if (InvokeRequired)
                {
                    Invoke(new Action(LoadNasabahPanels));
                    return;
                }

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
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.SuspendLayout();

            try
            {
                foreach (var nasabah in nasabahList)
                {
                    var panel = new panelNasabahAdmin(_mainForm, nasabah)
                    {
                        Margin = new Padding(5),
                    };
                    flowLayoutPanel2.Controls.Add(panel);
                }
            }
            finally
            {
                // Resume layout
                flowLayoutPanel2.ResumeLayout(true);
            }
        }

        // Search method - call this from your search textbox TextChanged event
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
                    // Filter nasabah based on search query (ID, NIK, Name)
                    var filteredNasabah = allNasabah
                        .Where(n =>
                            n.id_Nasabah.ToString().Contains(query) ||
                            (n.NIK?.ToLower().Contains(query) ?? false) ||
                            (n.Nama?.ToLower().Contains(query) ?? false))
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
            if (textBox1 != null)
            {
                textBox1.Text = string.Empty;
            }
            PopulateNasabahLayout(allNasabah);
        }

        // Method to refresh the panels manually if needed
        public void RefreshPanels()
        {
            LoadNasabahPanels();
        }

        // Event handlers


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshPanels();
        }

        private void btAddNasabah_Click(object sender, EventArgs e)
        {
            // Navigate to add nasabah page (adjust based on your MainForm structure)
            if (_mainForm != null)
            {
                _mainForm.ShowPage(_mainForm.addNasabah);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _mainForm.SetRole("");
            _mainForm.ShowPage(_mainForm.login);
        }

        private void btKaryawan_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.adminKaryawan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(_mainForm.adminPengeluaran);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                SearchNasabah(textBox.Text);
            }
        }
    }

}