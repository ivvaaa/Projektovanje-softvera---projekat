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
        private bool eksplicitnaSelekcijaAktivna = false; // SK2 korak 8: prati eksplicitni klik korisnika
        private bool punjenjePodataka = false;            // zastavica: ignorisi SelectionChanged tokom punjenja grida

        public UCSvaZaduzenja()
        {
            InitializeComponent();

            dgvStavke.DataSource = bsStavke;
            dgvPozajmice.CellFormatting += dgvPozajmice_CellFormatting;
            dgvStavke.CellFormatting += dgvStavke_CellFormatting;

            // SelectionChanged se kaci POSLE punjenja da ne okida gresku pri init
            UcitajPozajmice();
            pnlDetalji.Visible = false;

            dgvPozajmice.SelectionChanged += dgvPozajmice_SelectionChanged;
            dgvPozajmice.CellClick += dgvPozajmice_CellClick;
        }

        // SK2 korak 6: bibliotekar eksplicitno bira pozajmicu klikom
        private void dgvPozajmice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ignorisi klik na header
                eksplicitnaSelekcijaAktivna = true;
        }

        private void UcitajPozajmice()
        {
            try
            {
                List<Pozajmica> lista = Komunikacija.Instance.PretraziPozajmice("") ?? new List<Pozajmica>();

                lista = lista
                    .OrderBy(p => p.Status == "Zakasnelo" ? 0 : p.Status == "Aktivna" ? 1 : 2)
                    .ThenBy(p => p.DatumOd)
                    .ToList();

                // Postavi zastavicu pre dodele DataSource-a jer WinForms okida SelectionChanged
                // interno tokom punjenja, pre nego sto su indeksi validni
                punjenjePodataka = true;
                bsPozajmice.DataSource = lista;
                dgvPozajmice.DataSource = bsPozajmice;
                punjenjePodataka = false;

                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;
                lblBroj.Text = $"Ukupno: {lista.Count}";
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
            // SelectionChanged se okida interno tokom punjenja DataSource-a (WinForms behavior).
            // U tom trenutku DataGridView je u nestabilnom stanju - preskoci event.
            if (punjenjePodataka)
                return;

            try
            {
                // Guard: nema validnog reda
                if (dgvPozajmice.CurrentRow == null ||
                    dgvPozajmice.CurrentRow.Index < 0 ||
                    dgvPozajmice.CurrentRow.Index >= dgvPozajmice.Rows.Count)
                {
                    pnlDetalji.Visible = false;
                    selektovanaPozajmica = null;
                    return;
                }

                if (dgvPozajmice.CurrentRow.DataBoundItem is Pozajmica p)
                {
                    selektovanaPozajmica = p;
                    PrikaziDetalje(p);
                    pnlDetalji.Visible = true;

                    // SK2 korak 8: sistem prikazuje pozajmicu i poruku - samo pri eksplicitnom kliku bibliotekara
                    if (eksplicitnaSelekcijaAktivna)
                    {
                        eksplicitnaSelekcijaAktivna = false;
                        MessageBox.Show(
                            "Sistem je našao pozajmicu.",
                            "Pronađena pozajmica",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    pnlDetalji.Visible = false;
                    selektovanaPozajmica = null;
                    eksplicitnaSelekcijaAktivna = false;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // WinForms interno baca ArgumentOutOfRangeException tokom internog
                // preracunavanja indeksa u DataGridView - bezbedno ignorisati.
                // Ovo NIJE greška u podacima - DataGridView je u tranziciji.
                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;
                eksplicitnaSelekcijaAktivna = false;
            }
            catch (Exception)
            {
                // SK2 alternativa 8.1: sistem ne može da nađe pozajmicu
                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;
                eksplicitnaSelekcijaAktivna = false;
                MessageBox.Show(
                    "Sistem ne može da nađe pozajmicu.",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PrikaziDetalje(Pozajmica p)
        {
            lblClanVrednost.Text = p.ImePrezimeClana;
            lblBibliotekarVrednost.Text = string.IsNullOrEmpty(p.ImePrezimeBibliotekar) ? "-" : p.ImePrezimeBibliotekar;
            lblDatumVrednost.Text = p.DatumOd.ToString("dd.MM.yyyy");
            lblBrojKnjigaVrednost.Text = p.BrojKnjiga.ToString();

            lblStatusVrednost.Text = p.Status;
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
            }

            bsStavke.DataSource = null;
            bsStavke.DataSource = p.Stavke;

            // Postavi DateTimePicker na najkasniji rok aktivnih stavki (ili sutra ako nema)
            var aktivneStavke = p.Stavke?.Where(s => s.DatumVracanja == null).ToList();
            if (aktivneStavke != null && aktivneStavke.Count > 0)
            {
                dtpNoviRok.Value = aktivneStavke.Max(s => s.RokPozajmice);
                grpIzmenaRoka.Visible = true;
            }
            else
            {
                // Sve knjige vraćene - izmena roka nije moguća
                grpIzmenaRoka.Visible = false;
            }
        }

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

            // Prikaži crtu za null DatumVracanja
            if (prop == "DatumVracanja" && e.Value == DBNull.Value)
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

            // Vraćeno: prikaži crtu ako null, inače datum
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

            // Rok: crven ako je prošao a knjiga nije vraćena
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

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            Pretrazi();
        }

        private void Pretrazi()
        {
            try
            {
                string kriterijum = txtPretraga.Text.Trim();
                List<Pozajmica> lista = Komunikacija.Instance.PretraziPozajmice(kriterijum) ?? new List<Pozajmica>();

                //sort
                lista = lista
                    .OrderBy(p => p.Status == "Zakasnelo" ? 0 : p.Status == "Aktivna" ? 1 : 2)
                    .ThenBy(p => p.DatumOd)
                    .ToList();

                punjenjePodataka = true;
                bsPozajmice.DataSource = lista;
                punjenjePodataka = false;

                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;

                // SK2 - korak 4 / alternativa 4.1
                if (lista.Count == 0)
                {
                    lblBroj.Text = "Ukupno: 0";
                    MessageBox.Show(
                        "Sistem ne može da nađe pozajmice po zadatim kriterijumima.",
                        "Informacija",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    lblBroj.Text = $"Ukupno: {lista.Count}";
                    // SK2 - korak 4: poruka o uspešnoj pretrazi (samo kad je unet kriterijum)
                    if (!string.IsNullOrEmpty(kriterijum))
                    {
                        MessageBox.Show(
                            $"Sistem je našao {lista.Count} pozajmic{(lista.Count == 1 ? "u" : lista.Count < 5 ? "e" : "a")} po zadatim kriterijumima.",
                            "Pretraga uspešna",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Pretrazi();
            }
        }

        private void btnVratiKnjigu_Click(object sender, EventArgs e)
        {
            if (selektovanaPozajmica == null) return;

            if (dgvStavke.CurrentRow == null || !(dgvStavke.CurrentRow.DataBoundItem is StavkaPozajmice stavka))
            {
                MessageBox.Show("Izaberite stavku (knjigu) za vraćanje.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (stavka.DatumVracanja != null)
            {
                MessageBox.Show("Ova knjiga je već vraćena.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Da li ste sigurni da želite da vratite knjigu '{stavka.NazivKnjige}'?",
                "Potvrda vraćanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool uspeh = Komunikacija.Instance.VratiKnjigu(selektovanaPozajmica.Id, stavka.IdKnjige);

                if (uspeh)
                {
                    MessageBox.Show("Knjiga je uspešno vraćena!", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //osvezi prikaz - ponovo ucitaj sve pozajmice (sa azuriranim stavkama)
                    UcitajPozajmice();
                }
                else
                {
                    MessageBox.Show("Greška pri vraćanju knjige.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SK3 - PromeniPozajmica: izmena roka pozajmice
        private void btnSacuvajRok_Click(object sender, EventArgs e)
        {
            if (selektovanaPozajmica == null) return;

            // SK3 korak 10 - validacija
            if (dtpNoviRok.Value.Date <= DateTime.Today)
            {
                MessageBox.Show(
                    "Novi rok mora biti datum u budućnosti.",
                    "Validacija",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Da li ste sigurni da želite da promenite rok pozajmice #{selektovanaPozajmica.Id}\n" +
                $"na {dtpNoviRok.Value:dd.MM.yyyy}?\n\n" +
                "Rok će biti promenjen za sve aktivne (nevrаćene) knjige.",
                "Potvrda izmene",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // SK3 korak 11-12 - poziv sistema
                bool uspeh = Komunikacija.Instance.IzmeniRokPozajmice(
                    selektovanaPozajmica.Id,
                    dtpNoviRok.Value.Date);

                if (uspeh)
                {
                    // SK3 korak 13 - poruka o uspehu
                    MessageBox.Show(
                        "Sistem je zapamtio pozajmicu.",
                        "Uspeh",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Pretrazi(); // osveži listu
                }
                else
                {
                    // SK3 alternativa 13.1
                    MessageBox.Show(
                        "Sistem ne može da zapamti pozajmicu.",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // SK3 alternativa 13.1
                MessageBox.Show(
                    "Sistem ne može da zapamti pozajmicu.\n" + ex.Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}