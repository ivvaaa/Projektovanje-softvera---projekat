namespace KlijentskaAplikacija.UserControls
{
    partial class UCSvaZaduzenja
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
            lblNaslov = new Label();
            pnlPretraga = new Panel();
            lblBroj = new Label();
            btnReset = new Button();
            btnPretrazi = new Button();
            txtPretraga = new TextBox();
            lblPretraga = new Label();
            dgvPozajmice = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colClan = new DataGridViewTextBoxColumn();
            colDatumOd = new DataGridViewTextBoxColumn();
            colBrojKnjiga = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            bsPozajmice = new BindingSource(components);
            pnlDetalji = new Panel();
            btnVratiKnjigu = new Button();
            dgvStavke = new DataGridView();
            colStavkaId = new DataGridViewTextBoxColumn();
            colNazivKnjige = new DataGridViewTextBoxColumn();
            colRokPozajmice = new DataGridViewTextBoxColumn();
            colDatumVracanja = new DataGridViewTextBoxColumn();
            bsStavke = new BindingSource(components);
            lblStavkeNaslov = new Label();
            pnlStatusBar = new Panel();
            lblStatusVrednost = new Label();
            lblStatus = new Label();
            lblBrojKnjigaVrednost = new Label();
            lblBrojKnjiga = new Label();
            lblDatumVrednost = new Label();
            lblDatum = new Label();
            lblClanVrednost = new Label();
            lblClan = new Label();
            lblDetaljiNaslov = new Label();
            pnlPretraga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPozajmice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsPozajmice).BeginInit();
            pnlDetalji.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsStavke).BeginInit();
            pnlStatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(23, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(180, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Sva zaduženja";
            // 
            // pnlPretraga
            // 
            pnlPretraga.BackColor = Color.White;
            pnlPretraga.BorderStyle = BorderStyle.FixedSingle;
            pnlPretraga.Controls.Add(lblBroj);
            pnlPretraga.Controls.Add(btnReset);
            pnlPretraga.Controls.Add(btnPretrazi);
            pnlPretraga.Controls.Add(txtPretraga);
            pnlPretraga.Controls.Add(lblPretraga);
            pnlPretraga.Location = new Point(23, 70);
            pnlPretraga.Name = "pnlPretraga";
            pnlPretraga.Size = new Size(600, 70);
            pnlPretraga.TabIndex = 1;
            // 
            // lblBroj
            // 
            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F);
            lblBroj.ForeColor = Color.Gray;
            lblBroj.Location = new Point(480, 25);
            lblBroj.Name = "lblBroj";
            lblBroj.Size = new Size(100, 20);
            lblBroj.TabIndex = 4;
            lblBroj.Text = "Ukupno: 0";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gray;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(390, 18);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 34);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.FromArgb(18, 27, 41);
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(300, 18);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(80, 34);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // txtPretraga
            // 
            txtPretraga.Font = new Font("Segoe UI", 10F);
            txtPretraga.Location = new Point(100, 20);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.PlaceholderText = "Ime ili prezime člana...";
            txtPretraga.Size = new Size(190, 30);
            txtPretraga.TabIndex = 1;
            txtPretraga.KeyDown += txtPretraga_KeyDown;
            // 
            // lblPretraga
            // 
            lblPretraga.AutoSize = true;
            lblPretraga.Font = new Font("Segoe UI", 10F);
            lblPretraga.Location = new Point(15, 23);
            lblPretraga.Name = "lblPretraga";
            lblPretraga.Size = new Size(75, 23);
            lblPretraga.TabIndex = 0;
            lblPretraga.Text = "Pretraga:";
            // 
            // dgvPozajmice
            // 
            dgvPozajmice.AllowUserToAddRows = false;
            dgvPozajmice.AllowUserToDeleteRows = false;
            dgvPozajmice.AutoGenerateColumns = false;
            dgvPozajmice.BackgroundColor = Color.White;
            dgvPozajmice.BorderStyle = BorderStyle.Fixed3D;
            dgvPozajmice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPozajmice.Columns.AddRange(new DataGridViewColumn[] { colId, colClan, colDatumOd, colBrojKnjiga, colStatus });
            dgvPozajmice.DataSource = bsPozajmice;
            dgvPozajmice.Location = new Point(23, 150);
            dgvPozajmice.MultiSelect = false;
            dgvPozajmice.Name = "dgvPozajmice";
            dgvPozajmice.ReadOnly = true;
            dgvPozajmice.RowHeadersWidth = 30;
            dgvPozajmice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPozajmice.Size = new Size(600, 250);
            dgvPozajmice.TabIndex = 2;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 50;
            // 
            // colClan
            // 
            colClan.DataPropertyName = "ImePrezimeClana";
            colClan.HeaderText = "Član";
            colClan.Name = "colClan";
            colClan.ReadOnly = true;
            colClan.Width = 180;
            // 
            // colDatumOd
            // 
            colDatumOd.DataPropertyName = "DatumOd";
            colDatumOd.HeaderText = "Datum pozajmice";
            colDatumOd.Name = "colDatumOd";
            colDatumOd.ReadOnly = true;
            colDatumOd.Width = 130;
            // 
            // colBrojKnjiga
            // 
            colBrojKnjiga.DataPropertyName = "BrojKnjiga";
            colBrojKnjiga.HeaderText = "Broj knjiga";
            colBrojKnjiga.Name = "colBrojKnjiga";
            colBrojKnjiga.ReadOnly = true;
            colBrojKnjiga.Width = 90;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 100;
            // 
            // pnlDetalji
            // 
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalji.Controls.Add(btnVratiKnjigu);
            pnlDetalji.Controls.Add(dgvStavke);
            pnlDetalji.Controls.Add(lblStavkeNaslov);
            pnlDetalji.Controls.Add(pnlStatusBar);
            pnlDetalji.Controls.Add(lblBrojKnjigaVrednost);
            pnlDetalji.Controls.Add(lblBrojKnjiga);
            pnlDetalji.Controls.Add(lblDatumVrednost);
            pnlDetalji.Controls.Add(lblDatum);
            pnlDetalji.Controls.Add(lblClanVrednost);
            pnlDetalji.Controls.Add(lblClan);
            pnlDetalji.Controls.Add(lblDetaljiNaslov);
            pnlDetalji.Location = new Point(640, 70);
            pnlDetalji.Name = "pnlDetalji";
            pnlDetalji.Size = new Size(350, 520);
            pnlDetalji.TabIndex = 3;
            // 
            // btnVratiKnjigu
            // 
            btnVratiKnjigu.BackColor = Color.FromArgb(40, 167, 69);
            btnVratiKnjigu.Cursor = Cursors.Hand;
            btnVratiKnjigu.FlatAppearance.BorderSize = 0;
            btnVratiKnjigu.FlatStyle = FlatStyle.Flat;
            btnVratiKnjigu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVratiKnjigu.ForeColor = Color.White;
            btnVratiKnjigu.Location = new Point(15, 470);
            btnVratiKnjigu.Name = "btnVratiKnjigu";
            btnVratiKnjigu.Size = new Size(318, 35);
            btnVratiKnjigu.TabIndex = 10;
            btnVratiKnjigu.Text = "Vrati selektovanu knjigu";
            btnVratiKnjigu.UseVisualStyleBackColor = false;
            btnVratiKnjigu.Click += btnVratiKnjigu_Click;
            // 
            // dgvStavke
            // 
            dgvStavke.AllowUserToAddRows = false;
            dgvStavke.AllowUserToDeleteRows = false;
            dgvStavke.AutoGenerateColumns = false;
            dgvStavke.BackgroundColor = Color.White;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Columns.AddRange(new DataGridViewColumn[] { colStavkaId, colNazivKnjige, colRokPozajmice, colDatumVracanja });
            dgvStavke.DataSource = bsStavke;
            dgvStavke.Location = new Point(15, 260);
            dgvStavke.MultiSelect = false;
            dgvStavke.Name = "dgvStavke";
            dgvStavke.ReadOnly = true;
            dgvStavke.RowHeadersWidth = 30;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.Size = new Size(318, 200);
            dgvStavke.TabIndex = 9;
            // 
            // colStavkaId
            // 
            colStavkaId.DataPropertyName = "IdKnjige";
            colStavkaId.HeaderText = "ID";
            colStavkaId.Name = "colStavkaId";
            colStavkaId.ReadOnly = true;
            colStavkaId.Visible = false;
            colStavkaId.Width = 40;
            // 
            // colNazivKnjige
            // 
            colNazivKnjige.DataPropertyName = "NazivKnjige";
            colNazivKnjige.HeaderText = "Knjiga";
            colNazivKnjige.Name = "colNazivKnjige";
            colNazivKnjige.ReadOnly = true;
            colNazivKnjige.Width = 130;
            // 
            // colRokPozajmice
            // 
            colRokPozajmice.DataPropertyName = "RokPozajmice";
            colRokPozajmice.HeaderText = "Rok";
            colRokPozajmice.Name = "colRokPozajmice";
            colRokPozajmice.ReadOnly = true;
            colRokPozajmice.Width = 80;
            // 
            // colDatumVracanja
            // 
            colDatumVracanja.DataPropertyName = "DatumVracanja";
            colDatumVracanja.HeaderText = "Vraćeno";
            colDatumVracanja.Name = "colDatumVracanja";
            colDatumVracanja.ReadOnly = true;
            colDatumVracanja.Width = 80;
            // 
            // lblStavkeNaslov
            // 
            lblStavkeNaslov.AutoSize = true;
            lblStavkeNaslov.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStavkeNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblStavkeNaslov.Location = new Point(15, 230);
            lblStavkeNaslov.Name = "lblStavkeNaslov";
            lblStavkeNaslov.Size = new Size(139, 23);
            lblStavkeNaslov.TabIndex = 8;
            lblStavkeNaslov.Text = "Pozajmljene knjige:";
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.BackColor = Color.FromArgb(230, 242, 255);
            pnlStatusBar.Controls.Add(lblStatusVrednost);
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Location = new Point(15, 175);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(318, 40);
            pnlStatusBar.TabIndex = 7;
            // 
            // lblStatusVrednost
            // 
            lblStatusVrednost.AutoSize = true;
            lblStatusVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusVrednost.ForeColor = Color.FromArgb(0, 123, 255);
            lblStatusVrednost.Location = new Point(70, 8);
            lblStatusVrednost.Name = "lblStatusVrednost";
            lblStatusVrednost.Size = new Size(68, 23);
            lblStatusVrednost.TabIndex = 1;
            lblStatusVrednost.Text = "Aktivna";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(10, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblBrojKnjigaVrednost
            // 
            lblBrojKnjigaVrednost.AutoSize = true;
            lblBrojKnjigaVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBrojKnjigaVrednost.Location = new Point(120, 140);
            lblBrojKnjigaVrednost.Name = "lblBrojKnjigaVrednost";
            lblBrojKnjigaVrednost.Size = new Size(20, 23);
            lblBrojKnjigaVrednost.TabIndex = 6;
            lblBrojKnjigaVrednost.Text = "0";
            // 
            // lblBrojKnjiga
            // 
            lblBrojKnjiga.AutoSize = true;
            lblBrojKnjiga.Font = new Font("Segoe UI", 10F);
            lblBrojKnjiga.ForeColor = Color.Gray;
            lblBrojKnjiga.Location = new Point(15, 140);
            lblBrojKnjiga.Name = "lblBrojKnjiga";
            lblBrojKnjiga.Size = new Size(90, 23);
            lblBrojKnjiga.TabIndex = 5;
            lblBrojKnjiga.Text = "Broj knjiga:";
            // 
            // lblDatumVrednost
            // 
            lblDatumVrednost.AutoSize = true;
            lblDatumVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDatumVrednost.Location = new Point(120, 105);
            lblDatumVrednost.Name = "lblDatumVrednost";
            lblDatumVrednost.Size = new Size(96, 23);
            lblDatumVrednost.TabIndex = 4;
            lblDatumVrednost.Text = "01.01.2024";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 10F);
            lblDatum.ForeColor = Color.Gray;
            lblDatum.Location = new Point(15, 105);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(60, 23);
            lblDatum.TabIndex = 3;
            lblDatum.Text = "Datum:";
            // 
            // lblClanVrednost
            // 
            lblClanVrednost.AutoSize = true;
            lblClanVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClanVrednost.Location = new Point(120, 70);
            lblClanVrednost.Name = "lblClanVrednost";
            lblClanVrednost.Size = new Size(116, 23);
            lblClanVrednost.TabIndex = 2;
            lblClanVrednost.Text = "Ime Prezime";
            // 
            // lblClan
            // 
            lblClan.AutoSize = true;
            lblClan.Font = new Font("Segoe UI", 10F);
            lblClan.ForeColor = Color.Gray;
            lblClan.Location = new Point(15, 70);
            lblClan.Name = "lblClan";
            lblClan.Size = new Size(47, 23);
            lblClan.TabIndex = 1;
            lblClan.Text = "Član:";
            // 
            // lblDetaljiNaslov
            // 
            lblDetaljiNaslov.AutoSize = true;
            lblDetaljiNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetaljiNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblDetaljiNaslov.Location = new Point(15, 20);
            lblDetaljiNaslov.Name = "lblDetaljiNaslov";
            lblDetaljiNaslov.Size = new Size(172, 28);
            lblDetaljiNaslov.TabIndex = 0;
            lblDetaljiNaslov.Text = "Detalji pozajmice";
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
            Name = "UCSvaZaduzenja";
            Size = new Size(1010, 610);
            pnlPretraga.ResumeLayout(false);
            pnlPretraga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPozajmice).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsPozajmice).EndInit();
            pnlDetalji.ResumeLayout(false);
            pnlDetalji.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsStavke).EndInit();
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colClan;
        private DataGridViewTextBoxColumn colDatumOd;
        private DataGridViewTextBoxColumn colBrojKnjiga;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colStavkaId;
        private DataGridViewTextBoxColumn colNazivKnjige;
        private DataGridViewTextBoxColumn colRokPozajmice;
        private DataGridViewTextBoxColumn colDatumVracanja;
    }
}