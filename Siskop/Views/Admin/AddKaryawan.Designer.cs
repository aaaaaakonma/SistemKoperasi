namespace Siskop.Views
{
    partial class AddKaryawan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddKaryawan));
            tbNama = new TextBox();
            tbjabatan = new TextBox();
            tbAlamat = new TextBox();
            tbKontak = new TextBox();
            cbKelamin = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            lbjeniskelamin = new Label();
            label4 = new Label();
            dtpTanggalLahir = new DateTimePicker();
            label5 = new Label();
            lbKontak = new Label();
            BtnSave = new Button();
            BtnCancel = new Button();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            label3 = new Label();
            label6 = new Label();
            cbRole = new ComboBox();
            label7 = new Label();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.Location = new Point(257, 136);
            tbNama.Multiline = true;
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(872, 23);
            tbNama.TabIndex = 0;
            // 
            // tbjabatan
            // 
            tbjabatan.Location = new Point(257, 187);
            tbjabatan.Multiline = true;
            tbjabatan.Name = "tbjabatan";
            tbjabatan.Size = new Size(872, 23);
            tbjabatan.TabIndex = 1;
            // 
            // tbAlamat
            // 
            tbAlamat.Location = new Point(257, 284);
            tbAlamat.Multiline = true;
            tbAlamat.Name = "tbAlamat";
            tbAlamat.Size = new Size(872, 23);
            tbAlamat.TabIndex = 2;
            // 
            // tbKontak
            // 
            tbKontak.Location = new Point(257, 403);
            tbKontak.Multiline = true;
            tbKontak.Name = "tbKontak";
            tbKontak.Size = new Size(872, 23);
            tbKontak.TabIndex = 3;
            // 
            // cbKelamin
            // 
            cbKelamin.FormattingEnabled = true;
            cbKelamin.Location = new Point(257, 348);
            cbKelamin.Name = "cbKelamin";
            cbKelamin.Size = new Size(100, 23);
            cbKelamin.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(153, 135);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 5;
            label1.Text = "Nama";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(153, 186);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 6;
            label2.Text = "Jabatan";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbjeniskelamin
            // 
            lbjeniskelamin.AutoSize = true;
            lbjeniskelamin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbjeniskelamin.ImageAlign = ContentAlignment.MiddleLeft;
            lbjeniskelamin.Location = new Point(150, 346);
            lbjeniskelamin.Name = "lbjeniskelamin";
            lbjeniskelamin.Size = new Size(68, 21);
            lbjeniskelamin.TabIndex = 8;
            lbjeniskelamin.Text = "Kelamin";
            lbjeniskelamin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(153, 282);
            label4.Name = "label4";
            label4.Size = new Size(61, 21);
            label4.TabIndex = 7;
            label4.Text = "Alamat";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpTanggalLahir
            // 
            dtpTanggalLahir.Location = new Point(257, 236);
            dtpTanggalLahir.Name = "dtpTanggalLahir";
            dtpTanggalLahir.Size = new Size(200, 23);
            dtpTanggalLahir.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(150, 238);
            label5.Name = "label5";
            label5.Size = new Size(101, 21);
            label5.TabIndex = 10;
            label5.Text = "Tanggal lahir";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Click += label5_Click;
            // 
            // lbKontak
            // 
            lbKontak.AutoSize = true;
            lbKontak.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbKontak.ImageAlign = ContentAlignment.MiddleLeft;
            lbKontak.Location = new Point(150, 401);
            lbKontak.Name = "lbKontak";
            lbKontak.Size = new Size(61, 21);
            lbKontak.TabIndex = 11;
            lbKontak.Text = "Kontak";
            lbKontak.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnSave
            // 
            BtnSave.BackgroundImage = Properties.Resources.Group_1;
            BtnSave.BackgroundImageLayout = ImageLayout.Zoom;
            BtnSave.Location = new Point(1099, 683);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(182, 54);
            BtnSave.TabIndex = 12;
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.BackgroundImage = Properties.Resources.Group_2;
            BtnCancel.BackgroundImageLayout = ImageLayout.Zoom;
            BtnCancel.Location = new Point(51, 683);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(182, 54);
            BtnCancel.TabIndex = 13;
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(257, 451);
            tbUsername.Multiline = true;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(872, 26);
            tbUsername.TabIndex = 14;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(257, 497);
            tbPassword.Multiline = true;
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(872, 26);
            tbPassword.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(150, 451);
            label3.Name = "label3";
            label3.Size = new Size(83, 21);
            label3.TabIndex = 16;
            label3.Text = "Username";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(150, 496);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 17;
            label6.Text = "Password";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(257, 564);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(100, 23);
            cbRole.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(150, 563);
            label7.Name = "label7";
            label7.Size = new Size(79, 21);
            label7.TabIndex = 20;
            label7.Text = "Password";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(257, 608);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(71, 19);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "Availabe";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1366, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // AddKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(cbRole);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(BtnCancel);
            Controls.Add(BtnSave);
            Controls.Add(lbKontak);
            Controls.Add(label5);
            Controls.Add(dtpTanggalLahir);
            Controls.Add(lbjeniskelamin);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbKelamin);
            Controls.Add(tbKontak);
            Controls.Add(tbAlamat);
            Controls.Add(tbjabatan);
            Controls.Add(tbNama);
            Name = "AddKaryawan";
            Size = new Size(1366, 768);
            Load += AddKaryawan_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNama;
        private TextBox tbjabatan;
        private TextBox tbAlamat;
        private TextBox textBox5;
        private TextBox tbKontak;
        private ComboBox cbKelamin;
        private Label label1;
        private Label label2;
        private Label lbjeniskelamin;
        private Label label4;
        private DateTimePicker dtpTanggalLahir;
        private Label label5;
        private Label lbKontak;
        private Button BtnSave;
        private Button BtnCancel;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Label label3;
        private Label label6;
        private ComboBox cbRole;
        private Label label7;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
    }
}
