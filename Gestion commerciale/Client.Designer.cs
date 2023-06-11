namespace Gestion_commerciale
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.idArticle = new System.Windows.Forms.TextBox();
            this.modif = new System.Windows.Forms.Button();
            this.supprimer = new System.Windows.Forms.Button();
            this.modifier = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.qte = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.liste = new System.Windows.Forms.ComboBox();
            this.listeCmd = new System.Windows.Forms.DataGridView();
            this.libelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code_article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantité = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enregistrer = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.id = new System.Windows.Forms.TextBox();
            this.CmdValidé = new System.Windows.Forms.DataGridView();
            this.nomUser = new System.Windows.Forms.Label();
            this.prix = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listeCmd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdValidé)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Gestion_commerciale.Properties.Resources.icons8_sortie_64;
            this.pictureBox6.Location = new System.Drawing.Point(52, 571);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(35, 34);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(85, 571);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(118, 36);
            this.button7.TabIndex = 13;
            this.button7.Text = "Se déconnecter";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // idArticle
            // 
            this.idArticle.Location = new System.Drawing.Point(344, 499);
            this.idArticle.Name = "idArticle";
            this.idArticle.Size = new System.Drawing.Size(100, 20);
            this.idArticle.TabIndex = 98;
            this.idArticle.Visible = false;
            // 
            // modif
            // 
            this.modif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.modif.Location = new System.Drawing.Point(315, 328);
            this.modif.Name = "modif";
            this.modif.Size = new System.Drawing.Size(75, 43);
            this.modif.TabIndex = 97;
            this.modif.Text = "Modifier";
            this.modif.UseVisualStyleBackColor = false;
            this.modif.Click += new System.EventHandler(this.modif_Click);
            // 
            // supprimer
            // 
            this.supprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.supprimer.Location = new System.Drawing.Point(408, 328);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(75, 43);
            this.supprimer.TabIndex = 96;
            this.supprimer.Text = "Supprimer";
            this.supprimer.UseVisualStyleBackColor = false;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // modifier
            // 
            this.modifier.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.modifier.Location = new System.Drawing.Point(229, 328);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(75, 43);
            this.modifier.TabIndex = 95;
            this.modifier.Text = "Editer";
            this.modifier.UseVisualStyleBackColor = false;
            this.modifier.Click += new System.EventHandler(this.modifier_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button6.Location = new System.Drawing.Point(697, 328);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 43);
            this.button6.TabIndex = 93;
            this.button6.Text = "Valider Commande";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // qte
            // 
            this.qte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.qte.Location = new System.Drawing.Point(578, 69);
            this.qte.Name = "qte";
            this.qte.Size = new System.Drawing.Size(136, 13);
            this.qte.TabIndex = 92;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(569, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 1);
            this.panel3.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(575, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 90;
            this.label3.Text = "Quantité";
            // 
            // liste
            // 
            this.liste.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.liste.FormattingEnabled = true;
            this.liste.Location = new System.Drawing.Point(257, 64);
            this.liste.Name = "liste";
            this.liste.Size = new System.Drawing.Size(137, 21);
            this.liste.TabIndex = 89;
            this.liste.Text = "Choisir l\'article";
            // 
            // listeCmd
            // 
            this.listeCmd.BackgroundColor = System.Drawing.Color.White;
            this.listeCmd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listeCmd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.libelle,
            this.code_article,
            this.PU,
            this.Quantité,
            this.Total});
            this.listeCmd.Location = new System.Drawing.Point(229, 145);
            this.listeCmd.Name = "listeCmd";
            this.listeCmd.Size = new System.Drawing.Size(543, 115);
            this.listeCmd.TabIndex = 84;
            // 
            // libelle
            // 
            this.libelle.HeaderText = "libelle";
            this.libelle.Name = "libelle";
            // 
            // code_article
            // 
            this.code_article.HeaderText = "code_article";
            this.code_article.Name = "code_article";
            // 
            // PU
            // 
            this.PU.HeaderText = "pu";
            this.PU.Name = "PU";
            // 
            // Quantité
            // 
            this.Quantité.HeaderText = "Quantité";
            this.Quantité.Name = "Quantité";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // enregistrer
            // 
            this.enregistrer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.enregistrer.Location = new System.Drawing.Point(229, 96);
            this.enregistrer.Name = "enregistrer";
            this.enregistrer.Size = new System.Drawing.Size(75, 43);
            this.enregistrer.TabIndex = 83;
            this.enregistrer.Text = "Enregistrer";
            this.enregistrer.UseVisualStyleBackColor = false;
            this.enregistrer.Click += new System.EventHandler(this.enregistrer_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Location = new System.Drawing.Point(248, 87);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 1);
            this.panel5.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(254, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 81;
            this.label4.Text = "Article";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.nomUser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Location = new System.Drawing.Point(-43, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 620);
            this.panel1.TabIndex = 79;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestion_commerciale.Properties.Resources.icons8_shopping_cart_100;
            this.pictureBox1.Location = new System.Drawing.Point(52, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(396, 237);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 85;
            // 
            // CmdValidé
            // 
            this.CmdValidé.BackgroundColor = System.Drawing.Color.White;
            this.CmdValidé.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CmdValidé.Location = new System.Drawing.Point(229, 401);
            this.CmdValidé.Name = "CmdValidé";
            this.CmdValidé.Size = new System.Drawing.Size(543, 150);
            this.CmdValidé.TabIndex = 94;
            // 
            // nomUser
            // 
            this.nomUser.AutoSize = true;
            this.nomUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomUser.Location = new System.Drawing.Point(56, 15);
            this.nomUser.Name = "nomUser";
            this.nomUser.Size = new System.Drawing.Size(0, 19);
            this.nomUser.TabIndex = 16;
            // 
            // prix
            // 
            this.prix.AutoSize = true;
            this.prix.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prix.Location = new System.Drawing.Point(724, 279);
            this.prix.Name = "prix";
            this.prix.Size = new System.Drawing.Size(0, 16);
            this.prix.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(668, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 100;
            this.label1.Text = "Total :";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prix);
            this.Controls.Add(this.idArticle);
            this.Controls.Add(this.modif);
            this.Controls.Add(this.supprimer);
            this.Controls.Add(this.modifier);
            this.Controls.Add(this.CmdValidé);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.qte);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.liste);
            this.Controls.Add(this.listeCmd);
            this.Controls.Add(this.enregistrer);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.id);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listeCmd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdValidé)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox idArticle;
        private System.Windows.Forms.Button modif;
        private System.Windows.Forms.Button supprimer;
        private System.Windows.Forms.Button modifier;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox qte;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox liste;
        private System.Windows.Forms.DataGridView listeCmd;
        private System.Windows.Forms.Button enregistrer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.DataGridViewTextBoxColumn libelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn code_article;
        private System.Windows.Forms.DataGridViewTextBoxColumn PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantité;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView CmdValidé;
        private System.Windows.Forms.Label nomUser;
        private System.Windows.Forms.Label prix;
        private System.Windows.Forms.Label label1;
    }
}