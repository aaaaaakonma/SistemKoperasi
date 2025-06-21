namespace Siskop.Views
{
    partial class panelNasabahAdmin
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
            lbNik = new Label();
            lbNama = new Label();
            lbId = new Label();
            pictureBox1 = new PictureBox();
            Edit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbNik
            // 
            lbNik.BackColor = Color.Transparent;
            lbNik.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbNik.Location = new Point(462, 0);
            lbNik.Name = "lbNik";
            lbNik.Size = new Size(236, 25);
            lbNik.TabIndex = 12;
            lbNik.Text = "Jabatan";
            lbNik.MouseClick += lbJabatan_MouseClick;
            // 
            // lbNama
            // 
            lbNama.BackColor = Color.Transparent;
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
            lbId.BackColor = Color.Transparent;
            lbId.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbId.Location = new Point(3, 2);
            lbId.Name = "lbId";
            lbId.Size = new Size(136, 23);
            lbId.TabIndex = 10;
            lbId.Text = "ID";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MediumSpringGreen;
            pictureBox1.Image = Properties.Resources.Rectangle_44;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 30);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // Edit
            // 
            Edit.FlatStyle = FlatStyle.Flat;
            Edit.Location = new Point(781, 2);
            Edit.Name = "Edit";
            Edit.Size = new Size(104, 23);
            Edit.TabIndex = 14;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // panelNasabahAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Edit);
            Controls.Add(lbNik);
            Controls.Add(lbNama);
            Controls.Add(lbId);
            Controls.Add(pictureBox1);
            Name = "panelNasabahAdmin";
            Size = new Size(900, 29);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lbNik;
        private Label lbNama;
        private Label lbId;
        private PictureBox pictureBox1;
        private Button Edit;
    }
}
