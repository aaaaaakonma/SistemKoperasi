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
            pictureBox1 = new PictureBox();
            lbJabatan = new Label();
            lbNama = new Label();
            lbId = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Rectangle_44;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 49);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbJabatan
            // 
            lbJabatan.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbJabatan.Location = new Point(509, 13);
            lbJabatan.Name = "lbJabatan";
            lbJabatan.Size = new Size(374, 23);
            lbJabatan.TabIndex = 12;
            lbJabatan.Text = "Jabatan";
            // 
            // lbNama
            // 
            lbNama.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbNama.Location = new Point(157, 13);
            lbNama.Name = "lbNama";
            lbNama.Size = new Size(346, 23);
            lbNama.TabIndex = 11;
            lbNama.Text = "Nama";
            // 
            // lbId
            // 
            lbId.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbId.Location = new Point(15, 13);
            lbId.Name = "lbId";
            lbId.Size = new Size(136, 23);
            lbId.TabIndex = 10;
            lbId.Text = "ID";
            // 
            // panelKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(lbJabatan);
            Controls.Add(lbNama);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelKaryawan";
            Size = new Size(900, 49);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Label lbJabatan;
        private Label lbNama;
        private Label lbId;
    }
}
