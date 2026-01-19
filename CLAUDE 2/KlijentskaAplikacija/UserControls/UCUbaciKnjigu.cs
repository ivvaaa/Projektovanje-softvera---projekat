using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.UserControls
{
    public partial class UCUbaciKnjigu : UserControl
    {
        public UCUbaciKnjigu()
        {
            InitializeComponent();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            // Validacija
            if (!Validacija())
            {
                return;
            }

            // Kreiranje objekta
            Knjiga knjiga = new Knjiga
            {
                Naziv = txtNaziv.Text.Trim(),
                ImePisca = txtImePisca.Text.Trim(),
                PrezimePisca = txtPrezimePisca.Text.Trim()
            };

            // Slanje na server
            bool uspeh = Komunikacija.Instance.UbaciKnjigu(knjiga);

            if (uspeh)
            {
                MessageBox.Show("Knjiga je uspešno sačuvana!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OcistiPolja();
            }
            else
            {
                MessageBox.Show("Greška pri čuvanju knjige.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            OcistiPolja();
        }

        private bool Validacija()
        {
            bool ok = true;

            // Reset boja
            txtNaziv.BackColor = Color.White;
            txtImePisca.BackColor = Color.White;
            txtPrezimePisca.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                txtNaziv.BackColor = Color.LightCoral;
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtImePisca.Text))
            {
                txtImePisca.BackColor = Color.LightCoral;
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtPrezimePisca.Text))
            {
                txtPrezimePisca.BackColor = Color.LightCoral;
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show("Molimo popunite sva obavezna polja!", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ok;
        }

        private void OcistiPolja()
        {
            txtNaziv.Text = "";
            txtImePisca.Text = "";
            txtPrezimePisca.Text = "";

            txtNaziv.BackColor = Color.White;
            txtImePisca.BackColor = Color.White;
            txtPrezimePisca.BackColor = Color.White;

            txtNaziv.Focus();
        }
    }
}