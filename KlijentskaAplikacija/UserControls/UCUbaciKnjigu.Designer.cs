namespace KlijentskaAplikacija.UserControls
{
    partial class UCUbaciKnjigu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblNaslov = new Label();
            lblNaziv = new Label();
            lblImePisca = new Label();
            lblPrezimePisca = new Label();
            txtNaziv = new TextBox();
            txtImePisca = new TextBox();
            txtPrezimePisca = new TextBox();
            btnSacuvaj = new Button();
            btnOcisti = new Button();
            pnlForma = new Panel();
            pnlForma.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(23, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(248, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Ubaci novu knjigu";
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.Location = new Point(23, 27);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(106, 23);
            lblNaziv.TabIndex = 0;
            lblNaziv.Text = "Naziv knjige:";
            // 
            // lblImePisca
            // 
            lblImePisca.AutoSize = true;
            lblImePisca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblImePisca.Location = new Point(23, 107);
            lblImePisca.Name = "lblImePisca";
            lblImePisca.Size = new Size(86, 23);
            lblImePisca.TabIndex = 1;
            lblImePisca.Text = "Ime pisca:";
            // 
            // lblPrezimePisca
            // 
            lblPrezimePisca.AutoSize = true;
            lblPrezimePisca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrezimePisca.Location = new Point(23, 187);
            lblPrezimePisca.Name = "lblPrezimePisca";
            lblPrezimePisca.Size = new Size(118, 23);
            lblPrezimePisca.TabIndex = 2;
            lblPrezimePisca.Text = "Prezime pisca:";
            // 
            // txtNaziv
            // 
            txtNaziv.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(23, 56);
            txtNaziv.Margin = new Padding(3, 4, 3, 4);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(388, 30);
            txtNaziv.TabIndex = 3;
            // 
            // txtImePisca
            // 
            txtImePisca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtImePisca.Location = new Point(23, 136);
            txtImePisca.Margin = new Padding(3, 4, 3, 4);
            txtImePisca.Name = "txtImePisca";
            txtImePisca.Size = new Size(388, 30);
            txtImePisca.TabIndex = 4;
            // 
            // txtPrezimePisca
            // 
            txtPrezimePisca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrezimePisca.Location = new Point(23, 216);
            txtPrezimePisca.Margin = new Padding(3, 4, 3, 4);
            txtPrezimePisca.Name = "txtPrezimePisca";
            txtPrezimePisca.Size = new Size(388, 30);
            txtPrezimePisca.TabIndex = 5;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(18, 27, 41);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(23, 280);
            btnSacuvaj.Margin = new Padding(3, 4, 3, 4);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(183, 53);
            btnSacuvaj.TabIndex = 6;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // btnOcisti
            // 
            btnOcisti.BackColor = Color.Gray;
            btnOcisti.Cursor = Cursors.Hand;
            btnOcisti.FlatAppearance.BorderSize = 0;
            btnOcisti.FlatStyle = FlatStyle.Flat;
            btnOcisti.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnOcisti.ForeColor = Color.White;
            btnOcisti.Location = new Point(229, 280);
            btnOcisti.Margin = new Padding(3, 4, 3, 4);
            btnOcisti.Name = "btnOcisti";
            btnOcisti.Size = new Size(183, 53);
            btnOcisti.TabIndex = 7;
            btnOcisti.Text = "Očisti";
            btnOcisti.UseVisualStyleBackColor = false;
            btnOcisti.Click += btnOcisti_Click;
            // 
            // pnlForma
            // 
            pnlForma.BackColor = Color.White;
            pnlForma.BorderStyle = BorderStyle.FixedSingle;
            pnlForma.Controls.Add(btnOcisti);
            pnlForma.Controls.Add(btnSacuvaj);
            pnlForma.Controls.Add(txtPrezimePisca);
            pnlForma.Controls.Add(txtImePisca);
            pnlForma.Controls.Add(txtNaziv);
            pnlForma.Controls.Add(lblPrezimePisca);
            pnlForma.Controls.Add(lblImePisca);
            pnlForma.Controls.Add(lblNaziv);
            pnlForma.Location = new Point(23, 73);
            pnlForma.Margin = new Padding(3, 4, 3, 4);
            pnlForma.Name = "pnlForma";
            pnlForma.Padding = new Padding(23, 27, 23, 27);
            pnlForma.Size = new Size(457, 373);
            pnlForma.TabIndex = 1;
            // 
            // UCUbaciKnjigu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlForma);
            Controls.Add(lblNaslov);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UCUbaciKnjigu";
            Size = new Size(686, 533);
            pnlForma.ResumeLayout(false);
            pnlForma.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Panel pnlForma;
        private Label lblNaziv;
        private Label lblImePisca;
        private Label lblPrezimePisca;
        private TextBox txtNaziv;
        private TextBox txtImePisca;
        private TextBox txtPrezimePisca;
        private Button btnSacuvaj;
        private Button btnOcisti;
    }
}