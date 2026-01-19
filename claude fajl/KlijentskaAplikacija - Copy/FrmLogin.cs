using System;
using System.Drawing;
using System.Windows.Forms;
using Domeni;
using KlijentskaAplikacija.GuiKontroler;
using KlijentskaAplikacija.UIKontroler;


namespace KlijentskaAplikacija
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            this.AcceptButton = btnLogin;          // Enter = Login  
            txtBoxPass.UseSystemPasswordChar = true;
            //LoginGuiKontroler.Instance.FrmLogin = this; // Fixed assignment to a property instead of a method group  
            btnLogin.Click += new EventHandler(LoginGuiKontroler.Instance.Login);
        }

        public void ResetValidation()
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
            //if (!Validacija()) return;  

            //var kred = new Bibliotekar  
            //{  
            //    Username = txtBoxUsername.Text.Trim(),  
            //    Password = txtBoxPass.Text  
            //};  

            //btnLogin.Enabled = true;  
            //try  
            //{  
            //    var k = Komunikacija.Instance;  
            //    var b = k.PrijaviBibliotekara(kred);  

            //    if (b == null)  
            //    {  
            //        MessageBox.Show("Neispravni kredencijali.", "Prijava neuspešna",  
            //                        MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            //        txtBoxPass.Clear();  
            //        txtBoxPass.Focus();  
            //        return;  
            //    }  

            //    MessageBox.Show($"Dobrodošla, {b.Ime} {b.Prezime}!", "Prijava uspešna",  
            //                    MessageBoxButtons.OK, MessageBoxIcon.Information);  


            //    FrmMeni meni = new FrmMeni();  
            //    this.Visible = false;  
            //    meni.ShowDialog();  

            //}  
            //catch (Exception ex)  
            //{  
            //    MessageBox.Show(ex.Message, "Greška",  
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);  
            //    txtBoxPass.SelectAll();  
            //    txtBoxPass.Focus();  
            //}  
            //finally  
            //{  
            //    btnLogin.Enabled = true;  
            //}  
        }
    }
}
