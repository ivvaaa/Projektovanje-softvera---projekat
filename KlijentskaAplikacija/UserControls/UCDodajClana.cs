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
            try
            {
                // Odspoji event dok postavljamo DataSource - sprečava okidanje pre PostaviPocetneVrednosti
                cmbClanstvo.SelectedIndexChanged -= cmbClanstvo_SelectedIndexChanged;
                var tipovi = Komunikacija.Instance.VratiSvaClanstva() ?? new List<Clanstvo>();
                cmbClanstvo.DataSource = tipovi;
                cmbClanstvo.DisplayMember = "Vrsta";
                cmbClanstvo.ValueMember = "Id";
                if (tipovi.Count > 0)
                    cmbClanstvo.SelectedIndex = 0;
                cmbClanstvo.SelectedIndexChanged += cmbClanstvo_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju vrsta članstva: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PostaviPocetneVrednosti()
        {
            dtpDatumOd.Value = DateTime.Now;
            AzurirajDatumDo();
            // dtpDatumDo je ReadOnly – ne može se menjati ručno
            dtpDatumDo.Enabled = false;
        }

        private void AzurirajDatumDo()
        {
            if (cmbClanstvo.SelectedItem is Clanstvo c)
            {
                DateTime od = dtpDatumOd.Value.Date;
                string vrsta = c.Vrsta?.ToLower().Trim() ?? "";

                // VAZNO: polu mora biti pre god jer "polugodišnje".Contains("god") = true
                if (vrsta.Contains("polugodišnje") || vrsta.Contains("polugodisnje") || vrsta.Contains("polu"))
                    dtpDatumDo.Value = od.AddMonths(6);
                else if (vrsta.Contains("godišnje") || vrsta.Contains("godisnje") || vrsta.Contains("god"))
                    dtpDatumDo.Value = od.AddYears(1);
                else
                    // Mesecno i sve ostalo - 1 mesec
                    dtpDatumDo.Value = od.AddMonths(1);
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
                    MessageBox.Show("Sistem je zapamtio clana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OcistiPolja();
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da kreira clana.", "Greška",
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
                MessageBox.Show("Sistem ne moze da kreira clana - unesite sva polja.", "Validacija",
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