namespace Gestion_commerciale
{
    partial class Login
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button1 = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.motPasse = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Inscrire = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(596, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.White;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email.Location = new System.Drawing.Point(473, 103);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(198, 13);
            this.email.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(369, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(369, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de passe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(235, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 52);
            this.label3.TabIndex = 6;
            this.label3.Text = "S\'authentifier";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(473, 174);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Afficher le mot de passe";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(471, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 9;
            // 
            // motPasse
            // 
            this.motPasse.BackColor = System.Drawing.Color.White;
            this.motPasse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.motPasse.Location = new System.Drawing.Point(473, 148);
            this.motPasse.Name = "motPasse";
            this.motPasse.Size = new System.Drawing.Size(198, 13);
            this.motPasse.TabIndex = 10;
            this.motPasse.UseSystemPasswordChar = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(471, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 11;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Gestion_commerciale.Properties.Resources.icons8_password_52;
            this.pictureBox3.Location = new System.Drawing.Point(336, 150);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gestion_commerciale.Properties.Resources.icons8_email_60;
            this.pictureBox2.Location = new System.Drawing.Point(336, 103);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Gestion_commerciale.Properties.Resources.Secure_login_rafiki;
            this.pictureBox1.Location = new System.Drawing.Point(8, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Inscrire
            // 
            this.Inscrire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Inscrire.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Inscrire.BackgroundImage")));
            this.Inscrire.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Inscrire.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inscrire.Location = new System.Drawing.Point(518, 209);
            this.Inscrire.Margin = new System.Windows.Forms.Padding(0);
            this.Inscrire.Name = "Inscrire";
            this.Inscrire.Size = new System.Drawing.Size(75, 40);
            this.Inscrire.TabIndex = 5;
            this.Inscrire.Text = "S\'inscire";
            this.Inscrire.UseVisualStyleBackColor = false;
            this.Inscrire.Click += new System.EventHandler(this.Inscrire_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 295);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.motPasse);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Inscrire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email);
            this.Controls.Add(this.button1);
            this.Name = "Login";
            this.Text = "Form1";
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Inscrire;
        private System.Windows.Forms.Label label3;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Diagnostics.PerformanceCounter performanceCounter2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox motPasse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

