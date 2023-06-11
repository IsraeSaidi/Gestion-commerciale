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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gestion_commerciale
{
    public partial class Articles : Form
    {
        DataTable dt;
        SqlDataAdapter adapter;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
        public Articles()
        {
            InitializeComponent();
            listeArticles();
        }


        public DataTable reccuperer(String request)
        {
            dt = new DataTable();
            adapter = new SqlDataAdapter(request, conn);
            adapter.Fill(dt);
            return dt;
        }

        public void listeArticles()
        {
            String rqt = "SELECT * FROM [Article]";


            listeArticle.DataSource = reccuperer(rqt);
            listeArticle.Columns["libelle"].HeaderText = "Libelle";
            listeArticle.Columns["pu"].HeaderText = "Prix unitaire";
            



        }
        private void enregistrer_Click(object sender, EventArgs e)
        {
            conn.Open();

            if (libelle.Text == "" || pu.Text == "" )
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string libelleArticle = libelle.Text;
                string puArticle = pu.Text;
       

                string sqlQuery = "INSERT INTO [Article] (libelle, pu) VALUES (@Libelle, @Pu)";

                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    command.Parameters.AddWithValue("@Libelle", libelleArticle);
                    command.Parameters.AddWithValue("@Pu", puArticle);
             
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Article ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listeArticles();
                    }
                    else
                    {
                        MessageBox.Show("Échec de l'ajout de l'article.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            conn.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (listeArticle.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeArticle.SelectedRows[0].Index;

                // Obtenir les valeurs modifiées de chaque colonne

                int ArticleId = Convert.ToInt32(listeArticle.Rows[rowIndex].Cells["id"].Value);
                string libelleArticle = listeArticle.Rows[rowIndex].Cells["libelle"].Value.ToString();
                string puArticle = listeArticle.Rows[rowIndex].Cells["pu"].Value.ToString();
              
                // Exécuter la requête SQL UPDATE pour mettre à jour les données de l'article

                libelle.Text = libelleArticle;
                pu.Text = puArticle;
            
                id.Text = ArticleId.ToString();
                listeArticles();
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
            if (libelle.Text == "" || pu.Text == "" )
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string libelleArticle = libelle.Text;
                double puArticle = double.Parse(pu.Text);
              
                int idArticle = Convert.ToInt32(id.Text);
         
                string rqt = $"UPDATE [Article] SET libelle = '{libelleArticle}', pu = '{puArticle}'  WHERE id = {idArticle}";

                // Exécuter la requête de mise à jour
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Article modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeArticles();
            }
            conn.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            conn.Open();
            // Vérifier s'il y a une ligne sélectionnée
            if (listeArticle.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeArticle.SelectedRows[0].Index;

                // Obtenir la valeur de la colonne contenant l'ID de l'article
                int ArticleId = Convert.ToInt32(listeArticle.Rows[rowIndex].Cells["id"].Value);

                // Exécuter la requête SQL DELETE pour supprimer l'utilisateur de la base de données
                string rqt = $"DELETE FROM [Article] WHERE id = {ArticleId}";

                // Exécuter la requête de suppression
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("l'article Supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeArticles();
            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Achat achat = new Achat();
            achat.Show();

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
    }
}
