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
            pbEdit = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEdit).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.download__1_;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 49);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbJabatan
            // 
            lbJabatan.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbJabatan.Location = new Point(509, 13);
            lbJabatan.Name = "lbJabatan";
            lbJabatan.Size = new Size(314, 23);
            lbJabatan.TabIndex = 12;
            lbJabatan.Text = "Jabatan";
            // 
            // lbNama
            // 
            lbNama.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNama.Location = new Point(157, 13);
            lbNama.Name = "lbNama";
            lbNama.Size = new Size(346, 23);
            lbNama.TabIndex = 11;
            lbNama.Text = "Nama";
            // 
            // lbId
            // 
            lbId.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbId.Location = new Point(15, 13);
            lbId.Name = "lbId";
            lbId.Size = new Size(136, 23);
            lbId.TabIndex = 10;
            lbId.Text = "Id";
            // 
            // pbEdit
            // 
            pbEdit.Location = new Point(829, 13);
            pbEdit.Name = "pbEdit";
            pbEdit.Size = new Size(57, 25);
            pbEdit.TabIndex = 13;
            pbEdit.TabStop = false;
            // 
            // panelKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbEdit);
            Controls.Add(lbJabatan);
            Controls.Add(lbNama);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelKaryawan";
            Size = new Size(900, 49);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEdit).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Label lbJabatan;
        private Label lbNama;
        private Label lbId;
        private PictureBox pbEdit;
    }
}
