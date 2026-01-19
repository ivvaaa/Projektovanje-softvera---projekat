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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvKnjige = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNaziv = new DataGridViewTextBoxColumn();
            colIme = new DataGridViewTextBoxColumn();
            colPrezime = new DataGridViewTextBoxColumn();
            colCheck = new DataGridViewCheckBoxColumn();
            bindingSource1 = new BindingSource(components);
            pnlTop = new Panel();
            btnObrisi = new Button();
            lblKriterijum = new Label();
            txtKriterijum = new TextBox();
            btnPrikazi = new Button();
            btnReset = new Button();
            lblBroj = new Label();
            pnlGrid = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvKnjige).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            pnlTop.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();
            // 
            // dgvKnjige
            // 
            dgvKnjige.AllowUserToAddRows = false;
            dgvKnjige.AllowUserToDeleteRows = false;
            dgvKnjige.AutoGenerateColumns = false;
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKnjige.BackgroundColor = Color.White;
            dgvKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKnjige.Columns.AddRange(new DataGridViewColumn[] { colId, colNaziv, colIme, colPrezime, colCheck });
            dgvKnjige.DataSource = bindingSource1;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvKnjige.DefaultCellStyle = dataGridViewCellStyle1;
            dgvKnjige.Dock = DockStyle.Fill;
            dgvKnjige.Location = new Point(0, 0);
            dgvKnjige.MultiSelect = false;
            dgvKnjige.Name = "dgvKnjige";
            dgvKnjige.RowHeadersVisible = false;
            dgvKnjige.RowHeadersWidth = 51;
            dgvKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKnjige.Size = new Size(591, 384);
            dgvKnjige.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colNaziv
            // 
            colNaziv.DataPropertyName = "Naziv";
            colNaziv.HeaderText = "Naziv";
            colNaziv.MinimumWidth = 6;
            colNaziv.Name = "colNaziv";
            colNaziv.ReadOnly = true;
            // 
            // colIme
            // 
            colIme.DataPropertyName = "ImePisca";
            colIme.HeaderText = "Ime pisca";
            colIme.MinimumWidth = 6;
            colIme.Name = "colIme";
            colIme.ReadOnly = true;
            // 
            // colPrezime
            // 
            colPrezime.DataPropertyName = "PrezimePisca";
            colPrezime.HeaderText = "Prezime pisca";
            colPrezime.MinimumWidth = 6;
            colPrezime.Name = "colPrezime";
            colPrezime.ReadOnly = true;
            // 
            // colCheck
            // 
            colCheck.FalseValue = false;
            colCheck.HeaderText = "✓";
            colCheck.IndeterminateValue = false;
            colCheck.MinimumWidth = 6;
            colCheck.Name = "colCheck";
            colCheck.Resizable = DataGridViewTriState.False;
            colCheck.TrueValue = true;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Controls.Add(btnObrisi);
            pnlTop.Controls.Add(lblKriterijum);
            pnlTop.Controls.Add(txtKriterijum);
            pnlTop.Controls.Add(btnPrikazi);
            pnlTop.Controls.Add(btnReset);
            pnlTop.Controls.Add(lblBroj);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(20, 20);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(591, 70);
            pnlTop.TabIndex = 1;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(494, 33);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(94, 34);
            btnObrisi.TabIndex = 5;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // lblKriterijum
            // 
            lblKriterijum.AutoSize = true;
            lblKriterijum.Location = new Point(0, 10);
            lblKriterijum.Name = "lblKriterijum";
            lblKriterijum.Size = new Size(68, 20);
            lblKriterijum.TabIndex = 0;
            lblKriterijum.Text = "Pretraga:";
            // 
            // txtKriterijum
            // 
            txtKriterijum.Location = new Point(0, 35);
            txtKriterijum.Name = "txtKriterijum";
            txtKriterijum.Size = new Size(242, 27);
            txtKriterijum.TabIndex = 1;
            txtKriterijum.KeyDown += txtKriterijum_KeyDown;

            // 
            // btnPrikazi
            // 
            btnPrikazi.FlatStyle = FlatStyle.Flat;
            btnPrikazi.Location = new Point(248, 33);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(123, 32);
            btnPrikazi.TabIndex = 2;
            btnPrikazi.Text = "Prikaži";
            btnPrikazi.Click += btnPretrazi_Click;

            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(377, 33);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(111, 32);
            btnReset.TabIndex = 3;
            btnReset.Text = "Poništi";
            btnReset.Click += btnReset_Click;

            // 
            // lblBroj
            // 
            lblBroj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBroj.AutoSize = true;
            lblBroj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBroj.Location = new Point(494, 10);
            lblBroj.Name = "lblBroj";
            lblBroj.Size = new Size(81, 20);
            lblBroj.TabIndex = 4;
            lblBroj.Text = "Ukupno: 0";
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvKnjige);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(20, 90);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(591, 384);
            pnlGrid.TabIndex = 0;
            // 
            // UCPrikazKnjiga
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlGrid);
            Controls.Add(pnlTop);
            Name = "UCPrikazKnjiga";
            Padding = new Padding(20);
            Size = new Size(631, 494);
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
        private DataGridViewCheckBoxColumn colCheck;
        private Button btnObrisi;
    }
}
