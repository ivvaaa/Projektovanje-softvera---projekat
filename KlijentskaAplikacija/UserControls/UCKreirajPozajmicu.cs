using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCKreirajPozajmicu : UserControl
    {
        private Bibliotekar ulogovaniBibliotekar;
        private List<Knjiga> odabraneKnjige = new List<Knjiga>();

        public UCKreirajPozajmicu(Bibliotekar bibliotekar)
        {
            InitializeComponent();
            ulogovaniBibliotekar = bibliotekar;

            dtpDatumPozajmice.Value = DateTime.Now;
            dtpDatumPozajmice.MinDate = DateTime.Today;

            dtpRokVracanja.Value = DateTime.Now.AddDays(14);
            dtpRokVracanja.MinDate = DateTime.Today.AddDays(1);

            dtpDatumPozajmice.ValueChanged += dtpDatumPozajmice_ValueChanged;

            UcitajClanove();
            UcitajKnjige();
        }

        private void dtpDatumPozajmice_ValueChanged(object sender, EventArgs e)
        {
            // Rok vracanja mora biti posle datuma pozajmice
            dtpRokVracanja.MinDate = dtpDatumPozajmice.Value.AddDays(1);
            if (dtpRokVracanja.Value <= dtpDatumPozajmice.Value)
                dtpRokVracanja.Value = dtpDatumPozajmice.Value.AddDays(14);
        }

        private void UcitajClanove()
        {
            try
            {
                List<Clan> clanovi = Komunikacija.Instance.VratiSveClanova();
                cmbClan.DataSource = clanovi;
                cmbClan.DisplayMember = "ImePrezime";
                cmbClan.ValueMember = "Id";
                cmbClan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju članova: " + ex.Message);
            }
        }

        private void UcitajKnjige()
        {
            try
            {
                List<Knjiga> knjige = Komunikacija.Instance.VratiSveKnjige();
                dgvKnjige.DataSource = knjige;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju knjiga: " + ex.Message);
            }
        }

        private void btnDodajKnjigu_Click(object sender, EventArgs e)
        {
            if (dgvKnjige.CurrentRow?.DataBoundItem is Knjiga k)
            {
                if (odabraneKnjige.Exists(x => x.Id == k.Id))
                {
                    MessageBox.Show("Ova knjiga je već dodata.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                odabraneKnjige.Add(k);
                OsveziListuOdabranihKnjiga();
            }
        }

        private void btnUkloniKnjigu_Click(object sender, EventArgs e)
        {
            if (dgvOdabraneKnjige.CurrentRow?.DataBoundItem is Knjiga k)
            {
                odabraneKnjige.Remove(k);
                OsveziListuOdabranihKnjiga();
            }
        }

        private void OsveziListuOdabranihKnjiga()
        {
            dgvOdabraneKnjige.DataSource = null;
            dgvOdabraneKnjige.DataSource = odabraneKnjige;
            lblBrojKnjiga.Text = $"Odabrano knjiga: {odabraneKnjige.Count}";
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbClan.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati člana.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (odabraneKnjige.Count == 0)
            {
                MessageBox.Show("Morate dodati bar jednu knjigu.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Pozajmica p = new Pozajmica
                {
                    DatumOd = dtpDatumPozajmice.Value,
                    IdBibliotekar = ulogovaniBibliotekar.Id,
                    IdClan = ((Clan)cmbClan.SelectedItem).Id,
                    Stavke = new List<StavkaPozajmice>()
                };

                foreach (var knjiga in odabraneKnjige)
                {
                    p.Stavke.Add(new StavkaPozajmice
                    {
                        IdKnjige = knjiga.Id,
                        RokPozajmice = dtpRokVracanja.Value
                    });
                }

                long idPozajmice = Komunikacija.Instance.KreirajPozajmicu(p);

                if (idPozajmice > 0)
                {
                    MessageBox.Show($"Pozajmica uspešno kreirana! (ID: {idPozajmice})", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OcistiFormu();
                }
                else
                {
                    MessageBox.Show("Greška pri kreiranju pozajmice.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcistiFormu()
        {
            cmbClan.SelectedIndex = -1;
            odabraneKnjige.Clear();
            OsveziListuOdabranihKnjiga();
            dtpDatumPozajmice.Value = DateTime.Now;
            dtpRokVracanja.MinDate = DateTime.Today.AddDays(1);
            dtpRokVracanja.Value = DateTime.Now.AddDays(14);
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void txtPretragaKnjiga_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Knjiga> knjige = Komunikacija.Instance.PretraziKnjige(txtPretragaKnjiga.Text);
                dgvKnjige.DataSource = knjige;
            }
            catch { }
        }

        private void dgvKnjige_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SakrijNepotrebneKolone(dgvKnjige);
        }

        private void dgvOdabraneKnjige_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SakrijNepotrebneKolone(dgvOdabraneKnjige);
        }

        private void SakrijNepotrebneKolone(DataGridView dgv)
        {
            string[] sakrij = { "TableName", "Values", "InsertColumns", "PrimaryKey", "Join", "ImePisca", "PrezimePisca", "Dostupna" };

            foreach (string col in sakrij)
            {
                if (dgv.Columns.Contains(col))
                    dgv.Columns[col].Visible = false;
            }

            if (dgv.Columns.Contains("Id"))
            {
                dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns["Id"].Width = 50;
            }
            if (dgv.Columns.Contains("Naziv"))
                dgv.Columns["Naziv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (dgv.Columns.Contains("BrojPrimeraka"))
            {
                dgv.Columns["BrojPrimeraka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns["BrojPrimeraka"].Width = 120;
                dgv.Columns["BrojPrimeraka"].HeaderText = "Br. primeraka";
            }
            if (dgv.Columns.Contains("BrojSlobodnih"))
            {
                dgv.Columns["BrojSlobodnih"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns["BrojSlobodnih"].Width = 110;
                dgv.Columns["BrojSlobodnih"].HeaderText = "Slobodnih";
            }
        }

    }
}