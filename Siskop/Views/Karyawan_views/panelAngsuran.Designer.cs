namespace Siskop.Views
{
    partial class panelAngsuran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panelAngsuran));
            lbId = new Label();
            pictureBox1 = new PictureBox();
            lbJumlah = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbId
            // 
            lbId.BackColor = Color.MediumSpringGreen;
            lbId.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbId.Location = new Point(15, 0);
            lbId.Name = "lbId";
            lbId.Size = new Size(145, 26);
            lbId.TabIndex = 3;
            lbId.Text = "ID";
            lbId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(633, 32);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // lbJumlah
            // 
            lbJumlah.BackColor = Color.MediumSpringGreen;
            lbJumlah.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbJumlah.Location = new Point(234, 0);
            lbJumlah.Name = "lbJumlah";
            lbJumlah.Size = new Size(278, 26);
            lbJumlah.TabIndex = 6;
            lbJumlah.Text = "ID";
            lbJumlah.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelAngsuran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbJumlah);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelAngsuran";
            Size = new Size(632, 36);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lbId;
        private PictureBox pictureBox1;
        private Label lbJumlah;
    }
}
