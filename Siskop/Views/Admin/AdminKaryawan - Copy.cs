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
    public partial class AdminPengeluaran : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly PengeluaranModel _pengeluaranModel;
        private List<Pengeluaran> allPengeluaran;

        // Controls that need to be created in designer
        private TextBox textBoxSearch;


        public AdminPengeluaran(MainForm main, PengeluaranModel pengeluaran)
        {
            _pengeluaranModel = pengeluaran;
            _mainForm = main;
            InitializeComponent();

            // Subscribe to data changes
            _pengeluaranModel.DataChanged += LoadPengeluaranData;

            // Initial load
            LoadPengeluaranData();
        }

        private void LoadPengeluaranData()
        {
            try
            {
                allPengeluaran = _pengeluaranModel.GetPengeluarans();
                PopulatePengeluaranLayout(allPengeluaran);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pengeluaran data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulatePengeluaranLayout(List<Pengeluaran> pengeluaranList)
        {
            if (flowLayoutPanel2 == null) return;

            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.SuspendLayout();

            try
            {
                foreach (var pengeluaran in pengeluaranList)
                {
                    var panel = new panelPengeluaran(_mainForm, pengeluaran)
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

        private List<Pengeluaran> FilterPengeluaran(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return allPengeluaran;

            searchQuery = searchQuery.ToLower();
            return allPengeluaran.Where(p =>
                p.Nama_Pengeluaran.ToLower().Contains(searchQuery) ||
                p.Total_Pengeluaran.ToString().Contains(searchQuery) ||
                p.Tanggal_Pengeluaran.ToString("yyyy-MM-dd").Contains(searchQuery)
            ).ToList();
        }

        private void SearchPengeluaran(string searchQuery)
        {
            try
            {
                var filteredPengeluaran = FilterPengeluaran(searchQuery);
                PopulatePengeluaranLayout(filteredPengeluaran);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching pengeluaran: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Method to show all pengeluaran
        public void ShowAll()
        {
            PopulatePengeluaranLayout(allPengeluaran);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create and show the add pengeluaran form
                using (var addForm = new addPengeluaran(_pengeluaranModel))
                {
                    var result = addForm.ShowDialog();

                    // If pengeluaran was successfully added, refresh the data
                    if (result == DialogResult.OK)
                    {
                        LoadPengeluaranData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening add pengeluaran form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            _mainForm.ShowPage(_mainForm.adminKaryawan);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchPengeluaran(textBox1.Text);
        }
    }
}