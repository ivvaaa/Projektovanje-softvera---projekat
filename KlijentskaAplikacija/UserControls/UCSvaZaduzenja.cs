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

        public UCSvaZaduzenja()
        {
            InitializeComponent();

            dgvStavke.DataSource = bsStavke;
            dgvPozajmice.SelectionChanged += dgvPozajmice_SelectionChanged;
            dgvPozajmice.CellFormatting += dgvPozajmice_CellFormatting;
            dgvStavke.CellFormatting += dgvStavke_CellFormatting;

            UcitajPozajmice();
            pnlDetalji.Visible = false;
        }

        private void UcitajPozajmice()
        {
            try
            {
                //prazan kriterijum = vrati sve (inicijalno punjenje forme)
                List<Pozajmica> lista = Komunikacija.Instance.PretraziPozajmice("") ?? new List<Pozajmica>();

                // Sortiranje: Zakasnelo → Aktivna → Vraceno, pa po datumu
                lista = lista
                    .OrderBy(p => p.Status == "Zakasnelo" ? 0 : p.Status == "Aktivna" ? 1 : 2)
                    .ThenBy(p => p.DatumOd)
                    .ToList();

                bsPozajmice.DataSource = lista;
                dgvPozajmice.DataSource = bsPozajmice;
                pnlDetalji.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPozajmice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPozajmice.CurrentRow != null && dgvPozajmice.CurrentRow.DataBoundItem is Pozajmica p)
            {
                selektovanaPozajmica = p;
                PrikaziDetalje(p);
                pnlDetalji.Visible = true;
            }
            else
            {
                pnlDetalji.Visible = false;
                selektovanaPozajmica = null;
            }
        }

        private void PrikaziDetalje(Pozajmica p)
        {
            lblClanVrednost.Text = p.ImePrezimeClana;
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

            bsStavke.DataSource = null;        // DODAJ - resetuj pre
            bsStavke.DataSource = p.Stavke;    // postavi stavke
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
            if (e.RowIndex < 0) return;

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

                bsPozajmice.DataSource = lista;
                pnlDetalji.Visible = false;

                if (lista.Count == 0)
                {
                    MessageBox.Show("Sistem ne može da nadje pozajmicu.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nadje pozajmicu. - Greska", "Greška",
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
                MessageBox.Show("Sistem ne moze da nadje pozajmicu.", "Info",
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
                    MessageBox.Show("Sistem je zapamtio pozajmicu - knjiga je varcena.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //osvezi prikaz - ponovo ucitaj sve pozajmice (sa azuriranim stavkama)
                    UcitajPozajmice();
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da zapamti pozajmicu.Greška pri vraćanju knjige.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}