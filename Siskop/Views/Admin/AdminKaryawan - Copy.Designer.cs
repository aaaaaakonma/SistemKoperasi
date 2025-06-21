namespace Siskop.Views
{
    partial class AdminPengeluaran

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPengeluaran));
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            btNasabah = new Button();
            btKaryawan = new Button();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(187, 139);
            label1.Name = "label1";
            label1.Size = new Size(157, 32);
            label1.TabIndex = 0;
            label1.Text = "Pengeluaran";
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
            flowLayoutPanel2.Location = new Point(187, 174);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(900, 490);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.Group_11;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(1071, 690);
            button1.Name = "button1";
            button1.Size = new Size(241, 51);
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
            btNasabah.Click += btNasabah_Click;
            // 
            // btKaryawan
            // 
            btKaryawan.BackgroundImage = Properties.Resources.background;
            btKaryawan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btKaryawan.Location = new Point(3, 246);
            btKaryawan.Name = "btKaryawan";
            btKaryawan.Size = new Size(141, 53);
            btKaryawan.TabIndex = 29;
            btKaryawan.Text = "Data Karyawan";
            btKaryawan.Click += btKaryawan_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 720);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(123, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 31;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1113, 191);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(215, 23);
            textBox1.TabIndex = 32;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1113, 171);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 33;
            label2.Text = "Search";
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.background;
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(3, 344);
            button2.Name = "button2";
            button2.Size = new Size(141, 53);
            button2.TabIndex = 34;
            button2.Text = "Data Pengeluaran";
            button2.UseVisualStyleBackColor = true;
            // 
            // AdminPengeluaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(btKaryawan);
            Controls.Add(btNasabah);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Name = "AdminPengeluaran";
            Size = new Size(1366, 768);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private Label label2;
        private Button button2;
    }
}
