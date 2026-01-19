using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace KlijentskaAplikacija.GuiKontroler
{
    internal class MeniCoordinator
    {
        private static MeniCoordinator? instance;
        public static MeniCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MeniCoordinator();
                }
                return instance;
            }
        }

        private MeniCoordinator() { }

        private FrmMeni? frmMeni;
        private Bibliotekar? ulogovani;

        internal void SetUlogovani(Bibliotekar b)
        {
            ulogovani = b;
        }

        internal void ShowFrmMain()
        {
            if (ulogovani == null)
            {
                MessageBox.Show("Nema ulogovanog korisnika!", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmMeni = new FrmMeni(ulogovani);
            frmMeni.AutoSize = true;
            frmMeni.ShowDialog();
        }

        internal void ShowAddPersonPanel()
        {
            // frmMain.ChangePanel(personGuiController.CreateAddPerson());
        }
    }
}