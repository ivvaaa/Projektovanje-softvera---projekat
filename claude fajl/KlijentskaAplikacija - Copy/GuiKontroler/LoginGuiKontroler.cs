using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija.GuiKontroler
{
    internal class LoginGuiKontroler
    {
        private static LoginGuiKontroler instance;
        public static LoginGuiKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGuiKontroler();
                }
                return instance;
            }
        }

        private LoginGuiKontroler() { }

        private FrmLogin frmLogin;

        internal void ShowFrmLogin()
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin = new FrmLogin();
                frmLogin.AutoSize = true;
                Application.Run(frmLogin);
            }
            catch (SocketException)
            {
                MessageBox.Show("Nije moguce uspostaviti komunikaciju sa serverom!");
            }
        }


        public void Login(object sender, EventArgs e)
        {
            if (!frmLogin.Validacija()) return;

            var kred = new Bibliotekar
            {
                Username = frmLogin.txtBoxUsername.Text,
                Password = frmLogin.txtBoxPass.Text
            };

            frmLogin.btnLogin.Enabled = true;
            try
            {
                var k = Komunikacija.Instance;
                var b = k.PrijaviBibliotekara(kred);

                if (b == null)
                {
                    MessageBox.Show("Neispravni kredencijali.", "Prijava neuspešna",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmLogin.txtBoxPass.Clear();
                    frmLogin.txtBoxPass.Focus();
                    return;
                }

                MessageBox.Show($"Dobrodošla, {b.Ime} {b.Prezime}!", "Prijava uspešna",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);


                FrmMeni meni = new FrmMeni();
                frmLogin.Visible = false;
                meni.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmLogin.txtBoxPass.SelectAll();
                frmLogin.txtBoxPass.Focus();
            }
            finally
            {
                frmLogin.btnLogin.Enabled = true;
            }
        }
 

}
}
