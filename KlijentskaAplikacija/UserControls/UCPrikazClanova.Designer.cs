namespace KlijentskaAplikacija.UserControls
{
    partial class UCPrikazClanova
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();

            // Komponente
            pnlTop = new Panel();
            lblNaslov = new Label();
            lblKriterijum = new Label();
            txtKriterijum = new TextBox();
            btnPretrazi = new Button();
            btnReset = new Button();
            btnObrisi = new Button();
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

            lblImeLabela = new Label();
            lblImeVrednost = new Label();
            lblPrezimeLabela = new Label();
            lblPrezimeVrednost = new Label();
            lblTelefonLabela = new Label();
            lblTelefonVrednost = new Label();
            lblDatumOd = new Label();
            lblDatumOdVrednost = new Label();
            lblDatumDo = new Label();
            lblDatumDoVrednost = new Label();

            btnIzmeni = new Button();
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
            SuspendLayout();

            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Controls.Add(lblNaslov);
            pnlTop.Controls.Add(lblKriterijum);
            pnlTop.Controls.Add(txtKriterijum);
            pnlTop.Controls.Add(btnPretrazi);
            pnlTop.Controls.Add(btnReset);
            pnlTop.Controls.Add(btnObrisi);
            pnlTop.Controls.Add(lblBroj);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(20, 20);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(760, 90);
            pnlTop.TabIndex = 0;

            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(0, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(180, 32);
            lblNaslov.Text = "Pregled članova";

            // 
            // lblKriterijum
            // 
            lblKriterijum.AutoSize = true;
            lblKriterijum.Location = new Point(0, 45);
            lblKriterijum.Name = "lblKriterijum";
            lblKriterijum.Size = new Size(68, 20);
            lblKriterijum.Text = "Pretraga:";

            // 
            // txtKriterijum
            // 
            txtKriterijum.BorderStyle = BorderStyle.FixedSingle;
            txtKriterijum.Location = new Point(80, 42);
            txtKriterijum.Name = "txtKriterijum";
            txtKriterijum.Size = new Size(200, 27);
            txtKriterijum.TabIndex = 1;
            txtKriterijum.KeyDown += txtKriterijum_KeyDown;

            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.FromArgb(18, 27, 41);
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(290, 40);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(90, 32);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Prikaži";
            btnPretrazi.UseVisualStyleBackColor = false;
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.Click += btnPretrazi_Click;

            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gray;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(390, 40);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 32);
            btnReset.TabIndex = 3;
            btnReset.Text = "Poništi";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += btnReset_Click;

            // 
            // btnObrisi
            // 
            btnObrisi.BackColor = Color.FromArgb(220, 53, 69);
            btnObrisi.FlatAppearance.BorderSize = 0;
            btnObrisi.FlatStyle = FlatStyle.Flat;
            btnObrisi.ForeColor = Color.White;
            btnObrisi.Location = new Point(490, 40);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(120, 32);
            btnObrisi.TabIndex = 4;
            btnObrisi.Text = "Obriši označene";
            btnObrisi.UseVisualStyleBackColor = false;
            btnObrisi.Cursor = Cursors.Hand;
            btnObrisi.Click += btnObrisi_Click;

            // 
            // lblBroj
            // 
            lblBroj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBroj.ForeColor = Color.FromArgb(18, 27, 41);
            lblBroj.Location = new Point(670, 47);
            lblBroj.Name = "lblBroj";
            lblBroj.Size = new Size(81, 20);
            lblBroj.Text = "Ukupno: 0";

            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlDetalji);
            pnlContent.Controls.Add(pnlLista);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(20, 110);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(760, 370);
            pnlContent.TabIndex = 1;

            // 
            // pnlLista
            // 
            pnlLista.Controls.Add(pnlGrid);
            pnlLista.Dock = DockStyle.Left;
            pnlLista.Location = new Point(0, 0);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(420, 370);
            pnlLista.TabIndex = 0;

            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvClanovi);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Name = "pnlGrid";

            // 
            // dgvClanovi
            // 
            dgvClanovi.AllowUserToAddRows = false;
            dgvClanovi.AllowUserToDeleteRows = false;
            dgvClanovi.AutoGenerateColumns = false;
            dgvClanovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClanovi.BackgroundColor = Color.White;
            dgvClanovi.BorderStyle = BorderStyle.None;
            dgvClanovi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClanovi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Header style
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

            // Cell style
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
            dgvClanovi.Name = "dgvClanovi";
            dgvClanovi.RowHeadersVisible = false;
            dgvClanovi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClanovi.TabIndex = 0;

            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Visible = false;

            // 
            // colIme
            // 
            colIme.DataPropertyName = "Ime";
            colIme.HeaderText = "Ime";
            colIme.Name = "colIme";
            colIme.ReadOnly = true;
            colIme.FillWeight = 30;

            // 
            // colPrezime
            // 
            colPrezime.DataPropertyName = "Prezime";
            colPrezime.HeaderText = "Prezime";
            colPrezime.Name = "colPrezime";
            colPrezime.ReadOnly = true;
            colPrezime.FillWeight = 30;

            // 
            // colTelefon
            // 
            colTelefon.DataPropertyName = "Telefon";
            colTelefon.HeaderText = "Telefon";
            colTelefon.Name = "colTelefon";
            colTelefon.ReadOnly = true;
            colTelefon.FillWeight = 30;

            // 
            // colCheck
            // 
            colCheck.FalseValue = false;
            colCheck.HeaderText = "✓";
            colCheck.Name = "colCheck";
            colCheck.TrueValue = true;
            colCheck.FillWeight = 10;

            // Dodaj kolone u DataGridView
            dgvClanovi.Columns.AddRange(new DataGridViewColumn[] { colId, colIme, colPrezime, colTelefon, colCheck });
            dgvClanovi.DataSource = bindingSource1;

            // 
            // pnlDetalji
            // 
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.Controls.Add(pnlDetaljiContent);
            pnlDetalji.Controls.Add(pnlDetaljiHeader);
            pnlDetalji.Dock = DockStyle.Fill;
            pnlDetalji.Location = new Point(430, 0);
            pnlDetalji.Name = "pnlDetalji";
            pnlDetalji.Padding = new Padding(15, 0, 0, 0);
            pnlDetalji.Size = new Size(330, 370);
            pnlDetalji.TabIndex = 1;

            // 
            // pnlDetaljiHeader
            // 
            pnlDetaljiHeader.BackColor = Color.FromArgb(18, 27, 41);
            pnlDetaljiHeader.Controls.Add(lblDetaljiNaslov);
            pnlDetaljiHeader.Dock = DockStyle.Top;
            pnlDetaljiHeader.Location = new Point(15, 0);
            pnlDetaljiHeader.Name = "pnlDetaljiHeader";
            pnlDetaljiHeader.Size = new Size(315, 45);
            pnlDetaljiHeader.TabIndex = 0;

            // 
            // lblDetaljiNaslov
            // 
            lblDetaljiNaslov.AutoSize = true;
            lblDetaljiNaslov.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetaljiNaslov.ForeColor = Color.White;
            lblDetaljiNaslov.Location = new Point(15, 10);
            lblDetaljiNaslov.Name = "lblDetaljiNaslov";
            lblDetaljiNaslov.Text = "Detalji člana";

            // 
            // pnlDetaljiContent
            // 
            pnlDetaljiContent.BackColor = Color.White;
            pnlDetaljiContent.Controls.Add(pnlStatusBar);
            pnlDetaljiContent.Controls.Add(lblImeLabela);
            pnlDetaljiContent.Controls.Add(lblImeVrednost);
            pnlDetaljiContent.Controls.Add(lblPrezimeLabela);
            pnlDetaljiContent.Controls.Add(lblPrezimeVrednost);
            pnlDetaljiContent.Controls.Add(lblTelefonLabela);
            pnlDetaljiContent.Controls.Add(lblTelefonVrednost);
            pnlDetaljiContent.Controls.Add(lblDatumOd);
            pnlDetaljiContent.Controls.Add(lblDatumOdVrednost);
            pnlDetaljiContent.Controls.Add(lblDatumDo);
            pnlDetaljiContent.Controls.Add(lblDatumDoVrednost);
            pnlDetaljiContent.Controls.Add(btnIzmeni);
            pnlDetaljiContent.Controls.Add(btnObrisiSelektovanog);
            pnlDetaljiContent.Controls.Add(txtIzmeniIme);
            pnlDetaljiContent.Controls.Add(txtIzmeniPrezime);
            pnlDetaljiContent.Controls.Add(txtIzmeniTelefon);
            pnlDetaljiContent.Dock = DockStyle.Fill;
            pnlDetaljiContent.Location = new Point(15, 45);
            pnlDetaljiContent.Name = "pnlDetaljiContent";
            pnlDetaljiContent.Padding = new Padding(15);
            pnlDetaljiContent.Size = new Size(315, 325);
            pnlDetaljiContent.TabIndex = 1;

            // 
            // pnlStatusBar
            // 
            pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Location = new Point(15, 15);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(280, 35);
            pnlStatusBar.TabIndex = 0;

            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            lblStatus.Location = new Point(10, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Aktivna članarina";

            // 
            // lblImeLabela
            // 
            lblImeLabela.AutoSize = true;
            lblImeLabela.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImeLabela.ForeColor = Color.Gray;
            lblImeLabela.Location = new Point(15, 70);
            lblImeLabela.Name = "lblImeLabela";
            lblImeLabela.Text = "IME";

            // 
            // lblImeVrednost
            // 
            lblImeVrednost.AutoSize = true;
            lblImeVrednost.Font = new Font("Segoe UI", 10F);
            lblImeVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblImeVrednost.Location = new Point(15, 90);
            lblImeVrednost.Name = "lblImeVrednost";
            lblImeVrednost.Text = "-";

            // 
            // lblPrezimeLabela
            // 
            lblPrezimeLabela.AutoSize = true;
            lblPrezimeLabela.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrezimeLabela.ForeColor = Color.Gray;
            lblPrezimeLabela.Location = new Point(15, 115);
            lblPrezimeLabela.Name = "lblPrezimeLabela";
            lblPrezimeLabela.Text = "PREZIME";

            // 
            // lblPrezimeVrednost
            // 
            lblPrezimeVrednost.AutoSize = true;
            lblPrezimeVrednost.Font = new Font("Segoe UI", 10F);
            lblPrezimeVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblPrezimeVrednost.Location = new Point(15, 135);
            lblPrezimeVrednost.Name = "lblPrezimeVrednost";
            lblPrezimeVrednost.Text = "-";

            // 
            // lblTelefonLabela
            // 
            lblTelefonLabela.AutoSize = true;
            lblTelefonLabela.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefonLabela.ForeColor = Color.Gray;
            lblTelefonLabela.Location = new Point(15, 160);
            lblTelefonLabela.Name = "lblTelefonLabela";
            lblTelefonLabela.Text = "TELEFON";

            // 
            // lblTelefonVrednost
            // 
            lblTelefonVrednost.AutoSize = true;
            lblTelefonVrednost.Font = new Font("Segoe UI", 10F);
            lblTelefonVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblTelefonVrednost.Location = new Point(15, 180);
            lblTelefonVrednost.Name = "lblTelefonVrednost";
            lblTelefonVrednost.Text = "-";

            // 
            // lblDatumOd
            // 
            lblDatumOd.AutoSize = true;
            lblDatumOd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatumOd.ForeColor = Color.Gray;
            lblDatumOd.Location = new Point(15, 205);
            lblDatumOd.Name = "lblDatumOd";
            lblDatumOd.Text = "ČLAN OD";

            // 
            // lblDatumOdVrednost
            // 
            lblDatumOdVrednost.AutoSize = true;
            lblDatumOdVrednost.Font = new Font("Segoe UI", 10F);
            lblDatumOdVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblDatumOdVrednost.Location = new Point(15, 225);
            lblDatumOdVrednost.Name = "lblDatumOdVrednost";
            lblDatumOdVrednost.Text = "-";

            // 
            // lblDatumDo
            // 
            lblDatumDo.AutoSize = true;
            lblDatumDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatumDo.ForeColor = Color.Gray;
            lblDatumDo.Location = new Point(150, 205);
            lblDatumDo.Name = "lblDatumDo";
            lblDatumDo.Text = "ČLAN DO";

            // 
            // lblDatumDoVrednost
            // 
            lblDatumDoVrednost.AutoSize = true;
            lblDatumDoVrednost.Font = new Font("Segoe UI", 10F);
            lblDatumDoVrednost.ForeColor = Color.FromArgb(50, 50, 50);
            lblDatumDoVrednost.Location = new Point(150, 225);
            lblDatumDoVrednost.Name = "lblDatumDoVrednost";
            lblDatumDoVrednost.Text = "-";
            // txtIzmeniIme
            txtIzmeniIme = new TextBox();
            txtIzmeniIme.Location = new Point(15, 90);
            txtIzmeniIme.Size = new Size(260, 27);
            txtIzmeniIme.Visible = false;
            txtIzmeniIme.Font = new Font("Segoe UI", 10F);
            txtIzmeniIme.Name = "txtIzmeniIme";

            // txtIzmeniPrezime
            txtIzmeniPrezime = new TextBox();
            txtIzmeniPrezime.Location = new Point(15, 135);
            txtIzmeniPrezime.Size = new Size(260, 27);
            txtIzmeniPrezime.Visible = false;
            txtIzmeniPrezime.Font = new Font("Segoe UI", 10F);
            txtIzmeniPrezime.Name = "txtIzmeniPrezime";

            // txtIzmeniTelefon
            txtIzmeniTelefon = new TextBox();
            txtIzmeniTelefon.Location = new Point(15, 180);
            txtIzmeniTelefon.Size = new Size(260, 27);
            txtIzmeniTelefon.Visible = false;
            txtIzmeniTelefon.Font = new Font("Segoe UI", 10F);
            txtIzmeniTelefon.Name = "txtIzmeniTelefon";
            // 
            // btnIzmeni
            // 
            btnIzmeni.BackColor = Color.FromArgb(18, 27, 41);
            btnIzmeni.FlatAppearance.BorderSize = 0;
            btnIzmeni.FlatStyle = FlatStyle.Flat;
            btnIzmeni.ForeColor = Color.White;
            btnIzmeni.Location = new Point(15, 270);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(130, 38);
            btnIzmeni.TabIndex = 10;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = false;
            btnIzmeni.Cursor = Cursors.Hand;
            btnIzmeni.Click += btnIzmeni_Click;

            // 
            // btnObrisiSelektovanog
            // 
            btnObrisiSelektovanog.BackColor = Color.Gray;
            btnObrisiSelektovanog.FlatAppearance.BorderSize = 0;
            btnObrisiSelektovanog.FlatStyle = FlatStyle.Flat;
            btnObrisiSelektovanog.ForeColor = Color.White;
            btnObrisiSelektovanog.Location = new Point(155, 270);
            btnObrisiSelektovanog.Name = "btnObrisiSelektovanog";
            btnObrisiSelektovanog.Size = new Size(130, 38);
            btnObrisiSelektovanog.TabIndex = 11;
            btnObrisiSelektovanog.Text = "Obriši";
            btnObrisiSelektovanog.UseVisualStyleBackColor = false;
            btnObrisiSelektovanog.Cursor = Cursors.Hand;
            btnObrisiSelektovanog.Click += btnObrisiSelektovanog_Click;

            // 
            // UCPrikazClanova
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlContent);
            Controls.Add(pnlTop);
            Name = "UCPrikazClanova";
            Padding = new Padding(20);
            Size = new Size(800, 500);

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
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblNaslov;
        private Label lblKriterijum;
        private TextBox txtKriterijum;
        private Button btnPretrazi;
        private Button btnReset;
        private Button btnObrisi;
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

        private Label lblImeLabela;
        private Label lblImeVrednost;
        private Label lblPrezimeLabela;
        private Label lblPrezimeVrednost;
        private Label lblTelefonLabela;
        private Label lblTelefonVrednost;
        private Label lblDatumOd;
        private Label lblDatumOdVrednost;
        private Label lblDatumDo;
        private Label lblDatumDoVrednost;
        private TextBox txtIzmeniIme;
        private TextBox txtIzmeniPrezime;
        private TextBox txtIzmeniTelefon;

        private Button btnIzmeni;
        private Button btnObrisiSelektovanog;
    }
}