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
        private int _nasabahId;
        private string _nasabahNama;
        private readonly MainForm _mainForm;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NasabahId
        {
            get { return _nasabahId; }
            set { _nasabahId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NasabahNama
        {
            get { return _nasabahNama ?? string.Empty; }
            set { _nasabahNama = value; }
        }

        // Parameterless constructor for designer
        public panelNasabah()
        {
            InitializeComponent();
        }

        // Constructor with MainForm reference
        public panelNasabah(MainForm mainForm,Nasabah nasabah) : this()
        {
            _mainForm = mainForm;
            SetNasabahData(nasabah);
        }


        // Consolidated data setting logic
        public void SetNasabahData(Nasabah nasabah)
        {
            if (nasabah != null)
            {
                NasabahId = nasabah.id_Nasabah;
                NasabahNama = nasabah.Nama;
                label2.Text = $"{nasabah.id_Nasabah}";
                lbNama.Text = nasabah.Nama ?? string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navigate to pinjaman control with filtered data for this nasabah
            if (_mainForm != null && NasabahId > 0)
            {
                _mainForm.ShowPinjamanForNasabah(NasabahId);
            }
            else
            {
                MessageBox.Show("Unable to load pinjaman data. MainForm reference or Nasabah ID is missing.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}