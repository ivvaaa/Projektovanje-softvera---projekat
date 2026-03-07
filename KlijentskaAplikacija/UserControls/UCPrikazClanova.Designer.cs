namespace KlijentskaAplikacija.UserControls
{
    partial class UCPrikazClanova
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();

            pnlTop = new Panel();
            lblNaslov = new Label();
            lblKriterijum = new Label();
            txtKriterijum = new TextBox();
            lblClanstvoFilter = new Label();
            cmbClanstvoFilter = new ComboBox();
            btnPretrazi = new Button();
            btnReset = new Button();
            lblBroj = new Label();

            pnlContent = new Panel();
            pnlLista = new Panel();
            pnlGrid = new Panel();
            dgvClanovi = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colIme = new DataGridViewTextBoxColumn();
            colPrezime = new DataGridViewTextBoxColumn();
            colTelefon = new DataGridViewTextBoxColumn();
            colCheck = new DataGridViewCheckBoxColumn();
            bindingSource1 = new BindingSource(components);

            pnlDetalji = new Panel();
            pnlDetaljiHeader = new Panel();
            lblDetaljiNaslov = new Label();
            pnlDetaljiContent = new Panel();
            pnlStatusBar = new Panel();
            lblStatus = new Label();

            lblClanstvoLabela = new Label();
            lblClanstvoVrednost = new Label();
            lblDatumOd = new Label();
            lblDatumOdVrednost = new Label();
            lblDatumDo = new Label();
            lblDatumDoVrednost = new Label();

            grpIzmena = new GroupBox();
            lblIzmeniIme = new Label();
            txtIzmeniIme = new TextBox();
            lblIzmeniPrezime = new Label();
            txtIzmeniPrezime = new TextBox();
            lblIzmeniTelefon = new Label();
            txtIzmeniTelefon = new TextBox();
            btnSacuvaj = new Button();
            btnPonisti = new Button();
            btnObrisiSelektovanog = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvClanovi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            pnlTop.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlLista.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlDetalji.SuspendLayout();
            pnlDetaljiHeader.SuspendLayout();
            pnlDetaljiContent.SuspendLayout();
            pnlStatusBar.SuspendLayout();
            grpIzmena.SuspendLayout();
            SuspendLayout();

            // pnlTop
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Controls.Add(lblNaslov);
            pnlTop.Controls.Add(lblKriterijum);
            pnlTop.Controls.Add(txtKriterijum);
            pnlTop.Controls.Add(lblClanstvoFilter);
            pnlTop.Controls.Add(cmbClanstvoFilter);
            pnlTop.Controls.Add(btnPretrazi);
            pnlTop.Controls.Add(btnReset);
            pnlTop.Controls.Add(lblBroj);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 90);

            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(0, 0);
            lblNaslov.Text = "Pregled članova";

            lblKriterijum.AutoSize = true;
            lblKriterijum.Location = new Point(0, 45);
            lblKriterijum.Text = "Pretraga:";

            txtKriterijum.BorderStyle = BorderStyle.FixedSingle;
            txtKriterijum.Location = new Point(80, 42);
            txtKriterijum.Size = new Size(200, 27);
            txtKriterijum.TabIndex = 1;
            txtKriterijum.KeyDown += txtKriterijum_KeyDown;

            lblClanstvoFilter.AutoSize = true;
            lblClanstvoFilter.Location = new Point(290, 45);
            lblClanstvoFilter.Text = "Članstvo:";

            cmbClanstvoFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClanstvoFilter.FlatStyle = FlatStyle.Flat;
            cmbClanstvoFilter.Font = new Font("Segoe UI", 9F);
            cmbClanstvoFilter.Location = new Point(360, 41);
            cmbClanstvoFilter.Size = new Size(140, 28);
            cmbClanstvoFilter.TabIndex = 2;

            btnPretrazi.BackColor = Color.FromArgb(18, 27, 41);
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(510, 40);
            btnPretrazi.Size = new Size(90, 32);
            btnPretrazi.Text = "Prikaži";
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.Click += btnPretrazi_Click;

            btnReset.BackColor = Color.Gray;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(610, 40);
            btnReset.Size = new Size(90, 32);
            btnReset.Text = "Poništi";
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += btnReset_Click;


            lblBroj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBroj.ForeColor = Color.FromArgb(18, 27, 41);
            lblBroj.Location = new Point(670, 47);
            lblBroj.Text = "Ukupno: 0";

            // pnlContent
            pnlContent.Controls.Add(pnlDetalji);
            pnlContent.Controls.Add(pnlLista);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Name = "pnlContent";

            // pnlLista
            pnlLista.Controls.Add(pnlGrid);
            pnlLista.Dock = DockStyle.Left;
            pnlLista.Size = new Size(420, 500);

            // pnlGrid
            pnlGrid.Controls.Add(dgvClanovi);
            pnlGrid.Dock = DockStyle.Fill;

            // dgvClanovi
            dgvClanovi.AllowUserToAddRows = false;
            dgvClanovi.AllowUserToDeleteRows = false;
            dgvClanovi.AutoGenerateColumns = false;
            dgvClanovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClanovi.BackgroundColor = Color.White;
            dgvClanovi.BorderStyle = BorderStyle.None;
            dgvClanovi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClanovi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            headerStyle.BackColor = Color.FromArgb(18, 27, 41);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(18, 27, 41);
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvClanovi.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvClanovi.ColumnHeadersHeight = 40;
            dgvClanovi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvClanovi.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dgvClanovi.DefaultCellStyle = dataGridViewCellStyle1;
            dgvClanovi.RowTemplate.Height = 45;
            dgvClanovi.Dock = DockStyle.Fill;
            dgvClanovi.GridColor = Color.FromArgb(230, 230, 230);
            dgvClanovi.MultiSelect = false;
            dgvClanovi.RowHeadersVisible = false;
            dgvClanovi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Visible = false;

            colIme.DataPropertyName = "Ime";
            colIme.HeaderText = "Ime";
            colIme.ReadOnly = true;
            colIme.FillWeight = 30;

            colPrezime.DataPropertyName = "Prezime";
            colPrezime.HeaderText = "Prezime";
            colPrezime.ReadOnly = true;
            colPrezime.FillWeight = 30;

            colTelefon.DataPropertyName = "Telefon";
            colTelefon.HeaderText = "Telefon";
            colTelefon.ReadOnly = true;
            colTelefon.FillWeight = 30;

            colCheck.Name = "colCheck";
            colCheck.FalseValue = false;
            colCheck.HeaderText = "✓";
            colCheck.FillWeight = 10;
            colCheck.TrueValue = true;

            dgvClanovi.Columns.AddRange(new DataGridViewColumn[] { colId, colIme, colPrezime, colTelefon, colCheck });
            dgvClanovi.DataSource = bindingSource1;

            // pnlDetalji
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.Controls.Add(pnlDetaljiContent);
            pnlDetalji.Controls.Add(pnlDetaljiHeader);
            pnlDetalji.Dock = DockStyle.Fill;
            pnlDetalji.Location = new Point(430, 0);
            pnlDetalji.Padding = new Padding(15, 0, 0, 0);
            pnlDetalji.Size = new Size(370, 500);

            pnlDetaljiHeader.BackColor = Color.FromArgb(18, 27, 41);
            pnlDetaljiHeader.Controls.Add(lblDetaljiNaslov);
            pnlDetaljiHeader.Dock = DockStyle.Top;
            pnlDetaljiHeader.Size = new Size(355, 45);

            lblDetaljiNaslov.AutoSize = true;
            lblDetaljiNaslov.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetaljiNaslov.ForeColor = Color.White;
            lblDetaljiNaslov.Location = new Point(15, 10);
            lblDetaljiNaslov.Text = "Detalji člana";

            pnlDetaljiContent.BackColor = Color.White;
            pnlDetaljiContent.Controls.Add(pnlStatusBar);
            pnlDetaljiContent.Controls.Add(lblClanstvoLabela);
            pnlDetaljiContent.Controls.Add(lblClanstvoVrednost);
            pnlDetaljiContent.Controls.Add(lblDatumOd);
            pnlDetaljiContent.Controls.Add(lblDatumOdVrednost);
            pnlDetaljiContent.Controls.Add(lblDatumDo);
            pnlDetaljiContent.Controls.Add(lblDatumDoVrednost);
            pnlDetaljiContent.Controls.Add(grpIzmena);
            pnlDetaljiContent.Controls.Add(btnObrisiSelektovanog);
            pnlDetaljiContent.Dock = DockStyle.Fill;
            pnlDetaljiContent.Padding = new Padding(15);

            // pnlStatusBar
            pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Location = new Point(15, 15);
            pnlStatusBar.Size = new Size(310, 35);

            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            lblStatus.Location = new Point(10, 8);
            lblStatus.Text = "Aktivna članarina";

            // Clanstvo
            lblClanstvoLabela.AutoSize = true;
            lblClanstvoLabela.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClanstvoLabela.ForeColor = Color.Gray;
            lblClanstvoLabela.Location = new Point(15, 60);
            lblClanstvoLabela.Text = "VRSTA ČLANSTVA";

            lblClanstvoVrednost.AutoSize = true;
            lblClanstvoVrednost.Font = new Font("Segoe UI", 10F);
            lblClanstvoVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblClanstvoVrednost.Location = new Point(15, 80);
            lblClanstvoVrednost.Text = "-";

            // Datumi
            lblDatumOd.AutoSize = true;
            lblDatumOd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatumOd.ForeColor = Color.Gray;
            lblDatumOd.Location = new Point(15, 105);
            lblDatumOd.Text = "ČLAN OD";

            lblDatumOdVrednost.AutoSize = true;
            lblDatumOdVrednost.Font = new Font("Segoe UI", 10F);
            lblDatumOdVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblDatumOdVrednost.Location = new Point(15, 125);
            lblDatumOdVrednost.Text = "-";

            lblDatumDo.AutoSize = true;
            lblDatumDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatumDo.ForeColor = Color.Gray;
            lblDatumDo.Location = new Point(160, 105);
            lblDatumDo.Text = "ČLAN DO";

            lblDatumDoVrednost.AutoSize = true;
            lblDatumDoVrednost.Font = new Font("Segoe UI", 10F);
            lblDatumDoVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblDatumDoVrednost.Location = new Point(160, 125);
            lblDatumDoVrednost.Text = "-";

            // grpIzmena - uvek vidljiv GroupBox (kao kod knjiga)
            grpIzmena.Controls.Add(lblIzmeniIme);
            grpIzmena.Controls.Add(txtIzmeniIme);
            grpIzmena.Controls.Add(lblIzmeniPrezime);
            grpIzmena.Controls.Add(txtIzmeniPrezime);
            grpIzmena.Controls.Add(lblIzmeniTelefon);
            grpIzmena.Controls.Add(txtIzmeniTelefon);
            grpIzmena.Controls.Add(btnSacuvaj);
            grpIzmena.Controls.Add(btnPonisti);
            grpIzmena.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpIzmena.ForeColor = Color.FromArgb(18, 27, 41);
            grpIzmena.Location = new Point(15, 155);
            grpIzmena.Size = new Size(315, 230);
            grpIzmena.Text = "Izmeni člana";

            lblIzmeniIme.AutoSize = true;
            lblIzmeniIme.Font = new Font("Segoe UI", 9F);
            lblIzmeniIme.ForeColor = Color.Gray;
            lblIzmeniIme.Location = new Point(10, 28);
            lblIzmeniIme.Text = "Ime:";

            txtIzmeniIme.BorderStyle = BorderStyle.FixedSingle;
            txtIzmeniIme.Font = new Font("Segoe UI", 10F);
            txtIzmeniIme.Location = new Point(10, 48);
            txtIzmeniIme.Size = new Size(290, 27);

            lblIzmeniPrezime.AutoSize = true;
            lblIzmeniPrezime.Font = new Font("Segoe UI", 9F);
            lblIzmeniPrezime.ForeColor = Color.Gray;
            lblIzmeniPrezime.Location = new Point(10, 83);
            lblIzmeniPrezime.Text = "Prezime:";

            txtIzmeniPrezime.BorderStyle = BorderStyle.FixedSingle;
            txtIzmeniPrezime.Font = new Font("Segoe UI", 10F);
            txtIzmeniPrezime.Location = new Point(10, 103);
            txtIzmeniPrezime.Size = new Size(290, 27);

            lblIzmeniTelefon.AutoSize = true;
            lblIzmeniTelefon.Font = new Font("Segoe UI", 9F);
            lblIzmeniTelefon.ForeColor = Color.Gray;
            lblIzmeniTelefon.Location = new Point(10, 138);
            lblIzmeniTelefon.Text = "Telefon:";

            txtIzmeniTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtIzmeniTelefon.Font = new Font("Segoe UI", 10F);
            txtIzmeniTelefon.Location = new Point(10, 158);
            txtIzmeniTelefon.Size = new Size(290, 27);

            btnSacuvaj.BackColor = Color.FromArgb(40, 167, 69);
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(10, 193);
            btnSacuvaj.Size = new Size(135, 30);
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.Click += btnSacuvaj_Click;

            btnPonisti.BackColor = Color.Gray;
            btnPonisti.FlatAppearance.BorderSize = 0;
            btnPonisti.FlatStyle = FlatStyle.Flat;
            btnPonisti.ForeColor = Color.White;
            btnPonisti.Location = new Point(155, 193);
            btnPonisti.Size = new Size(135, 30);
            btnPonisti.Text = "Poništi";
            btnPonisti.Cursor = Cursors.Hand;
            btnPonisti.Click += btnPonisti_Click;

            // btnObrisiSelektovanog - ispod GroupBox-a
            btnObrisiSelektovanog.BackColor = Color.FromArgb(220, 53, 69);
            btnObrisiSelektovanog.FlatAppearance.BorderSize = 0;
            btnObrisiSelektovanog.FlatStyle = FlatStyle.Flat;
            btnObrisiSelektovanog.ForeColor = Color.White;
            btnObrisiSelektovanog.Location = new Point(15, 395);
            btnObrisiSelektovanog.Size = new Size(315, 35);
            btnObrisiSelektovanog.Text = "Obriši ovog člana";
            btnObrisiSelektovanog.Cursor = Cursors.Hand;
            btnObrisiSelektovanog.Click += btnObrisiSelektovanog_Click;

            // UCPrikazClanova
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlContent);
            Controls.Add(pnlTop);
            Padding = new Padding(20);
            Size = new Size(800, 600);

            ((System.ComponentModel.ISupportInitialize)dgvClanovi).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlLista.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            pnlDetalji.ResumeLayout(false);
            pnlDetaljiHeader.ResumeLayout(false);
            pnlDetaljiHeader.PerformLayout();
            pnlDetaljiContent.ResumeLayout(false);
            pnlDetaljiContent.PerformLayout();
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            grpIzmena.ResumeLayout(false);
            grpIzmena.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblNaslov;
        private Label lblKriterijum;
        private TextBox txtKriterijum;
        private Label lblClanstvoFilter;
        private ComboBox cmbClanstvoFilter;
        private Button btnPretrazi;
        private Button btnReset;
        private Label lblBroj;

        private Panel pnlContent;
        private Panel pnlLista;
        private Panel pnlGrid;
        private DataGridView dgvClanovi;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colIme;
        private DataGridViewTextBoxColumn colPrezime;
        private DataGridViewTextBoxColumn colTelefon;
        private DataGridViewCheckBoxColumn colCheck;
        private BindingSource bindingSource1;

        private Panel pnlDetalji;
        private Panel pnlDetaljiHeader;
        private Label lblDetaljiNaslov;
        private Panel pnlDetaljiContent;
        private Panel pnlStatusBar;
        private Label lblStatus;

        private Label lblClanstvoLabela;
        private Label lblClanstvoVrednost;
        private Label lblDatumOd;
        private Label lblDatumOdVrednost;
        private Label lblDatumDo;
        private Label lblDatumDoVrednost;

        private GroupBox grpIzmena;
        private Label lblIzmeniIme;
        private TextBox txtIzmeniIme;
        private Label lblIzmeniPrezime;
        private TextBox txtIzmeniPrezime;
        private Label lblIzmeniTelefon;
        private TextBox txtIzmeniTelefon;
        private Button btnSacuvaj;
        private Button btnPonisti;
        private Button btnObrisiSelektovanog;
    }
}