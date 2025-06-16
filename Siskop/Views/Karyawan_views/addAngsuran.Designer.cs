namespace Siskop.Views.Karyawan_views
{
    partial class addAngsuran
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbJumlah = new TextBox();
            tbKet = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btSave = new Button();
            btCancel = new Button();
            SuspendLayout();
            // 
            // tbJumlah
            // 
            tbJumlah.Location = new Point(111, 49);
            tbJumlah.Name = "tbJumlah";
            tbJumlah.Size = new Size(342, 23);
            tbJumlah.TabIndex = 0;
            // 
            // tbKet
            // 
            tbKet.Location = new Point(111, 106);
            tbKet.Multiline = true;
            tbKet.Name = "tbKet";
            tbKet.Size = new Size(342, 23);
            tbKet.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 55);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Jumlah";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 109);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Keterangan";
            // 
            // btSave
            // 
            btSave.Location = new Point(378, 188);
            btSave.Name = "btSave";
            btSave.Size = new Size(102, 26);
            btSave.TabIndex = 4;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(12, 188);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(102, 26);
            btCancel.TabIndex = 5;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // addAngsuran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 226);
            Controls.Add(btCancel);
            Controls.Add(btSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbKet);
            Controls.Add(tbJumlah);
            Name = "addAngsuran";
            Text = "addAngsuran";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbJumlah;
        private TextBox tbKet;
        private Label label1;
        private Label label2;
        private Button btSave;
        private Button btCancel;
    }
}