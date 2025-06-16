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
using Siskop.Views;

namespace Siskop
{
    public partial class panelPinjaman : UserControl
    {

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PinjamanId;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PinjamanKeterangan;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal SaldoPinjaman;

        // Event for when this panel is clicked
        public event EventHandler<PinjamanClickedEventArgs> PinjamanClicked;

        public panelPinjaman()
        {
            InitializeComponent();

            // Make the entire panel clickable
            this.Click += OnPanelClick;

            // Make all child controls also trigger the click event
            foreach (Control control in this.Controls)
            {
                control.Click += OnPanelClick;
            }
        }

        public panelPinjaman(Pinjaman Pinjaman) : this()
        {
            SetPinjamanData(Pinjaman);
        }

        public void SetPinjamanData(Pinjaman Pinjaman)
        {
            if (Pinjaman != null)
            {
                PinjamanKeterangan = Pinjaman.Keterangan;
                SaldoPinjaman = Pinjaman.Saldo_pinjaman;
                PinjamanId = Pinjaman.id_Pinjaman;

                lbId.Text = $"{Pinjaman.id_Pinjaman}";
                lbSaldo.Text = $"{Pinjaman.Saldo_pinjaman:N0}"; // Format currency
                lbKeterangan.Text = Pinjaman.Keterangan ?? string.Empty;
            }
        }

        // Handle panel click
        private void OnPanelClick(object sender, EventArgs e)
        {
            // Change background color to indicate selection
            this.BackColor = Color.LightBlue;

            // Reset other panels (you might want to implement this differently)
            // For now, just raise the event
            PinjamanClicked?.Invoke(this, new PinjamanClickedEventArgs(
                PinjamanId,
                PinjamanKeterangan,
                SaldoPinjaman));
        }

        // Optional: Add method to reset selection appearance
        public void ResetSelection()
        {
            this.BackColor = SystemColors.Control;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // This will now trigger the panel click event
            OnPanelClick(sender, e);
        }

        private void lbId_Click(object sender, EventArgs e)
        {
            // This will now trigger the panel click event
            OnPanelClick(sender, e);
        }
    }
}
