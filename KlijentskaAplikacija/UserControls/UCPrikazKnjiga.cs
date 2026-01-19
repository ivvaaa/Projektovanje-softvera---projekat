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

                // ako koristiš BindingSource iz designera
                bindingSource1.DataSource = lista;

                // opciono
                lblBroj.Text = "Ukupno: " + lista.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju knjiga: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
