using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlijentskaAplikacija
{
    public partial class FrmMeni : Form
    {
        public FrmMeni()
        {
            InitializeComponent();
        }

        private void PrikazUC(UserControl uc)
        {
            uc.Dock= DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnUbaciKnjigu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            //var uc = new UCUbaciKnjigu();
        }
    }
}
