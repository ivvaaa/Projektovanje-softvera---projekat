using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KlijentskaAplikacija
{
    partial class FrmMeni
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
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
            picLogo = new PictureBox();
            lblBib = new Label();
            imageList1 = new ImageList(components);
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
            pnlSidebar.Margin = new Padding(6);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 603);
            pnlSidebar.TabIndex = 0;
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
            flpMenu.Location = new Point(0, 70);
            flpMenu.Margin = new Padding(6);
            flpMenu.Name = "flpMenu";
            flpMenu.Padding = new Padding(12, 10, 0, 0);
            flpMenu.Size = new Size(220, 533);
            flpMenu.TabIndex = 2;
            flpMenu.WrapContents = false;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenu.ForeColor = Color.Silver;
            lblMenu.Location = new Point(15, 10);
            lblMenu.Name = "lblMenu";
            lblMenu.Padding = new Padding(5, 0, 0, 10);
            lblMenu.Size = new Size(49, 29);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "MENI";
            // 
            // btnUbaciKnjigu
            // 
            btnUbaciKnjigu.BackColor = Color.White;
            btnUbaciKnjigu.Cursor = Cursors.Hand;
            btnUbaciKnjigu.FlatAppearance.BorderSize = 0;
            btnUbaciKnjigu.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnUbaciKnjigu.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnUbaciKnjigu.FlatStyle = FlatStyle.Flat;
            btnUbaciKnjigu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnUbaciKnjigu.ForeColor = Color.FromArgb(50, 50, 50);
            btnUbaciKnjigu.Image = Properties.Resources.dodaj;
            btnUbaciKnjigu.ImageAlign = ContentAlignment.MiddleLeft;
            btnUbaciKnjigu.Location = new Point(15, 42);
            btnUbaciKnjigu.Name = "btnUbaciKnjigu";
            btnUbaciKnjigu.Padding = new Padding(10, 0, 0, 0);
            btnUbaciKnjigu.Size = new Size(193, 45);
            btnUbaciKnjigu.TabIndex = 1;
            btnUbaciKnjigu.Text = "Ubaci knjigu";
            btnUbaciKnjigu.TextAlign = ContentAlignment.MiddleLeft;
            btnUbaciKnjigu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUbaciKnjigu.UseVisualStyleBackColor = false;
            btnUbaciKnjigu.Click += btnUbaciKnjigu_Click;
            // 
            // btnSveKnjige
            // 
            btnSveKnjige.BackColor = Color.White;
            btnSveKnjige.Cursor = Cursors.Hand;
            btnSveKnjige.FlatAppearance.BorderSize = 0;
            btnSveKnjige.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnSveKnjige.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnSveKnjige.FlatStyle = FlatStyle.Flat;
            btnSveKnjige.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnSveKnjige.ForeColor = Color.FromArgb(50, 50, 50);
            btnSveKnjige.Image = Properties.Resources.knjige;
            btnSveKnjige.ImageAlign = ContentAlignment.MiddleLeft;
            btnSveKnjige.Location = new Point(15, 93);
            btnSveKnjige.Name = "btnSveKnjige";
            btnSveKnjige.Padding = new Padding(10, 0, 0, 0);
            btnSveKnjige.Size = new Size(193, 45);
            btnSveKnjige.TabIndex = 2;
            btnSveKnjige.Text = "Sve knjige";
            btnSveKnjige.TextAlign = ContentAlignment.MiddleLeft;
            btnSveKnjige.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSveKnjige.UseVisualStyleBackColor = false;
            btnSveKnjige.Click += btnSveKnjige_Click;
            // 
            // btnDodajClana
            // 
            btnDodajClana.BackColor = Color.White;
            btnDodajClana.Cursor = Cursors.Hand;
            btnDodajClana.FlatAppearance.BorderSize = 0;
            btnDodajClana.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnDodajClana.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnDodajClana.FlatStyle = FlatStyle.Flat;
            btnDodajClana.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodajClana.ForeColor = Color.FromArgb(50, 50, 50);
            btnDodajClana.Image = Properties.Resources.dodajClana;
            btnDodajClana.ImageAlign = ContentAlignment.MiddleLeft;
            btnDodajClana.Location = new Point(15, 144);
            btnDodajClana.Name = "btnDodajClana";
            btnDodajClana.Padding = new Padding(10, 0, 0, 0);
            btnDodajClana.Size = new Size(193, 45);
            btnDodajClana.TabIndex = 3;
            btnDodajClana.Text = "Dodaj člana";
            btnDodajClana.TextAlign = ContentAlignment.MiddleLeft;
            btnDodajClana.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDodajClana.UseVisualStyleBackColor = false;
            // 
            // btnPronadjiClana
            // 
            btnPronadjiClana.BackColor = Color.White;
            btnPronadjiClana.Cursor = Cursors.Hand;
            btnPronadjiClana.FlatAppearance.BorderSize = 0;
            btnPronadjiClana.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnPronadjiClana.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnPronadjiClana.FlatStyle = FlatStyle.Flat;
            btnPronadjiClana.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnPronadjiClana.ForeColor = Color.FromArgb(50, 50, 50);
            btnPronadjiClana.Image = Properties.Resources.nadji;
            btnPronadjiClana.ImageAlign = ContentAlignment.MiddleLeft;
            btnPronadjiClana.Location = new Point(15, 195);
            btnPronadjiClana.Name = "btnPronadjiClana";
            btnPronadjiClana.Padding = new Padding(10, 0, 0, 0);
            btnPronadjiClana.Size = new Size(193, 45);
            btnPronadjiClana.TabIndex = 4;
            btnPronadjiClana.Text = "Pronađi člana";
            btnPronadjiClana.TextAlign = ContentAlignment.MiddleLeft;
            btnPronadjiClana.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPronadjiClana.UseVisualStyleBackColor = false;
            btnPronadjiClana.Click += btnPronadjiClana_Click;
            // 
            // btnNovaPozajmica
            // 
            btnNovaPozajmica.BackColor = Color.White;
            btnNovaPozajmica.Cursor = Cursors.Hand;
            btnNovaPozajmica.FlatAppearance.BorderSize = 0;
            btnNovaPozajmica.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnNovaPozajmica.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnNovaPozajmica.FlatStyle = FlatStyle.Flat;
            btnNovaPozajmica.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnNovaPozajmica.ForeColor = Color.FromArgb(50, 50, 50);
            btnNovaPozajmica.Image = Properties.Resources.clanarina;
            btnNovaPozajmica.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovaPozajmica.Location = new Point(15, 246);
            btnNovaPozajmica.Name = "btnNovaPozajmica";
            btnNovaPozajmica.Padding = new Padding(10, 0, 0, 0);
            btnNovaPozajmica.Size = new Size(193, 45);
            btnNovaPozajmica.TabIndex = 5;
            btnNovaPozajmica.Text = "Nova pozajmica";
            btnNovaPozajmica.TextAlign = ContentAlignment.MiddleLeft;
            btnNovaPozajmica.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNovaPozajmica.UseVisualStyleBackColor = false;
            btnNovaPozajmica.Click += btnNovaPozajmica_Click;
            // 
            // btnSvaZaduzenja
            // 
            btnSvaZaduzenja.BackColor = Color.White;
            btnSvaZaduzenja.Cursor = Cursors.Hand;
            btnSvaZaduzenja.FlatAppearance.BorderSize = 0;
            btnSvaZaduzenja.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnSvaZaduzenja.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnSvaZaduzenja.FlatStyle = FlatStyle.Flat;
            btnSvaZaduzenja.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnSvaZaduzenja.ForeColor = Color.FromArgb(50, 50, 50);
            btnSvaZaduzenja.Image = Properties.Resources.knjiga;
            btnSvaZaduzenja.ImageAlign = ContentAlignment.MiddleLeft;
            btnSvaZaduzenja.Location = new Point(15, 297);
            btnSvaZaduzenja.Name = "btnSvaZaduzenja";
            btnSvaZaduzenja.Padding = new Padding(10, 0, 0, 0);
            btnSvaZaduzenja.Size = new Size(193, 45);
            btnSvaZaduzenja.TabIndex = 6;
            btnSvaZaduzenja.Text = "Sva zaduženja";
            btnSvaZaduzenja.TextAlign = ContentAlignment.MiddleLeft;
            btnSvaZaduzenja.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSvaZaduzenja.UseVisualStyleBackColor = false;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(picLogo);
            pnlLogo.Controls.Add(lblBib);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(15, 15, 10, 10);
            pnlLogo.Size = new Size(220, 70);
            pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Left;
            picLogo.Location = new Point(15, 15);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(40, 45);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblBib
            // 
            lblBib.AutoSize = true;
            lblBib.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblBib.ForeColor = Color.White;
            lblBib.Location = new Point(60, 22);
            lblBib.Name = "lblBib";
            lblBib.Size = new Size(117, 25);
            lblBib.TabIndex = 1;
            lblBib.Text = "BIBLIOTEKA";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(24, 24);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pnlTopbar
            // 
            pnlTopbar.BackColor = Color.White;
            pnlTopbar.Controls.Add(lblDobrodosli);
            pnlTopbar.Dock = DockStyle.Top;
            pnlTopbar.Location = new Point(220, 0);
            pnlTopbar.Name = "pnlTopbar";
            pnlTopbar.Size = new Size(762, 60);
            pnlTopbar.TabIndex = 1;
            // 
            // lblDobrodosli
            // 
            lblDobrodosli.AutoSize = true;
            lblDobrodosli.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDobrodosli.ForeColor = Color.FromArgb(18, 27, 41);
            lblDobrodosli.Location = new Point(20, 18);
            lblDobrodosli.Name = "lblDobrodosli";
            lblDobrodosli.Size = new Size(245, 28);
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
            pnlMain.Size = new Size(762, 543);
            pnlMain.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(18, 27, 41);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 517);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(762, 26);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.White;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(321, 20);
            lblStatus.Text = "Prijavljen bibliotekar: Ime i prezime (username)";
            // 
            // FrmMeni
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(982, 603);
            Controls.Add(pnlMain);
            Controls.Add(pnlTopbar);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(1000, 650);
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
            private ImageList imageList1;
    }
}
