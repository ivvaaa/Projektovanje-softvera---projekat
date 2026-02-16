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
using KlijentskaAplikacija.UIKontroler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCDodajClana : UserControl
    {
        public UCDodajClana()
        {
            InitializeComponent();
            PostaviPocetneVrednosti();
        }

        private void PostaviPocetneVrednosti()
        {
            // Postavi datume - članarina počinje danas i traje godinu dana
            dtpDatumOd.Value = DateTime.Now;
            dtpDatumDo.Value = DateTime.Now.AddYears(1);

            // Popuni ComboBox sa tipovima članstva
            UcitajTipoveClanstva();
        }

        private void UcitajTipoveClanstva()
        {
            // Hardkodirani tipovi članstva (možeš kasnije povezati sa serverom)
            var tipovi = new List<Clanstvo>
            {
                new Clanstvo { Id = 1, Vrsta = "Mesečno", Cena = 500 },
                new Clanstvo { Id = 2, Vrsta = "Tromesečno", Cena = 1200 },
                new Clanstvo { Id = 3, Vrsta = "Godišnje", Cena = 4000 }
            };

            cmbClanstvo.DataSource = tipovi;
            cmbClanstvo.DisplayMember = "Vrsta";
            cmbClanstvo.ValueMember = "Id";
            cmbClanstvo.SelectedIndex = 0;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                return;
            }

            try
            {
                Clan clan = new Clan
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

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            OcistiPolja();
        }

        private bool Validacija()
        {
            bool ok = true;

            // Reset boja
            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtTelefon.BackColor = Color.White;

            // Validacija imena
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                txtIme.BackColor = Color.LightCoral;
                ok = false;
            }

            // Validacija prezimena
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                txtPrezime.BackColor = Color.LightCoral;
                ok = false;
            }

            // Validacija telefona
            if (string.IsNullOrWhiteSpace(txtTelefon.Text) || !long.TryParse(txtTelefon.Text.Trim(), out _))
            {
                txtTelefon.BackColor = Color.LightCoral;
                ok = false;
            }

            // Validacija datuma
            if (dtpDatumDo.Value <= dtpDatumOd.Value)
            {
                MessageBox.Show("Datum isteka članarine mora biti nakon datuma početka!", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ok)
            {
                MessageBox.Show("Molimo popunite sva obavezna polja ispravno!", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ok;
        }

        private void OcistiPolja()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtTelefon.Text = "";
            dtpDatumOd.Value = DateTime.Now;
            dtpDatumDo.Value = DateTime.Now.AddYears(1);
            cmbClanstvo.SelectedIndex = 0;

            // Reset boja
            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtTelefon.BackColor = Color.White;

            txtIme.Focus();
        }

        // Samo brojevi u polje za telefon
        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Automatski podesi datum isteka na osnovu tipa članstva
        private void cmbClanstvo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClanstvo.SelectedItem is Clanstvo clanstvo)
            {
                DateTime datumOd = dtpDatumOd.Value;

                switch (clanstvo.Vrsta)
                {
                    case "Mesečno":
                        dtpDatumDo.Value = datumOd.AddMonths(1);
                        break;
                    case "Tromesečno":
                        dtpDatumDo.Value = datumOd.AddMonths(3);
                        break;
                    case "Godišnje":
                        dtpDatumDo.Value = datumOd.AddYears(1);
                        break;
                }
            }
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            // Kada se promeni datum početka, ažuriraj datum isteka
            cmbClanstvo_SelectedIndexChanged(sender, e);
        }
    }
}
