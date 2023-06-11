using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gestion_commerciale
{
    public partial class Dashboard : Form
    {

        DataTable dt;
        SqlDataAdapter adapter;


        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
        public Dashboard()
        {
            InitializeComponent();
            listeUtilisateurs();
        }

        public DataTable reccuperer(String request)
        {
            dt = new DataTable();
            adapter = new SqlDataAdapter(request, conn);
            adapter.Fill(dt);
            return dt;
        }

        public void listeUtilisateurs()
        {
            String rqt = "SELECT u.id, u.nom, u.email, u.pwd, r.nom " +"FROM [User] u " +"JOIN Role r ON u.role_id = r.id";


            listeUsers.DataSource = reccuperer(rqt);
            listeUsers.Columns["nom1"].HeaderText = "Role";
            listeUsers.Columns["email"].HeaderText = "Email";
            listeUsers.Columns["nom"].HeaderText = "Nom";
            listeUsers.Columns["pwd"].HeaderText = "Mot de passe";
          


        }

        private void enregistrer_Click(object sender, EventArgs e)
        {
            conn.Open();

            if (nom.Text == "" || email.Text == "" || pwd.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { 
            string nomUser = nom.Text;
            string emailUser = email.Text;
            string motPasseUser = pwd.Text;
            string typeUser = type.Text;
            int typeNumber = 0;


            if (typeUser == "Admin")
            {
                typeNumber = 1;
            }
            else
            {
                typeNumber = 2;
            }

            string sqlQuery = "INSERT INTO [User] (nom, email, pwd, role_id) VALUES (@Nom, @Email, @Password, @type)";

                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    command.Parameters.AddWithValue("@Nom", nomUser);
                    command.Parameters.AddWithValue("@Email", emailUser);
                    command.Parameters.AddWithValue("@Password", motPasseUser);
                    command.Parameters.AddWithValue("@type", typeNumber);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Utilisateur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listeUtilisateurs();
                    }
                    else
                    {
                        MessageBox.Show("Échec de l'ajout de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            conn.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {

            conn.Open();
            // Vérifier s'il y a une ligne sélectionnée
            if (listeUsers.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeUsers.SelectedRows[0].Index;

                // Obtenir la valeur de la colonne contenant l'ID de l'utilisateur
                int userId = Convert.ToInt32(listeUsers.Rows[rowIndex].Cells["id"].Value);

                // Exécuter la requête SQL DELETE pour supprimer l'utilisateur de la base de données
                string rqt = $"DELETE FROM [User] WHERE id = {userId}";

                // Exécuter la requête de suppression
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Utilisateur Supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeUtilisateurs();
            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (listeUsers.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeUsers.SelectedRows[0].Index;

                // Obtenir les valeurs modifiées de chaque colonne
              
                int userId = Convert.ToInt32(listeUsers.Rows[rowIndex].Cells["id"].Value);
                string username = listeUsers.Rows[rowIndex].Cells["nom"].Value.ToString();
                string roleName = listeUsers.Rows[rowIndex].Cells["nom1"].Value.ToString();
                string useremail = listeUsers.Rows[rowIndex].Cells["email"].Value.ToString();
                string userpwd = listeUsers.Rows[rowIndex].Cells["pwd"].Value.ToString();
                // Exécuter la requête SQL UPDATE pour mettre à jour les données de l'utilisateur

                nom.Text = username;
                email.Text = useremail;
                pwd.Text = userpwd;
                type.Text = roleName;
                id.Text = userId.ToString();


            
             
                listeUtilisateurs();
            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void modif_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (nom.Text == "" || email.Text == "" || pwd.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nomUser = nom.Text;
                string emailUser = email.Text;
                string motPasseUser = pwd.Text;
                string typeUser = type.Text;
                int idUser = Convert.ToInt32(id.Text);
                int typeNumber = 0;


                if (typeUser == "Admin")
                {
                    typeNumber = 1;
                }
                else
                {
                    typeNumber = 2;
                }

                string rqt = $"UPDATE [User] SET nom = '{nomUser}', email = '{emailUser}', pwd = '{motPasseUser}', role_id = '{typeNumber}'  WHERE id = {idUser}";

                // Exécuter la requête de mise à jour
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Utilisateur modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeUtilisateurs();
            }
        conn.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard da = new Dashboard();
            da.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard da = new Dashboard();
            da.Show();

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articles art = new Articles();
            art.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articles art = new Articles();
            art.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fournisseurs four = new Fournisseurs();
            four.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Achat achat = new Achat();
            achat.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listeUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commandes cmd = new Commandes();
            cmd.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
