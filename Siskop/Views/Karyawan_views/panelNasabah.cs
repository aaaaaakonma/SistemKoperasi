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
    public partial class panelNasabah : UserControl
    {
        private Nasabah _nasabah;
        private readonly MainForm _mainForm;



        // Parameterless constructor for designer
        public panelNasabah()
        {
            InitializeComponent();
        }

        // Constructor with MainForm reference
        public panelNasabah(MainForm mainForm, Nasabah nasabah) : this()
        {
            _nasabah = nasabah;
            _mainForm = mainForm;
            SetNasabahData(nasabah);
        }


        // Consolidated data setting logic
        public void SetNasabahData(Nasabah nasabah)
        {
            if (nasabah != null)
            {
                lbNik.Text = $"{nasabah.NIK}";
                label2.Text = $"{nasabah.id_Nasabah}";
                lbNama.Text = nasabah.Nama ?? string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navigate to pinjaman control with filtered data for this nasabah
            if (_mainForm != null && _nasabah != null)
            {
                _mainForm.ShowPinjamanForNasabah(_nasabah);
            }
            else
            {
                MessageBox.Show("Unable to load pinjaman data. MainForm reference or Nasabah ID is missing.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}