﻿namespace Siskop
{
    partial class panelPinjaman
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lbId = new Label();
            lbKeterangan = new Label();
            lbSaldo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MediumSeaGreen;
            pictureBox1.Image = Properties.Resources.Rectangle_44;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(633, 41);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbId
            // 
            lbId.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbId.Location = new Point(14, 10);
            lbId.Name = "lbId";
            lbId.Size = new Size(0, 0);
            lbId.TabIndex = 6;
            lbId.Text = "ID";
            lbId.Click += lbId_Click;
            // 
            // lbKeterangan
            // 
            lbKeterangan.BackColor = Color.Transparent;
            lbKeterangan.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbKeterangan.Location = new Point(14, 10);
            lbKeterangan.Name = "lbKeterangan";
            lbKeterangan.Size = new Size(251, 23);
            lbKeterangan.TabIndex = 7;
            lbKeterangan.Text = "Keterangan";
            // 
            // lbSaldo
            // 
            lbSaldo.BackColor = Color.Transparent;
            lbSaldo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbSaldo.Location = new Point(271, 10);
            lbSaldo.Name = "lbSaldo";
            lbSaldo.Size = new Size(218, 23);
            lbSaldo.TabIndex = 8;
            lbSaldo.Text = "Saldo";
            // 
            // panelPinjaman
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbSaldo);
            Controls.Add(lbKeterangan);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelPinjaman";
            Size = new Size(633, 40);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Label lbId;
        private Label lbKeterangan;
        private Label lbSaldo;
    }
}
