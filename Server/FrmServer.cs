using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Start();
                txtStatus.Text = "Server je pokrenut na portu 9999!";
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                server.Stop();
                txtStatus.Text = "Server je zaustavljen.";
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }

}
