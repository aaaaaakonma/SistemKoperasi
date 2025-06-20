namespace Siskop.Views
{
    partial class AdminNasabah
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
            if (disposing)
            {
                // Unsubscribe from events to prevent memory leaks
                if (_nasabahModel != null)
                {
                    _nasabahModel.DataChanged -= LoadNasabahPanels;
                }

                // Dispose components
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminNasabah));
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            btNasabah = new Button();
            btKaryawan = new Button();
            btAddNasabah = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanel2.Location = new Point(185, 150);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1125, 490);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1366, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Rectangle_39;
            pictureBox3.Location = new Point(0, 101);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(151, 667);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 26;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(186, 115);
            label1.Name = "label1";
            label1.Size = new Size(112, 32);
            label1.TabIndex = 27;
            label1.Text = "Nasabah";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btNasabah
            // 
            btNasabah.BackgroundImage = Properties.Resources.background;
            btNasabah.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btNasabah.Location = new Point(3, 150);
            btNasabah.Name = "btNasabah";
            btNasabah.Size = new Size(141, 53);
            btNasabah.TabIndex = 28;
            btNasabah.Text = "Data Nasabah";
            btNasabah.UseVisualStyleBackColor = true;
            // 
            // btKaryawan
            // 
            btKaryawan.BackgroundImage = Properties.Resources.background;
            btKaryawan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btKaryawan.Location = new Point(3, 246);
            btKaryawan.Name = "btKaryawan";
            btKaryawan.Size = new Size(141, 56);
            btKaryawan.TabIndex = 29;
            btKaryawan.Text = "Data Karyawan";
            btKaryawan.UseVisualStyleBackColor = true;
            btKaryawan.Click += btKaryawan_Click;
            // 
            // btAddNasabah
            // 
            btAddNasabah.BackgroundImage = Properties.Resources.Nasabah_Baru;
            btAddNasabah.BackgroundImageLayout = ImageLayout.Zoom;
            btAddNasabah.Location = new Point(1057, 666);
            btAddNasabah.Name = "btAddNasabah";
            btAddNasabah.Size = new Size(253, 50);
            btAddNasabah.TabIndex = 30;
            btAddNasabah.UseVisualStyleBackColor = true;
            btAddNasabah.Click += btAddNasabah_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 666);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(132, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 32;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // AdminNasabah
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox2);
            Controls.Add(btAddNasabah);
            Controls.Add(btKaryawan);
            Controls.Add(btNasabah);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Name = "AdminNasabah";
            Size = new Size(1366, 768);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Label label1;
        private Button btNasabah;
        private Button btKaryawan;
        private Button btAddNasabah;
        private PictureBox pictureBox2;
    }
}
