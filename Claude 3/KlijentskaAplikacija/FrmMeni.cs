using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UserControls;

namespace KlijentskaAplikacija
{
    public partial class FrmMeni : Form
    {
        private Bibliotekar ulogovani;

        public FrmMeni(Bibliotekar bibliotekar)
        {
            InitializeComponent();
            ulogovani = bibliotekar;

            // Postavi ime u labelu dobrodošlice
            lblDobrodosli.Text = $"Dobrodošli nazad, {ulogovani.Ime}!";

            // Postavi status bar
            lblStatus.Text = $"Prijavljen bibliotekar: {ulogovani.Ime} {ulogovani.Prezime} ({ulogovani.Username})";

            // Učitaj ikonice
            UcitajIkonice();
        }

        private void UcitajIkonice()
        {
            picLogo.Image = Properties.Resources.biblioteka;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            PostaviIkonicu(btnUbaciKnjigu, Properties.Resources.dodaj);
            PostaviIkonicu(btnSveKnjige, Properties.Resources.knjige);
            PostaviIkonicu(btnDodajClana, Properties.Resources.dodajClana);
            PostaviIkonicu(btnPronadjiClana, Properties.Resources.nadji);
            PostaviIkonicu(btnNovaPozajmica, Properties.Resources.knjiga);
            PostaviIkonicu(btnSvaZaduzenja, Properties.Resources.clanarina);
        }
        private void PostaviIkonicu(Button btn, Image img)
        {
            btn.Image = new Bitmap(img, new Size(24, 24));
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
        }


        private void PrikazUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnUbaciKnjigu_Click(object sender, EventArgs e)
        {
            var uc = new UCUbaciKnjigu();
            PrikazUC(uc);
        }
    }
}
