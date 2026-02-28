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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblNaslov = new Label();
            pnlLeft = new Panel();
            lblClan = new Label();
            cmbClan = new ComboBox();
            lblDatumPozajmice = new Label();
            dtpDatumPozajmice = new DateTimePicker();
            lblRokVracanja = new Label();
            dtpRokVracanja = new DateTimePicker();
            pnlOdabraneKnjige = new Panel();
            lblOdabraneKnjige = new Label();
            dgvOdabraneKnjige = new DataGridView();
            lblBrojKnjiga = new Label();
            btnUkloniKnjigu = new Button();
            btnSacuvaj = new Button();
            btnOcisti = new Button();
            pnlRight = new Panel();
            lblDostupneKnjige = new Label();
            dgvKnjige = new DataGridView();
            btnDodajKnjigu = new Button();
            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlOdabraneKnjige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOdabraneKnjige).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKnjige).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblNaslov);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(20, 20);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(0, 10, 0, 0);
            pnlTop.Size = new Size(1118, 50);
            pnlTop.TabIndex = 2;
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(0, 10);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(197, 32);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Nova pozajmica";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(lblClan);
            pnlLeft.Controls.Add(cmbClan);
            pnlLeft.Controls.Add(lblDatumPozajmice);
            pnlLeft.Controls.Add(dtpDatumPozajmice);
            pnlLeft.Controls.Add(lblRokVracanja);
            pnlLeft.Controls.Add(dtpRokVracanja);
            pnlLeft.Controls.Add(pnlOdabraneKnjige);
            pnlLeft.Controls.Add(btnSacuvaj);
            pnlLeft.Controls.Add(btnOcisti);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(20, 70);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(0, 0, 15, 0);
            pnlLeft.Size = new Size(450, 593);
            pnlLeft.TabIndex = 1;
            // 
            // lblClan
            // 
            lblClan.AutoSize = true;
            lblClan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClan.Location = new Point(0, 0);
            lblClan.Name = "lblClan";
            lblClan.Size = new Size(43, 20);
            lblClan.TabIndex = 0;
            lblClan.Text = "Član:";
            // 
            // cmbClan
            // 
            cmbClan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbClan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbClan.Location = new Point(0, 22);
            cmbClan.Name = "cmbClan";
            cmbClan.Size = new Size(420, 31);
            cmbClan.TabIndex = 1;
            // 
            // lblDatumPozajmice
            // 
            lblDatumPozajmice.AutoSize = true;
            lblDatumPozajmice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDatumPozajmice.Location = new Point(0, 60);
            lblDatumPozajmice.Name = "lblDatumPozajmice";
            lblDatumPozajmice.Size = new Size(135, 20);
            lblDatumPozajmice.TabIndex = 2;
            lblDatumPozajmice.Text = "Datum pozajmice:";
            // 
            // dtpDatumPozajmice
            // 
            dtpDatumPozajmice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumPozajmice.Format = DateTimePickerFormat.Short;
            dtpDatumPozajmice.Location = new Point(0, 82);
            dtpDatumPozajmice.Name = "dtpDatumPozajmice";
            dtpDatumPozajmice.Size = new Size(197, 30);
            dtpDatumPozajmice.TabIndex = 3;
            // 
            // lblRokVracanja
            // 
            lblRokVracanja.AutoSize = true;
            lblRokVracanja.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRokVracanja.Location = new Point(221, 61);
            lblRokVracanja.Name = "lblRokVracanja";
            lblRokVracanja.Size = new Size(102, 20);
            lblRokVracanja.TabIndex = 4;
            lblRokVracanja.Text = "Rok vraćanja:";
            // 
            // dtpRokVracanja
            // 
            dtpRokVracanja.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpRokVracanja.Format = DateTimePickerFormat.Short;
            dtpRokVracanja.Location = new Point(221, 84);
            dtpRokVracanja.Name = "dtpRokVracanja";
            dtpRokVracanja.Size = new Size(199, 30);
            dtpRokVracanja.TabIndex = 5;
            // 
            // pnlOdabraneKnjige
            // 
            pnlOdabraneKnjige.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlOdabraneKnjige.Controls.Add(lblOdabraneKnjige);
            pnlOdabraneKnjige.Controls.Add(dgvOdabraneKnjige);
            pnlOdabraneKnjige.Controls.Add(lblBrojKnjiga);
            pnlOdabraneKnjige.Controls.Add(btnUkloniKnjigu);
            pnlOdabraneKnjige.Location = new Point(0, 120);
            pnlOdabraneKnjige.Name = "pnlOdabraneKnjige";
            pnlOdabraneKnjige.Size = new Size(420, 513);
            pnlOdabraneKnjige.TabIndex = 6;
            // 
            // lblOdabraneKnjige
            // 
            lblOdabraneKnjige.AutoSize = true;
            lblOdabraneKnjige.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblOdabraneKnjige.Location = new Point(0, 0);
            lblOdabraneKnjige.Name = "lblOdabraneKnjige";
            lblOdabraneKnjige.Size = new Size(127, 20);
            lblOdabraneKnjige.TabIndex = 0;
            lblOdabraneKnjige.Text = "Odabrane knjige:";
            // 
            // dgvOdabraneKnjige
            // 
            dgvOdabraneKnjige.AllowUserToAddRows = false;
            dgvOdabraneKnjige.AllowUserToDeleteRows = false;
            dgvOdabraneKnjige.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOdabraneKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOdabraneKnjige.BackgroundColor = Color.White;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(18, 27, 41);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(18, 27, 41);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvOdabraneKnjige.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOdabraneKnjige.ColumnHeadersHeight = 35;
            dgvOdabraneKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOdabraneKnjige.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOdabraneKnjige.EnableHeadersVisualStyles = false;
            dgvOdabraneKnjige.Location = new Point(0, 22);
            dgvOdabraneKnjige.MultiSelect = false;
            dgvOdabraneKnjige.Name = "dgvOdabraneKnjige";
            dgvOdabraneKnjige.ReadOnly = true;
            dgvOdabraneKnjige.RowHeadersVisible = false;
            dgvOdabraneKnjige.RowHeadersWidth = 51;
            dgvOdabraneKnjige.RowTemplate.Height = 35;
            dgvOdabraneKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOdabraneKnjige.Size = new Size(420, 403);
            dgvOdabraneKnjige.TabIndex = 1;
            dgvOdabraneKnjige.DataBindingComplete += dgvOdabraneKnjige_DataBindingComplete;
            // 
            // lblBrojKnjiga
            // 
            lblBrojKnjiga.AutoSize = true;
            lblBrojKnjiga.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBrojKnjiga.Location = new Point(0, 300);
            lblBrojKnjiga.Name = "lblBrojKnjiga";
            lblBrojKnjiga.Size = new Size(135, 20);
            lblBrojKnjiga.TabIndex = 2;
            lblBrojKnjiga.Text = "Odabrano knjiga: 0";
            // 
            // btnUkloniKnjigu
            // 
            btnUkloniKnjigu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUkloniKnjigu.BackColor = Color.FromArgb(220, 53, 69);
            btnUkloniKnjigu.Cursor = Cursors.Hand;
            btnUkloniKnjigu.FlatAppearance.BorderSize = 0;
            btnUkloniKnjigu.FlatStyle = FlatStyle.Flat;
            btnUkloniKnjigu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnUkloniKnjigu.ForeColor = Color.White;
            btnUkloniKnjigu.Location = new Point(297, 441);
            btnUkloniKnjigu.Name = "btnUkloniKnjigu";
            btnUkloniKnjigu.Size = new Size(120, 32);
            btnUkloniKnjigu.TabIndex = 3;
            btnUkloniKnjigu.Text = "Ukloni";
            btnUkloniKnjigu.UseVisualStyleBackColor = false;
            btnUkloniKnjigu.Click += btnUkloniKnjigu_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSacuvaj.BackColor = Color.FromArgb(18, 27, 41);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(0, 533);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(150, 40);
            btnSacuvaj.TabIndex = 7;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // btnOcisti
            // 
            btnOcisti.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOcisti.BackColor = Color.Gray;
            btnOcisti.Cursor = Cursors.Hand;
            btnOcisti.FlatAppearance.BorderSize = 0;
            btnOcisti.FlatStyle = FlatStyle.Flat;
            btnOcisti.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOcisti.ForeColor = Color.White;
            btnOcisti.Location = new Point(170, 533);
            btnOcisti.Name = "btnOcisti";
            btnOcisti.Size = new Size(150, 40);
            btnOcisti.TabIndex = 8;
            btnOcisti.Text = "Očisti";
            btnOcisti.UseVisualStyleBackColor = false;
            btnOcisti.Click += btnOcisti_Click;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(lblDostupneKnjige);
            pnlRight.Controls.Add(dgvKnjige);
            pnlRight.Controls.Add(btnDodajKnjigu);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(470, 70);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(15, 0, 0, 0);
            pnlRight.Size = new Size(668, 593);
            pnlRight.TabIndex = 0;
            // 
            // lblDostupneKnjige
            // 
            lblDostupneKnjige.AutoSize = true;
            lblDostupneKnjige.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDostupneKnjige.Location = new Point(99, 60);
            lblDostupneKnjige.Name = "lblDostupneKnjige";
            lblDostupneKnjige.Size = new Size(127, 20);
            lblDostupneKnjige.TabIndex = 0;
            lblDostupneKnjige.Text = "Dostupne knjige:";
            // 
            // dgvKnjige
            // 
            dgvKnjige.AllowUserToAddRows = false;
            dgvKnjige.AllowUserToDeleteRows = false;
            dgvKnjige.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKnjige.BackgroundColor = Color.White;
            dgvKnjige.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKnjige.ColumnHeadersHeight = 35;
            dgvKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvKnjige.DefaultCellStyle = dataGridViewCellStyle3;
            dgvKnjige.EnableHeadersVisualStyles = false;
            dgvKnjige.Location = new Point(99, 82);
            dgvKnjige.MultiSelect = false;
            dgvKnjige.Name = "dgvKnjige";
            dgvKnjige.ReadOnly = true;
            dgvKnjige.RowHeadersVisible = false;
            dgvKnjige.RowHeadersWidth = 51;
            dgvKnjige.RowTemplate.Height = 35;
            dgvKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKnjige.Size = new Size(554, 463);
            dgvKnjige.TabIndex = 2;
            dgvKnjige.DataBindingComplete += dgvKnjige_DataBindingComplete;
            // 
            // btnDodajKnjigu
            // 
            btnDodajKnjigu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDodajKnjigu.BackColor = Color.FromArgb(40, 167, 69);
            btnDodajKnjigu.Cursor = Cursors.Hand;
            btnDodajKnjigu.FlatAppearance.BorderSize = 0;
            btnDodajKnjigu.FlatStyle = FlatStyle.Flat;
            btnDodajKnjigu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodajKnjigu.ForeColor = Color.White;
            btnDodajKnjigu.Location = new Point(99, 555);
            btnDodajKnjigu.Name = "btnDodajKnjigu";
            btnDodajKnjigu.Size = new Size(150, 35);
            btnDodajKnjigu.TabIndex = 3;
            btnDodajKnjigu.Text = "← Dodaj knjigu";
            btnDodajKnjigu.UseVisualStyleBackColor = false;
            btnDodajKnjigu.Click += btnDodajKnjigu_Click;
            // 
            // UCKreirajPozajmicu
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Name = "UCKreirajPozajmicu";
            Padding = new Padding(20);
            Size = new Size(1158, 683);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlOdabraneKnjige.ResumeLayout(false);
            pnlOdabraneKnjige.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOdabraneKnjige).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKnjige).EndInit();
            ResumeLayout(false);
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
        private DataGridView dgvKnjige;
        private Button btnDodajKnjigu;
    }
}