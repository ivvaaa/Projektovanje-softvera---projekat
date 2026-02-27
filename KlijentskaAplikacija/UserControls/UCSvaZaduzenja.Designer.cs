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

            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(18, 27, 41),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(18, 27, 41),
                SelectionForeColor = Color.White
            };
            var cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(50, 50, 50),
                SelectionBackColor = Color.FromArgb(232, 240, 254),
                SelectionForeColor = Color.FromArgb(50, 50, 50)
            };

            lblNaslov = new Label();
            pnlPretraga = new Panel();
            lblBroj = new Label(); btnReset = new Button(); btnPretrazi = new Button();
            txtPretraga = new TextBox(); lblPretraga = new Label();
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
            lblStatusVrednost = new Label(); lblStatus = new Label();
            lblBrojKnjigaVrednost = new Label(); lblBrojKnjiga = new Label();
            lblDatumVrednost = new Label(); lblDatum = new Label();
            lblClanVrednost = new Label(); lblClan = new Label();
            lblDetaljiNaslov = new Label();

            pnlPretraga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPozajmice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsPozajmice).BeginInit();
            pnlDetalji.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsStavke).BeginInit();
            pnlStatusBar.SuspendLayout();
            SuspendLayout();

            // lblNaslov
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(0, 0);
            lblNaslov.Text = "Sva zaduženja";

            // pnlPretraga – Anchor Top+Left+Right
            pnlPretraga.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPretraga.BackColor = Color.White;
            pnlPretraga.BorderStyle = BorderStyle.FixedSingle;
            pnlPretraga.Controls.AddRange(new Control[] { lblPretraga, txtPretraga, btnPretrazi, btnReset, lblBroj });
            pnlPretraga.Location = new Point(0, 40);
            pnlPretraga.Size = new Size(700, 55);

            lblPretraga.AutoSize = true; lblPretraga.Font = new Font("Segoe UI", 10F);
            lblPretraga.Location = new Point(10, 16); lblPretraga.Text = "Pretraga:";
            txtPretraga.Font = new Font("Segoe UI", 10F);
            txtPretraga.Location = new Point(90, 14); txtPretraga.Size = new Size(200, 30);
            txtPretraga.PlaceholderText = "Ime ili prezime člana...";
            txtPretraga.KeyDown += txtPretraga_KeyDown;
            btnPretrazi.BackColor = Color.FromArgb(18, 27, 41); btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.FlatStyle = FlatStyle.Flat; btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold); btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(298, 13); btnPretrazi.Size = new Size(80, 30);
            btnPretrazi.Text = "Pretraži"; btnPretrazi.Click += btnPretrazi_Click;
            btnReset.BackColor = Color.Gray; btnReset.Cursor = Cursors.Hand;
            btnReset.FlatStyle = FlatStyle.Flat; btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold); btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(385, 13); btnReset.Size = new Size(65, 30);
            btnReset.Text = "Reset"; btnReset.Click += btnReset_Click;
            // lblBroj – Anchor Right da uvek ostaje vidljiv
            lblBroj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBroj.AutoSize = true; lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBroj.ForeColor = Color.Gray; lblBroj.Location = new Point(490, 18);
            lblBroj.Text = "Ukupno pozajmica: 0";

            // dgvPozajmice – Anchor sve 4: rasteže se sa prozorom
            dgvPozajmice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvPozajmice.AllowUserToAddRows = false; dgvPozajmice.AllowUserToDeleteRows = false;
            dgvPozajmice.AutoGenerateColumns = false;
            dgvPozajmice.BackgroundColor = Color.White; dgvPozajmice.BorderStyle = BorderStyle.FixedSingle;
            dgvPozajmice.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvPozajmice.ColumnHeadersHeight = 35;
            dgvPozajmice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPozajmice.DefaultCellStyle = cellStyle; dgvPozajmice.EnableHeadersVisualStyles = false;
            dgvPozajmice.Location = new Point(0, 105); dgvPozajmice.Size = new Size(700, 450);
            dgvPozajmice.MultiSelect = false; dgvPozajmice.ReadOnly = true;
            dgvPozajmice.RowHeadersVisible = false; dgvPozajmice.RowTemplate.Height = 38;
            dgvPozajmice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPozajmice.DataSource = bsPozajmice;
            dgvPozajmice.Columns.AddRange(new DataGridViewColumn[] { colId, colClan, colDatumOd, colBrojKnjiga, colStatus });

            colId.DataPropertyName = "Id"; colId.HeaderText = "ID"; colId.Name = "colId";
            colId.ReadOnly = true; colId.Width = 50;
            colClan.DataPropertyName = "ImePrezimeClana"; colClan.HeaderText = "Član"; colClan.Name = "colClan";
            colClan.ReadOnly = true; colClan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDatumOd.DataPropertyName = "DatumOd"; colDatumOd.HeaderText = "Datum pozajmice"; colDatumOd.Name = "colDatumOd";
            colDatumOd.ReadOnly = true; colDatumOd.Width = 140;
            colBrojKnjiga.DataPropertyName = "BrojKnjiga"; colBrojKnjiga.HeaderText = "Br. knjiga"; colBrojKnjiga.Name = "colBrojKnjiga";
            colBrojKnjiga.ReadOnly = true; colBrojKnjiga.Width = 90;
            colStatus.DataPropertyName = "Status"; colStatus.HeaderText = "Status"; colStatus.Name = "colStatus";
            colStatus.ReadOnly = true; colStatus.Width = 100;

            // pnlDetalji – Anchor Top+Right+Bottom: ostaje desno
            pnlDetalji.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalji.Location = new Point(720, 40);
            pnlDetalji.Size = new Size(330, 515);
            pnlDetalji.Controls.AddRange(new Control[] {
                lblDetaljiNaslov, lblClan, lblClanVrednost,
                lblDatum, lblDatumVrednost, lblBrojKnjiga, lblBrojKnjigaVrednost,
                pnlStatusBar, lblStavkeNaslov, dgvStavke, btnVratiKnjigu
            });

            lblDetaljiNaslov.AutoSize = true; lblDetaljiNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetaljiNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblDetaljiNaslov.Location = new Point(15, 15); lblDetaljiNaslov.Text = "Detalji pozajmice";

            lblClan.AutoSize = true; lblClan.Font = new Font("Segoe UI", 10F); lblClan.ForeColor = Color.Gray;
            lblClan.Location = new Point(15, 55); lblClan.Text = "Član:";
            lblClanVrednost.AutoSize = true; lblClanVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClanVrednost.Location = new Point(110, 55); lblClanVrednost.Text = "Ime Prezime";

            lblDatum.AutoSize = true; lblDatum.Font = new Font("Segoe UI", 10F); lblDatum.ForeColor = Color.Gray;
            lblDatum.Location = new Point(15, 85); lblDatum.Text = "Datum:";
            lblDatumVrednost.AutoSize = true; lblDatumVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDatumVrednost.Location = new Point(110, 85); lblDatumVrednost.Text = "01.01.2024";

            lblBrojKnjiga.AutoSize = true; lblBrojKnjiga.Font = new Font("Segoe UI", 10F); lblBrojKnjiga.ForeColor = Color.Gray;
            lblBrojKnjiga.Location = new Point(15, 115); lblBrojKnjiga.Text = "Br. knjiga:";
            lblBrojKnjigaVrednost.AutoSize = true; lblBrojKnjigaVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBrojKnjigaVrednost.Location = new Point(110, 115); lblBrojKnjigaVrednost.Text = "0";

            // pnlStatusBar
            pnlStatusBar.BackColor = Color.FromArgb(230, 242, 255);
            pnlStatusBar.Controls.AddRange(new Control[] { lblStatus, lblStatusVrednost });
            pnlStatusBar.Location = new Point(15, 148); pnlStatusBar.Size = new Size(295, 38);
            lblStatus.AutoSize = true; lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(8, 8); lblStatus.Text = "Status:";
            lblStatusVrednost.AutoSize = true; lblStatusVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusVrednost.ForeColor = Color.FromArgb(0, 123, 255);
            lblStatusVrednost.Location = new Point(72, 8); lblStatusVrednost.Text = "Aktivna";

            // Stavke pozajmice
            lblStavkeNaslov.AutoSize = true; lblStavkeNaslov.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStavkeNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblStavkeNaslov.Location = new Point(15, 205); lblStavkeNaslov.Text = "Pozajmljene knjige:";

            // dgvStavke – Anchor Top+Left+Right+Bottom
            dgvStavke.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvStavke.AllowUserToAddRows = false; dgvStavke.AllowUserToDeleteRows = false;
            dgvStavke.AutoGenerateColumns = false;
            dgvStavke.BackgroundColor = Color.White; dgvStavke.BorderStyle = BorderStyle.FixedSingle;
            dgvStavke.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvStavke.ColumnHeadersHeight = 32;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStavke.DefaultCellStyle = cellStyle; dgvStavke.EnableHeadersVisualStyles = false;
            dgvStavke.Location = new Point(15, 232); dgvStavke.Size = new Size(295, 230);
            dgvStavke.MultiSelect = false; dgvStavke.ReadOnly = true;
            dgvStavke.RowHeadersVisible = false; dgvStavke.RowTemplate.Height = 32;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.DataSource = bsStavke;
            dgvStavke.Columns.AddRange(new DataGridViewColumn[] { colStavkaId, colNazivKnjige, colRokPozajmice, colDatumVracanja });

            colStavkaId.DataPropertyName = "IdKnjige"; colStavkaId.HeaderText = "ID"; colStavkaId.Name = "colStavkaId";
            colStavkaId.ReadOnly = true; colStavkaId.Visible = false;
            colNazivKnjige.DataPropertyName = "NazivKnjige"; colNazivKnjige.HeaderText = "Knjiga"; colNazivKnjige.Name = "colNazivKnjige";
            colNazivKnjige.ReadOnly = true; colNazivKnjige.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRokPozajmice.DataPropertyName = "RokPozajmice"; colRokPozajmice.HeaderText = "Rok"; colRokPozajmice.Name = "colRokPozajmice";
            colRokPozajmice.ReadOnly = true; colRokPozajmice.Width = 80;
            colDatumVracanja.DataPropertyName = "DatumVracanja"; colDatumVracanja.HeaderText = "Vraćeno"; colDatumVracanja.Name = "colDatumVracanja";
            colDatumVracanja.ReadOnly = true; colDatumVracanja.Width = 75;

            btnVratiKnjigu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVratiKnjigu.BackColor = Color.FromArgb(40, 167, 69); btnVratiKnjigu.Cursor = Cursors.Hand;
            btnVratiKnjigu.FlatStyle = FlatStyle.Flat; btnVratiKnjigu.FlatAppearance.BorderSize = 0;
            btnVratiKnjigu.Font = new Font("Segoe UI", 9F, FontStyle.Bold); btnVratiKnjigu.ForeColor = Color.White;
            btnVratiKnjigu.Location = new Point(15, 470); btnVratiKnjigu.Size = new Size(295, 35);
            btnVratiKnjigu.Text = "✓  Vrati selektovanu knjigu";
            btnVratiKnjigu.Click += btnVratiKnjigu_Click;

            // UCSvaZaduzenja
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Dock = DockStyle.Fill; Padding = new Padding(20);
            Controls.AddRange(new Control[] { pnlDetalji, dgvPozajmice, pnlPretraga, lblNaslov });
            Name = "UCSvaZaduzenja";

            pnlPretraga.ResumeLayout(false); pnlPretraga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPozajmice).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsPozajmice).EndInit();
            pnlDetalji.ResumeLayout(false); pnlDetalji.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsStavke).EndInit();
            pnlStatusBar.ResumeLayout(false); pnlStatusBar.PerformLayout();
            ResumeLayout(false); PerformLayout();
        }

        private Label lblNaslov;
        private Panel pnlPretraga;
        private Label lblPretraga; private TextBox txtPretraga;
        private Button btnPretrazi; private Button btnReset; private Label lblBroj;
        private DataGridView dgvPozajmice; private BindingSource bsPozajmice;
        private Panel pnlDetalji;
        private Label lblDetaljiNaslov;
        private Label lblClan; private Label lblClanVrednost;
        private Label lblDatum; private Label lblDatumVrednost;
        private Label lblBrojKnjiga; private Label lblBrojKnjigaVrednost;
        private Panel pnlStatusBar; private Label lblStatus; private Label lblStatusVrednost;
        private Label lblStavkeNaslov;
        private DataGridView dgvStavke; private BindingSource bsStavke;
        private Button btnVratiKnjigu;
        private DataGridViewTextBoxColumn colId, colClan, colDatumOd, colBrojKnjiga, colStatus;
        private DataGridViewTextBoxColumn colStavkaId, colNazivKnjige, colRokPozajmice, colDatumVracanja;
    }
}
