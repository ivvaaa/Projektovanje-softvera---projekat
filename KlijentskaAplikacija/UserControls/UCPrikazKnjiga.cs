using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCPrikazKnjiga : UserControl
    {
        public UCPrikazKnjiga()
        {
            InitializeComponent();

            UcitajSveKnjige();
        }

        private void UcitajSveKnjige()
        {
            try
            {
                List<Knjiga> lista = Komunikacija.Instance.PretraziKnjige("") ?? new List<Knjiga>();
                bindingSource1.DataSource = lista;
                lblBroj.Text = "Ukupno: " + lista.Count;
                ResetujBoje();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju knjiga: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblBroj.Text = "Ukupno: " + lista.Count;

                ResetujBoje();

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

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> ids = new List<long>();

                foreach (DataGridViewRow row in dgvKnjige.Rows)
                {
                    bool oznaceno = row.Cells["colCheck"].Value is bool b && b;

                    if (oznaceno)
                    {
                        if (row.DataBoundItem is Knjiga k)
                        {
                            ids.Add(k.Id);
                        }
                        else
                        {
                            if (long.TryParse(row.Cells["colId"].Value?.ToString(), out long id))
                                ids.Add(id);
                        }
                    }
                }

                if (ids.Count == 0)
                {
                    MessageBox.Show("Niste označili nijednu knjigu.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Da li ste sigurni da želite da obrišete označene knjige? (Broj: {ids.Count})",
                    "Potvrda brisanja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                foreach (long id in ids)
                {
                    bool ok = Komunikacija.Instance.ObrisiKnjigu(id);
                    if (!ok)
                    {
                        MessageBox.Show($"Brisanje nije uspelo za ID: {id}", "Greška",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Označene knjige su obrisane.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Pretrazi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}