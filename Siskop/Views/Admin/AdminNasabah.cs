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
        private readonly MainForm _mainForm;
        private readonly NasabahModel _nasabahModel;
        private List<Nasabah> allNasabah; // Store all nasabah data for searching
        private TextBox searchTextBox; // Search textbox
        private Button addButton; // Add nasabah button

        public AdminNasabah()
        {
            InitializeComponent();
        }

        // Constructor with dependencies - call this after InitializeComponent
        public void Initialize(MainForm mainForm, NasabahModel nasabahModel)
        {
            _mainForm = mainForm;
            _nasabahModel = nasabahModel;

            // Initialize the list
            allNasabah = new List<Nasabah>();

            // Subscribe to data changes
            _nasabahModel.DataChanged += LoadNasabahPanels;

            // Add search and add controls
            AddSearchControls();
            AddActionButtons();

            // Initial load
            LoadNasabahPanels();
        }

        // Alternative constructor with parameters (if you prefer this approach)
        public AdminNasabah(MainForm mainForm, NasabahModel nasabahModel) : this()
        {
            Initialize(mainForm, nasabahModel);
        }

        private void AddSearchControls()
        {
            // Create search textbox
            searchTextBox = new TextBox()
            {
                Location = new Point(320, 115),
                Size = new Size(200, 23),
                PlaceholderText = "Search by ID...",
                Font = new Font("Segoe UI", 9F)
            };
            searchTextBox.TextChanged += SearchTextBox_TextChanged;

            // Add search label
            var searchLabel = new Label()
            {
                Text = "Search:",
                Location = new Point(320, 95),
                Size = new Size(50, 15),
                Font = new Font("Segoe UI", 9F)
            };

            this.Controls.Add(searchLabel);
            this.Controls.Add(searchTextBox);
        }

        private void AddActionButtons()
        {
            // Create add button
            addButton = new Button()
            {
                Text = "Add Nasabah",
                Location = new Point(540, 113),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(0, 122, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddButton_Click;

            // Create refresh button
            var refreshButton = new Button()
            {
                Text = "Refresh",
                Location = new Point(650, 113),
                Size = new Size(70, 25),
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.Click += RefreshButton_Click;

            this.Controls.Add(addButton);
            this.Controls.Add(refreshButton);
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
            flowLayoutPanel2.Controls.Clear();

            // Suspend layout for better performance
            flowLayoutPanel2.SuspendLayout();

            try
            {
                foreach (var nasabah in nasabahList)
                {
                    var panel = new panelNasabah(_mainForm, nasabah)
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
            if (searchTextBox != null)
            {
                searchTextBox.Text = string.Empty;
            }
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
            return flowLayoutPanel2.Controls.Count;
        }

        // Method to get total nasabah count
        public int GetTotalNasabahCount()
        {
            return allNasabah?.Count ?? 0;
        }

        // Event handlers
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                SearchNasabah(textBox.Text);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Navigate to add nasabah page (adjust based on your MainForm structure)
            if (_mainForm != null)
            {
                // Assuming MainForm has an addNasabah page similar to the original code
                _mainForm.ShowPage(_mainForm.addNasabah);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshPanels();
        }

        // Override Dispose to clean up event subscriptions
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Unsubscribe from events to prevent memory leaks
                if (_nasabahModel != null)
                {
                    _nasabahModel.DataChanged -= LoadNasabahPanels;
                }

                // Dispose components
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // Additional admin-specific methods can be added here

        // Method to get statistics for admin dashboard
        public Dictionary<string, int> GetNasabahStatistics()
        {
            var stats = new Dictionary<string, int>();

            if (allNasabah != null)
            {
                stats.Add("Total Nasabah", allNasabah.Count);

                // Group by religion if needed
                var agamaGroups = allNasabah
                    .Where(n => !string.IsNullOrEmpty(n.Agama))
                    .GroupBy(n => n.Agama)
                    .ToDictionary(g => $"Agama {g.Key}", g => g.Count());

                foreach (var kvp in agamaGroups)
                {
                    stats.Add(kvp.Key, kvp.Value);
                }

                // Group by kelurahan if needed
                var kelurahanGroups = allNasabah
                    .Where(n => !string.IsNullOrEmpty(n.Kelurahan))
                    .GroupBy(n => n.Kelurahan)
                    .Take(5) // Top 5 kelurahan
                    .ToDictionary(g => $"Kelurahan {g.Key}", g => g.Count());

                foreach (var kvp in kelurahanGroups)
                {
                    stats.Add(kvp.Key, kvp.Value);
                }
            }

            return stats;
        }

        // Method for admin to perform bulk operations (if needed)
        public async Task<bool> BulkDeleteNasabah(List<int> nasabahIds)
        {
            try
            {
                // Confirm bulk delete
                var result = MessageBox.Show(
                    $"Are you sure you want to delete {nasabahIds.Count} nasabah records? This action cannot be undone.",
                    "Confirm Bulk Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (var id in nasabahIds)
                    {
                        await _nasabahModel.DeleteNasabah(id);
                    }

                    MessageBox.Show($"Successfully deleted {nasabahIds.Count} nasabah records.",
                        "Bulk Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during bulk delete: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}