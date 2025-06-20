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

namespace Siskop.Views
{
    public partial class panelKaryawan : UserControl
    {
        public Karyawan _karyawan;
        private readonly MainForm _mainForm;


        // Parameterless constructor for designer
        public panelKaryawan()
        {
            InitializeComponent();
        }

        // Constructor with MainForm reference
        public panelKaryawan(MainForm mainForm, Karyawan karyawan) : this()
        {
            _mainForm = mainForm;
            _karyawan = karyawan;
            SetKaryawanData(karyawan);
        }

        // Modified constructor to chain to parameterless version (kept for backward compatibility)
        public panelKaryawan(Karyawan karyawan) : this()
        {
            SetKaryawanData(karyawan);
        }

        // Consolidated data setting logic
        public void SetKaryawanData(Karyawan karyawan)
        {
            if (karyawan != null)
            {
                // Update UI labels (assuming these exist in the designer)
                if (lbId != null) lbId.Text = $"{karyawan.ID_Karyawan}";
                if (lbNama != null) lbNama.Text = karyawan.Nama_Karyawan ?? string.Empty;
                if (lbJabatan != null) lbJabatan.Text = karyawan.Jabatan ?? string.Empty;
            }
        }


        private void lbJabatan_MouseClick(object sender, MouseEventArgs e)
        {

            // Navigate to karyawan details or related functionality
            if (_mainForm != null)
            {
                _mainForm.ShowKaryawanDetails(_karyawan);
            }
            else
            {
                MessageBox.Show("Unable to load karyawan details. MainForm reference or Karyawan ID is missing.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}