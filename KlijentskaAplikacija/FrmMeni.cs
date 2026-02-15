using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            PostaviIkone();
            PostaviBeliLogo();

            lblDobrodosli.Text = $"Dobrodošli nazad, {ulogovani.Ime}!";
            lblStatus.Text = $"Prijavljen bibliotekar: {ulogovani.Ime} {ulogovani.Prezime} ({ulogovani.Username})";
        }

        private void PostaviIkone()
        {
            btnUbaciKnjigu.Image = PromeniVelicinu(Properties.Resources.dodaj, 24, 24);
            btnSveKnjige.Image = PromeniVelicinu(Properties.Resources.knjige, 24, 24);
            btnDodajClana.Image = PromeniVelicinu(Properties.Resources.dodajClana, 24, 24);
            btnPronadjiClana.Image = PromeniVelicinu(Properties.Resources.nadji, 24, 24);
            btnNovaPozajmica.Image = PromeniVelicinu(Properties.Resources.clanarina, 24, 24);
            btnSvaZaduzenja.Image = PromeniVelicinu(Properties.Resources.knjiga, 24, 24);
        }

        private Image PromeniVelicinu(Image original, int sirina, int visina)
        {
            Bitmap nova = new Bitmap(sirina, visina);
            using (Graphics g = Graphics.FromImage(nova))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(original, 0, 0, sirina, visina);
            }
            return nova;
        }

        private void PostaviBeliLogo()
        {
            int velicina = 32;
            Bitmap original = new Bitmap(PromeniVelicinu(Properties.Resources.biblioteka, velicina, velicina));
            Bitmap bela = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    if (pixelColor.A > 0)
                    {
                        bela.SetPixel(x, y, Color.FromArgb(pixelColor.A, 255, 255, 255));
                    }
                }
            }
            picLogo.Image = bela;
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

        private void btnSveKnjige_Click(object sender, EventArgs e)
        {
            var uc = new UCPrikazKnjiga();
            PrikazUC(uc);
        }

        private void btnPronadjiClana_Click(object sender, EventArgs e)
        {
            var uc = new UCPrikazClanova();
            PrikazUC(uc);

        }

        private void btnNovaPozajmica_Click(object sender, EventArgs e)
        {
            var uc = new UCKreirajPozajmicu(ulogovani);
            PrikazUC(uc);
        }

        private void btnSvaZaduzenja_Click(object sender, EventArgs e)
        {
            var uc = new UCSvaZaduzenja();
            PrikazUC(uc);

        }
    }
}