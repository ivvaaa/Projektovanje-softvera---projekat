using Domeni;
using KlijentskaAplikacija.UIKontroler;

namespace KlijentskaAplikacija
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private bool Validacija()
        {
            txtBoxPass.BackColor = Color.White;
            txtBoxUsername.BackColor = Color.White;
            bool okej = true;
            if (string.IsNullOrEmpty(txtBoxPass.Text)) {
                txtBoxPass.BackColor = Color.Salmon;
                return false; 
            }
            if (string.IsNullOrEmpty(txtBoxUsername.Text))
            {
                txtBoxUsername.BackColor = Color.Salmon;
                okej = false;
            }
            if (!okej)
            {
                MessageBox.Show("Nisu uneti svi podaci!", "Upoyorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return okej;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;

            Bibliotekar bibliotekar = new Bibliotekar()
            {
                Username = txtBoxUsername.Text,
                Password=txtBoxPass.Text
            };
            try
            {
                Kontroler k = Kontroler.Instance;
                k.PoveziSe();
                Bibliotekar b = k.PrijaviBibliotekara(bibliotekar);
                MessageBox.Show("Uspesno povezivanje sa serverom!");


            }
            catch (Exception ex)
            {
            }


        }
    }
}
