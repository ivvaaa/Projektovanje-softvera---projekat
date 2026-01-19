namespace Forme
{
    partial class FrmUbaciKnjigu
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txNaziv = new TextBox();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            btnDodaj = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 111);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv knjige:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 180);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Ime pisca:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(156, 251);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 2;
            label3.Text = "Prezime pisca:";
            // 
            // txNaziv
            // 
            txNaziv.Location = new Point(274, 108);
            txNaziv.Name = "txNaziv";
            txNaziv.Size = new Size(245, 27);
            txNaziv.TabIndex = 3;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(274, 177);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(245, 27);
            txtIme.TabIndex = 4;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(274, 248);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(245, 27);
            txtPrezime.TabIndex = 5;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(274, 336);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(245, 29);
            btnDodaj.TabIndex = 6;
            btnDodaj.Text = "Dodaj knjigu!";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // FrmUbaciKnjigu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDodaj);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(txNaziv);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmUbaciKnjigu";
            Text = "FrmUbaciKnjigu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txNaziv;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private Button btnDodaj;
    }
}