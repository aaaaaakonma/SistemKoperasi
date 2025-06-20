namespace Siskop.Views
{
    partial class panelKaryawan
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
            lbJabatan = new Label();
            lbNama = new Label();
            lbId = new Label();
            pictureBox1 = new PictureBox();
            lbrole = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbJabatan
            // 
            lbJabatan.BackColor = Color.MediumSpringGreen;
            lbJabatan.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbJabatan.Location = new Point(464, 0);
            lbJabatan.Name = "lbJabatan";
            lbJabatan.Size = new Size(236, 23);
            lbJabatan.TabIndex = 12;
            lbJabatan.Text = "Jabatan";
            lbJabatan.MouseClick += lbJabatan_MouseClick;
            // 
            // lbNama
            // 
            lbNama.BackColor = Color.MediumSpringGreen;
            lbNama.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbNama.Location = new Point(157, 0);
            lbNama.Name = "lbNama";
            lbNama.Size = new Size(288, 23);
            lbNama.TabIndex = 11;
            lbNama.Text = "Nama";
            lbNama.MouseClick += lbJabatan_MouseClick;
            // 
            // lbId
            // 
            lbId.BackColor = Color.MediumSpringGreen;
            lbId.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbId.Location = new Point(3, 0);
            lbId.Name = "lbId";
            lbId.Size = new Size(136, 23);
            lbId.TabIndex = 10;
            lbId.Text = "ID";
            lbId.MouseClick += lbJabatan_MouseClick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MediumSpringGreen;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 26);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += lbJabatan_MouseClick;
            // 
            // lbrole
            // 
            lbrole.BackColor = Color.MediumSpringGreen;
            lbrole.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbrole.Location = new Point(735, 0);
            lbrole.Name = "lbrole";
            lbrole.Size = new Size(141, 23);
            lbrole.TabIndex = 14;
            lbrole.Text = "Role";
            lbrole.MouseClick += lbJabatan_MouseClick;
            // 
            // panelKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbrole);
            Controls.Add(lbJabatan);
            Controls.Add(lbNama);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelKaryawan";
            Size = new Size(900, 25);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lbJabatan;
        private Label lbNama;
        private Label lbId;
        private PictureBox pictureBox1;
        private Label lbrole;
    }
}
