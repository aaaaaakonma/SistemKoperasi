namespace Siskop.Views
{
    partial class AdminKaryawan

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminKaryawan));
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            btNasabah = new Button();
            btKaryawan = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(185, 115);
            label1.Name = "label1";
            label1.Size = new Size(127, 32);
            label1.TabIndex = 0;
            label1.Text = "Karyawan";
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
            flowLayoutPanel2.BackgroundImage = Properties.Resources.Group_2__2_;
            flowLayoutPanel2.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanel2.Location = new Point(185, 150);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1125, 492);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.Group_1__1_1;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(1120, 678);
            button1.Name = "button1";
            button1.Size = new Size(190, 50);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // btNasabah
            // 
            btNasabah.BackgroundImage = Properties.Resources.background;
            btNasabah.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btNasabah.Location = new Point(3, 196);
            btNasabah.Name = "btNasabah";
            btNasabah.Size = new Size(141, 30);
            btNasabah.TabIndex = 28;
            btNasabah.Text = "Data Nasabah";
            btNasabah.UseVisualStyleBackColor = true;
            // 
            // btKaryawan
            // 
            btKaryawan.BackgroundImage = Properties.Resources.background;
            btKaryawan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btKaryawan.Location = new Point(3, 258);
            btKaryawan.Name = "btKaryawan";
            btKaryawan.Size = new Size(141, 30);
            btKaryawan.TabIndex = 29;
            btKaryawan.Text = "Data Karyawan";
            btKaryawan.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Image = Properties.Resources.background;
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(3, 124);
            label2.Name = "label2";
            label2.Size = new Size(138, 32);
            label2.TabIndex = 30;
            label2.Text = "Dashboard";
            // 
            // AdminKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(btKaryawan);
            Controls.Add(btNasabah);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Name = "AdminKaryawan";
            Size = new Size(1366, 768);
            Load += AdminKaryawan_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Button btNasabah;
        private Button btKaryawan;
        private Label label2;
    }
}
