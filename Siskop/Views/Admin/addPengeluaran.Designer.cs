namespace Siskop.Views
{
    partial class addPengeluaran
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
            tbNama = new TextBox();
            tbJumlah = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btSave = new Button();
            btCancel = new Button();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.Location = new Point(111, 49);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(342, 23);
            tbNama.TabIndex = 0;
            // 
            // tbJumlah
            // 
            tbJumlah.Location = new Point(111, 106);
            tbJumlah.Multiline = true;
            tbJumlah.Name = "tbJumlah";
            tbJumlah.Size = new Size(342, 23);
            tbJumlah.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 109);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Jumlah";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 52);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Nama";
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
            // addPengeluaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 226);
            Controls.Add(btCancel);
            Controls.Add(btSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbJumlah);
            Controls.Add(tbNama);
            Name = "addPengeluaran";
            Text = "addAngsuran";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNama;
        private TextBox tbJumlah;
        private Label label1;
        private Label label2;
        private Button btSave;
        private Button btCancel;
    }
}