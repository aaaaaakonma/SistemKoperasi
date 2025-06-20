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
using Siskop.Models;
using System.Reflection.Emit;
using Siskop;

namespace Siskop.Views
{
    public partial class panelNasabahAdmin : UserControl
    {
        public Nasabah _nasabah;
        private readonly MainForm _mainForm;


        // Parameterless constructor for designer
        public panelNasabahAdmin()
        {
            InitializeComponent();
        }

        // Constructor with MainForm reference
        public panelNasabahAdmin(MainForm mainForm, Nasabah nasabah) : this()
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
                // Update UI labels (assuming these exist in the designer)
                if (lbId != null) lbId.Text = $"{nasabah.id_Nasabah}";
                if (lbNama != null) lbNama.Text = nasabah.Nama ?? string.Empty;
                if (lbNik != null) lbNik.Text = $"{nasabah.NIK ?? string.Empty}";
            }
        }


        private void lbJabatan_MouseClick(object sender, MouseEventArgs e)
        {
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

        private void Edit_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
            {
                _mainForm.ShowNasabahDetails(_nasabah);
            }
            else
            {
                MessageBox.Show("Unable to load karyawan details. MainForm reference or Karyawan ID is missing.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}