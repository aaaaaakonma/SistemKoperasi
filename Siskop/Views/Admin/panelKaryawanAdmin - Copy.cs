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
        private int _karyawanId;
        private string _karyawanNama;
        private string _jabatan;
        private bool _available;
        private readonly MainForm _mainForm;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int KaryawanId
        {
            get { return _karyawanId; }
            set { _karyawanId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string KaryawanNama
        {
            get { return _karyawanNama ?? string.Empty; }
            set { _karyawanNama = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Jabatan
        {
            get { return _jabatan ?? string.Empty; }
            set { _jabatan = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }

        // Parameterless constructor for designer
        public panelKaryawan()
        {
            InitializeComponent();
        }

        // Constructor with MainForm reference
        public panelKaryawan(MainForm mainForm, Karyawan karyawan) : this()
        {
            _mainForm = mainForm;
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
                KaryawanId = karyawan.ID_Karyawan;
                KaryawanNama = karyawan.Nama_Karyawan;
                Jabatan = karyawan.Jabatan;
                Available = karyawan.Available;

                // Update UI labels (assuming these exist in the designer)
                if (lbId != null) lbId.Text = $"{karyawan.ID_Karyawan}";
                if (lbNama != null) lbNama.Text = karyawan.Nama_Karyawan ?? string.Empty;
                if (lbJabatan != null) lbJabatan.Text = karyawan.Jabatan ?? string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navigate to karyawan details or related functionality
            if (_mainForm != null && KaryawanId > 0)
            {
                //_mainForm.ShowKaryawanDetails(KaryawanId);
            }
            else
            {
                MessageBox.Show("Unable to load karyawan details. MainForm reference or Karyawan ID is missing.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}