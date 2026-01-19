namespace KlijentskaAplikacija
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBoxUsername = new TextBox();
            txtBoxPass = new TextBox();
            lable1 = new Label();
            label1 = new Label();
            btnOtkazi = new Button();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(211, 88);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.Size = new Size(322, 27);
            txtBoxUsername.TabIndex = 0;
            // 
            // txtBoxPass
            // 
            txtBoxPass.Location = new Point(211, 164);
            txtBoxPass.Name = "txtBoxPass";
            txtBoxPass.Size = new Size(322, 27);
            txtBoxPass.TabIndex = 1;
            // 
            // lable1
            // 
            lable1.AutoSize = true;
            lable1.Location = new Point(99, 91);
            lable1.Name = "lable1";
            lable1.Size = new Size(106, 20);
            lable1.TabIndex = 2;
            lable1.Text = "Korisnicko ime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 167);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 3;
            label1.Text = "Sifra";
            // 
            // btnOtkazi
            // 
            btnOtkazi.Location = new Point(211, 248);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(94, 29);
            btnOtkazi.TabIndex = 4;
            btnOtkazi.Text = "Otkazi";
            btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(439, 248);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Prijavi se";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(btnOtkazi);
            Controls.Add(label1);
            Controls.Add(lable1);
            Controls.Add(txtBoxPass);
            Controls.Add(txtBoxUsername);
            Name = "FrmLogin";
            Text = "Prijavljivanje";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtBoxUsername;
        public TextBox txtBoxPass;
        public Label lable1;
        public Label label1;
        public Button btnOtkazi;
        public Button btnLogin;
    }
}
