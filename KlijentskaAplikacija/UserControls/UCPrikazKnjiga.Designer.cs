namespace KlijentskaAplikacija.UserControls
{
    partial class UCPrikazKnjiga
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
            btnObrisi = new Button();
            btnReset = new Button();
            btnPretrazi = new Button();
            txtKriterijum = new TextBox();
            lblKriterijum = new Label();
            dgvKnjige = new DataGridView();
            colCheck = new DataGridViewCheckBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            colNaziv = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            pnlDetalji = new Panel();
            grpIzmena = new GroupBox();
            btnPonistiIzmene = new Button();
            btnSacuvajIzmene = new Button();
            numBrojPrimeraka = new NumericUpDown();
            lblIzmeniBrojPrimeraka = new Label();
            txtIzmeniPrezimePisca = new TextBox();
            lblIzmeniPrezimePisca = new Label();
            txtIzmeniImePisca = new TextBox();
            lblIzmeniImePisca = new Label();
            txtIzmeniNaziv = new TextBox();
            lblIzmeniNaziv = new Label();
            btnObrisiSelektovanu = new Button();
            pnlStatusBar = new Panel();
            lblStatusVrednost = new Label();
            lblStatus = new Label();
            lblSlobodnoVrednost = new Label();
            lblSlobodno = new Label();
            lblUkupnoVrednost = new Label();
            lblUkupno = new Label();
            lblPisacVrednost = new Label();
            lblPisac = new Label();
            lblNazivVrednost = new Label();
            lblNazivDetalji = new Label();
            lblDetaljiNaslov = new Label();
            pnlPretraga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKnjige).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            pnlDetalji.SuspendLayout();
            grpIzmena.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBrojPrimeraka).BeginInit();
            pnlStatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblNaslov.Location = new Point(23, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(147, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Sve knjige";
            // 
            // pnlPretraga
            // 
            pnlPretraga.BackColor = Color.White;
            pnlPretraga.BorderStyle = BorderStyle.FixedSingle;
            pnlPretraga.Controls.Add(lblBroj);
            pnlPretraga.Controls.Add(btnObrisi);
            pnlPretraga.Controls.Add(btnReset);
            pnlPretraga.Controls.Add(btnPretrazi);
            pnlPretraga.Controls.Add(txtKriterijum);
            pnlPretraga.Controls.Add(lblKriterijum);
            pnlPretraga.Location = new Point(23, 70);
            pnlPretraga.Name = "pnlPretraga";
            pnlPretraga.Size = new Size(620, 70);
            pnlPretraga.TabIndex = 1;
            // 
            // lblBroj
            // 
            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBroj.ForeColor = Color.Gray;
            lblBroj.Location = new Point(530, 25);
            lblBroj.Name = "lblBroj";
            lblBroj.Size = new Size(81, 20);
            lblBroj.TabIndex = 5;
            lblBroj.Text = "Ukupno: 0";
            // 
            // btnObrisi
            // 
            btnObrisi.BackColor = Color.FromArgb(220, 53, 69);
            btnObrisi.Cursor = Cursors.Hand;
            btnObrisi.FlatAppearance.BorderSize = 0;
            btnObrisi.FlatStyle = FlatStyle.Flat;
            btnObrisi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnObrisi.ForeColor = Color.White;
            btnObrisi.Location = new Point(455, 18);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(65, 34);
            btnObrisi.TabIndex = 4;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = false;
            // btnObrisi.Click += btnObrisi_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gray;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(380, 18);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(65, 34);
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
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(290, 18);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(80, 34);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // txtKriterijum
            // 
            txtKriterijum.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtKriterijum.Location = new Point(85, 20);
            txtKriterijum.Name = "txtKriterijum";
            txtKriterijum.PlaceholderText = "Naziv ili pisac...";
            txtKriterijum.Size = new Size(195, 30);
            txtKriterijum.TabIndex = 1;
            txtKriterijum.KeyDown += txtKriterijum_KeyDown;
            // 
            // lblKriterijum
            // 
            lblKriterijum.AutoSize = true;
            lblKriterijum.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblKriterijum.Location = new Point(10, 23);
            lblKriterijum.Name = "lblKriterijum";
            lblKriterijum.Size = new Size(79, 23);
            lblKriterijum.TabIndex = 0;
            lblKriterijum.Text = "Pretraga:";
            // 
            // dgvKnjige
            // 
            dgvKnjige.AllowUserToAddRows = false;
            dgvKnjige.AllowUserToDeleteRows = false;
            dgvKnjige.AutoGenerateColumns = true;
            dgvKnjige.BackgroundColor = Color.White;
            dgvKnjige.BorderStyle = BorderStyle.Fixed3D;
            dgvKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKnjige.Columns.AddRange(new DataGridViewColumn[] { colCheck, colId, colNaziv });
            dgvKnjige.DataSource = bindingSource1;
            dgvKnjige.Location = new Point(23, 150);
            dgvKnjige.MultiSelect = false;
            dgvKnjige.Name = "dgvKnjige";
            dgvKnjige.ReadOnly = true;
            dgvKnjige.RowHeadersWidth = 30;
            dgvKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKnjige.Size = new Size(620, 300);
            dgvKnjige.TabIndex = 2;
            // 
            // colCheck
            // 
            colCheck.FalseValue = false;
            colCheck.HeaderText = "✓";
            colCheck.MinimumWidth = 6;
            colCheck.Name = "colCheck";
            colCheck.ReadOnly = true;
            colCheck.TrueValue = true;
            colCheck.Width = 40;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 50;
            // 
            // colNaziv
            // 
            colNaziv.DataPropertyName = "Naziv";
            colNaziv.HeaderText = "Naziv";
            colNaziv.MinimumWidth = 6;
            colNaziv.Name = "colNaziv";
            colNaziv.ReadOnly = true;
            colNaziv.Width = 200;
            // 
            // pnlDetalji
            // 
            pnlDetalji.BackColor = Color.White;
            pnlDetalji.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalji.Controls.Add(grpIzmena);
            pnlDetalji.Controls.Add(btnObrisiSelektovanu);
            pnlDetalji.Controls.Add(pnlStatusBar);
            pnlDetalji.Controls.Add(lblSlobodnoVrednost);
            pnlDetalji.Controls.Add(lblSlobodno);
            pnlDetalji.Controls.Add(lblUkupnoVrednost);
            pnlDetalji.Controls.Add(lblUkupno);
            pnlDetalji.Controls.Add(lblPisacVrednost);
            pnlDetalji.Controls.Add(lblPisac);
            pnlDetalji.Controls.Add(lblNazivVrednost);
            pnlDetalji.Controls.Add(lblNazivDetalji);
            pnlDetalji.Controls.Add(lblDetaljiNaslov);
            pnlDetalji.Location = new Point(660, 70);
            pnlDetalji.Name = "pnlDetalji";
            pnlDetalji.Size = new Size(320, 540);
            pnlDetalji.TabIndex = 3;
            // 
            // grpIzmena
            // 
            grpIzmena.Controls.Add(btnPonistiIzmene);
            grpIzmena.Controls.Add(btnSacuvajIzmene);
            grpIzmena.Controls.Add(numBrojPrimeraka);
            grpIzmena.Controls.Add(lblIzmeniBrojPrimeraka);
            grpIzmena.Controls.Add(txtIzmeniPrezimePisca);
            grpIzmena.Controls.Add(lblIzmeniPrezimePisca);
            grpIzmena.Controls.Add(txtIzmeniImePisca);
            grpIzmena.Controls.Add(lblIzmeniImePisca);
            grpIzmena.Controls.Add(txtIzmeniNaziv);
            grpIzmena.Controls.Add(lblIzmeniNaziv);
            grpIzmena.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            grpIzmena.ForeColor = Color.FromArgb(18, 27, 41);
            grpIzmena.Location = new Point(15, 250);
            grpIzmena.Name = "grpIzmena";
            grpIzmena.Size = new Size(288, 280);
            grpIzmena.TabIndex = 12;
            grpIzmena.TabStop = false;
            grpIzmena.Text = "Izmeni knjigu";
            // 
            // btnPonistiIzmene
            // 
            btnPonistiIzmene.BackColor = Color.Gray;
            btnPonistiIzmene.Cursor = Cursors.Hand;
            btnPonistiIzmene.FlatAppearance.BorderSize = 0;
            btnPonistiIzmene.FlatStyle = FlatStyle.Flat;
            btnPonistiIzmene.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPonistiIzmene.ForeColor = Color.White;
            btnPonistiIzmene.Location = new Point(150, 230);
            btnPonistiIzmene.Name = "btnPonistiIzmene";
            btnPonistiIzmene.Size = new Size(125, 35);
            btnPonistiIzmene.TabIndex = 9;
            btnPonistiIzmene.Text = "Poništi";
            btnPonistiIzmene.UseVisualStyleBackColor = false;
            btnPonistiIzmene.Click += btnPonistiIzmene_Click;
            // 
            // btnSacuvajIzmene
            // 
            btnSacuvajIzmene.BackColor = Color.FromArgb(40, 167, 69);
            btnSacuvajIzmene.Cursor = Cursors.Hand;
            btnSacuvajIzmene.FlatAppearance.BorderSize = 0;
            btnSacuvajIzmene.FlatStyle = FlatStyle.Flat;
            btnSacuvajIzmene.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSacuvajIzmene.ForeColor = Color.White;
            btnSacuvajIzmene.Location = new Point(15, 230);
            btnSacuvajIzmene.Name = "btnSacuvajIzmene";
            btnSacuvajIzmene.Size = new Size(125, 35);
            btnSacuvajIzmene.TabIndex = 8;
            btnSacuvajIzmene.Text = "Sačuvaj";
            btnSacuvajIzmene.UseVisualStyleBackColor = false;
            btnSacuvajIzmene.Click += btnSacuvajIzmene_Click;
            // 
            // numBrojPrimeraka
            // 
            numBrojPrimeraka.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numBrojPrimeraka.Location = new Point(18, 194);
            numBrojPrimeraka.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numBrojPrimeraka.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBrojPrimeraka.Name = "numBrojPrimeraka";
            numBrojPrimeraka.Size = new Size(100, 30);
            numBrojPrimeraka.TabIndex = 7;
            numBrojPrimeraka.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblIzmeniBrojPrimeraka
            // 
            lblIzmeniBrojPrimeraka.AutoSize = true;
            lblIzmeniBrojPrimeraka.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIzmeniBrojPrimeraka.ForeColor = Color.Gray;
            lblIzmeniBrojPrimeraka.Location = new Point(15, 167);
            lblIzmeniBrojPrimeraka.Name = "lblIzmeniBrojPrimeraka";
            lblIzmeniBrojPrimeraka.Size = new Size(110, 20);
            lblIzmeniBrojPrimeraka.TabIndex = 6;
            lblIzmeniBrojPrimeraka.Text = "Broj primeraka:";
            // 
            // txtIzmeniPrezimePisca
            // 
            txtIzmeniPrezimePisca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtIzmeniPrezimePisca.Location = new Point(15, 135);
            txtIzmeniPrezimePisca.Name = "txtIzmeniPrezimePisca";
            txtIzmeniPrezimePisca.Size = new Size(260, 30);
            txtIzmeniPrezimePisca.TabIndex = 5;
            // 
            // lblIzmeniPrezimePisca
            // 
            lblIzmeniPrezimePisca.AutoSize = true;
            lblIzmeniPrezimePisca.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIzmeniPrezimePisca.ForeColor = Color.Gray;
            lblIzmeniPrezimePisca.Location = new Point(15, 112);
            lblIzmeniPrezimePisca.Name = "lblIzmeniPrezimePisca";
            lblIzmeniPrezimePisca.Size = new Size(103, 20);
            lblIzmeniPrezimePisca.TabIndex = 4;
            lblIzmeniPrezimePisca.Text = "Prezime pisca:";
            // 
            // txtIzmeniImePisca
            // 
            txtIzmeniImePisca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtIzmeniImePisca.Location = new Point(150, 80);
            txtIzmeniImePisca.Name = "txtIzmeniImePisca";
            txtIzmeniImePisca.Size = new Size(125, 30);
            txtIzmeniImePisca.TabIndex = 3;
            // 
            // lblIzmeniImePisca
            // 
            lblIzmeniImePisca.AutoSize = true;
            lblIzmeniImePisca.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIzmeniImePisca.ForeColor = Color.Gray;
            lblIzmeniImePisca.Location = new Point(150, 57);
            lblIzmeniImePisca.Name = "lblIzmeniImePisca";
            lblIzmeniImePisca.Size = new Size(75, 20);
            lblIzmeniImePisca.TabIndex = 2;
            lblIzmeniImePisca.Text = "Ime pisca:";
            // 
            // txtIzmeniNaziv
            // 
            txtIzmeniNaziv.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtIzmeniNaziv.Location = new Point(15, 80);
            txtIzmeniNaziv.Name = "txtIzmeniNaziv";
            txtIzmeniNaziv.Size = new Size(125, 30);
            txtIzmeniNaziv.TabIndex = 1;
            // 
            // lblIzmeniNaziv
            // 
            lblIzmeniNaziv.AutoSize = true;
            lblIzmeniNaziv.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIzmeniNaziv.ForeColor = Color.Gray;
            lblIzmeniNaziv.Location = new Point(15, 57);
            lblIzmeniNaziv.Name = "lblIzmeniNaziv";
            lblIzmeniNaziv.Size = new Size(49, 20);
            lblIzmeniNaziv.TabIndex = 0;
            lblIzmeniNaziv.Text = "Naziv:";
            // 
            // btnObrisiSelektovanu
            // 
            btnObrisiSelektovanu.BackColor = Color.FromArgb(220, 53, 69);
            btnObrisiSelektovanu.Cursor = Cursors.Hand;
            btnObrisiSelektovanu.FlatAppearance.BorderSize = 0;
            btnObrisiSelektovanu.FlatStyle = FlatStyle.Flat;
            btnObrisiSelektovanu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnObrisiSelektovanu.ForeColor = Color.White;
            btnObrisiSelektovanu.Location = new Point(165, 200);
            btnObrisiSelektovanu.Name = "btnObrisiSelektovanu";
            btnObrisiSelektovanu.Size = new Size(138, 35);
            btnObrisiSelektovanu.TabIndex = 11;
            btnObrisiSelektovanu.Text = "Obriši ovu knjigu";
            btnObrisiSelektovanu.UseVisualStyleBackColor = false;
            btnObrisiSelektovanu.Click += btnObrisiSelektovanu_Click;
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
            pnlStatusBar.Controls.Add(lblStatusVrednost);
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Location = new Point(15, 195);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(140, 40);
            pnlStatusBar.TabIndex = 10;
            // 
            // lblStatusVrednost
            // 
            lblStatusVrednost.AutoSize = true;
            lblStatusVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatusVrednost.ForeColor = Color.FromArgb(40, 167, 69);
            lblStatusVrednost.Location = new Point(60, 8);
            lblStatusVrednost.Name = "lblStatusVrednost";
            lblStatusVrednost.Size = new Size(87, 23);
            lblStatusVrednost.TabIndex = 1;
            lblStatusVrednost.Text = "Dostupna";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(5, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblSlobodnoVrednost
            // 
            lblSlobodnoVrednost.AutoSize = true;
            lblSlobodnoVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSlobodnoVrednost.Location = new Point(130, 160);
            lblSlobodnoVrednost.Name = "lblSlobodnoVrednost";
            lblSlobodnoVrednost.Size = new Size(20, 23);
            lblSlobodnoVrednost.TabIndex = 9;
            lblSlobodnoVrednost.Text = "0";
            // 
            // lblSlobodno
            // 
            lblSlobodno.AutoSize = true;
            lblSlobodno.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSlobodno.ForeColor = Color.Gray;
            lblSlobodno.Location = new Point(15, 160);
            lblSlobodno.Name = "lblSlobodno";
            lblSlobodno.Size = new Size(116, 23);
            lblSlobodno.TabIndex = 8;
            lblSlobodno.Text = "Slobodnih pr.:";
            // 
            // lblUkupnoVrednost
            // 
            lblUkupnoVrednost.AutoSize = true;
            lblUkupnoVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblUkupnoVrednost.Location = new Point(130, 130);
            lblUkupnoVrednost.Name = "lblUkupnoVrednost";
            lblUkupnoVrednost.Size = new Size(20, 23);
            lblUkupnoVrednost.TabIndex = 7;
            lblUkupnoVrednost.Text = "0";
            // 
            // lblUkupno
            // 
            lblUkupno.AutoSize = true;
            lblUkupno.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUkupno.ForeColor = Color.Gray;
            lblUkupno.Location = new Point(15, 130);
            lblUkupno.Name = "lblUkupno";
            lblUkupno.Size = new Size(114, 23);
            lblUkupno.TabIndex = 6;
            lblUkupno.Text = "Ukupno prim:";
            // 
            // lblPisacVrednost
            // 
            lblPisacVrednost.AutoSize = true;
            lblPisacVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblPisacVrednost.Location = new Point(130, 100);
            lblPisacVrednost.Name = "lblPisacVrednost";
            lblPisacVrednost.Size = new Size(109, 23);
            lblPisacVrednost.TabIndex = 5;
            lblPisacVrednost.Text = "Ime Prezime";
            // 
            // lblPisac
            // 
            lblPisac.AutoSize = true;
            lblPisac.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPisac.ForeColor = Color.Gray;
            lblPisac.Location = new Point(15, 100);
            lblPisac.Name = "lblPisac";
            lblPisac.Size = new Size(52, 23);
            lblPisac.TabIndex = 4;
            lblPisac.Text = "Pisac:";
            // 
            // lblNazivVrednost
            // 
            lblNazivVrednost.AutoSize = true;
            lblNazivVrednost.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblNazivVrednost.Location = new Point(130, 70);
            lblNazivVrednost.Name = "lblNazivVrednost";
            lblNazivVrednost.Size = new Size(109, 23);
            lblNazivVrednost.TabIndex = 3;
            lblNazivVrednost.Text = "Naziv knjige";
            // 
            // lblNazivDetalji
            // 
            lblNazivDetalji.AutoSize = true;
            lblNazivDetalji.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNazivDetalji.ForeColor = Color.Gray;
            lblNazivDetalji.Location = new Point(15, 70);
            lblNazivDetalji.Name = "lblNazivDetalji";
            lblNazivDetalji.Size = new Size(56, 23);
            lblNazivDetalji.TabIndex = 2;
            lblNazivDetalji.Text = "Naziv:";
            // 
            // lblDetaljiNaslov
            // 
            lblDetaljiNaslov.AutoSize = true;
            lblDetaljiNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetaljiNaslov.ForeColor = Color.FromArgb(18, 27, 41);
            lblDetaljiNaslov.Location = new Point(15, 20);
            lblDetaljiNaslov.Name = "lblDetaljiNaslov";
            lblDetaljiNaslov.Size = new Size(139, 28);
            lblDetaljiNaslov.TabIndex = 0;
            lblDetaljiNaslov.Text = "Detalji knjige";
            // 
            // UCPrikazKnjiga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlDetalji);
            Controls.Add(dgvKnjige);
            Controls.Add(pnlPretraga);
            Controls.Add(lblNaslov);
            Name = "UCPrikazKnjiga";
            Size = new Size(1000, 620);
            pnlPretraga.ResumeLayout(false);
            pnlPretraga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKnjige).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            pnlDetalji.ResumeLayout(false);
            pnlDetalji.PerformLayout();
            grpIzmena.ResumeLayout(false);
            grpIzmena.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBrojPrimeraka).EndInit();
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Panel pnlPretraga;
        private Label lblKriterijum;
        private TextBox txtKriterijum;
        private Button btnPretrazi;
        private Button btnReset;
        private Button btnObrisi;
        private Label lblBroj;
        private DataGridView dgvKnjige;
        private BindingSource bindingSource1;
        private Panel pnlDetalji;
        private Label lblDetaljiNaslov;
        private Label lblNazivDetalji;
        private Label lblNazivVrednost;
        private Label lblPisac;
        private Label lblPisacVrednost;
        private Label lblUkupno;
        private Label lblUkupnoVrednost;
        private Label lblSlobodno;
        private Label lblSlobodnoVrednost;
        private Panel pnlStatusBar;
        private Label lblStatus;
        private Label lblStatusVrednost;
        private Button btnObrisiSelektovanu;
        private GroupBox grpIzmena;
        private Label lblIzmeniNaziv;
        private TextBox txtIzmeniNaziv;
        private Label lblIzmeniImePisca;
        private TextBox txtIzmeniImePisca;
        private Label lblIzmeniPrezimePisca;
        private TextBox txtIzmeniPrezimePisca;
        private Label lblIzmeniBrojPrimeraka;
        private NumericUpDown numBrojPrimeraka;
        private Button btnSacuvajIzmene;
        private Button btnPonistiIzmene;
        private DataGridViewCheckBoxColumn colCheck;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNaziv;
        private DataGridViewTextBoxColumn colPisac;
        private DataGridViewTextBoxColumn colBrojPrimeraka;
        private DataGridViewTextBoxColumn colBrojSlobodnih;
    }
}