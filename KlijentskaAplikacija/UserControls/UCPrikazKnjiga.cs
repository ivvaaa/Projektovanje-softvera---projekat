using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCPrikazKnjiga : UserControl
    {
        private Knjiga selektovanaKnjiga = null;

        public UCPrikazKnjiga()
        {
            InitializeComponent();
            PodesavanjeKolona();
            dgvKnjige.SelectionChanged += dgvKnjige_SelectionChanged;
            dgvKnjige.CellFormatting += dgvKnjige_CellFormatting;

            dgvKnjige.AllowUserToOrderColumns = true;

            UcitajSveKnjige();
            pnlDetalji.Visible = false;
        }

        private void UcitajSveKnjige()
        {
            try
            {
                List<Knjiga> lista = Komunikacija.Instance.PretraziKnjige("") ?? new List<Knjiga>();
                bindingSource1.DataSource = lista;
                lblBroj.Text = $"Ukupno knjiga: {lista.Count}";
                ResetujBoje();
                pnlDetalji.Visible = false;
                selektovanaKnjiga = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju knjiga: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKnjige_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKnjige.CurrentRow != null && dgvKnjige.CurrentRow.DataBoundItem is Knjiga k)
            {
                selektovanaKnjiga = k;
                PrikaziDetalje(k);
                pnlDetalji.Visible = true;
            }
            else
            {
                pnlDetalji.Visible = false;
                selektovanaKnjiga = null;
            }
        }

        private void PrikaziDetalje(Knjiga k)
        {
            lblNazivVrednost.Text = k.Naziv;
            lblPisacVrednost.Text = $"{k.ImePisca} {k.PrezimePisca}";
            lblUkupnoVrednost.Text = k.BrojPrimeraka.ToString();
            lblSlobodnoVrednost.Text = k.BrojSlobodnih.ToString();

            // Status dostupnosti
            if (k.BrojSlobodnih > 0)
            {
                lblStatusVrednost.Text = "Dostupna";
                lblStatusVrednost.ForeColor = Color.FromArgb(40, 167, 69);
                pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
            }
            else
            {
                lblStatusVrednost.Text = "Nedostupna";
                lblStatusVrednost.ForeColor = Color.FromArgb(220, 53, 69);
                pnlStatusBar.BackColor = Color.FromArgb(255, 235, 238);
            }

            // Postavi vrednosti u polja za izmenu
            txtIzmeniNaziv.Text = k.Naziv;
            txtIzmeniImePisca.Text = k.ImePisca;
            txtIzmeniPrezimePisca.Text = k.PrezimePisca;
            numBrojPrimeraka.Value = k.BrojPrimeraka;

            // Postavi minimum za broj primeraka na osnovu pozajmljenih
            int brojPozajmljenih = k.BrojPrimeraka - k.BrojSlobodnih;
            numBrojPrimeraka.Minimum = brojPozajmljenih;

            // Ako je neki primerak pozajmljen, prikaži upozorenje
            if (brojPozajmljenih > 0)
            {
                lblUkupnoVrednost.Text = $"{k.BrojPrimeraka} (min: {brojPozajmljenih} pozajmljeno)";
            }
        }

        private void dgvKnjige_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Bojenje kolone BrojSlobodnih
            if (dgvKnjige.Columns[e.ColumnIndex].DataPropertyName == "BrojSlobodnih" && e.Value != null)
            {
                int brojSlobodnih = Convert.ToInt32(e.Value);
                if (brojSlobodnih == 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font(dgvKnjige.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                }
            }

            // Bojenje kolone BrojPrimeraka - prikaži upozorenje ako je nizak broj
            if (dgvKnjige.Columns[e.ColumnIndex].DataPropertyName == "BrojPrimeraka" && e.Value != null)
            {
                int brojPrimeraka = Convert.ToInt32(e.Value);
                if (brojPrimeraka <= 3)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7); // Warning boja
                    e.CellStyle.Font = new Font(dgvKnjige.Font, FontStyle.Bold);
                }
            }
        }

        private void ResetujBoje()
        {
            foreach (DataGridViewRow row in dgvKnjige.Rows)
            {
                row.Cells["colCheck"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            Pretrazi();
        }

        private void Pretrazi()
        {
            try
            {
                string kriterijum = txtKriterijum.Text.Trim();
                List<Knjiga> lista = Komunikacija.Instance.PretraziKnjige(kriterijum) ?? new List<Knjiga>();

                bindingSource1.DataSource = lista;
                lblBroj.Text = $"Ukupno knjiga: {lista.Count}";

                ResetujBoje();
                pnlDetalji.Visible = false;

                if (lista.Count == 0)
                {
                    MessageBox.Show("Nema rezultata za uneti kriterijum.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pretrazi: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKriterijum.Text = "";
            UcitajSveKnjige();
        }

        private void txtKriterijum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Pretrazi();
            }
        }

        //private void btnObrisi_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<long> ids = new List<long>();
        //        List<string> nazivi = new List<string>();

        //        foreach (DataGridViewRow row in dgvKnjige.Rows)
        //        {
        //            bool oznaceno = row.Cells["colCheck"].Value is bool b && b;

        //            if (oznaceno)
        //            {
        //                if (row.DataBoundItem is Knjiga k)
        //                {
        //                    //da li knjiga ima pozajmljene primerke
        //                    if (k.BrojSlobodnih < k.BrojPrimeraka)
        //                    {
        //                        MessageBox.Show(
        //                            $"Knjiga '{k.Naziv}' ima pozajmljene primerke i ne može biti obrisana.",
        //                            "Upozorenje",
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Warning);
        //                        return;
        //                    }

        //                    ids.Add(k.Id);
        //                    nazivi.Add(k.Naziv);
        //                }
        //            }
        //        }

        //        if (ids.Count == 0)
        //        {
        //            MessageBox.Show("Niste označili nijednu knjigu.", "Info",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        string listaKnjiga = string.Join("\n", nazivi);
        //        var confirm = MessageBox.Show(
        //            $"Da li ste sigurni da želite da obrišete sledeće knjige?\n\n{listaKnjiga}\n\n(Ukupno: {ids.Count})",
        //            "Potvrda brisanja",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Warning);

        //        if (confirm != DialogResult.Yes)
        //            return;

        //        int uspesno = 0;
        //        foreach (long id in ids)
        //        {
        //            try
        //            {
        //                if (Komunikacija.Instance.ObrisiKnjigu(id))
        //                    uspesno++;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Greška pri brisanju: {ex.Message}", "Greška",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        //        MessageBox.Show($"Obrisano {uspesno} od {ids.Count} knjiga.", "Uspeh",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        Pretrazi();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Greška pri brisanju: " + ex.Message,
        //            "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnObrisiSelektovanu_Click(object sender, EventArgs e)
        {
            if (selektovanaKnjiga == null) return;

            //da li knjiga ima pozajmljene primerke
            if (selektovanaKnjiga.BrojSlobodnih < selektovanaKnjiga.BrojPrimeraka)
            {
                int pozajmljeno = selektovanaKnjiga.BrojPrimeraka - selektovanaKnjiga.BrojSlobodnih;
                MessageBox.Show(
                    $"Knjiga '{selektovanaKnjiga.Naziv}' ima {pozajmljeno} pozajmljenih primeraka i ne može biti obrisana.",
                    "Upozorenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete knjigu '{selektovanaKnjiga.Naziv}'?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = Komunikacija.Instance.ObrisiKnjigu(selektovanaKnjiga.Id);
                if (ok)
                {
                    MessageBox.Show("Knjiga uspešno obrisana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pretrazi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacuvajIzmene_Click(object sender, EventArgs e)
        {
            if (selektovanaKnjiga == null) return;

            if (string.IsNullOrWhiteSpace(txtIzmeniNaziv.Text))
            {
                MessageBox.Show("Naziv knjige je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIzmeniNaziv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIzmeniImePisca.Text))
            {
                MessageBox.Show("Ime pisca je obavezno.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIzmeniImePisca.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIzmeniPrezimePisca.Text))
            {
                MessageBox.Show("Prezime pisca je obavezno.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIzmeniPrezimePisca.Focus();
                return;
            }

            if (numBrojPrimeraka.Value < 1)
            {
                MessageBox.Show("Broj primeraka mora biti najmanje 1.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //da li smanjujemo broj primeraka ispod pozajmljenih
            int brojPozajmljenih = selektovanaKnjiga.BrojPrimeraka - selektovanaKnjiga.BrojSlobodnih;
            if (numBrojPrimeraka.Value < brojPozajmljenih)
            {
                MessageBox.Show(
                    $"Ne možete smanjiti broj primeraka na {numBrojPrimeraka.Value}.\n" +
                    $"Trenutno je pozajmljeno {brojPozajmljenih} primeraka.",
                    "Validacija",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Knjiga izmenjenaKnjiga = new Knjiga
                {
                    Id = selektovanaKnjiga.Id,
                    Naziv = txtIzmeniNaziv.Text.Trim(),
                    ImePisca = txtIzmeniImePisca.Text.Trim(),
                    PrezimePisca = txtIzmeniPrezimePisca.Text.Trim(),
                    BrojPrimeraka = (int)numBrojPrimeraka.Value
                };

                bool uspeh = Komunikacija.Instance.IzmeniKnjigu(izmenjenaKnjiga);

                if (uspeh)
                {
                    MessageBox.Show(
                        "Knjiga je uspešno izmenjena!\n\n" +
                        $"Naziv: {izmenjenaKnjiga.Naziv}\n" +
                        $"Pisac: {izmenjenaKnjiga.ImePisca} {izmenjenaKnjiga.PrezimePisca}\n" +
                        $"Broj primeraka: {izmenjenaKnjiga.BrojPrimeraka}",
                        "Uspeh",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Pretrazi(); //osvezi
                }
                else
                {
                    MessageBox.Show("Greška pri izmeni knjige.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPonistiIzmene_Click(object sender, EventArgs e)
        {
            if (selektovanaKnjiga != null)
            {
                PrikaziDetalje(selektovanaKnjiga);
                MessageBox.Show("Izmene su poništene.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PodesavanjeKolona()
        {
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            if (dgvKnjige.Columns["colCheck"] != null)
                dgvKnjige.Columns["colCheck"].Width = 50;

            if (dgvKnjige.Columns["Naziv"] != null)
                dgvKnjige.Columns["Naziv"].Width = 300;

            if (dgvKnjige.Columns["ImePisca"] != null)
                dgvKnjige.Columns["ImePisca"].Width = 120;

            if (dgvKnjige.Columns["PrezimePisca"] != null)
                dgvKnjige.Columns["PrezimePisca"].Width = 120;

            if (dgvKnjige.Columns["BrojPrimeraka"] != null)
            {
                dgvKnjige.Columns["BrojPrimeraka"].Width = 120;
                dgvKnjige.Columns["BrojPrimeraka"].HeaderText = "Ukupno";
                dgvKnjige.Columns["BrojPrimeraka"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvKnjige.Columns["BrojSlobodnih"] != null)
            {
                dgvKnjige.Columns["BrojSlobodnih"].Width = 120;
                dgvKnjige.Columns["BrojSlobodnih"].HeaderText = "Slobodno";
                dgvKnjige.Columns["BrojSlobodnih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvKnjige.Columns["Id"] != null)
                dgvKnjige.Columns["Id"].Visible = false;

            // Lepši izgled
            dgvKnjige.RowTemplate.Height = 35;
            dgvKnjige.ColumnHeadersHeight = 40;
        }
    }
}