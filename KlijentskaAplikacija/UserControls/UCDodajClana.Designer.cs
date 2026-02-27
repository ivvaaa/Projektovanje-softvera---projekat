namespace KlijentskaAplikacija.UserControls
{
    partial class UCDodajClana
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNaslov = new Label();
            pnlForma = new Panel();
            lblIme = new Label(); txtIme = new TextBox();
            lblPrezime = new Label(); txtPrezime = new TextBox();
            lblTelefon = new Label(); txtTelefon = new TextBox();
            // Redosled: tip → početak → (readonly) kraj
            lblClanstvo = new Label(); cmbClanstvo = new ComboBox();
            lblDatumOd = new Label(); dtpDatumOd = new DateTimePicker();
            lblDatumDo = new Label(); dtpDatumDo = new DateTimePicker();
            btnSacuvaj = new Button(); btnOcisti = new Button();

            pnlForma.SuspendLayout();
            SuspendLayout();

            // lblNaslov
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(23, 20);
            lblNaslov.Text = "Dodaj novog člana";

            // pnlForma
            pnlForma.BackColor = Color.White;
            pnlForma.BorderStyle = BorderStyle.FixedSingle;
            pnlForma.Padding = new Padding(23, 20, 23, 20);
            pnlForma.Location = new Point(23, 70);
            pnlForma.Size = new Size(500, 500);
            pnlForma.Controls.AddRange(new Control[] {
                lblIme, txtIme, lblPrezime, txtPrezime,
                lblTelefon, txtTelefon,
                lblClanstvo, cmbClanstvo,
                lblDatumOd, dtpDatumOd,
                lblDatumDo, dtpDatumDo,
                btnSacuvaj, btnOcisti
            });

            // Ime + Prezime (red 1)
            lblIme.AutoSize = true; lblIme.Font = new Font("Segoe UI", 10F);
            lblIme.Location = new Point(23, 20); lblIme.Text = "Ime:";
            txtIme.Font = new Font("Segoe UI", 10F);
            txtIme.Location = new Point(23, 43); txtIme.Size = new Size(210, 30);

            lblPrezime.AutoSize = true; lblPrezime.Font = new Font("Segoe UI", 10F);
            lblPrezime.Location = new Point(245, 20); lblPrezime.Text = "Prezime:";
            txtPrezime.Font = new Font("Segoe UI", 10F);
            txtPrezime.Location = new Point(245, 43); txtPrezime.Size = new Size(210, 30);

            // Telefon (red 2)
            lblTelefon.AutoSize = true; lblTelefon.Font = new Font("Segoe UI", 10F);
            lblTelefon.Location = new Point(23, 90); lblTelefon.Text = "Telefon:";
            txtTelefon.Font = new Font("Segoe UI", 10F);
            txtTelefon.Location = new Point(23, 113); txtTelefon.Size = new Size(210, 30);
            txtTelefon.KeyPress += txtTelefon_KeyPress;

            // Tip članarine (red 3) — PRVI od datumskih polja
            lblClanstvo.AutoSize = true; lblClanstvo.Font = new Font("Segoe UI", 10F);
            lblClanstvo.Location = new Point(23, 163); lblClanstvo.Text = "Tip članarine:";
            cmbClanstvo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClanstvo.Font = new Font("Segoe UI", 10F);
            cmbClanstvo.Location = new Point(23, 186); cmbClanstvo.Size = new Size(210, 31);
            cmbClanstvo.SelectedIndexChanged += cmbClanstvo_SelectedIndexChanged;

            // Početak članarine (red 4)
            lblDatumOd.AutoSize = true; lblDatumOd.Font = new Font("Segoe UI", 10F);
            lblDatumOd.Location = new Point(23, 236); lblDatumOd.Text = "Početak članarine:";
            dtpDatumOd.Font = new Font("Segoe UI", 10F); dtpDatumOd.Format = DateTimePickerFormat.Short;
            dtpDatumOd.Location = new Point(23, 259); dtpDatumOd.Size = new Size(210, 30);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;

            // Istek članarine — READONLY, automatski izračunat (red 5)
            lblDatumDo.AutoSize = true; lblDatumDo.Font = new Font("Segoe UI", 10F);
            lblDatumDo.Location = new Point(245, 236); lblDatumDo.Text = "Istek članarine:";
            dtpDatumDo.Font = new Font("Segoe UI", 10F); dtpDatumDo.Format = DateTimePickerFormat.Short;
            dtpDatumDo.Location = new Point(245, 259); dtpDatumDo.Size = new Size(210, 30);
            dtpDatumDo.Enabled = false;  // Korisnik ne može da menja

            
            // Dugmad
            btnSacuvaj.BackColor = Color.FromArgb(18, 27, 41);
            btnSacuvaj.Cursor = Cursors.Hand; btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(23, 380); btnSacuvaj.Size = new Size(210, 48);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.Click += btnSacuvaj_Click;

            btnOcisti.BackColor = Color.Gray;
            btnOcisti.Cursor = Cursors.Hand; btnOcisti.FlatStyle = FlatStyle.Flat;
            btnOcisti.FlatAppearance.BorderSize = 0;
            btnOcisti.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOcisti.ForeColor = Color.White;
            btnOcisti.Location = new Point(245, 380); btnOcisti.Size = new Size(210, 48);
            btnOcisti.Text = "Očisti"; btnOcisti.Click += btnOcisti_Click;

            // UCDodajClana
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlForma); Controls.Add(lblNaslov);
            Name = "UCDodajClana"; Size = new Size(700, 620);

            pnlForma.ResumeLayout(false); pnlForma.PerformLayout();
            ResumeLayout(false); PerformLayout();
        }

        private Label lblNaslov;
        private Panel pnlForma;
        private Label lblIme; private TextBox txtIme;
        private Label lblPrezime; private TextBox txtPrezime;
        private Label lblTelefon; private TextBox txtTelefon;
        private Label lblClanstvo; private ComboBox cmbClanstvo;
        private Label lblDatumOd; private DateTimePicker dtpDatumOd;
        private Label lblDatumDo; private DateTimePicker dtpDatumDo;
        private Button btnSacuvaj; private Button btnOcisti;
    }
}
