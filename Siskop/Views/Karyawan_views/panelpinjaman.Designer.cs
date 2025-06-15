namespace Siskop
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
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.download__1_;
            pictureBox1.Location = new Point(-3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(903, 41);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbId
            // 
            lbId.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbId.Location = new Point(14, 10);
            lbId.Name = "lbId";
            lbId.Size = new Size(136, 23);
            lbId.TabIndex = 6;
            lbId.Text = "Id";
            // 
            // lbKeterangan
            // 
            lbKeterangan.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbKeterangan.Location = new Point(156, 10);
            lbKeterangan.Name = "lbKeterangan";
            lbKeterangan.Size = new Size(252, 23);
            lbKeterangan.TabIndex = 7;
            lbKeterangan.Text = "Keterangan";
            // 
            // lbSaldo
            // 
            lbSaldo.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSaldo.Location = new Point(414, 10);
            lbSaldo.Name = "lbSaldo";
            lbSaldo.Size = new Size(250, 23);
            lbSaldo.TabIndex = 8;
            lbSaldo.Text = "Saldo";
            // 
            // label4
            // 
            label4.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(670, 10);
            label4.Name = "label4";
            label4.Size = new Size(214, 23);
            label4.TabIndex = 9;
            label4.Text = "LastPaid";
            // 
            // panelPinjaman
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(lbSaldo);
            Controls.Add(lbKeterangan);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelPinjaman";
            Size = new Size(900, 40);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Label lbId;
        private Label lbKeterangan;
        private Label lbSaldo;
        private Label label4;
    }
}
