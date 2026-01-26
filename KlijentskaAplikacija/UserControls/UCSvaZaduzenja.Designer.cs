namespace KlijentskaAplikacija.UserControls
{
    partial class UCSvaZaduzenja
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
            dataGridView1 = new DataGridView();
            txtPretraga = new TextBox();
            btnPretrazi = new Button();
            btnReset = new Button();
            Ime = new DataGridViewTextBoxColumn();
            prezime = new DataGridViewTextBoxColumn();
            datum_od = new DataGridViewTextBoxColumn();
            datum_do = new DataGridViewTextBoxColumn();
            br_knjiga = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Ime, prezime, datum_od, datum_do, br_knjiga, status });
            dataGridView1.Location = new Point(21, 192);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(804, 297);
            dataGridView1.TabIndex = 0;
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(22, 130);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(293, 27);
            txtPretraga.TabIndex = 1;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(349, 131);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(94, 29);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(468, 131);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 3;
            btnReset.Text = "Otkazi";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // Ime
            // 
            Ime.HeaderText = "Ime";
            Ime.MinimumWidth = 6;
            Ime.Name = "Ime";
            Ime.Width = 125;
            // 
            // prezime
            // 
            prezime.HeaderText = "Prezime";
            prezime.MinimumWidth = 6;
            prezime.Name = "prezime";
            prezime.Width = 125;
            // 
            // datum_od
            // 
            datum_od.HeaderText = "Datum pozajmice";
            datum_od.MinimumWidth = 6;
            datum_od.Name = "datum_od";
            datum_od.Width = 125;
            // 
            // datum_do
            // 
            datum_do.HeaderText = "Rok pozajmice";
            datum_do.MinimumWidth = 6;
            datum_do.Name = "datum_do";
            datum_do.Width = 125;
            // 
            // br_knjiga
            // 
            br_knjiga.HeaderText = "Broj Knjiga";
            br_knjiga.MinimumWidth = 6;
            br_knjiga.Name = "br_knjiga";
            br_knjiga.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.Width = 125;
            // 
            // UCSvaZaduzenja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReset);
            Controls.Add(btnPretrazi);
            Controls.Add(txtPretraga);
            Controls.Add(dataGridView1);
            Name = "UCSvaZaduzenja";
            Size = new Size(965, 603);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn prezime;
        private DataGridViewTextBoxColumn datum_od;
        private DataGridViewTextBoxColumn datum_do;
        private DataGridViewTextBoxColumn br_knjiga;
        private DataGridViewTextBoxColumn status;
        private TextBox txtPretraga;
        private Button btnPretrazi;
        private Button btnReset;
    }
}
