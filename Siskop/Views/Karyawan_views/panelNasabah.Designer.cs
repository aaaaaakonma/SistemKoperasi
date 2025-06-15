namespace Siskop.Views
{
    partial class panelNasabah
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
            lbNama = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbNama
            // 
            lbNama.BackColor = Color.Transparent;
            lbNama.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbNama.Location = new Point(213, 12);
            lbNama.Name = "lbNama";
            lbNama.Size = new Size(244, 26);
            lbNama.TabIndex = 1;
            lbNama.Text = "Nama";
            lbNama.TextAlign = ContentAlignment.MiddleLeft;
            lbNama.Click += this.lbNama_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(11, 12);
            label2.Name = "label2";
            label2.Size = new Size(196, 26);
            label2.TabIndex = 3;
            label2.Text = "ID";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.panellayout_FIX;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 60);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panelNasabah
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(lbNama);
            Controls.Add(pictureBox1);
            Name = "panelNasabah";
            Size = new Size(900, 49);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lbNama;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
