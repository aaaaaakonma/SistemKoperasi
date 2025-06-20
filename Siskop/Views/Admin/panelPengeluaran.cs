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
        public panelPengeluaran(MainForm mainForm, Pengeluaran pengeluaran) : this()
        {
            _mainForm = mainForm;
            _pengeluaran = _pengeluaran;
            SetPengeluaranData(pengeluaran);
        }

        public void SetPengeluaranData(Pengeluaran pengeluaran)
        {
            if (pengeluaran != null)
            {
                // Update UI labels (assuming these exist in the designer)
                if (lbId != null)
                    lbId.Text = $"ID: {pengeluaran.ID_Pengeluaran}";

                if (lbNama != null)
                    lbNama.Text = pengeluaran.Nama_Pengeluaran ?? string.Empty;

                if (lbJumlah != null)
                    lbJumlah.Text = $"Rp {pengeluaran.Total_Pengeluaran:N0}";

                // If you have a date label
                if (Controls.Find("lbTanggal", true).FirstOrDefault() is System.Windows.Forms.Label lbTanggal)
                    lbTanggal.Text = pengeluaran.Tanggal_Pengeluaran.ToString("dd/MM/yyyy");

                // Store the pengeluaran reference
                _pengeluaran = pengeluaran;
            }
        }
    }
    
}