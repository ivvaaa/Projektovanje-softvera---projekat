using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCSvaZaduzenja : UserControl
    {
        private Pozajmica selektovanaPozajmica = null;
        private bool punjenjePodataka = false;
        private bool pretrazivanjeAktivno = false;

        public UCSvaZaduzenja()
        {
            InitializeComponent();

            dgvPozajmice.CellFormatting += dgvPozajmice_CellFormatting;
            dgvStavke.CellFormatting += dgvStavke_CellFormatting;
            dgvPozajmice.SelectionChanged += dgvPozajmice_SelectionChanged;

            UcitajPozajmice();
        }

        // -----------------------------------------------------------------------
        // Punjenje liste
        // -----------------------------------------------------------------------

        private void UcitajPozajmice()
        {
            try
            {
                List<Pozajmica> lista = Komunikacija.Instance.PretraziPozajmice("") ?? new List<Pozajmica>();

                lista = lista
                    .OrderBy(p => p.Status == "Zakasnelo" ? 0 : p.Status == "Aktivna" ? 1 : 2)
                    .ThenBy(p => p.DatumOd)
                    .ToList();

                punjenjePodataka = true;
                bsPozajmice.DataSource = lista;
                dgvPozajmice.DataSource = bsPozajmice;
                punjenjePodataka = false;

                lblBroj.Text = $"Ukupno: {lista.Count}";
                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;
                pretrazivanjeAktivno = false;
            }
            catch (Exception ex)
            {
                punjenjePodataka = false;
                MessageBox.Show("Greška pri učitavanju: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvPozajmice_SelectionChanged(object sender, EventArgs e)
        {
            if (punjenjePodataka) return;

            BeginInvoke(new Action(PrikaziSelektovanu));
        }

        private void PrikaziSelektovanu()
        {
            try
            {
                if (dgvPozajmice.CurrentRow == null || dgvPozajmice.Rows.Count == 0)
                {
                    pnlDetalji.Visible = false;
                    selektovanaPozajmica = null;
                    return;
                }

                int idx = dgvPozajmice.CurrentRow.Index;
                if (idx < 0 || idx >= bsPozajmice.Count)
                {
                    pnlDetalji.Visible = false;
                    selektovanaPozajmica = null;
                    return;
                }

                Pozajmica p = bsPozajmice[idx] as Pozajmica;
                if (p == null)
                {
                    pnlDetalji.Visible = false;
                    selektovanaPozajmica = null;
                    return;
                }

                selektovanaPozajmica = p;
                PrikaziDetalje(p);
                pnlDetalji.Visible = true;
                if (pretrazivanjeAktivno)
                {
                    MessageBox.Show($"Sistem je našao pozajmicu.",
                        "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;
                System.Diagnostics.Debug.WriteLine("PrikaziSelektovanu greška: " + ex.Message);
            }
        }

        // -----------------------------------------------------------------------
        // Prikaz detalja — radi za SVE statuse
        // -----------------------------------------------------------------------

        private void PrikaziDetalje(Pozajmica p)
        {
            lblClanVrednost.Text = p.ImePrezimeClana ?? "-";
            lblBibliotekarVrednost.Text = string.IsNullOrEmpty(p.ImePrezimeBibliotekar)
                ? "-" : p.ImePrezimeBibliotekar;
            lblDatumVrednost.Text = p.DatumOd.ToString("dd.MM.yyyy");
            lblBrojKnjigaVrednost.Text = p.BrojKnjiga.ToString();

            lblStatusVrednost.Text = p.Status ?? "-";
            switch (p.Status)
            {
                case "Aktivna":
                    lblStatusVrednost.ForeColor = Color.FromArgb(0, 123, 255);
                    pnlStatusBar.BackColor = Color.FromArgb(230, 242, 255);
                    break;
                case "Zakasnelo":
                    lblStatusVrednost.ForeColor = Color.FromArgb(220, 53, 69);
                    pnlStatusBar.BackColor = Color.FromArgb(255, 235, 238);
                    break;
                case "Vraceno":
                    lblStatusVrednost.ForeColor = Color.FromArgb(40, 167, 69);
                    pnlStatusBar.BackColor = Color.FromArgb(232, 245, 233);
                    break;
                default:
                    lblStatusVrednost.ForeColor = Color.Gray;
                    pnlStatusBar.BackColor = Color.FromArgb(240, 240, 240);
                    break;
            }

            bsStavke.DataSource = null;
            bsStavke.DataSource = p.Stavke ?? new List<StavkaPozajmice>();

            bool aktivnaIliZakasnela = p.Status == "Aktivna" || p.Status == "Zakasnelo";
            btnVratiKnjigu.Visible = false;
            grpIzmenaRoka.Visible = aktivnaIliZakasnela;
            btnSacuvajIzmene.Visible = aktivnaIliZakasnela;

            // Reset checkbox kolone — checkbox vidljiv samo za aktivne stavke
            dgvStavke.Columns["colVrati"].Visible = aktivnaIliZakasnela;
            if (aktivnaIliZakasnela)
            {
                foreach (DataGridViewRow row in dgvStavke.Rows)
                {
                    if (row.DataBoundItem is StavkaPozajmice s)
                    {
                        bool vracena = s.DatumVracanja != null;
                        row.Cells["colVrati"].Value = vracena; // vraćene = čekirano
                        row.Cells["colVrati"].ReadOnly = vracena; // vraćene = zaključano
                        if (vracena)
                            row.DefaultCellStyle.ForeColor = Color.LightGray;
                        else
                            row.DefaultCellStyle.ForeColor = Color.Empty;
                    }
                }
            }

            // Reset checkbox i dtp pri svakoj novoj selekciji
            chkIzmeniRok.Checked = false;
            dtpNoviRok.Enabled = false;

            if (aktivnaIliZakasnela && p.Stavke != null && p.Stavke.Count > 0)
            {
                var aktivne = p.Stavke.Where(s => s.DatumVracanja == null).ToList();
                DateTime noviRokValue = (aktivne.Count > 0)
                    ? aktivne.Max(s => s.RokPozajmice)
                    : DateTime.Today.AddDays(7);

                dtpNoviRok.MinDate = DateTimePicker.MinimumDateTime;
                dtpNoviRok.Value = noviRokValue;
                dtpNoviRok.MinDate = DateTime.Today.AddDays(1);
            }
        }

        // -----------------------------------------------------------------------
        // Formatiranje ćelija
        // -----------------------------------------------------------------------

        private void dgvPozajmice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string prop = dgvPozajmice.Columns[e.ColumnIndex].DataPropertyName;

            if (prop == "Status")
            {
                switch (e.Value.ToString())
                {
                    case "Aktivna":
                        e.CellStyle.ForeColor = Color.FromArgb(0, 123, 255);
                        e.CellStyle.Font = new Font(dgvPozajmice.Font, FontStyle.Bold);
                        break;
                    case "Zakasnelo":
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                        e.CellStyle.Font = new Font(dgvPozajmice.Font, FontStyle.Bold);
                        break;
                    case "Vraceno":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                        break;
                }
            }

            if (prop == "DatumVracanja" && (e.Value == DBNull.Value || e.Value == null))
            {
                e.Value = "—";
                e.CellStyle.ForeColor = Color.LightGray;
                e.FormattingApplied = true;
            }
        }

        private void dgvStavke_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStavke.Rows.Count || e.ColumnIndex < 0) return;
            string prop = dgvStavke.Columns[e.ColumnIndex].DataPropertyName;

            if (prop == "DatumVracanja")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "—";
                    e.CellStyle.ForeColor = Color.LightGray;
                    e.FormattingApplied = true;
                }
                else if (e.Value is DateTime dt)
                {
                    e.Value = dt.ToString("dd.MM.yyyy");
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                    e.FormattingApplied = true;
                }
            }

            if (prop == "RokPozajmice" && e.Value is DateTime rok)
            {
                if (dgvStavke.Rows[e.RowIndex].DataBoundItem is StavkaPozajmice s
                    && s.DatumVracanja == null && rok < DateTime.Today)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font(dgvStavke.Font, FontStyle.Bold);
                }
            }
        }

        // -----------------------------------------------------------------------
        // Pretraga
        // -----------------------------------------------------------------------

        private void btnPretrazi_Click(object sender, EventArgs e) => Pretrazi();

        private void Pretrazi()
        {
            try
            {
                string kriterijum = txtPretraga.Text.Trim();
                List<Pozajmica> lista = Komunikacija.Instance.PretraziPozajmice(kriterijum) ?? new List<Pozajmica>();

                lista = lista
                    .OrderBy(p => p.Status == "Zakasnelo" ? 0 : p.Status == "Aktivna" ? 1 : 2)
                    .ThenBy(p => p.DatumOd)
                    .ToList();

                punjenjePodataka = true;
                bsPozajmice.DataSource = lista;
                dgvPozajmice.DataSource = bsPozajmice;
                punjenjePodataka = false;

                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;

                if (lista.Count == 0)
                {
                    lblBroj.Text = "Ukupno: 0";
                    MessageBox.Show("Sistem ne može da nađe pozajmice po zadatim kriterijumima.",
                        "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblBroj.Text = $"Ukupno: {lista.Count}";
                    // Poruka samo ako je korisnik zaista uneo kriterijum
                    if (!string.IsNullOrWhiteSpace(kriterijum))
                    {
                        pretrazivanjeAktivno = true;
                        MessageBox.Show($"Sistem je našao pozajmice po zadatom kriterijumu.",
                            "Pretraga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                punjenjePodataka = false;
                MessageBox.Show("Greška pri pretrazi: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPretraga.Text = "";
            UcitajPozajmice();
        }

        private void txtPretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Pretrazi(); }
        }


        // zaj izmena -----------------------------------------------------------------------

        private void chkIzmeniRok_CheckedChanged(object sender, EventArgs e)
        {
            dtpNoviRok.Enabled = chkIzmeniRok.Checked;
        }

        private void btnVratiKnjigu_Click(object sender, EventArgs e)
        {
        }

        private void btnSacuvajIzmene_Click(object sender, EventArgs e)
        {
            if (selektovanaPozajmica == null) return;

            //sve cekirane aktivne stavke za vraćanje
            var stavkeZaVracanje = new List<StavkaPozajmice>();
            foreach (DataGridViewRow row in dgvStavke.Rows)
            {
                if (row.DataBoundItem is StavkaPozajmice s
                    && s.DatumVracanja == null
                    && row.Cells["colVrati"].Value is true)
                {
                    stavkeZaVracanje.Add(s);
                }
            }

            bool vratiKnjige = stavkeZaVracanje.Count > 0;
            bool izmeniRok = chkIzmeniRok.Checked;

            //bar jedna akcija
            if (!vratiKnjige && !izmeniRok)
            {
                MessageBox.Show(
                    "Označite knjige za vraćanje i/ili označite izmenu roka.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Validacija roka
            if (izmeniRok && dtpNoviRok.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Novi rok mora biti datum u budućnosti.",
                    "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string poruka = "Da li želite da sačuvate sledeće izmene?\n\n";
            if (vratiKnjige)
            {
                poruka += "Vraćanje knjiga:\n";
                foreach (var s in stavkeZaVracanje)
                    poruka += $"   • {s.NazivKnjige}\n";
            }
            if (izmeniRok) poruka += $"\nNovi rok za sve aktivne knjige: {dtpNoviRok.Value:dd.MM.yyyy}\n";

            if (MessageBox.Show(poruka, "Potvrda", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bool greska = false;

                //Vrati svaku oznacenu knjigu
                foreach (var stavka in stavkeZaVracanje)
                {
                    bool uspeh = Komunikacija.Instance.VratiKnjigu(selektovanaPozajmica.Id, stavka.IdKnjige);
                    if (!uspeh) greska = true;
                }

                if (izmeniRok)
                {
                    bool uspeh = Komunikacija.Instance.IzmeniRokPozajmice(
                        selektovanaPozajmica.Id, dtpNoviRok.Value.Date);
                    if (!uspeh) greska = true;
                }

                if (greska)
                    MessageBox.Show("Jedna ili više izmena nije uspela.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Sistem je zapamtio izmene.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajPozajmice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}