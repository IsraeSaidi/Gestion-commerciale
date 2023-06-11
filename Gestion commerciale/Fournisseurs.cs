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
    public partial class Fournisseurs : Form
    {
        DataTable dt;
        SqlDataAdapter adapter;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
    

        public Fournisseurs()
        {
            InitializeComponent();
            listeFournisseurs();
        }


        public DataTable reccuperer(String request)
        {
            dt = new DataTable();
            adapter = new SqlDataAdapter(request, conn);
            adapter.Fill(dt);
            return dt;
        }

        public void listeFournisseurs()
        {
            String rqt = "SELECT * FROM [Fournisseur]";


            listeFournisseur.DataSource = reccuperer(rqt);
            listeFournisseur.Columns["nom"].HeaderText = "Nom Fournisseur";
    
        }

        private void enregistrer_Click(object sender, EventArgs e)
        {
            conn.Open();

            if (nom.Text == "" )
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nomFour = nom.Text;
       
                string sqlQuery = "INSERT INTO [Fournisseur] (nom) VALUES (@Nom)";

                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    command.Parameters.AddWithValue("@Nom", nomFour);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Fournisseur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listeFournisseurs();
                    }
                    else
                    {
                        MessageBox.Show("Échec de l'ajout de fournisseur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            conn.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (listeFournisseur.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeFournisseur.SelectedRows[0].Index;

                // Obtenir les valeurs modifiées de chaque colonne

                int FournisseurId = Convert.ToInt32(listeFournisseur.Rows[rowIndex].Cells["id"].Value);
                string nomFournisseur = listeFournisseur.Rows[rowIndex].Cells["nom"].Value.ToString();
             

                // Exécuter la requête SQL UPDATE pour mettre à jour les données du fournisseur

                nom.Text = nomFournisseur;
         
                id.Text = FournisseurId.ToString();
                listeFournisseurs();
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
            if (nom.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nomFournisseur = nom.Text;
                int idFournisseur = Convert.ToInt32(id.Text);

                string rqt = $"UPDATE [Fournisseur] SET nom = '{nomFournisseur}'  WHERE id = {idFournisseur}";

                // Exécuter la requête de mise à jour
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Fournisseur modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeFournisseurs();
            }
            conn.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            conn.Open();
            // Vérifier s'il y a une ligne sélectionnée
            if (listeFournisseur.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeFournisseur.SelectedRows[0].Index;

                // Obtenir la valeur de la colonne contenant l'ID du fournisseur
                int FournisseurId = Convert.ToInt32(listeFournisseur.Rows[rowIndex].Cells["id"].Value);

                // Exécuter la requête SQL DELETE pour supprimer le fournisseur de la base de données
                string rqt = $"DELETE FROM [Fournisseur] WHERE id = {FournisseurId}";

                // Exécuter la requête de suppression
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Fournisseur Supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeFournisseurs();
            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fournisseurs four = new Fournisseurs();
            four.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articles art = new Articles();
            art.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Achat achat = new Achat();
            achat.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commandes commandes = new Commandes();
            commandes.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
