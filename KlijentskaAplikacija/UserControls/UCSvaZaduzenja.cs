using System;
using System.Collections.Generic;
using System.Drawing;
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

            dgvPozajmice.SelectionChanged += dgvPozajmice_SelectionChanged;
            dgvPozajmice.CellFormatting += dgvPozajmice_CellFormatting;

            UcitajPozajmice();
            pnlDetalji.Visible = false;
        }

        private void UcitajPozajmice()
        {
            try
            {
                //prazan kriterijum = vrati sve (inicijalno punjenje forme)
                List<Pozajmica> lista = Komunikacija.Instance.PretraziPozajmice("") ?? new List<Pozajmica>();
                bsPozajmice.DataSource = lista;
                dgvPozajmice.DataSource = bsPozajmice;
                lblBroj.Text = $"Ukupno pozajmica: {lista.Count}";
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

            //status sa bojom
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

            //ucitaj stavke pozajmice (vec su u objektu)
            UcitajStavke(p);
        }

        private void UcitajStavke(Pozajmica pozajmica)
        {
            //Stavke su već tu zajedno sa pozajmicom
            bsStavke.DataSource = pozajmica.Stavke ?? new List<StavkaPozajmice>();
            dgvStavke.DataSource = bsStavke;
        }

        private void dgvPozajmice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPozajmice.Columns[e.ColumnIndex].DataPropertyName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                switch (status)
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
                bsPozajmice.DataSource = lista;
                lblBroj.Text = $"Ukupno pozajmica: {lista.Count}";
                pnlDetalji.Visible = false;

                if (lista.Count == 0)
                {
                    MessageBox.Show("Nema rezultata za uneti kriterijum.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
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
    }
}