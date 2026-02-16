namespace KlijentskaAplikacija.UserControls
{
    partial class UCDodajClana
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
            pnlForma = new Panel();
            lblIme = new Label();
            txtIme = new TextBox();
            lblPrezime = new Label();
            txtPrezime = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblDatumOd = new Label();
            dtpDatumOd = new DateTimePicker();
            lblDatumDo = new Label();
            dtpDatumDo = new DateTimePicker();
            lblClanstvo = new Label();
            cmbClanstvo = new ComboBox();
            btnSacuvaj = new Button();
            btnOcisti = new Button();
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
            lblNaslov.Size = new Size(230, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Dodaj novog člana";
            // 
            // pnlForma
            // 
            pnlForma.BackColor = Color.White;
            pnlForma.BorderStyle = BorderStyle.FixedSingle;
            pnlForma.Controls.Add(btnOcisti);
            pnlForma.Controls.Add(btnSacuvaj);
            pnlForma.Controls.Add(cmbClanstvo);
            pnlForma.Controls.Add(lblClanstvo);
            pnlForma.Controls.Add(dtpDatumDo);
            pnlForma.Controls.Add(lblDatumDo);
            pnlForma.Controls.Add(dtpDatumOd);
            pnlForma.Controls.Add(lblDatumOd);
            pnlForma.Controls.Add(txtTelefon);
            pnlForma.Controls.Add(lblTelefon);
            pnlForma.Controls.Add(txtPrezime);
            pnlForma.Controls.Add(lblPrezime);
            pnlForma.Controls.Add(txtIme);
            pnlForma.Controls.Add(lblIme);
            pnlForma.Location = new Point(23, 73);
            pnlForma.Margin = new Padding(3, 4, 3, 4);
            pnlForma.Name = "pnlForma";
            pnlForma.Padding = new Padding(23, 27, 23, 27);
            pnlForma.Size = new Size(500, 520);
            pnlForma.TabIndex = 1;
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblIme.Location = new Point(23, 20);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(42, 23);
            lblIme.TabIndex = 0;
            lblIme.Text = "Ime:";
            // 
            // txtIme
            // 
            txtIme.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtIme.Location = new Point(23, 46);
            txtIme.Margin = new Padding(3, 4, 3, 4);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(220, 30);
            txtIme.TabIndex = 1;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrezime.Location = new Point(255, 20);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(72, 23);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime:";
            // 
            // txtPrezime
            // 
            txtPrezime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrezime.Location = new Point(255, 46);
            txtPrezime.Margin = new Padding(3, 4, 3, 4);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(220, 30);
            txtPrezime.TabIndex = 2;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefon.Location = new Point(23, 95);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(68, 23);
            lblTelefon.TabIndex = 4;
            lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefon.Location = new Point(23, 121);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(220, 30);
            txtTelefon.TabIndex = 3;
            txtTelefon.KeyPress += txtTelefon_KeyPress;
            // 
            // lblDatumOd
            // 
            lblDatumOd.AutoSize = true;
            lblDatumOd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumOd.Location = new Point(23, 170);
            lblDatumOd.Name = "lblDatumOd";
            lblDatumOd.Size = new Size(139, 23);
            lblDatumOd.TabIndex = 6;
            lblDatumOd.Text = "Početak članarine:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumOd.Format = DateTimePickerFormat.Short;
            dtpDatumOd.Location = new Point(23, 196);
            dtpDatumOd.Margin = new Padding(3, 4, 3, 4);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(220, 30);
            dtpDatumOd.TabIndex = 4;
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // lblDatumDo
            // 
            lblDatumDo.AutoSize = true;
            lblDatumDo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumDo.Location = new Point(255, 170);
            lblDatumDo.Name = "lblDatumDo";
            lblDatumDo.Size = new Size(121, 23);
            lblDatumDo.TabIndex = 8;
            lblDatumDo.Text = "Istek članarine:";
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumDo.Format = DateTimePickerFormat.Short;
            dtpDatumDo.Location = new Point(255, 196);
            dtpDatumDo.Margin = new Padding(3, 4, 3, 4);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(220, 30);
            dtpDatumDo.TabIndex = 5;
            // 
            // lblClanstvo
            // 
            lblClanstvo.AutoSize = true;
            lblClanstvo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblClanstvo.Location = new Point(23, 250);
            lblClanstvo.Name = "lblClanstvo";
            lblClanstvo.Size = new Size(108, 23);
            lblClanstvo.TabIndex = 10;
            lblClanstvo.Text = "Tip članarine:";
            // 
            // cmbClanstvo
            // 
            cmbClanstvo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClanstvo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbClanstvo.FormattingEnabled = true;
            cmbClanstvo.Location = new Point(23, 276);
            cmbClanstvo.Margin = new Padding(3, 4, 3, 4);
            cmbClanstvo.Name = "cmbClanstvo";
            cmbClanstvo.Size = new Size(220, 31);
            cmbClanstvo.TabIndex = 6;
            cmbClanstvo.SelectedIndexChanged += cmbClanstvo_SelectedIndexChanged;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(18, 27, 41);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(23, 340);
            btnSacuvaj.Margin = new Padding(3, 4, 3, 4);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(220, 50);
            btnSacuvaj.TabIndex = 7;
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
            btnOcisti.Location = new Point(255, 340);
            btnOcisti.Margin = new Padding(3, 4, 3, 4);
            btnOcisti.Name = "btnOcisti";
            btnOcisti.Size = new Size(220, 50);
            btnOcisti.TabIndex = 8;
            btnOcisti.Text = "Očisti";
            btnOcisti.UseVisualStyleBackColor = false;
            btnOcisti.Click += btnOcisti_Click;
            // 
            // UCDodajClana
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlForma);
            Controls.Add(lblNaslov);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UCDodajClana";
            Size = new Size(700, 620);
            pnlForma.ResumeLayout(false);
            pnlForma.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Panel pnlForma;
        private Label lblIme;
        private TextBox txtIme;
        private Label lblPrezime;
        private TextBox txtPrezime;
        private Label lblTelefon;
        private TextBox txtTelefon;
        private Label lblDatumOd;
        private DateTimePicker dtpDatumOd;
        private Label lblDatumDo;
        private DateTimePicker dtpDatumDo;
        private Label lblClanstvo;
        private ComboBox cmbClanstvo;
        private Button btnSacuvaj;
        private Button btnOcisti;
    }
}
