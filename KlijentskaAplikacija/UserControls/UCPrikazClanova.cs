using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCPrikazClanova : UserControl
    {
        private Clan selektovaniClan = null;
        private List<Clanstvo> listaClanstava = new List<Clanstvo>();

        public UCPrikazClanova()
        {
            InitializeComponent();

            // Odspoji SelectionChanged pri punjenju da ne okida PrikaziSelektovanogClana
            dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;
            dgvClanovi.CellClick += dgvClanovi_CellClick;

            UcitajClanstva();
            UcitajSveClanove();

            pnlDetalji.Visible = false;
        }

        // SK7 preduslov - ucitavanje liste clanstava u ComboBox
        private void UcitajClanstva()
        {
            try
            {
                listaClanstava = Komunikacija.Instance.VratiSvaClanstva() ?? new List<Clanstvo>();
                cmbClanstvoFilter.Items.Clear();
                cmbClanstvoFilter.Items.Add("(Sva članstva)");
                foreach (var c in listaClanstava)
                    cmbClanstvoFilter.Items.Add(c);
                cmbClanstvoFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju vrsta članstva: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClanovi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                PrikaziSelektovanogClana();
        }

        private void dgvClanovi_SelectionChanged(object sender, EventArgs e)
        {
            PrikaziSelektovanogClana();
        }

        // SK7 koraci 5-8
        private void PrikaziSelektovanogClana()
        {
            if (dgvClanovi.CurrentRow != null && dgvClanovi.CurrentRow.DataBoundItem is Clan c)
            {
                try
                {
                    selektovaniClan = c;
                    PrikaziDetalje(c);
                    pnlDetalji.Visible = true;
                }
                catch (Exception)
                {
                    // SK7 alternativa 8.1
                    pnlDetalji.Visible = false;
                    selektovaniClan = null;
                    MessageBox.Show("Sistem ne može da nađe člana.",
                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pnlDetalji.Visible = false;
                selektovaniClan = null;
            }
        }

        private void PrikaziDetalje(Clan c)
        {
            // Status bar
            if (c.DatumDo < DateTime.Now)
            {
                lblStatus.Text = "Članarina istekla";
                lblStatus.ForeColor = Color.FromArgb(220, 53, 69);
                pnlStatusBar.BackColor = Color.FromArgb(255, 235, 238);
            }
            else
            {
                lblStatus.Text = "Aktivna članarina";
                lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
                pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
            }

            lblDatumOdVrednost.Text = c.DatumOd.ToString("dd.MM.yyyy");
            lblDatumDoVrednost.Text = c.DatumDo.ToString("dd.MM.yyyy");

            // Clanstvo naziv
            var clanstvo = listaClanstava.FirstOrDefault(cs => cs.Id == c.IdClanstva);
            lblClanstvoVrednost.Text = clanstvo != null ? clanstvo.ToString() : "-";

            // Popuni polja za izmenu - uvek vidljiva (kao kod knjiga)
            txtIzmeniIme.Text = c.Ime;
            txtIzmeniPrezime.Text = c.Prezime;
            txtIzmeniTelefon.Text = c.Telefon.ToString();
        }


        private void UcitajSveClanove()
        {
            try
            {
                // Odspoji event pri punjenju
                dgvClanovi.SelectionChanged -= dgvClanovi_SelectionChanged;

                List<Clan> lista = Komunikacija.Instance.PretraziClanove("") ?? new List<Clan>();
                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                ResetujBoje();
                pnlDetalji.Visible = false;
                selektovaniClan = null;

                dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;
            }
            catch (Exception ex)
            {
                dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;
                MessageBox.Show("Greška pri učitavanju članova: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetujBoje()
        {
            foreach (DataGridViewRow row in dgvClanovi.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            Pretrazi();
        }

        // SK7 koraci 1-4 i alternativa 4.1
        private void Pretrazi()
        {
            try
            {
                string kriterijum = txtKriterijum.Text.Trim();

                // Odspoji pri punjenju
                dgvClanovi.SelectionChanged -= dgvClanovi_SelectionChanged;

                // a) pretraga po tekstu - server
                List<Clan> lista = Komunikacija.Instance.PretraziClanove(kriterijum) ?? new List<Clan>();

                // b) filter po clanstvu - klijentski
                if (cmbClanstvoFilter.SelectedItem is Clanstvo izabranoClanstvo)
                    lista = lista.Where(c => c.IdClanstva == izabranoClanstvo.Id).ToList();

                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                ResetujBoje();
                pnlDetalji.Visible = false;
                selektovaniClan = null;

                dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;

                // SK7 korak 4 / alternativa 4.1
                bool imaKriterijum = !string.IsNullOrEmpty(kriterijum) ||
                                     cmbClanstvoFilter.SelectedItem is Clanstvo;
                if (lista.Count == 0 && imaKriterijum)
                    MessageBox.Show("Sistem ne može da nađe članove po zadatom kriterijumu.",
                        "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (lista.Count > 0 && imaKriterijum)
                    MessageBox.Show(
                        $"Sistem je našao člane po zadatim kriterijumima.",
                        "Pretraga uspešna", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;
                MessageBox.Show("Greška pri pretrazi: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKriterijum.Text = "";
            cmbClanstvoFilter.SelectedIndex = 0;
            UcitajSveClanove();
        }

        private void txtKriterijum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Pretrazi();
            }
        }


        private void btnObrisiSelektovanog_Click(object sender, EventArgs e)
        {
            if (selektovaniClan == null) return;

            var confirm = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete člana {selektovaniClan.Ime} {selektovaniClan.Prezime}?",
                "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = Komunikacija.Instance.ObrisiClana(selektovaniClan.Id);
                if (ok)
                {
                    MessageBox.Show("Član uspešno obrisan.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajSveClanove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SK7 korak 10-13 - Sacuvaj (uvek vidljiv, nema toggle rezima)
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (selektovaniClan == null) return;

            // SK7 korak 10 - validacija
            if (string.IsNullOrWhiteSpace(txtIzmeniIme.Text) ||
                string.IsNullOrWhiteSpace(txtIzmeniPrezime.Text))
            {
                MessageBox.Show("Sistem ne može da zapamti člana - unesite sva polja.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selektovaniClan.Ime = txtIzmeniIme.Text.Trim();
                selektovaniClan.Prezime = txtIzmeniPrezime.Text.Trim();
                if (long.TryParse(txtIzmeniTelefon.Text.Trim(), out long tel))
                    selektovaniClan.Telefon = tel;

                bool ok = Komunikacija.Instance.IzmeniClana(selektovaniClan);
                if (ok)
                {
                    // SK7 korak 13
                    MessageBox.Show("Sistem je zapamtio člana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajSveClanove();
                }
                else
                {
                    // SK7 alternativa 13.1
                    MessageBox.Show("Sistem ne može da zapamti člana.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti člana.\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            // Poništi izmene - vrati originalne vrednosti
            if (selektovaniClan != null)
                PrikaziDetalje(selektovaniClan);
        }
    }
}