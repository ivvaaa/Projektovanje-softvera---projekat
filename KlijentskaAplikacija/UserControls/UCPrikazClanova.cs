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
        private bool rezimiIzmene = false;

        public UCPrikazClanova()
        {
            InitializeComponent();
            dgvClanovi.SelectionChanged += dgvClanovi_SelectionChanged;
            dgvClanovi.CellMouseUp += dgvClanovi_CellMouseUp;
            dgvClanovi.CellClick += dgvClanovi_CellClick;

            UcitajSveClanove();

            pnlDetalji.Visible = false;
        }

        private void dgvClanovi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrikaziSelektovanogClana();
            }
        }

        private void dgvClanovi_SelectionChanged(object sender, EventArgs e)
        {
            PrikaziSelektovanogClana();
        }

        private void PrikaziSelektovanogClana()
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
                List<Clan> lista = Komunikacija.Instance.VratiSveClanova() ?? new List<Clan>();
                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                ResetujBoje();
                pnlDetalji.Visible = false;
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
                List<Clan> lista = Komunikacija.Instance.PretraziClanove(kriterijum) ?? new List<Clan>();

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

                var confirm = MessageBox.Show("Da li ste sigurni da želite da obrišete označene članove?", "Potvrda brisanja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                foreach (long id in ids)
                {
                    Komunikacija.Instance.ObrisiClana(id);
                }

                MessageBox.Show("Označeni članovi su obrisani.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Pretrazi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisiSelektovanog_Click(object sender, EventArgs e)
        {
            if (rezimiIzmene)
            {
                IzadjiIzRezimaIzmene();
                return;
            }
            if (selektovaniClan == null) return;

            var confirm = MessageBox.Show("Da li ste sigurni da želite da obrišete člana?", "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = Komunikacija.Instance.ObrisiClana(selektovaniClan.Id);
                if (ok)
                {
                    MessageBox.Show("Član uspešno obrisan.", "Uspeh",
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

        private void IzadjiIzRezimaIzmene()
        {
            rezimiIzmene = false;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.BackColor = Color.FromArgb(18, 27, 41);
            btnIzmeni.Size = new Size(270, 38);

            btnObrisiSelektovanog.Visible = false;

            txtIzmeniIme.Visible = false;
            txtIzmeniPrezime.Visible = false;
            txtIzmeniTelefon.Visible = false;

            lblImeVrednost.Visible = true;
            lblPrezimeVrednost.Visible = true;
            lblTelefonVrednost.Visible = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selektovaniClan == null) return;

            if (!rezimiIzmene)
            {
                // Uđi u režim izmene
                rezimiIzmene = true;
                btnIzmeni.Text = "Sačuvaj";
                btnIzmeni.BackColor = Color.FromArgb(40, 167, 69);
                btnIzmeni.Size = new Size(130, 38);

                btnObrisiSelektovanog.Text = "Otkaži";
                btnObrisiSelektovanog.BackColor = Color.FromArgb(220, 53, 69);
                btnObrisiSelektovanog.Visible = true;

                // Prikaži TextBox-ove, sakrij labele
                lblImeVrednost.Visible = false;
                lblPrezimeVrednost.Visible = false;
                lblTelefonVrednost.Visible = false;

                txtIzmeniIme.Text = selektovaniClan.Ime;
                txtIzmeniPrezime.Text = selektovaniClan.Prezime;
                txtIzmeniTelefon.Text = selektovaniClan.Telefon.ToString();

                txtIzmeniIme.Visible = true;
                txtIzmeniPrezime.Visible = true;
                txtIzmeniTelefon.Visible = true;
                txtIzmeniIme.Focus();
            }
            else
            {
                // Sačuvaj izmene
                if (string.IsNullOrWhiteSpace(txtIzmeniIme.Text) || string.IsNullOrWhiteSpace(txtIzmeniPrezime.Text))
                {
                    MessageBox.Show("Sistem ne moze da zapamti clana - unesite sva polja.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Sistem je zapamtio clana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IzadjiIzRezimaIzmene();
                        UcitajSveClanove();
                    }
                    else
                    {
                        MessageBox.Show("Sistem ne moze da zapamti clana.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}