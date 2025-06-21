namespace Siskop.Views
{
    partial class panelPengeluaran

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
            lbJumlah = new Label();
            lbNama = new Label();
            lbId = new Label();
            pictureBox1 = new PictureBox();
            lbTanggal = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbJumlah
            // 
            lbJumlah.BackColor = Color.Transparent;
            lbJumlah.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbJumlah.Location = new Point(438, -1);
            lbJumlah.Name = "lbJumlah";
            lbJumlah.Size = new Size(225, 23);
            lbJumlah.TabIndex = 12;
            lbJumlah.Text = "Jabatan";
            // 
            // lbNama
            // 
            lbNama.BackColor = Color.Transparent;
            lbNama.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbNama.Location = new Point(157, 0);
            lbNama.Name = "lbNama";
            lbNama.Size = new Size(244, 23);
            lbNama.TabIndex = 11;
            lbNama.Text = "Nama";
            // 
            // lbId
            // 
            lbId.BackColor = Color.Transparent;
            lbId.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbId.Location = new Point(3, 0);
            lbId.Name = "lbId";
            lbId.Size = new Size(136, 23);
            lbId.TabIndex = 10;
            lbId.Text = "ID";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Rectangle_44;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 26);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // lbTanggal
            // 
            lbTanggal.BackColor = Color.Transparent;
            lbTanggal.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbTanggal.Location = new Point(697, 0);
            lbTanggal.Name = "lbTanggal";
            lbTanggal.Size = new Size(179, 23);
            lbTanggal.TabIndex = 14;
            lbTanggal.Text = "Role";
            // 
            // panelPengeluaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbTanggal);
            Controls.Add(lbJumlah);
            Controls.Add(lbNama);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelPengeluaran";
            Size = new Size(900, 25);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lbJumlah;
        private Label lbNama;
        private Label lbId;
        private PictureBox pictureBox1;
        private Label lbTanggal;
    }
}
