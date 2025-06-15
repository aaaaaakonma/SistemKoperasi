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

namespace Siskop
{
    public partial class panelPinjaman : UserControl
    {
        private string _PinjamanId;
        private string _PinjamanKeterangan;
        private decimal _SaldoPinjaman;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PinjamanId;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PinjamanKeterangan;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal SaldoPinjaman;

        public panelPinjaman()
        {
            InitializeComponent();
        }

        public panelPinjaman(Pinjaman Pinjaman) : this()
        {
            SetPinjamanData(Pinjaman);
        }

        public void SetPinjamanData(Pinjaman Pinjaman)
        {
            if (Pinjaman != null)
            {
                PinjamanId = Pinjaman.id_Pinjaman;
                PinjamanKeterangan = Pinjaman.Keterangan;
                SaldoPinjaman = Pinjaman.Saldo_pinjaman;

                lbId.Text = $"{Pinjaman.id_Pinjaman}";
                lbSaldo.Text = $"{Pinjaman.Saldo_pinjaman}";
                lbKeterangan.Text = Pinjaman.Keterangan ?? string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("horeee");
        }
    }
}