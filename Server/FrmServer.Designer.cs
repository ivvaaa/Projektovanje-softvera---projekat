using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using Font = System.Drawing.Font;

namespace Server
{
    partial class FrmServer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            txtStatus = new TextBox();
            lblNaslov = new Label();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNaslov.Location = new Point(150, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(200, 25);
            lblNaslov.Text = "BIBLIOTEKA - SERVER";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(50, 80);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(120, 50);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(50, 150);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(120, 50);
            btnStop.TabIndex = 1;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(200, 115);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(280, 23);
            txtStatus.TabIndex = 2;
            txtStatus.Text = "Server nije pokrenut.";
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 230);
            Controls.Add(lblNaslov);
            Controls.Add(txtStatus);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "FrmServer";
            Text = "Biblioteka - Server";
            FormClosed += FrmServer_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnStart;
        private Button btnStop;
        private TextBox txtStatus;
        private Label lblNaslov;
    }
}