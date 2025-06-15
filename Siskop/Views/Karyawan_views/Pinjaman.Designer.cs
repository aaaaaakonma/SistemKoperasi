namespace Siskop.Views
{
    partial class PinjamanControl
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
                if (_pinjamanModel != null)
                {
                    _pinjamanModel.DataChanged -= LoadPinjamanPanels;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PinjamanControl));
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            btAddNasabah = new Button();
            btnCancel = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackgroundImage = Properties.Resources.Group_2__2_;
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(52, 265);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(633, 400);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1366, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // btAddNasabah
            // 
            btAddNasabah.BackColor = Color.Transparent;
            btAddNasabah.BackgroundImage = Properties.Resources.Group_1__2_;
            btAddNasabah.BackgroundImageLayout = ImageLayout.Zoom;
            btAddNasabah.Location = new Point(1146, 688);
            btAddNasabah.Name = "btAddNasabah";
            btAddNasabah.Size = new Size(190, 50);
            btAddNasabah.TabIndex = 27;
            btAddNasabah.UseVisualStyleBackColor = false;
            btAddNasabah.Click += btAddNasabah_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackgroundImage = Properties.Resources.Group_2;
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.Location = new Point(52, 688);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(190, 50);
            btnCancel.TabIndex = 28;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackgroundImage = Properties.Resources.Group_2__2_;
            flowLayoutPanel2.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanel2.Location = new Point(703, 265);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(410, 405);
            flowLayoutPanel2.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.WindowFrame;
            label1.Location = new Point(52, 230);
            label1.Name = "label1";
            label1.Size = new Size(142, 32);
            label1.TabIndex = 40;
            label1.Text = "PINJAMAN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.WindowFrame;
            label2.Location = new Point(703, 230);
            label2.Name = "label2";
            label2.Size = new Size(149, 32);
            label2.TabIndex = 41;
            label2.Text = "ANGSURAN";
            // 
            // PinjamanControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.Control;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(btnCancel);
            Controls.Add(btAddNasabah);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            Name = "PinjamanControl";
            Size = new Size(1366, 768);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private Button btAddNasabah;
        private Button btnCancel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private Label label2;
    }
}
