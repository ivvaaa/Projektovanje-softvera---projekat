namespace KlijentskaAplikacija
{
    partial class FrmMeni
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            flpMenu = new FlowLayoutPanel();
            lblMenu = new Label();
            btnUbaciKnjigu = new Button();
            btnSveKnjige = new Button();
            btnDodajClana = new Button();
            btnPronadjiClana = new Button();
            btnNovaPozajmica = new Button();
            btnSvaZaduzenja = new Button();
            pnlLogo = new Panel();
            lblBib = new Label();
            picLogo = new PictureBox();
            pnlTopbar = new Panel();
            lblDobrodosli = new Label();
            pnlMain = new Panel();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pnlSidebar.SuspendLayout();
            flpMenu.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlTopbar.SuspendLayout();
            pnlMain.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(18, 27, 41);
            pnlSidebar.Controls.Add(flpMenu);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 600);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(picLogo);
            pnlLogo.Controls.Add(lblBib);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(15, 10, 10, 10);
            pnlLogo.Size = new Size(220, 60);
            pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Left;
            picLogo.Location = new Point(15, 10);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(40, 40);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblBib
            // 
            lblBib.AutoSize = true;
            lblBib.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBib.ForeColor = Color.White;
            lblBib.Location = new Point(60, 18);
            lblBib.Name = "lblBib";
            lblBib.Size = new Size(103, 21);
            lblBib.TabIndex = 1;
            lblBib.Text = "BIBLIOTEKA";
            // 
            // flpMenu
            // 
            flpMenu.AutoScroll = true;
            flpMenu.Controls.Add(lblMenu);
            flpMenu.Controls.Add(btnUbaciKnjigu);
            flpMenu.Controls.Add(btnSveKnjige);
            flpMenu.Controls.Add(btnDodajClana);
            flpMenu.Controls.Add(btnPronadjiClana);
            flpMenu.Controls.Add(btnNovaPozajmica);
            flpMenu.Controls.Add(btnSvaZaduzenja);
            flpMenu.Dock = DockStyle.Fill;
            flpMenu.FlowDirection = FlowDirection.TopDown;
            flpMenu.ForeColor = Color.White;
            flpMenu.Location = new Point(0, 60);
            flpMenu.Name = "flpMenu";
            flpMenu.Padding = new Padding(15, 10, 0, 0);
            flpMenu.Size = new Size(220, 540);
            flpMenu.TabIndex = 2;
            flpMenu.WrapContents = false;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblMenu.ForeColor = Color.Silver;
            lblMenu.Location = new Point(18, 10);
            lblMenu.Name = "lblMenu";
            lblMenu.Padding = new Padding(5, 0, 0, 5);
            lblMenu.Size = new Size(45, 18);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "MENI";
            // 
            // btnUbaciKnjigu
            // 
            btnUbaciKnjigu.BackColor = Color.White;
            btnUbaciKnjigu.Cursor = Cursors.Hand;
            btnUbaciKnjigu.FlatAppearance.BorderSize = 0;
            btnUbaciKnjigu.FlatStyle = FlatStyle.Flat;
            btnUbaciKnjigu.Font = new Font("Segoe UI", 9.5F);
            btnUbaciKnjigu.ForeColor = Color.FromArgb(50, 50, 50);
            btnUbaciKnjigu.Location = new Point(18, 31);
            btnUbaciKnjigu.Name = "btnUbaciKnjigu";
            btnUbaciKnjigu.Size = new Size(185, 40);
            btnUbaciKnjigu.TabIndex = 1;
            btnUbaciKnjigu.Text = "    Ubaci knjigu";
            btnUbaciKnjigu.TextAlign = ContentAlignment.MiddleLeft;
            btnUbaciKnjigu.UseVisualStyleBackColor = false;
            btnUbaciKnjigu.Click += btnUbaciKnjigu_Click;
            // 
            // btnSveKnjige
            // 
            btnSveKnjige.BackColor = Color.White;
            btnSveKnjige.Cursor = Cursors.Hand;
            btnSveKnjige.FlatAppearance.BorderSize = 0;
            btnSveKnjige.FlatStyle = FlatStyle.Flat;
            btnSveKnjige.Font = new Font("Segoe UI", 9.5F);
            btnSveKnjige.ForeColor = Color.FromArgb(50, 50, 50);
            btnSveKnjige.Location = new Point(18, 77);
            btnSveKnjige.Name = "btnSveKnjige";
            btnSveKnjige.Size = new Size(185, 40);
            btnSveKnjige.TabIndex = 2;
            btnSveKnjige.Text = "    Sve knjige";
            btnSveKnjige.TextAlign = ContentAlignment.MiddleLeft;
            btnSveKnjige.UseVisualStyleBackColor = false;
            // 
            // btnDodajClana
            // 
            btnDodajClana.BackColor = Color.White;
            btnDodajClana.Cursor = Cursors.Hand;
            btnDodajClana.FlatAppearance.BorderSize = 0;
            btnDodajClana.FlatStyle = FlatStyle.Flat;
            btnDodajClana.Font = new Font("Segoe UI", 9.5F);
            btnDodajClana.ForeColor = Color.FromArgb(50, 50, 50);
            btnDodajClana.Location = new Point(18, 123);
            btnDodajClana.Name = "btnDodajClana";
            btnDodajClana.Size = new Size(185, 40);
            btnDodajClana.TabIndex = 3;
            btnDodajClana.Text = "    Dodaj člana";
            btnDodajClana.TextAlign = ContentAlignment.MiddleLeft;
            btnDodajClana.UseVisualStyleBackColor = false;
            // 
            // btnPronadjiClana
            // 
            btnPronadjiClana.BackColor = Color.White;
            btnPronadjiClana.Cursor = Cursors.Hand;
            btnPronadjiClana.FlatAppearance.BorderSize = 0;
            btnPronadjiClana.FlatStyle = FlatStyle.Flat;
            btnPronadjiClana.Font = new Font("Segoe UI", 9.5F);
            btnPronadjiClana.ForeColor = Color.FromArgb(50, 50, 50);
            btnPronadjiClana.Location = new Point(18, 169);
            btnPronadjiClana.Name = "btnPronadjiClana";
            btnPronadjiClana.Size = new Size(185, 40);
            btnPronadjiClana.TabIndex = 4;
            btnPronadjiClana.Text = "    Pronađi člana";
            btnPronadjiClana.TextAlign = ContentAlignment.MiddleLeft;
            btnPronadjiClana.UseVisualStyleBackColor = false;
            // 
            // btnNovaPozajmica
            // 
            btnNovaPozajmica.BackColor = Color.White;
            btnNovaPozajmica.Cursor = Cursors.Hand;
            btnNovaPozajmica.FlatAppearance.BorderSize = 0;
            btnNovaPozajmica.FlatStyle = FlatStyle.Flat;
            btnNovaPozajmica.Font = new Font("Segoe UI", 9.5F);
            btnNovaPozajmica.ForeColor = Color.FromArgb(50, 50, 50);
            btnNovaPozajmica.Location = new Point(18, 215);
            btnNovaPozajmica.Name = "btnNovaPozajmica";
            btnNovaPozajmica.Size = new Size(185, 40);
            btnNovaPozajmica.TabIndex = 5;
            btnNovaPozajmica.Text = "    Nova pozajmica";
            btnNovaPozajmica.TextAlign = ContentAlignment.MiddleLeft;
            btnNovaPozajmica.UseVisualStyleBackColor = false;
            // 
            // btnSvaZaduzenja
            // 
            btnSvaZaduzenja.BackColor = Color.White;
            btnSvaZaduzenja.Cursor = Cursors.Hand;
            btnSvaZaduzenja.FlatAppearance.BorderSize = 0;
            btnSvaZaduzenja.FlatStyle = FlatStyle.Flat;
            btnSvaZaduzenja.Font = new Font("Segoe UI", 9.5F);
            btnSvaZaduzenja.ForeColor = Color.FromArgb(50, 50, 50);
            btnSvaZaduzenja.Location = new Point(18, 261);
            btnSvaZaduzenja.Name = "btnSvaZaduzenja";
            btnSvaZaduzenja.Size = new Size(185, 40);
            btnSvaZaduzenja.TabIndex = 6;
            btnSvaZaduzenja.Text = "    Sva zaduženja";
            btnSvaZaduzenja.TextAlign = ContentAlignment.MiddleLeft;
            btnSvaZaduzenja.UseVisualStyleBackColor = false;
            // 
            // pnlTopbar
            // 
            pnlTopbar.BackColor = Color.White;
            pnlTopbar.Controls.Add(lblDobrodosli);
            pnlTopbar.Dock = DockStyle.Top;
            pnlTopbar.Location = new Point(220, 0);
            pnlTopbar.Name = "pnlTopbar";
            pnlTopbar.Size = new Size(764, 60);
            pnlTopbar.TabIndex = 1;
            // 
            // lblDobrodosli
            // 
            lblDobrodosli.AutoSize = true;
            lblDobrodosli.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDobrodosli.ForeColor = Color.FromArgb(18, 27, 41);
            lblDobrodosli.Location = new Point(20, 18);
            lblDobrodosli.Name = "lblDobrodosli";
            lblDobrodosli.Size = new Size(230, 25);
            lblDobrodosli.TabIndex = 0;
            lblDobrodosli.Text = "Dobrodošli nazad, {ime}!";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(245, 247, 250);
            pnlMain.Controls.Add(statusStrip1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(220, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(764, 540);
            pnlMain.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(18, 27, 41);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(764, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.White;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(250, 17);
            lblStatus.Text = "Prijavljen bibliotekar: Ime i prezime (username)";
            // 
            // FrmMeni
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 600);
            Controls.Add(pnlMain);
            Controls.Add(pnlTopbar);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1000, 640);
            Name = "FrmMeni";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Biblioteka - Glavni meni";
            pnlSidebar.ResumeLayout(false);
            flpMenu.ResumeLayout(false);
            flpMenu.PerformLayout();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlTopbar.ResumeLayout(false);
            pnlTopbar.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlLogo;
        private PictureBox picLogo;
        private Label lblBib;
        private FlowLayoutPanel flpMenu;
        private Label lblMenu;
        private Button btnUbaciKnjigu;
        private Button btnSveKnjige;
        private Button btnDodajClana;
        private Button btnPronadjiClana;
        private Button btnNovaPozajmica;
        private Button btnSvaZaduzenja;
        private Panel pnlTopbar;
        private Label lblDobrodosli;
        private Panel pnlMain;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}
