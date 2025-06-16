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
    public partial class panelAngsuran : UserControl
    {
        private Angsuran _Angsuran;



        // Parameterless constructor for designer
        public panelAngsuran(Angsuran a)
        {
            InitializeComponent();
            _Angsuran = a;
            SetAngsuranData(a);
        }


        // Consolidated data setting logic
        public void SetAngsuranData(Angsuran Angsuran)
        {
            if (Angsuran != null)
            {
                lbId.Text = $"{Angsuran.ID_Pembayaran}";
                lbJumlah.Text = $"{Angsuran.Jumlah_Angsuran}";
                lbKeterangan.Text = $"{Angsuran.Jumlah_Angsuran}";
            }
        }
    }
}