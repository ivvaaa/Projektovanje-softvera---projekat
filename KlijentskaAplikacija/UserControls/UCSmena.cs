using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    /// <summary>
    /// UserControl za pregled rasporeda smena i slanje zahteva za promenu sopstvene smene.
    /// </summary>
    public partial class UCSmena : UserControl
    {
        private BibSmena selektovanaSmena = null;
        private List<TerminSmene> listaTermina = new List<TerminSmene>();
        private bool punjenje = false;

        public UCSmena()
        {
            InitializeComponent();
            UcitajTermine();
            UcitajSmene();
            dgvSmene.SelectionChanged += dgvSmene_SelectionChanged;
            pnlZahtev.Visible = false;
            pnlDetalji.Visible = false;
        }

        // -----------------------------------------------------------------------
        // Ucitavanje
        // -----------------------------------------------------------------------

        private void UcitajTermine()
        {
            try
            {
                listaTermina = Komunikacija.Instance.VratiSveTermine() ?? new List<TerminSmene>();
                System.Diagnostics.Debug.WriteLine($">>> Termini ucitani: {listaTermina.Count}");

                cmbTerminZahtev.Items.Clear();
                foreach (var t in listaTermina)
                {
                    cmbTerminZahtev.Items.Add(t);
                    System.Diagnostics.Debug.WriteLine($">>> Dodat termin: {t.Id} - {t.Termin}");
                }
                if (cmbTerminZahtev.Items.Count > 0)
                    cmbTerminZahtev.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($">>> GRESKA termini: {ex.Message}");
                MessageBox.Show("Greška pri učitavanju termina: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajSmene()
        {
            try
            {
                punjenje = true;
                dgvSmene.SelectionChanged -= dgvSmene_SelectionChanged;

                string kriterijum = txtKriterijum.Text.Trim();
                List<BibSmena> lista = Komunikacija.Instance.PretraziSmene(kriterijum)
                                       ?? new List<BibSmena>();

                // Narednih 7 dana — bez filter po terminu
                DateTime od = DateTime.Today;
                DateTime do7 = DateTime.Today.AddDays(7);
                lista = lista
                    .Where(s => s.Datum.Date >= od && s.Datum.Date <= do7)
                    .OrderBy(s => s.Datum)
                    .ThenBy(s => s.IdTerminSmene)
                    .ToList();

                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                pnlDetalji.Visible = false;
                pnlZahtev.Visible = false;
                selektovanaSmena = null;
                BojaSmenaPoDatumu();

                punjenje = false;
                dgvSmene.SelectionChanged += dgvSmene_SelectionChanged;
            }
            catch (Exception ex)
            {
                punjenje = false;
                dgvSmene.SelectionChanged += dgvSmene_SelectionChanged;
                MessageBox.Show("Greška pri učitavanju smena: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // -----------------------------------------------------------------------
        // Selekcija
        // -----------------------------------------------------------------------

        private void dgvSmene_SelectionChanged(object sender, EventArgs e)
        {
            if (punjenje) return;
            BeginInvoke(new Action(PrikaziSelektovanu));
        }

        private void PrikaziSelektovanu()
        {
            if (dgvSmene.CurrentRow?.DataBoundItem is BibSmena s)
            {
                selektovanaSmena = s;
                PrikaziDetalje(s);
                pnlDetalji.Visible = true;
                pnlZahtev.Visible = false;
            }
            else
            {
                pnlDetalji.Visible = false;
                pnlZahtev.Visible = false;
                selektovanaSmena = null;
            }
        }

        private void PrikaziDetalje(BibSmena s)
        {
            lblBibliotekarVrednost.Text = s.ImeBibliotekara;
            lblTerminVrednost.Text = s.NazivTermina;
            lblDatumVrednost.Text = s.Datum.ToString("dd.MM.yyyy (dddd)");

            bool jeDanas = s.Datum.Date == DateTime.Today;
            bool jeProsla = s.Datum.Date < DateTime.Today;

            if (jeProsla)
            {
                lblStatusVrednost.Text = "Prošla";
                lblStatusVrednost.ForeColor = Color.FromArgb(108, 117, 125);
                pnlStatusBar.BackColor = Color.FromArgb(233, 236, 239);
            }
            else if (jeDanas)
            {
                lblStatusVrednost.Text = "Danas";
                lblStatusVrednost.ForeColor = Color.FromArgb(0, 86, 179);
                pnlStatusBar.BackColor = Color.FromArgb(227, 242, 253);
            }
            else
            {
                lblStatusVrednost.Text = "Predstojeća";
                lblStatusVrednost.ForeColor = Color.FromArgb(40, 167, 69);
                pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
            }

            // DEBUG — proveri u Output prozoru
            var ulogovan = Komunikacija.UlogovaniBibliotekar;
           
            bool jeSopstvena = ulogovan != null && s.IdBibliotekara == ulogovan.Id;

            System.Diagnostics.Debug.WriteLine(
                $">>> Ulogovan: ID={ulogovan?.Id}, Ime={ulogovan?.Ime}");
            System.Diagnostics.Debug.WriteLine(
                $">>> Smena: IdBibliotekara={s.IdBibliotekara}, Ime={s.ImeBibliotekara}");
            System.Diagnostics.Debug.WriteLine(
                $">>> jeSopstvena={ulogovan != null && s.IdBibliotekara == ulogovan.Id}, jeProsla={jeProsla}");

            bool jeBuducnost = s.Datum.Date > DateTime.Today;
            btnZahtevZaPromenu.Visible = jeSopstvena && jeBuducnost;
        }
        // -----------------------------------------------------------------------
        // Bojenje redova
        // -----------------------------------------------------------------------

        private void BojaSmenaPoDatumu()
        {
            foreach (DataGridViewRow row in dgvSmene.Rows)
            {
                if (row.DataBoundItem is BibSmena s)
                {
                    if (s.Datum.Date == DateTime.Today)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 86, 179);
                        row.DefaultCellStyle.Font = new Font(dgvSmene.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.Font = dgvSmene.Font;
                    }
                }
            }
        }

        // -----------------------------------------------------------------------
        // Pretraga
        // -----------------------------------------------------------------------

        private void btnPretrazi_Click(object sender, EventArgs e) => UcitajSmene();
        private void txtKriterijum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; UcitajSmene(); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKriterijum.Text = "";
            UcitajSmene();
        }

        // -----------------------------------------------------------------------
        // Zahtev za promenu smene
        // -----------------------------------------------------------------------

        private void btnZahtevZaPromenu_Click(object sender, EventArgs e)
        {
            if (selektovanaSmena == null) return;

            // Popuni zahtev panel sa trenutnim podacima smene
            for (int i = 0; i < cmbTerminZahtev.Items.Count; i++)
            {
                if (cmbTerminZahtev.Items[i] is TerminSmene t &&
                    t.Id == selektovanaSmena.IdTerminSmene)
                {
                    cmbTerminZahtev.SelectedIndex = i;
                    break;
                }
            }
            dtpZahtev.Value = selektovanaSmena.Datum;
            lblZahtevInfo.Text = $"Trenutna smena: {selektovanaSmena.NazivTermina} — " +
                                 $"{selektovanaSmena.Datum:dd.MM.yyyy}";

            pnlZahtev.Visible = true;
            pnlDetalji.Visible = false;
        }

        private void btnOtkaziZahtev_Click(object sender, EventArgs e)
        {
            pnlZahtev.Visible = false;
            pnlDetalji.Visible = selektovanaSmena != null;
        }

        private void btnPosaljiZahtev_Click(object sender, EventArgs e)
        {
            if (selektovanaSmena == null) return;

            if (cmbTerminZahtev.SelectedItem is not TerminSmene noviTermin)
            {
                MessageBox.Show("Izaberite novi termin.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpZahtev.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Datum mora biti u buducnosti.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Provera da li je nešto uopšte izmenjeno
            if (noviTermin.Id == selektovanaSmena.IdTerminSmene &&
                dtpZahtev.Value.Date == selektovanaSmena.Datum.Date)
            {
                MessageBox.Show("Niste izmenili ni termin ni datum.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var potvrda = MessageBox.Show(
                $"Potvrdite promenu smene:\n\n" +
                $"Staro: {selektovanaSmena.NazivTermina} — {selektovanaSmena.Datum:dd.MM.yyyy}\n" +
                $"Novo:  {noviTermin.Termin} — {dtpZahtev.Value:dd.MM.yyyy}",
                "Potvrda zahteva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            try
            {
                BibSmena novaSmena = new BibSmena
                {
                    IdBibliotekara = selektovanaSmena.IdBibliotekara,
                    IdTerminSmene = noviTermin.Id,
                    Datum = dtpZahtev.Value.Date
                };

                bool ok = Komunikacija.Instance.IzmeniSmenu(selektovanaSmena, novaSmena);
                if (ok)
                {
                    MessageBox.Show("Sistem je zapamtio promenu smene.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlZahtev.Visible = false;
                    UcitajSmene();
                }
                else
                {
                    MessageBox.Show("Sistem ne može da zapamti promenu.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}