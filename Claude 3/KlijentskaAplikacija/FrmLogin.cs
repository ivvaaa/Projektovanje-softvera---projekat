using System;
using System.Drawing;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            txtBoxPass.UseSystemPasswordChar = true;
        }

        private void ResetValidation()
        {
            txtBoxUsername.BackColor = Color.White;
            txtBoxPass.BackColor = Color.White;
        }

        public bool Validacija()
        {
            ResetValidation();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtBoxUsername.Text))
            {
                txtBoxUsername.BackColor = Color.Salmon;
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxPass.Text))
            {
                txtBoxPass.BackColor = Color.Salmon;
                ok = false;
            }

            if (!ok)
                MessageBox.Show("Nisu uneti svi podaci!", "Upozorenje",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return ok;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;

            var kred = new Bibliotekar
            {
                Username = txtBoxUsername.Text.Trim(),
                Password = txtBoxPass.Text
            };

            btnLogin.Enabled = false;
            try
            {
                var k = Komunikacija.Instance;
                var b = k.PrijaviBibliotekara(kred);

                if (b == null)
                {
                    MessageBox.Show("Neispravni kredencijali.", "Prijava neuspešna",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBoxPass.Clear();
                    txtBoxPass.Focus();
                    return;
                }

                MessageBox.Show($"Dobrodošla, {b.Ime} {b.Prezime}!", "Prijava uspešna",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Otvori meni i sakrij login
                this.Hide();
                FrmMeni meni = new FrmMeni(b);
                meni.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxPass.SelectAll();
                txtBoxPass.Focus();
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}