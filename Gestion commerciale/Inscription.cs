using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gestion_commerciale
{
    public partial class Inscription : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
      
        public Inscription()
        {
            InitializeComponent();
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Afficher la page de connexion en créant une nouvelle instance
            Login login = new Login();
            login.Show();
        }

        private void inscrire_Click(object sender, EventArgs e)
        {
            conn.Open();
            string nomUser = nom.Text;
            string emailUser = email.Text;
            string motPasseUser = motPasse.Text;
            string confirmMotPasseUser = ConfirmeMotPasse.Text;

            if (motPasseUser != confirmMotPasseUser)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqlQuery = "INSERT INTO [User] (nom, email, pwd, role_id) VALUES (@Nom, @Email, @Password, 2)";

            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                command.Parameters.AddWithValue("@Nom", nomUser);
                command.Parameters.AddWithValue("@Email", emailUser);
                command.Parameters.AddWithValue("@Password", motPasseUser);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Utilisateur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    // Afficher la page de connexion en créant une nouvelle instance
                    Login login = new Login();
                    login.RemplirChampEmail(emailUser); // Appel d'une méthode pour remplir automatiquement le champ d'e-mail
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Échec de l'ajout de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            conn.Close();

        }
    }
}
