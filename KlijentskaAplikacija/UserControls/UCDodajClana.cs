using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCDodajClana : UserControl
    {
        public UCDodajClana()
        {
            InitializeComponent();
            UcitajTipoveClanstva();
            PostaviPocetneVrednosti();
        }

        private void UcitajTipoveClanstva()
        {
            var tipovi = new List<Clanstvo>
            {
                new Clanstvo { Id = 1, Vrsta = "Mesečno",     Cena = 300  },
                new Clanstvo { Id = 2, Vrsta = "Polugodišnje", Cena = 1200 },
                new Clanstvo { Id = 3, Vrsta = "Godišnje",    Cena = 2000 }
            };

            cmbClanstvo.DataSource = tipovi;
            cmbClanstvo.DisplayMember = "Vrsta";
            cmbClanstvo.ValueMember = "Id";
            cmbClanstvo.SelectedIndex = 0;
        }

        private void PostaviPocetneVrednosti()
        {
            dtpDatumOd.Value = DateTime.Now;
            AzurirajDatumDo();
            // dtpDatumDo je ReadOnly – ne može se menjati ručno
            dtpDatumDo.Enabled = false;
        }

        // Izračunava kraj na osnovu tipa i početka
        private void AzurirajDatumDo()
        {
            if (cmbClanstvo.SelectedItem is Clanstvo c)
            {
                DateTime od = dtpDatumOd.Value.Date;
                dtpDatumDo.Value = c.Vrsta switch
                {
                    "Mesečno" => od.AddMonths(1),
                    "Polugodišnje" => od.AddMonths(6),
                    "Godišnje" => od.AddYears(1),
                    _ => od.AddMonths(1)
                };
            }
        }

        private void cmbClanstvo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AzurirajDatumDo();
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            AzurirajDatumDo();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;

            try
            {
                var clan = new Clan
                {
                    Ime = txtIme.Text.Trim(),
                    Prezime = txtPrezime.Text.Trim(),
                    Telefon = long.Parse(txtTelefon.Text.Trim()),
                    DatumOd = dtpDatumOd.Value.Date,
                    DatumDo = dtpDatumDo.Value.Date,
                    IdClanstva = (long)cmbClanstvo.SelectedValue
                };

                bool uspeh = Komunikacija.Instance.KreirajClana(clan);

                if (uspeh)
                {
                    MessageBox.Show("Član je uspešno dodat!", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OcistiPolja();
                }
                else
                {
                    MessageBox.Show("Greška pri dodavanju člana.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOcisti_Click(object sender, EventArgs e) => OcistiPolja();

        private bool Validacija()
        {
            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtTelefon.BackColor = Color.White;

            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtIme.Text)) { txtIme.BackColor = Color.LightCoral; ok = false; }
            if (string.IsNullOrWhiteSpace(txtPrezime.Text)) { txtPrezime.BackColor = Color.LightCoral; ok = false; }
            if (string.IsNullOrWhiteSpace(txtTelefon.Text) || !long.TryParse(txtTelefon.Text.Trim(), out _))
            { txtTelefon.BackColor = Color.LightCoral; ok = false; }

            if (!ok)
                MessageBox.Show("Molimo popunite sva obavezna polja ispravno!", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return ok;
        }

        private void OcistiPolja()
        {
            txtIme.Text = txtPrezime.Text = txtTelefon.Text = "";
            txtIme.BackColor = txtPrezime.BackColor = txtTelefon.BackColor = Color.White;
            cmbClanstvo.SelectedIndex = 0;
            dtpDatumOd.Value = DateTime.Now;
            AzurirajDatumDo();
            txtIme.Focus();
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
