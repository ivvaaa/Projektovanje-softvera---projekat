namespace KlijentskaAplikacija.UserControls
{
    partial class UCKreirajPozajmicu
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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            this.pnlTop = new Panel();
            this.lblNaslov = new Label();
            this.pnlLeft = new Panel();
            this.lblClan = new Label();
            this.cmbClan = new ComboBox();
            this.lblDatumPozajmice = new Label();
            this.dtpDatumPozajmice = new DateTimePicker();
            this.lblRokVracanja = new Label();
            this.dtpRokVracanja = new DateTimePicker();
            this.pnlOdabraneKnjige = new Panel();
            this.lblOdabraneKnjige = new Label();
            this.dgvOdabraneKnjige = new DataGridView();
            this.lblBrojKnjiga = new Label();
            this.btnUkloniKnjigu = new Button();
            this.btnSacuvaj = new Button();
            this.btnOcisti = new Button();
            this.pnlRight = new Panel();
            this.lblDostupneKnjige = new Label();
            this.txtPretragaKnjiga = new TextBox();
            this.dgvKnjige = new DataGridView();
            this.btnDodajKnjigu = new Button();

            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlOdabraneKnjige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvOdabraneKnjige).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvKnjige).BeginInit();
            this.SuspendLayout();

            // Header style
            headerStyle.BackColor = Color.FromArgb(18, 27, 41);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(18, 27, 41);
            headerStyle.SelectionForeColor = Color.White;

            cellStyle.BackColor = Color.White;
            cellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            cellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            cellStyle.SelectionForeColor = Color.FromArgb(50, 50, 50);

            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblNaslov);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(760, 50);
            this.pnlTop.Padding = new Padding(0, 10, 0, 0);

            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            this.lblNaslov.Location = new Point(0, 10);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Text = "Nova pozajmica";

            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblClan);
            this.pnlLeft.Controls.Add(this.cmbClan);
            this.pnlLeft.Controls.Add(this.lblDatumPozajmice);
            this.pnlLeft.Controls.Add(this.dtpDatumPozajmice);
            this.pnlLeft.Controls.Add(this.lblRokVracanja);
            this.pnlLeft.Controls.Add(this.dtpRokVracanja);
            this.pnlLeft.Controls.Add(this.pnlOdabraneKnjige);
            this.pnlLeft.Controls.Add(this.btnSacuvaj);
            this.pnlLeft.Controls.Add(this.btnOcisti);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new Size(450, 460);
            this.pnlLeft.Padding = new Padding(0, 0, 15, 0);

            // 
            // lblClan
            // 
            this.lblClan.AutoSize = true;
            this.lblClan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblClan.Location = new Point(0, 0);
            this.lblClan.Name = "lblClan";
            this.lblClan.Text = "Član:";

            // 
            // cmbClan
            // 
            this.cmbClan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbClan.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClan.Font = new Font("Segoe UI", 10F);
            this.cmbClan.Location = new Point(0, 22);
            this.cmbClan.Name = "cmbClan";
            this.cmbClan.Size = new Size(340, 28);

            // 
            // lblDatumPozajmice
            // 
            this.lblDatumPozajmice.AutoSize = true;
            this.lblDatumPozajmice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDatumPozajmice.Location = new Point(0, 60);
            this.lblDatumPozajmice.Name = "lblDatumPozajmice";
            this.lblDatumPozajmice.Text = "Datum pozajmice:";

            // 
            // dtpDatumPozajmice
            // 
            this.dtpDatumPozajmice.Format = DateTimePickerFormat.Short;
            this.dtpDatumPozajmice.Font = new Font("Segoe UI", 10F);
            this.dtpDatumPozajmice.Location = new Point(0, 82);
            this.dtpDatumPozajmice.Name = "dtpDatumPozajmice";
            this.dtpDatumPozajmice.Size = new Size(150, 27);

            // 
            // lblRokVracanja
            // 
            this.lblRokVracanja.AutoSize = true;
            this.lblRokVracanja.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblRokVracanja.Location = new Point(170, 60);
            this.lblRokVracanja.Name = "lblRokVracanja";
            this.lblRokVracanja.Text = "Rok vraćanja:";

            // 
            // dtpRokVracanja
            // 
            this.dtpRokVracanja.Format = DateTimePickerFormat.Short;
            this.dtpRokVracanja.Font = new Font("Segoe UI", 10F);
            this.dtpRokVracanja.Location = new Point(170, 82);
            this.dtpRokVracanja.Name = "dtpRokVracanja";
            this.dtpRokVracanja.Size = new Size(150, 27);

            // 
            // pnlOdabraneKnjige
            // 
            this.pnlOdabraneKnjige.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.pnlOdabraneKnjige.Controls.Add(this.lblOdabraneKnjige);
            this.pnlOdabraneKnjige.Controls.Add(this.dgvOdabraneKnjige);
            this.pnlOdabraneKnjige.Controls.Add(this.lblBrojKnjiga);
            this.pnlOdabraneKnjige.Controls.Add(this.btnUkloniKnjigu);
            this.pnlOdabraneKnjige.Location = new Point(0, 120);
            this.pnlOdabraneKnjige.Name = "pnlOdabraneKnjige";
            this.pnlOdabraneKnjige.Size = new Size(420, 380);

            // 
            // lblOdabraneKnjige
            // 
            this.lblOdabraneKnjige.AutoSize = true;
            this.lblOdabraneKnjige.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblOdabraneKnjige.Location = new Point(0, 0);
            this.lblOdabraneKnjige.Name = "lblOdabraneKnjige";
            this.lblOdabraneKnjige.Text = "Odabrane knjige:";

            // 
            // dgvOdabraneKnjige
            // 
            this.dgvOdabraneKnjige.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.dgvOdabraneKnjige.AllowUserToAddRows = false;
            this.dgvOdabraneKnjige.AllowUserToDeleteRows = false;
            this.dgvOdabraneKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOdabraneKnjige.BackgroundColor = Color.White;
            this.dgvOdabraneKnjige.BorderStyle = BorderStyle.FixedSingle;
            this.dgvOdabraneKnjige.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvOdabraneKnjige.ColumnHeadersHeight = 35;
            this.dgvOdabraneKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOdabraneKnjige.DefaultCellStyle = cellStyle;
            this.dgvOdabraneKnjige.EnableHeadersVisualStyles = false;
            this.dgvOdabraneKnjige.Location = new Point(0, 22);
            this.dgvOdabraneKnjige.MultiSelect = false;
            this.dgvOdabraneKnjige.Name = "dgvOdabraneKnjige";
            this.dgvOdabraneKnjige.ReadOnly = true;
            this.dgvOdabraneKnjige.RowHeadersVisible = false;
            this.dgvOdabraneKnjige.RowTemplate.Height = 35;
            this.dgvOdabraneKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOdabraneKnjige.Size = new Size(400, 270);
            this.dgvOdabraneKnjige.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvOdabraneKnjige_DataBindingComplete);

            // 
            // lblBrojKnjiga
            // 
            this.lblBrojKnjiga.AutoSize = true;
            this.lblBrojKnjiga.Font = new Font("Segoe UI", 9F);
            this.lblBrojKnjiga.Location = new Point(0, 300);
            this.lblBrojKnjiga.Name = "lblBrojKnjiga";
            this.lblBrojKnjiga.Text = "Odabrano knjiga: 0";

            // 
            // btnUkloniKnjigu
            // 
            this.btnUkloniKnjigu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnUkloniKnjigu.BackColor = Color.FromArgb(220, 53, 69);
            this.btnUkloniKnjigu.FlatAppearance.BorderSize = 0;
            this.btnUkloniKnjigu.FlatStyle = FlatStyle.Flat;
            this.btnUkloniKnjigu.Font = new Font("Segoe UI", 9F);
            this.btnUkloniKnjigu.ForeColor = Color.White;
            this.btnUkloniKnjigu.Location = new Point(200, 295);
            this.btnUkloniKnjigu.Name = "btnUkloniKnjigu";
            this.btnUkloniKnjigu.Size = new Size(120, 32);
            this.btnUkloniKnjigu.Text = "Ukloni";
            this.btnUkloniKnjigu.Cursor = Cursors.Hand;
            this.btnUkloniKnjigu.Click += new EventHandler(this.btnUkloniKnjigu_Click);

            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnSacuvaj.BackColor = Color.FromArgb(18, 27, 41);
            this.btnSacuvaj.FlatAppearance.BorderSize = 0;
            this.btnSacuvaj.FlatStyle = FlatStyle.Flat;
            this.btnSacuvaj.Font = new Font("Segoe UI", 10F);
            this.btnSacuvaj.ForeColor = Color.White;
            this.btnSacuvaj.Location = new Point(0, 400);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new Size(150, 40);
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.Cursor = Cursors.Hand;
            this.btnSacuvaj.Click += new EventHandler(this.btnSacuvaj_Click);

            // 
            // btnOcisti
            // 
            this.btnOcisti.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnOcisti.BackColor = Color.Gray;
            this.btnOcisti.FlatAppearance.BorderSize = 0;
            this.btnOcisti.FlatStyle = FlatStyle.Flat;
            this.btnOcisti.Font = new Font("Segoe UI", 10F);
            this.btnOcisti.ForeColor = Color.White;
            this.btnOcisti.Location = new Point(170, 400);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new Size(150, 40);
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.Cursor = Cursors.Hand;
            this.btnOcisti.Click += new EventHandler(this.btnOcisti_Click);

            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lblDostupneKnjige);
            this.pnlRight.Controls.Add(this.txtPretragaKnjiga);
            this.pnlRight.Controls.Add(this.dgvKnjige);
            this.pnlRight.Controls.Add(this.btnDodajKnjigu);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Location = new Point(370, 70);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new Size(410, 430);
            this.pnlRight.Padding = new Padding(15, 0, 0, 0);

            // 
            // lblDostupneKnjige
            // 
            this.lblDostupneKnjige.AutoSize = true;
            this.lblDostupneKnjige.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDostupneKnjige.Location = new Point(15, 0);
            this.lblDostupneKnjige.Name = "lblDostupneKnjige";
            this.lblDostupneKnjige.Text = "Dostupne knjige:";

            // 
            // txtPretragaKnjiga
            // 
            this.txtPretragaKnjiga.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtPretragaKnjiga.BorderStyle = BorderStyle.FixedSingle;
            this.txtPretragaKnjiga.Font = new Font("Segoe UI", 10F);
            this.txtPretragaKnjiga.Location = new Point(15, 22);
            this.txtPretragaKnjiga.Name = "txtPretragaKnjiga";
            this.txtPretragaKnjiga.PlaceholderText = "Pretraži knjige...";
            this.txtPretragaKnjiga.Size = new Size(380, 27);
            this.txtPretragaKnjiga.TextChanged += new EventHandler(this.txtPretragaKnjiga_TextChanged);

            // 
            // dgvKnjige
            // 
            this.dgvKnjige.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.dgvKnjige.AllowUserToAddRows = false;
            this.dgvKnjige.AllowUserToDeleteRows = false;
            this.dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKnjige.BackgroundColor = Color.White;
            this.dgvKnjige.BorderStyle = BorderStyle.FixedSingle;
            this.dgvKnjige.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvKnjige.ColumnHeadersHeight = 35;
            this.dgvKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKnjige.DefaultCellStyle = cellStyle;
            this.dgvKnjige.EnableHeadersVisualStyles = false;
            this.dgvKnjige.Location = new Point(15, 55);
            this.dgvKnjige.MultiSelect = false;
            this.dgvKnjige.Name = "dgvKnjige";
            this.dgvKnjige.ReadOnly = true;
            this.dgvKnjige.RowHeadersVisible = false;
            this.dgvKnjige.RowTemplate.Height = 35;
            this.dgvKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKnjige.Size = new Size(380, 310);
            this.dgvKnjige.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvKnjige_DataBindingComplete);

            // 
            // btnDodajKnjigu
            // 
            this.btnDodajKnjigu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnDodajKnjigu.BackColor = Color.FromArgb(40, 167, 69);
            this.btnDodajKnjigu.FlatAppearance.BorderSize = 0;
            this.btnDodajKnjigu.FlatStyle = FlatStyle.Flat;
            this.btnDodajKnjigu.Font = new Font("Segoe UI", 10F);
            this.btnDodajKnjigu.ForeColor = Color.White;
            this.btnDodajKnjigu.Location = new Point(15, 375);
            this.btnDodajKnjigu.Name = "btnDodajKnjigu";
            this.btnDodajKnjigu.Size = new Size(150, 35);
            this.btnDodajKnjigu.Text = "← Dodaj knjigu";
            this.btnDodajKnjigu.Cursor = Cursors.Hand;
            this.btnDodajKnjigu.Click += new EventHandler(this.btnDodajKnjigu_Click);

            // 
            // UCKreirajPozajmicu
            // 
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCKreirajPozajmicu";
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(20);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlOdabraneKnjige.ResumeLayout(false);
            this.pnlOdabraneKnjige.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvOdabraneKnjige).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvKnjige).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblNaslov;
        private Panel pnlLeft;
        private Label lblClan;
        private ComboBox cmbClan;
        private Label lblDatumPozajmice;
        private DateTimePicker dtpDatumPozajmice;
        private Label lblRokVracanja;
        private DateTimePicker dtpRokVracanja;
        private Panel pnlOdabraneKnjige;
        private Label lblOdabraneKnjige;
        private DataGridView dgvOdabraneKnjige;
        private Label lblBrojKnjiga;
        private Button btnUkloniKnjigu;
        private Button btnSacuvaj;
        private Button btnOcisti;
        private Panel pnlRight;
        private Label lblDostupneKnjige;
        private TextBox txtPretragaKnjiga;
        private DataGridView dgvKnjige;
        private Button btnDodajKnjigu;
    }
}