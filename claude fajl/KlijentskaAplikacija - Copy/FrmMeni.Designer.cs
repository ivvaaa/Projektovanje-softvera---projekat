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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMeni));
            pnlSidebar = new Panel();
            flpMenu = new FlowLayoutPanel();
            lblMenu = new Label();
            btnUbaciKnjigu = new Button();
            imageList1 = new ImageList(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            lblBib = new Label();
            pnlTopbar = new Panel();
            lblDobrodosli = new Label();
            pnlMain = new Panel();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pnlSidebar.SuspendLayout();
            flpMenu.SuspendLayout();
            pnlTopbar.SuspendLayout();
            pnlMain.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(18, 27, 41);
            pnlSidebar.Controls.Add(flpMenu);
            pnlSidebar.Controls.Add(lblBib);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(6);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(12, 0, 0, 0);
            pnlSidebar.Size = new Size(218, 603);
            pnlSidebar.TabIndex = 0;
            // 
            // flpMenu
            // 
            flpMenu.AutoScroll = true;
            flpMenu.Controls.Add(lblMenu);
            flpMenu.Controls.Add(btnUbaciKnjigu);
            flpMenu.Controls.Add(button1);
            flpMenu.Controls.Add(button2);
            flpMenu.Controls.Add(button3);
            flpMenu.Controls.Add(button4);
            flpMenu.Controls.Add(button5);
            flpMenu.Dock = DockStyle.Fill;
            flpMenu.FlowDirection = FlowDirection.TopDown;
            flpMenu.ForeColor = Color.White;
            flpMenu.Location = new Point(12, 23);
            flpMenu.Margin = new Padding(6);
            flpMenu.Name = "flpMenu";
            flpMenu.Padding = new Padding(10, 5, 0, 0);
            flpMenu.Size = new Size(206, 580);
            flpMenu.TabIndex = 2;
            flpMenu.WrapContents = false;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenu.ForeColor = Color.Silver;
            lblMenu.Location = new Point(13, 5);
            lblMenu.Name = "lblMenu";
            lblMenu.Padding = new Padding(8, 2, 0, 0);
            lblMenu.Size = new Size(52, 21);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "MENI";
            lblMenu.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnUbaciKnjigu
            // 
            btnUbaciKnjigu.BackColor = Color.White;
            btnUbaciKnjigu.Cursor = Cursors.Hand;
            btnUbaciKnjigu.FlatAppearance.BorderSize = 0;
            btnUbaciKnjigu.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            btnUbaciKnjigu.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnUbaciKnjigu.FlatStyle = FlatStyle.Flat;
            btnUbaciKnjigu.ForeColor = Color.DimGray;
            btnUbaciKnjigu.ImageAlign = ContentAlignment.MiddleLeft;
            btnUbaciKnjigu.ImageKey = "add.png";
            btnUbaciKnjigu.ImageList = imageList1;
            btnUbaciKnjigu.Location = new Point(13, 29);
            btnUbaciKnjigu.Name = "btnUbaciKnjigu";
            btnUbaciKnjigu.Padding = new Padding(16, 0, 0, 0);
            btnUbaciKnjigu.Size = new Size(193, 45);
            btnUbaciKnjigu.TabIndex = 2;
            btnUbaciKnjigu.Text = "Ubaci knjigu";
            btnUbaciKnjigu.UseVisualStyleBackColor = false;
            btnUbaciKnjigu.Click += btnUbaciKnjigu_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "biblioteka.png");
            imageList1.Images.SetKeyName(1, "clan.png");
            imageList1.Images.SetKeyName(2, "clanarina.png");
            imageList1.Images.SetKeyName(3, "dodaj.png");
            imageList1.Images.SetKeyName(4, "dodajClana.png");
            imageList1.Images.SetKeyName(5, "izmeni.png");
            imageList1.Images.SetKeyName(6, "knjiga.png");
            imageList1.Images.SetKeyName(7, "knjige.png");
            imageList1.Images.SetKeyName(8, "nadji.png");
            imageList1.Images.SetKeyName(9, "podesavanja.png");
            imageList1.Images.SetKeyName(10, "add.png");
            imageList1.Images.SetKeyName(11, "book.png");
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.DimGray;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageKey = "knjiga.png";
            button1.ImageList = imageList1;
            button1.Location = new Point(13, 80);
            button1.Name = "button1";
            button1.Padding = new Padding(16, 0, 0, 0);
            button1.Size = new Size(193, 45);
            button1.TabIndex = 3;
            button1.Text = "Sve knjige";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.DimGray;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImageKey = "dodajClana.png";
            button2.ImageList = imageList1;
            button2.Location = new Point(13, 131);
            button2.Name = "button2";
            button2.Padding = new Padding(16, 0, 0, 0);
            button2.Size = new Size(193, 45);
            button2.TabIndex = 4;
            button2.Text = "Dodaj člana";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.DimGray;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.ImageKey = "nadji.png";
            button3.ImageList = imageList1;
            button3.Location = new Point(13, 182);
            button3.Name = "button3";
            button3.Padding = new Padding(16, 0, 0, 0);
            button3.Size = new Size(193, 45);
            button3.TabIndex = 5;
            button3.Text = "  Pronađi člana";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.DimGray;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.ImageKey = "clanarina.png";
            button4.ImageList = imageList1;
            button4.Location = new Point(13, 233);
            button4.Name = "button4";
            button4.Padding = new Padding(16, 0, 0, 0);
            button4.Size = new Size(193, 45);
            button4.TabIndex = 6;
            button4.Text = "     Nova pozajmica";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.LightCyan;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.DimGray;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.ImageKey = "book.png";
            button5.ImageList = imageList1;
            button5.Location = new Point(13, 284);
            button5.Name = "button5";
            button5.Padding = new Padding(16, 0, 0, 0);
            button5.Size = new Size(200, 45);
            button5.TabIndex = 7;
            button5.Text = "  Sva zaduženja";
            button5.UseVisualStyleBackColor = false;
            // 
            // lblBib
            // 
            lblBib.AutoSize = true;
            lblBib.Dock = DockStyle.Top;
            lblBib.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblBib.ForeColor = Color.White;
            lblBib.Location = new Point(12, 0);
            lblBib.Name = "lblBib";
            lblBib.Size = new Size(105, 23);
            lblBib.TabIndex = 1;
            lblBib.Text = "BIBLIOTEKA";
            lblBib.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTopbar
            // 
            pnlTopbar.AutoScroll = true;
            pnlTopbar.AutoScrollMinSize = new Size(54, 10);
            pnlTopbar.BackColor = Color.White;
            pnlTopbar.Controls.Add(lblDobrodosli);
            pnlTopbar.Dock = DockStyle.Top;
            pnlTopbar.Location = new Point(218, 0);
            pnlTopbar.Name = "pnlTopbar";
            pnlTopbar.Size = new Size(764, 49);
            pnlTopbar.TabIndex = 1;
            // 
            // lblDobrodosli
            // 
            lblDobrodosli.AutoSize = true;
            lblDobrodosli.BackColor = Color.Transparent;
            lblDobrodosli.Dock = DockStyle.Fill;
            lblDobrodosli.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDobrodosli.Location = new Point(0, 0);
            lblDobrodosli.Margin = new Padding(3, 7, 3, 3);
            lblDobrodosli.Name = "lblDobrodosli";
            lblDobrodosli.Padding = new Padding(16, 2, 2, 0);
            lblDobrodosli.Size = new Size(263, 30);
            lblDobrodosli.TabIndex = 0;
            lblDobrodosli.Text = "Dobrodošli nazad, {ime}!";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(statusStrip1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(218, 49);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(764, 554);
            pnlMain.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 528);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(764, 26);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.ActiveLinkColor = Color.Gray;
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
            Text = "Pocetna";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            flpMenu.ResumeLayout(false);
            flpMenu.PerformLayout();
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
        private FlowLayoutPanel flpMenu;
        private Label lblBib;
        private Label lblMenu;
        private Button btnUbaciKnjigu;
        private Panel pnlTopbar;
        private Label lblDobrodosli;
        private Panel pnlMain;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ImageList imageList1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}