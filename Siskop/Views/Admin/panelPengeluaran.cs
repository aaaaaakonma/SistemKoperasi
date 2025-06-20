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
    public partial class panelPengeluaran: UserControl
    {
        public Pengeluaran _pengeluaran;
        private readonly MainForm _mainForm;


        // Parameterless constructor for designer
        public panelPengeluaran()
        {
            InitializeComponent();
        }

        // Constructor with MainForm reference
        public panelPengeluaran(MainForm mainForm, Karyawan karyawan) : this()
        {
            _mainForm = mainForm;
            _pengeluaran = _pengeluaran;
            SetKaryawanData(karyawan);
        }

        public void SetKaryawanData(Karyawan karyawan)
        {
            if (karyawan != null)
            {
                // Update UI labels (assuming these exist in the designer)
                if (lbId != null) lbId.Text = $"{karyawan.ID_Karyawan}";
                if (lbNama != null) lbNama.Text = karyawan.Nama_Karyawan ?? string.Empty;
                if (lbJumlah != null) lbJumlah.Text = karyawan.Jabatan ?? string.Empty;
            }
        }
        }
    }
}