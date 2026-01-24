using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCPrikazClanova : UserControl
    {
        private Clan selektovaniClan = null;

        public UCPrikazClanova()
        {
            InitializeComponent();

            dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;
            dgvClanovi.CellMouseUp += dgvClanovi_CellMouseUp;

            UcitajSveClanove();
            pnlDetalji.Visible = false;
        }

        private void dgvClanovi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClanovi.CurrentRow != null && dgvClanovi.CurrentRow.DataBoundItem is Clan c)
            {
                selektovaniClan = c;
                PrikaziDetalje(c);
                pnlDetalji.Visible = true;
            }
            else
            {
                pnlDetalji.Visible = false;
                selektovaniClan = null;
            }
        }

        private void PrikaziDetalje(Clan c)
        {
            lblImeVrednost.Text = c.Ime;
            lblPrezimeVrednost.Text = c.Prezime;
            lblTelefonVrednost.Text = c.Telefon.ToString();
            lblDatumOdVrednost.Text = c.DatumOd.ToString("dd.MM.yyyy");
            lblDatumDoVrednost.Text = c.DatumDo.ToString("dd.MM.yyyy");

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
        }

        private void dgvClanovi_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvClanovi.Columns[e.ColumnIndex].Name != "colCheck") return;

            dgvClanovi.EndEdit();

            var row = dgvClanovi.Rows[e.RowIndex];
            bool cekirano = row.Cells["colCheck"].Value is bool b && b;

            if (cekirano)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            dgvClanovi.RefreshEdit();
        }

        private void UcitajSveClanove()
        {
            try
            {
                List<Clan> lista;

                var rezultat = Komunikacija.Instance.PretraziClanove("");

                if (rezultat == null)
                    lista = new List<Clan>();
                else
                    lista = rezultat;

                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                ResetujBoje();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju članova: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetujBoje()
        {
            foreach (DataGridViewRow row in dgvClanovi.Rows)
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
                List<Clan> lista;
                var rezultat = Komunikacija.Instance.PretraziClanove(kriterijum);

                if (rezultat == null)
                    lista = new List<Clan>();
                else
                    lista = rezultat;

                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                ResetujBoje();
                pnlDetalji.Visible = false;

                if (lista.Count == 0)
                {
                    MessageBox.Show("Nema rezultata za uneti kriterijum.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pretrazi: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKriterijum.Text = "";
            UcitajSveClanove();
            pnlDetalji.Visible = false;
        }

        private void txtKriterijum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Pretrazi();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> ids = new List<long>();

                foreach (DataGridViewRow row in dgvClanovi.Rows)
                {
                    bool oznaceno = row.Cells["colCheck"].Value is bool b && b;

                    if (oznaceno)
                    {
                        if (row.DataBoundItem is Clan c)
                        {
                            ids.Add(c.Id);
                        }
                    }
                }

                if (ids.Count == 0)
                {
                    MessageBox.Show("Niste označili nijednog člana.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show("Da li ste sigurni da želite da obrišete označene članove?", "Potvrda brisanja", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                foreach (long id in ids)
                {
                    Komunikacija.Instance.ObrisiClana(id);
                }

                MessageBox.Show("Označeni članovi su obrisani.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Pretrazi();
                pnlDetalji.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisiSelektovanog_Click(object sender, EventArgs e)
        {
            if (selektovaniClan == null) return;

            var confirm = MessageBox.Show(
                ("Da li ste sigurni da želite da obrišete člana "+selektovaniClan.Ime+ selektovaniClan.Prezime +"?"), "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = Komunikacija.Instance.ObrisiClana(selektovaniClan.Id);
                if (ok)
                {
                    MessageBox.Show("Član uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pretrazi();
                    pnlDetalji.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selektovaniClan == null) return;
            MessageBox.Show("Funkcija izmene će biti implementirana.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}