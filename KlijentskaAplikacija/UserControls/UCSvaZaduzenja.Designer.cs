namespace KlijentskaAplikacija.UserControls
{
    partial class UCSvaZaduzenja
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblNaslov = new Label();
            pnlPretraga = new Panel();
            lblPretraga = new Label();
            txtPretraga = new TextBox();
            btnPretrazi = new Button();
            btnReset = new Button();
            lblBroj = new Label();
            dgvPozajmice = new DataGridView();
            bsPozajmice = new BindingSource(components);
            pnlDetalji = new Panel();
            lblDetaljiNaslov = new Label();
            lblClan = new Label();
            lblClanVrednost = new Label();
            lblBibliotekar = new Label();
            lblBibliotekarVrednost = new Label();
            lblDatum = new Label();
            lblDatumVrednost = new Label();
            lblBrojKnjiga = new Label();
            lblBrojKnjigaVrednost = new Label();
            pnlStatusBar = new Panel();
            lblStatus = new Label();
            lblStatusVrednost = new Label();
            lblStavkeNaslov = new Label();
            dgvStavke = new DataGridView();
            bsStavke = new BindingSource(components);
            btnVratiKnjigu = new Button();
            grpIzmenaRoka = new GroupBox();
            chkIzmeniRok = new CheckBox();
            lblNoviRok = new Label();
            dtpNoviRok = new DateTimePicker();
            btnSacuvajIzmene = new Button();
            colId = new DataGridViewTextBoxColumn();
            colClan = new DataGridViewTextBoxColumn();
            colBibliotekar = new DataGridViewTextBoxColumn();
            colDatumOd = new DataGridViewTextBoxColumn();
            colBrojKnjiga = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colDatumVracanjaP = new DataGridViewTextBoxColumn();
            colVrati = new DataGridViewCheckBoxColumn();
            colStavkaId = new DataGridViewTextBoxColumn();
            colNazivKnjige = new DataGridViewTextBoxColumn();
            colRokPozajmice = new DataGridViewTextBoxColumn();
            colDatumVracanja = new DataGridViewTextBoxColumn();
            pnlPretraga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPozajmice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsPozajmice).BeginInit();
            pnlDetalji.SuspendLayout();
            pnlStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsStavke).BeginInit();
            grpIzmenaRoka.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(20, 15);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(196, 37);
            lblNaslov.TabIndex = 3;
            lblNaslov.Text = "Sva zaduženja";
            // 
            // pnlPretraga
            // 
            pnlPretraga.BackColor = Color.White;
            pnlPretraga.BorderStyle = BorderStyle.FixedSingle;
            pnlPretraga.Controls.Add(lblPretraga);
            pnlPretraga.Controls.Add(txtPretraga);
            pnlPretraga.Controls.Add(btnPretrazi);
            pnlPretraga.Controls.Add(btnReset);
            pnlPretraga.Location = new Point(20, 55);
            pnlPretraga.Name = "pnlPretraga";
            pnlPretraga.Size = new Size(592, 48);
            pnlPretraga.TabIndex = 2;
            // 
            // lblPretraga
            // 
            lblPretraga.AutoSize = true;
            lblPretraga.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPretraga.Location = new Point(8, 12);
            lblPretraga.Name = "lblPretraga";
            lblPretraga.Size = new Size(79, 23);
            lblPretraga.TabIndex = 0;
            lblPretraga.Text = "Pretraga:";
            // 
            // txtPretraga
            // 
            txtPretraga.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPretraga.Location = new Point(90, 10);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.PlaceholderText = "Član, bibliotekar, knjiga ili ID pozajmice...";
            txtPretraga.Size = new Size(250, 30);
            txtPretraga.TabIndex = 1;
            txtPretraga.KeyDown += txtPretraga_KeyDown;
            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.FromArgb(18, 27, 41);
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(348, 9);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(85, 28);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gray;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(439, 9);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(70, 28);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lblBroj
            // 
            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBroj.ForeColor = Color.Gray;
            lblBroj.Location = new Point(510, 32);
            lblBroj.Name = "lblBroj";
            lblBroj.Size = new Size(81, 20);
            lblBroj.TabIndex = 4;
            lblBroj.Text = "Ukupno: 0";
            // 
            // dgvPozajmice
            // 
            dgvPozajmice.AllowUserToAddRows = false;
            dgvPozajmice.AllowUserToDeleteRows = false;
            dgvPozajmice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvPozajmice.AutoGenerateColumns = false;
            dgvPozajmice.BackgroundColor = Color.White;
            dgvPozajmice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPozajmice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(18, 27, 41);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(18, 27, 41);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvPozajmice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPozajmice.ColumnHeadersHeight = 36;
            dgvPozajmice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPozajmice.DataSource = bsPozajmice;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPozajmice.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPozajmice.EnableHeadersVisualStyles = false;
            dgvPozajmice.GridColor = Color.FromArgb(230, 230, 230);
            dgvPozajmice.Location = new Point(20, 110);
            dgvPozajmice.MultiSelect = false;
            dgvPozajmice.Name = "dgvPozajmice";
            dgvPozajmice.ReadOnly = true;
            dgvPozajmice.RowHeadersVisible = false;
            dgvPozajmice.RowHeadersWidth = 51;
            dgvPozajmice.RowTemplate.Height = 38;
            dgvPozajmice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPozajmice.Size = new Size(592, 440);
            dgvPozajmice.TabIndex = 1;

            // dgvPozajmice kolone
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Visible = false;
            colId.ReadOnly = true;

            colClan.DataPropertyName = "ImePrezimeClana";
            colClan.HeaderText = "Član";
            colClan.Width = 145;
            colClan.ReadOnly = true;

            colBibliotekar.DataPropertyName = "ImePrezimeBibliotekar";
            colBibliotekar.HeaderText = "Bibliotekar";
            colBibliotekar.Width = 120;
            colBibliotekar.ReadOnly = true;

            colDatumOd.DataPropertyName = "DatumOd";
            colDatumOd.HeaderText = "Datum";
            colDatumOd.Width = 90;
            colDatumOd.ReadOnly = true;
            colDatumOd.DefaultCellStyle.Format = "dd.MM.yyyy";

            colBrojKnjiga.DataPropertyName = "BrojKnjiga";
            colBrojKnjiga.HeaderText = "Br.kn.";
            colBrojKnjiga.Width = 50;
            colBrojKnjiga.ReadOnly = true;
            colBrojKnjiga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Width = 90;
            colStatus.ReadOnly = true;

            colDatumVracanjaP.DataPropertyName = "DatumVracanja";
            colDatumVracanjaP.HeaderText = "Vraćeno";
            colDatumVracanjaP.Width = 90;
            colDatumVracanjaP.ReadOnly = true;
            colDatumVracanjaP.DefaultCellStyle.Format = "dd.MM.yyyy";

            dgvPozajmice.Columns.AddRange(new DataGridViewColumn[]
            {
                colId, colClan, colBibliotekar, colDatumOd, colBrojKnjiga, colStatus, colDatumVracanjaP
            });

            // 
            // pnlDetalji
            // 
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalji.Controls.Add(lblDetaljiNaslov);
            pnlDetalji.Controls.Add(lblClan);
            pnlDetalji.Controls.Add(lblClanVrednost);
            pnlDetalji.Controls.Add(lblBibliotekar);
            pnlDetalji.Controls.Add(lblBibliotekarVrednost);
            pnlDetalji.Controls.Add(lblDatum);
            pnlDetalji.Controls.Add(lblDatumVrednost);
            pnlDetalji.Controls.Add(lblBrojKnjiga);
            pnlDetalji.Controls.Add(lblBrojKnjigaVrednost);
            pnlDetalji.Controls.Add(pnlStatusBar);
            pnlDetalji.Controls.Add(lblStavkeNaslov);
            pnlDetalji.Controls.Add(dgvStavke);
            pnlDetalji.Controls.Add(btnVratiKnjigu);
            pnlDetalji.Controls.Add(grpIzmenaRoka);
            pnlDetalji.Controls.Add(btnSacuvajIzmene);
            pnlDetalji.Location = new Point(618, 10);
            pnlDetalji.Name = "pnlDetalji";
            pnlDetalji.Padding = new Padding(12);
            pnlDetalji.Size = new Size(409, 510);
            pnlDetalji.TabIndex = 0;
            // 
            // lblDetaljiNaslov
            // 
            lblDetaljiNaslov.AutoSize = true;
            lblDetaljiNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetaljiNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblDetaljiNaslov.Location = new Point(12, 10);
            lblDetaljiNaslov.Name = "lblDetaljiNaslov";
            lblDetaljiNaslov.Size = new Size(177, 28);
            lblDetaljiNaslov.TabIndex = 0;
            lblDetaljiNaslov.Text = "Detalji pozajmice";
            // 
            // lblClan
            // 
            lblClan.AutoSize = true;
            lblClan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblClan.ForeColor = Color.Gray;
            lblClan.Location = new Point(12, 48);
            lblClan.Name = "lblClan";
            lblClan.Size = new Size(41, 20);
            lblClan.TabIndex = 1;
            lblClan.Text = "Član:";
            // 
            // lblClanVrednost
            // 
            lblClanVrednost.AutoSize = true;
            lblClanVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClanVrednost.Location = new Point(115, 48);
            lblClanVrednost.Name = "lblClanVrednost";
            lblClanVrednost.Size = new Size(15, 20);
            lblClanVrednost.TabIndex = 2;
            lblClanVrednost.Text = "-";
            // 
            // lblBibliotekar
            // 
            lblBibliotekar.AutoSize = true;
            lblBibliotekar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBibliotekar.ForeColor = Color.Gray;
            lblBibliotekar.Location = new Point(12, 70);
            lblBibliotekar.Name = "lblBibliotekar";
            lblBibliotekar.Size = new Size(84, 20);
            lblBibliotekar.TabIndex = 11;
            lblBibliotekar.Text = "Bibliotekar:";
            // 
            // lblBibliotekarVrednost
            // 
            lblBibliotekarVrednost.AutoSize = true;
            lblBibliotekarVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBibliotekarVrednost.Location = new Point(115, 70);
            lblBibliotekarVrednost.Name = "lblBibliotekarVrednost";
            lblBibliotekarVrednost.Size = new Size(15, 20);
            lblBibliotekarVrednost.TabIndex = 12;
            lblBibliotekarVrednost.Text = "-";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.ForeColor = Color.Gray;
            lblDatum.Location = new Point(12, 92);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(57, 20);
            lblDatum.TabIndex = 3;
            lblDatum.Text = "Datum:";
            // 
            // lblDatumVrednost
            // 
            lblDatumVrednost.AutoSize = true;
            lblDatumVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDatumVrednost.Location = new Point(115, 92);
            lblDatumVrednost.Name = "lblDatumVrednost";
            lblDatumVrednost.Size = new Size(15, 20);
            lblDatumVrednost.TabIndex = 4;
            lblDatumVrednost.Text = "-";
            // 
            // lblBrojKnjiga
            // 
            lblBrojKnjiga.AutoSize = true;
            lblBrojKnjiga.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBrojKnjiga.ForeColor = Color.Gray;
            lblBrojKnjiga.Location = new Point(12, 114);
            lblBrojKnjiga.Name = "lblBrojKnjiga";
            lblBrojKnjiga.Size = new Size(73, 20);
            lblBrojKnjiga.TabIndex = 5;
            lblBrojKnjiga.Text = "Br. knjiga:";
            // 
            // lblBrojKnjigaVrednost
            // 
            lblBrojKnjigaVrednost.AutoSize = true;
            lblBrojKnjigaVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBrojKnjigaVrednost.Location = new Point(115, 114);
            lblBrojKnjigaVrednost.Name = "lblBrojKnjigaVrednost";
            lblBrojKnjigaVrednost.Size = new Size(18, 20);
            lblBrojKnjigaVrednost.TabIndex = 6;
            lblBrojKnjigaVrednost.Text = "0";
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.BackColor = Color.FromArgb(230, 242, 255);
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Controls.Add(lblStatusVrednost);
            pnlStatusBar.Location = new Point(12, 138);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(381, 32);
            pnlStatusBar.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(8, 7);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblStatusVrednost
            // 
            lblStatusVrednost.AutoSize = true;
            lblStatusVrednost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatusVrednost.ForeColor = Color.FromArgb(0, 123, 255);
            lblStatusVrednost.Location = new Point(65, 7);
            lblStatusVrednost.Name = "lblStatusVrednost";
            lblStatusVrednost.Size = new Size(63, 20);
            lblStatusVrednost.TabIndex = 1;
            lblStatusVrednost.Text = "Aktivna";
            // 
            // lblStavkeNaslov
            // 
            lblStavkeNaslov.AutoSize = true;
            lblStavkeNaslov.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStavkeNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblStavkeNaslov.Location = new Point(12, 180);
            lblStavkeNaslov.Name = "lblStavkeNaslov";
            lblStavkeNaslov.Size = new Size(143, 20);
            lblStavkeNaslov.TabIndex = 8;
            lblStavkeNaslov.Text = "Pozajmljene knjige:";
            // 
            // dgvStavke
            // 
            dgvStavke.AllowUserToAddRows = false;
            dgvStavke.AllowUserToDeleteRows = false;
            dgvStavke.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvStavke.AutoGenerateColumns = false;
            dgvStavke.BackgroundColor = Color.White;
            dgvStavke.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStavke.ColumnHeadersHeight = 30;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStavke.DataSource = bsStavke;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStavke.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStavke.EnableHeadersVisualStyles = false;
            dgvStavke.Location = new Point(12, 200);
            dgvStavke.MultiSelect = false;
            dgvStavke.Name = "dgvStavke";
            dgvStavke.ReadOnly = false;
            dgvStavke.RowHeadersVisible = false;
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.RowTemplate.Height = 32;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.Size = new Size(381, 135);
            dgvStavke.TabIndex = 9;

            // dgvStavke kolone
            colVrati.HeaderText = "Vrati";
            colVrati.Name = "colVrati";
            colVrati.Width = 30;
            colVrati.ReadOnly = false;
            colVrati.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colVrati.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colStavkaId.DataPropertyName = "IdKnjige";
            colStavkaId.HeaderText = "ID";
            colStavkaId.Width = 35;
            colStavkaId.Visible = false;
            colStavkaId.ReadOnly = true;

            colNazivKnjige.DataPropertyName = "NazivKnjige";
            colNazivKnjige.HeaderText = "Knjiga";
            colNazivKnjige.Width = 150;
            colNazivKnjige.ReadOnly = true;

            colRokPozajmice.DataPropertyName = "RokPozajmice";
            colRokPozajmice.HeaderText = "Rok";
            colRokPozajmice.Width = 90;
            colRokPozajmice.ReadOnly = true;
            colRokPozajmice.DefaultCellStyle.Format = "dd.MM.yyyy";

            colDatumVracanja.DataPropertyName = "DatumVracanja";
            colDatumVracanja.HeaderText = "Vraćeno";
            colDatumVracanja.Width = 90;
            colDatumVracanja.ReadOnly = true;
            colDatumVracanja.DefaultCellStyle.Format = "dd.MM.yyyy";

            dgvStavke.Columns.AddRange(new DataGridViewColumn[]
            {
                colVrati, colStavkaId, colNazivKnjige, colRokPozajmice, colDatumVracanja
            });

            // 
            // btnVratiKnjigu
            // 
            btnVratiKnjigu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnVratiKnjigu.BackColor = Color.FromArgb(40, 167, 69);
            btnVratiKnjigu.Cursor = Cursors.Hand;
            btnVratiKnjigu.FlatAppearance.BorderSize = 0;
            btnVratiKnjigu.FlatStyle = FlatStyle.Flat;
            btnVratiKnjigu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnVratiKnjigu.ForeColor = Color.White;
            btnVratiKnjigu.Location = new Point(12, 345);
            btnVratiKnjigu.Name = "btnVratiKnjigu";
            btnVratiKnjigu.Size = new Size(381, 30);
            btnVratiKnjigu.TabIndex = 10;
            btnVratiKnjigu.Text = "✓  Vrati selektovanu knjigu";
            btnVratiKnjigu.UseVisualStyleBackColor = false;
            btnVratiKnjigu.Click += btnVratiKnjigu_Click;
            // 
            // grpIzmenaRoka
            // 
            grpIzmenaRoka.Controls.Add(chkIzmeniRok);
            grpIzmenaRoka.Controls.Add(lblNoviRok);
            grpIzmenaRoka.Controls.Add(dtpNoviRok);
            grpIzmenaRoka.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpIzmenaRoka.ForeColor = Color.FromArgb(18, 27, 41);
            grpIzmenaRoka.Location = new Point(12, 385);
            grpIzmenaRoka.Name = "grpIzmenaRoka";
            grpIzmenaRoka.Size = new Size(381, 65);
            grpIzmenaRoka.TabIndex = 13;
            grpIzmenaRoka.TabStop = false;
            grpIzmenaRoka.Text = "Izmeni rok pozajmice";
            // 
            // chkIzmeniRok
            // 
            chkIzmeniRok.AutoSize = true;
            chkIzmeniRok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkIzmeniRok.Location = new Point(6, 26);
            chkIzmeniRok.Name = "chkIzmeniRok";
            chkIzmeniRok.Size = new Size(103, 24);
            chkIzmeniRok.TabIndex = 0;
            chkIzmeniRok.Text = "Izmeni rok:";
            chkIzmeniRok.CheckedChanged += chkIzmeniRok_CheckedChanged;
            // 
            // lblNoviRok
            // 
            lblNoviRok.AutoSize = true;
            lblNoviRok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNoviRok.ForeColor = Color.Gray;
            lblNoviRok.Location = new Point(115, 26);
            lblNoviRok.Name = "lblNoviRok";
            lblNoviRok.Size = new Size(68, 20);
            lblNoviRok.TabIndex = 1;
            lblNoviRok.Text = "Novi rok:";
            // 
            // dtpNoviRok
            // 
            dtpNoviRok.Enabled = false;
            dtpNoviRok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNoviRok.Format = DateTimePickerFormat.Short;
            dtpNoviRok.Location = new Point(190, 22);
            dtpNoviRok.Name = "dtpNoviRok";
            dtpNoviRok.Size = new Size(100, 27);
            dtpNoviRok.TabIndex = 2;
            dtpNoviRok.Value = new DateTime(2026, 3, 2, 0, 0, 0, 0);
            // 
            // btnSacuvajIzmene
            // 
            btnSacuvajIzmene.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSacuvajIzmene.BackColor = Color.FromArgb(18, 27, 41);
            btnSacuvajIzmene.Cursor = Cursors.Hand;
            btnSacuvajIzmene.FlatAppearance.BorderSize = 0;
            btnSacuvajIzmene.FlatStyle = FlatStyle.Flat;
            btnSacuvajIzmene.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSacuvajIzmene.ForeColor = Color.White;
            btnSacuvajIzmene.Location = new Point(12, 460);
            btnSacuvajIzmene.Name = "btnSacuvajIzmene";
            btnSacuvajIzmene.Size = new Size(381, 32);
            btnSacuvajIzmene.TabIndex = 14;
            btnSacuvajIzmene.Text = "💾  Sačuvaj izmene";
            btnSacuvajIzmene.UseVisualStyleBackColor = false;
            btnSacuvajIzmene.Click += btnSacuvajIzmene_Click;
            // 
            // UCSvaZaduzenja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlDetalji);
            Controls.Add(dgvPozajmice);
            Controls.Add(pnlPretraga);
            Controls.Add(lblNaslov);
            Controls.Add(lblBroj);
            Name = "UCSvaZaduzenja";
            Size = new Size(1040, 584);
            pnlPretraga.ResumeLayout(false);
            pnlPretraga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPozajmice).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsPozajmice).EndInit();
            pnlDetalji.ResumeLayout(false);
            pnlDetalji.PerformLayout();
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsStavke).EndInit();
            grpIzmenaRoka.ResumeLayout(false);
            grpIzmenaRoka.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Panel pnlPretraga;
        private Label lblPretraga;
        private TextBox txtPretraga;
        private Button btnPretrazi;
        private Button btnReset;
        private Label lblBroj;
        private DataGridView dgvPozajmice;
        private BindingSource bsPozajmice;
        private Panel pnlDetalji;
        private Label lblDetaljiNaslov;
        private Label lblClan;
        private Label lblClanVrednost;
        private Label lblBibliotekar;
        private Label lblBibliotekarVrednost;
        private Label lblDatum;
        private Label lblDatumVrednost;
        private Label lblBrojKnjiga;
        private Label lblBrojKnjigaVrednost;
        private Panel pnlStatusBar;
        private Label lblStatus;
        private Label lblStatusVrednost;
        private Label lblStavkeNaslov;
        private DataGridView dgvStavke;
        private BindingSource bsStavke;
        private Button btnVratiKnjigu;
        private GroupBox grpIzmenaRoka;
        private CheckBox chkIzmeniRok;
        private Label lblNoviRok;
        private DateTimePicker dtpNoviRok;
        private Button btnSacuvajIzmene;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colClan;
        private DataGridViewTextBoxColumn colBibliotekar;
        private DataGridViewTextBoxColumn colDatumOd;
        private DataGridViewTextBoxColumn colBrojKnjiga;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDatumVracanjaP;
        private DataGridViewCheckBoxColumn colVrati;
        private DataGridViewTextBoxColumn colStavkaId;
        private DataGridViewTextBoxColumn colNazivKnjige;
        private DataGridViewTextBoxColumn colRokPozajmice;
        private DataGridViewTextBoxColumn colDatumVracanja;
    }
}