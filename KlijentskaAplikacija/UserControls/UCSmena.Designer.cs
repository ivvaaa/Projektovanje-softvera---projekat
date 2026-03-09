namespace KlijentskaAplikacija.UserControls
{
    partial class UCSmena
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle styleHeader = new DataGridViewCellStyle();
            DataGridViewCellStyle styleCell = new DataGridViewCellStyle();

            bindingSource1 = new BindingSource(components);
            lblNaslov = new Label();
            pnlPretraga = new Panel();
            lblPretraga = new Label();
            txtKriterijum = new TextBox();
            btnPretrazi = new Button();
            btnReset = new Button();
            lblBroj = new Label();
            dgvSmene = new DataGridView();
            pnlDetalji = new Panel();
            lblDetaljiNaslov = new Label();
            lblBibliotekarLbl = new Label();
            lblBibliotekarVrednost = new Label();
            lblTerminLbl = new Label();
            lblTerminVrednost = new Label();
            lblDatumLbl = new Label();
            lblDatumVrednost = new Label();
            pnlStatusBar = new Panel();
            lblStatusLbl = new Label();
            lblStatusVrednost = new Label();
            btnZahtevZaPromenu = new Button();
            pnlZahtev = new Panel();
            lblZahtevNaslov = new Label();
            lblZahtevInfo = new Label();
            lblZahtevTerminLbl = new Label();
            cmbTerminZahtev = new ComboBox();
            lblZahtevDatumLbl = new Label();
            dtpZahtev = new DateTimePicker();
            btnPosaljiZahtev = new Button();
            btnOtkaziZahtev = new Button();

            pnlPretraga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSmene).BeginInit();
            pnlDetalji.SuspendLayout();
            pnlStatusBar.SuspendLayout();
            pnlZahtev.SuspendLayout();
            SuspendLayout();

            // ── lblNaslov ────────────────────────────────────────────
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(20, 15);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.TabIndex = 3;
            lblNaslov.Text = "Raspored smena";

            // ── pnlPretraga ──────────────────────────────────────────
            pnlPretraga.BackColor = Color.White;
            pnlPretraga.BorderStyle = BorderStyle.FixedSingle;
            pnlPretraga.Location = new Point(20, 55);
            pnlPretraga.Name = "pnlPretraga";
            pnlPretraga.Size = new Size(592, 48);
            pnlPretraga.TabIndex = 2;

            lblPretraga.AutoSize = true;
            lblPretraga.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            lblPretraga.Location = new Point(8, 12);
            lblPretraga.Name = "lblPretraga";
            lblPretraga.TabIndex = 0;
            lblPretraga.Text = "Pretraga:";

            txtKriterijum.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            txtKriterijum.Location = new Point(90, 10);
            txtKriterijum.Name = "txtKriterijum";
            txtKriterijum.PlaceholderText = "Pretraži po imenu bibliotekara...";
            txtKriterijum.Size = new Size(230, 30);
            txtKriterijum.TabIndex = 1;
            txtKriterijum.KeyDown += txtKriterijum_KeyDown;

            btnPretrazi.BackColor = Color.FromArgb(18, 27, 41);
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(328, 9);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(85, 28);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            btnPretrazi.Click += btnPretrazi_Click;

            btnReset.BackColor = Color.Gray;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(419, 9);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(70, 28);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;

            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBroj.ForeColor = Color.Gray;
            lblBroj.Location = new Point(495, 15);
            lblBroj.Name = "lblBroj";
            lblBroj.TabIndex = 4;
            lblBroj.Text = "Ukupno: 0";

            pnlPretraga.Controls.AddRange(new Control[] {
                lblPretraga, txtKriterijum, btnPretrazi, btnReset, lblBroj });

            // ── dgvSmene ─────────────────────────────────────────────
            styleHeader.BackColor = Color.FromArgb(18, 27, 41);
            styleHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            styleHeader.ForeColor = Color.White;
            styleHeader.SelectionBackColor = Color.FromArgb(18, 27, 41);
            styleHeader.SelectionForeColor = Color.White;

            styleCell.Alignment = DataGridViewContentAlignment.MiddleLeft;
            styleCell.BackColor = Color.White;
            styleCell.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            styleCell.ForeColor = Color.FromArgb(50, 50, 50);
            styleCell.SelectionBackColor = Color.FromArgb(210, 228, 255);
            styleCell.SelectionForeColor = Color.FromArgb(30, 30, 30);
            styleCell.WrapMode = DataGridViewTriState.False;

            dgvSmene.AllowUserToAddRows = false;
            dgvSmene.AllowUserToDeleteRows = false;
            dgvSmene.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvSmene.AutoGenerateColumns = false;
            dgvSmene.BackgroundColor = Color.White;
            dgvSmene.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSmene.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSmene.ColumnHeadersDefaultCellStyle = styleHeader;
            dgvSmene.ColumnHeadersHeight = 36;
            dgvSmene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSmene.DataSource = bindingSource1;
            dgvSmene.DefaultCellStyle = styleCell;
            dgvSmene.EnableHeadersVisualStyles = false;
            dgvSmene.GridColor = Color.FromArgb(230, 230, 230);
            dgvSmene.Location = new Point(20, 110);
            dgvSmene.MultiSelect = false;
            dgvSmene.Name = "dgvSmene";
            dgvSmene.ReadOnly = true;
            dgvSmene.RowHeadersVisible = false;
            dgvSmene.RowTemplate.Height = 38;
            dgvSmene.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSmene.Size = new Size(592, 440);
            dgvSmene.TabIndex = 1;

            dgvSmene.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn {
                    DataPropertyName = "ImeBibliotekara", HeaderText = "Bibliotekar",
                    Width = 160, ReadOnly = true, Name = "colBibliotekar" },
                new DataGridViewTextBoxColumn {
                    DataPropertyName = "NazivTermina", HeaderText = "Termin",
                    Width = 80, ReadOnly = true, Name = "colTermin" },
                new DataGridViewTextBoxColumn {
                    DataPropertyName = "Datum", HeaderText = "Datum",
                    Width = 100, ReadOnly = true, Name = "colDatum",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" } },
                new DataGridViewTextBoxColumn {
                    DataPropertyName = "Datum", HeaderText = "Dan",
                    Width = 120, ReadOnly = true, Name = "colDan",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dddd" } }
            });

            // ── pnlDetalji ───────────────────────────────────────────
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalji.Location = new Point(618, 10);
            pnlDetalji.Name = "pnlDetalji";
            pnlDetalji.Padding = new Padding(12);
            pnlDetalji.Size = new Size(409, 510);
            pnlDetalji.TabIndex = 0;
            pnlDetalji.Visible = false;

            lblDetaljiNaslov.AutoSize = true;
            lblDetaljiNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetaljiNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblDetaljiNaslov.Location = new Point(12, 10);
            lblDetaljiNaslov.Name = "lblDetaljiNaslov";
            lblDetaljiNaslov.TabIndex = 0;
            lblDetaljiNaslov.Text = "Detalji smene";

            lblBibliotekarLbl.AutoSize = true;
            lblBibliotekarLbl.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            lblBibliotekarLbl.ForeColor = Color.Gray;
            lblBibliotekarLbl.Location = new Point(12, 48);
            lblBibliotekarLbl.Name = "lblBibliotekarLbl";
            lblBibliotekarLbl.TabIndex = 1;
            lblBibliotekarLbl.Text = "Bibliotekar:";

            lblBibliotekarVrednost.AutoSize = true;
            lblBibliotekarVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBibliotekarVrednost.Location = new Point(115, 48);
            lblBibliotekarVrednost.Name = "lblBibliotekarVrednost";
            lblBibliotekarVrednost.TabIndex = 2;
            lblBibliotekarVrednost.Text = "-";

            lblTerminLbl.AutoSize = true;
            lblTerminLbl.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            lblTerminLbl.ForeColor = Color.Gray;
            lblTerminLbl.Location = new Point(12, 70);
            lblTerminLbl.Name = "lblTerminLbl";
            lblTerminLbl.TabIndex = 3;
            lblTerminLbl.Text = "Termin:";

            lblTerminVrednost.AutoSize = true;
            lblTerminVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTerminVrednost.Location = new Point(115, 70);
            lblTerminVrednost.Name = "lblTerminVrednost";
            lblTerminVrednost.TabIndex = 4;
            lblTerminVrednost.Text = "-";

            lblDatumLbl.AutoSize = true;
            lblDatumLbl.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            lblDatumLbl.ForeColor = Color.Gray;
            lblDatumLbl.Location = new Point(12, 92);
            lblDatumLbl.Name = "lblDatumLbl";
            lblDatumLbl.TabIndex = 5;
            lblDatumLbl.Text = "Datum:";

            lblDatumVrednost.AutoSize = true;
            lblDatumVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDatumVrednost.Location = new Point(115, 92);
            lblDatumVrednost.Name = "lblDatumVrednost";
            lblDatumVrednost.TabIndex = 6;
            lblDatumVrednost.Text = "-";

            // Status bar
            pnlStatusBar.BackColor = Color.FromArgb(230, 242, 255);
            pnlStatusBar.Location = new Point(12, 120);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(381, 32);
            pnlStatusBar.TabIndex = 7;

            lblStatusLbl.AutoSize = true;
            lblStatusLbl.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            lblStatusLbl.Location = new Point(8, 7);
            lblStatusLbl.Name = "lblStatusLbl";
            lblStatusLbl.TabIndex = 0;
            lblStatusLbl.Text = "Status:";

            lblStatusVrednost.AutoSize = true;
            lblStatusVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatusVrednost.ForeColor = Color.FromArgb(0, 86, 179);
            lblStatusVrednost.Location = new Point(65, 7);
            lblStatusVrednost.Name = "lblStatusVrednost";
            lblStatusVrednost.TabIndex = 1;
            lblStatusVrednost.Text = "-";

            pnlStatusBar.Controls.AddRange(new Control[] { lblStatusLbl, lblStatusVrednost });

            btnZahtevZaPromenu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnZahtevZaPromenu.BackColor = Color.FromArgb(0, 86, 179);
            btnZahtevZaPromenu.Cursor = Cursors.Hand;
            btnZahtevZaPromenu.FlatAppearance.BorderSize = 0;
            btnZahtevZaPromenu.FlatStyle = FlatStyle.Flat;
            btnZahtevZaPromenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnZahtevZaPromenu.ForeColor = Color.White;
            btnZahtevZaPromenu.Location = new Point(12, 165);
            btnZahtevZaPromenu.Name = "btnZahtevZaPromenu";
            btnZahtevZaPromenu.Size = new Size(381, 32);
            btnZahtevZaPromenu.TabIndex = 8;
            btnZahtevZaPromenu.Text = "Zahtev za promenu smene";
            btnZahtevZaPromenu.UseVisualStyleBackColor = false;
            btnZahtevZaPromenu.Visible = false;
            btnZahtevZaPromenu.Click += btnZahtevZaPromenu_Click;

            pnlDetalji.Controls.AddRange(new Control[] {
                lblDetaljiNaslov,
                lblBibliotekarLbl, lblBibliotekarVrednost,
                lblTerminLbl,      lblTerminVrednost,
                lblDatumLbl,       lblDatumVrednost,
                pnlStatusBar,
                btnZahtevZaPromenu
            });

            // ── pnlZahtev ────────────────────────────────────────────
            pnlZahtev.BackColor = Color.White;
            pnlZahtev.BorderStyle = BorderStyle.FixedSingle;
            pnlZahtev.Location = new Point(618, 10);
            pnlZahtev.Name = "pnlZahtev";
            pnlZahtev.Padding = new Padding(12);
            pnlZahtev.Size = new Size(409, 510);
            pnlZahtev.TabIndex = 5;
            pnlZahtev.Visible = false;

            lblZahtevNaslov.AutoSize = true;
            lblZahtevNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblZahtevNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblZahtevNaslov.Location = new Point(12, 10);
            lblZahtevNaslov.Name = "lblZahtevNaslov";
            lblZahtevNaslov.TabIndex = 0;
            lblZahtevNaslov.Text = "Zahtev za promenu smene";

            lblZahtevInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblZahtevInfo.ForeColor = Color.Gray;
            lblZahtevInfo.Location = new Point(12, 48);
            lblZahtevInfo.Name = "lblZahtevInfo";
            lblZahtevInfo.Size = new Size(381, 36);
            lblZahtevInfo.TabIndex = 1;
            lblZahtevInfo.Text = "";

            lblZahtevTerminLbl.AutoSize = true;
            lblZahtevTerminLbl.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            lblZahtevTerminLbl.ForeColor = Color.Gray;
            lblZahtevTerminLbl.Location = new Point(12, 95);
            lblZahtevTerminLbl.Name = "lblZahtevTerminLbl";
            lblZahtevTerminLbl.TabIndex = 2;
            lblZahtevTerminLbl.Text = "Novi termin:";

            cmbTerminZahtev.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTerminZahtev.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            cmbTerminZahtev.Location = new Point(12, 118);
            cmbTerminZahtev.Name = "cmbTerminZahtev";
            cmbTerminZahtev.Size = new Size(381, 30);
            cmbTerminZahtev.TabIndex = 3;

            lblZahtevDatumLbl.AutoSize = true;
            lblZahtevDatumLbl.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            lblZahtevDatumLbl.ForeColor = Color.Gray;
            lblZahtevDatumLbl.Location = new Point(12, 160);
            lblZahtevDatumLbl.Name = "lblZahtevDatumLbl";
            lblZahtevDatumLbl.TabIndex = 4;
            lblZahtevDatumLbl.Text = "Novi datum:";

            dtpZahtev.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            dtpZahtev.Format = DateTimePickerFormat.Short;
            dtpZahtev.Location = new Point(12, 183);
            dtpZahtev.MinDate = DateTime.Today.AddDays(1);
            dtpZahtev.Name = "dtpZahtev";
            dtpZahtev.Size = new Size(381, 30);
            dtpZahtev.TabIndex = 5;

            btnPosaljiZahtev.BackColor = Color.FromArgb(18, 27, 41);
            btnPosaljiZahtev.Cursor = Cursors.Hand;
            btnPosaljiZahtev.FlatAppearance.BorderSize = 0;
            btnPosaljiZahtev.FlatStyle = FlatStyle.Flat;
            btnPosaljiZahtev.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPosaljiZahtev.ForeColor = Color.White;
            btnPosaljiZahtev.Location = new Point(12, 228);
            btnPosaljiZahtev.Name = "btnPosaljiZahtev";
            btnPosaljiZahtev.Size = new Size(240, 32);
            btnPosaljiZahtev.TabIndex = 6;
            btnPosaljiZahtev.Text = "💾  Potvrdi promenu";
            btnPosaljiZahtev.UseVisualStyleBackColor = false;
            btnPosaljiZahtev.Click += btnPosaljiZahtev_Click;

            btnOtkaziZahtev.BackColor = Color.Gray;
            btnOtkaziZahtev.Cursor = Cursors.Hand;
            btnOtkaziZahtev.FlatAppearance.BorderSize = 0;
            btnOtkaziZahtev.FlatStyle = FlatStyle.Flat;
            btnOtkaziZahtev.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnOtkaziZahtev.ForeColor = Color.White;
            btnOtkaziZahtev.Location = new Point(260, 228);
            btnOtkaziZahtev.Name = "btnOtkaziZahtev";
            btnOtkaziZahtev.Size = new Size(133, 32);
            btnOtkaziZahtev.TabIndex = 7;
            btnOtkaziZahtev.Text = "Otkaži";
            btnOtkaziZahtev.UseVisualStyleBackColor = false;
            btnOtkaziZahtev.Click += btnOtkaziZahtev_Click;

            pnlZahtev.Controls.AddRange(new Control[] {
                lblZahtevNaslov,
                lblZahtevInfo,
                lblZahtevTerminLbl, cmbTerminZahtev,
                lblZahtevDatumLbl,  dtpZahtev,
                btnPosaljiZahtev,   btnOtkaziZahtev
            });

            // ── UCSmena ───────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlDetalji);
            Controls.Add(pnlZahtev);
            Controls.Add(dgvSmene);
            Controls.Add(pnlPretraga);
            Controls.Add(lblNaslov);
            Controls.Add(lblBroj);
            Name = "UCSmena";
            Size = new Size(1040, 584);

            pnlPretraga.ResumeLayout(false);
            pnlPretraga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSmene).EndInit();
            pnlDetalji.ResumeLayout(false);
            pnlDetalji.PerformLayout();
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            pnlZahtev.ResumeLayout(false);
            pnlZahtev.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Panel pnlPretraga;
        private Label lblPretraga;
        private TextBox txtKriterijum;
        private Button btnPretrazi;
        private Button btnReset;
        private Label lblBroj;
        private BindingSource bindingSource1;
        private DataGridView dgvSmene;
        private Panel pnlDetalji;
        private Label lblDetaljiNaslov;
        private Label lblBibliotekarLbl;
        private Label lblBibliotekarVrednost;
        private Label lblTerminLbl;
        private Label lblTerminVrednost;
        private Label lblDatumLbl;
        private Label lblDatumVrednost;
        private Panel pnlStatusBar;
        private Label lblStatusLbl;
        private Label lblStatusVrednost;
        private Button btnZahtevZaPromenu;
        private Panel pnlZahtev;
        private Label lblZahtevNaslov;
        private Label lblZahtevInfo;
        private Label lblZahtevTerminLbl;
        private ComboBox cmbTerminZahtev;
        private Label lblZahtevDatumLbl;
        private DateTimePicker dtpZahtev;
        private Button btnPosaljiZahtev;
        private Button btnOtkaziZahtev;
    }
}