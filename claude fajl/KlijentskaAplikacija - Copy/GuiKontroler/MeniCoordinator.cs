using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.GuiKontroler
{
    internal class MeniCoordinator
    {
        private static MeniCoordinator instance;
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

        private MeniCoordinator()
        {
            //personGuiController = new PersonGuiController();
        }

        private FrmMeni frmMeni;
        //private PersonGuiController personGuiController;

        internal void ShowFrmMain()
        {
            frmMeni = new FrmMeni();
            frmMeni.AutoSize = true;
            frmMeni.ShowDialog();
        }

        internal void ShowAddPersonPanel()
        {
            // frmMain.ChangePanel(personGuiController.CreateAddPerson());
        }
    }
}
