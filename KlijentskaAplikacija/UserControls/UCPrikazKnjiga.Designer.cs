namespace KlijentskaAplikacija.UserControls
{
    partial class UCPrikazKnjiga
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvKnjige = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNaziv = new DataGridViewTextBoxColumn();
            colIme = new DataGridViewTextBoxColumn();
            colPrezime = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);

            pnlTop = new Panel();
            pnlGrid = new Panel();
            lblKriterijum = new Label();

            txtKriterijum = new TextBox();
            btnPrikazi = new Button();
            btnReset = new Button();
            lblBroj = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvKnjige).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            pnlTop.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();

            // UC
            BackColor = Color.FromArgb(245, 247, 250);
            Padding = new Padding(20);
            Name = "UCPrikazKnjiga";
            Size = new Size(631, 494);

            // pnlTop
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 70;
            pnlTop.BackColor = Color.Transparent;

            // lblKriterijum
            lblKriterijum.AutoSize = true;
            lblKriterijum.Location = new Point(0, 10);
            lblKriterijum.Text = "Pretraga:";

            // txtKriterijum
            txtKriterijum.Location = new Point(0, 35);
            txtKriterijum.Size = new Size(260, 27);

            // btnPrikazi
            btnPrikazi.Location = new Point(275, 33);
            btnPrikazi.Size = new Size(110, 32);
            btnPrikazi.Text = "Prikaži";
            btnPrikazi.FlatStyle = FlatStyle.Flat;

            // btnReset
            btnReset.Location = new Point(395, 33);
            btnReset.Size = new Size(110, 32);
            btnReset.Text = "Poništi";
            btnReset.FlatStyle = FlatStyle.Flat;

            // lblBroj
            lblBroj.AutoSize = true;
            lblBroj.Text = "Ukupno: 0";
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            // desno gore (pošto panel nema auto layout, držimo fiksno; ili Anchor)
            lblBroj.Location = new Point(520, 10);
            lblBroj.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            pnlTop.Controls.Add(lblKriterijum);
            pnlTop.Controls.Add(txtKriterijum);
            pnlTop.Controls.Add(btnPrikazi);
            pnlTop.Controls.Add(btnReset);
            pnlTop.Controls.Add(lblBroj);

            // pnlGrid
            pnlGrid.Dock = DockStyle.Fill;

            // dgvKnjige
            dgvKnjige.AllowUserToAddRows = false;
            dgvKnjige.AllowUserToDeleteRows = false;
            dgvKnjige.AutoGenerateColumns = false;
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKnjige.Columns.AddRange(new DataGridViewColumn[] { colId, colNaziv, colIme, colPrezime });
            dgvKnjige.DataSource = bindingSource1;
            dgvKnjige.Dock = DockStyle.Fill;
            dgvKnjige.MultiSelect = false;
            dgvKnjige.ReadOnly = true;
            dgvKnjige.RowHeadersVisible = false;
            dgvKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKnjige.BackgroundColor = Color.White;
            dgvKnjige.BorderStyle = BorderStyle.FixedSingle;

            // kolone
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false; // preporuka

            colNaziv.DataPropertyName = "Naziv";
            colNaziv.HeaderText = "Naziv";
            colNaziv.Name = "colNaziv";
            colNaziv.ReadOnly = true;

            colIme.DataPropertyName = "ImePisca";
            colIme.HeaderText = "Ime pisca";
            colIme.Name = "colIme";
            colIme.ReadOnly = true;

            colPrezime.DataPropertyName = "PrezimePisca";
            colPrezime.HeaderText = "Prezime pisca";
            colPrezime.Name = "colPrezime";
            colPrezime.ReadOnly = true;

            pnlGrid.Controls.Add(dgvKnjige);

            Controls.Add(pnlGrid);
            Controls.Add(pnlTop);

            ((System.ComponentModel.ISupportInitialize)dgvKnjige).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private Panel pnlTop;
        private Panel pnlGrid;
        private DataGridView dgvKnjige;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNaziv;
        private DataGridViewTextBoxColumn colIme;
        private DataGridViewTextBoxColumn colPrezime;
        private BindingSource bindingSource1;
        private TextBox txtKriterijum;
        private Button btnPrikazi;
        private Button btnReset;
        private Label lblKriterijum;
        private Label lblBroj;
    }
}
