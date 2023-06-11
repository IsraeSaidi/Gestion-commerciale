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
    public partial class Achat : Form
    {
        DataTable dt;
        SqlDataAdapter adapter;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
        List<Fournisseur> fournisseurs;
        List<Article> articles;
        public Achat()
        {
            InitializeComponent();
            LoadFournisseurs();
            LoadArticles();
            listeAchat();
        }
        private void LoadFournisseurs()
        {
            fournisseurs = new List<Fournisseur>();

            try
            {

                conn.Open();
                string query = "SELECT id, nom FROM Fournisseur";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int fournisseurId = reader.GetInt32(0);
                    string fournisseurNom = reader.GetString(1);
                    Fournisseur Four = new Fournisseur(fournisseurId, fournisseurNom);
                    fournisseurs.Add(Four);
                }
                conn.Close();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading Fournisseurs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set the ComboBox data source and properties
            listeFour.DataSource = fournisseurs;
            listeFour.ValueMember = "fournisseurId";
            listeFour.DisplayMember = "fournisseurNom";
        }



        private void LoadArticles()
        {
            articles = new List<Article>();

            try
            {

                conn.Open();
                string query = "SELECT id, libelle FROM Article";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int articleId = reader.GetInt32(0);
                    string articleLibelle = reader.GetString(1);
                    Article art = new Article(articleId, articleLibelle, 7);
                    articles.Add(art);
                }
                conn.Close();

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading Articles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set the ComboBox data source and properties
            liste.DataSource = articles;
            liste.ValueMember = "articleId";
            liste.DisplayMember = "articleLibelle";
        }

        private void enregistrer_Click(object sender, EventArgs e)
        {

            if (qte.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int qteArticle = Convert.ToInt32(qte.Text);
                var selectedFournisseur = (Fournisseur)listeFour.SelectedItem;
                var selectedArticle = (Article)liste.SelectedItem;
                int fourId = selectedFournisseur.fournisseurId;
                string fourNom = selectedFournisseur.fournisseurNom;
                int articleId = selectedArticle.articleId;
                String articleLibelle = selectedArticle.articleLibelle;
                double articlePu = selectedArticle.articlePU;
                String total = (qteArticle * articlePu).ToString();
                listeAchats.Rows.Add(articleLibelle, articleId, articlePu, fourNom, fourId, qteArticle, total);


            }
        }


        private void Achat_Load(object sender, EventArgs e)
        {

        }

        public DataTable reccuperer(String request)
        {
            dt = new DataTable();
            adapter = new SqlDataAdapter(request, conn);
            adapter.Fill(dt);
            return dt;
        }

        public void listeAchat()
        {
            String rqt = "SELECT a.id, a.date, la.qte, ar.libelle AS libelle_article, ar.id AS code_article, f.nom AS nom_fournisseur " +
                            "FROM [Achat] a " +
                            "JOIN ligneAchat la ON a.id = la.achat_id " +
                            "JOIN article ar ON la.article_id = ar.id " +
                            "JOIN fournisseur f ON a.fournisseur_id = f.id";

            achatValidé.DataSource = reccuperer(rqt);




        }

        private void modifier_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (listeAchats.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeAchats.SelectedRows[0].Index;

                // Obtenir les valeurs modifiées de chaque colonne

                int achatId = Convert.ToInt32(listeAchats.Rows[rowIndex].Cells["id"].Value);
                string article = listeAchats.Rows[rowIndex].Cells["libelle_article"].Value.ToString();
                string fournisseur = listeAchats.Rows[rowIndex].Cells["nom_fournisseur"].Value.ToString();
                int qteArticle = Convert.ToInt32(listeAchats.Rows[rowIndex].Cells["qte"].Value.ToString());

                // Exécuter la requête SQL UPDATE pour mettre à jour les données de l'achat


                qte.Text = qteArticle.ToString();

                id.Text = achatId.ToString();

                listeAchat();

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
            if (qte.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int qteArticle = Convert.ToInt32(qte.Text);
                var selectedFournisseur = (Fournisseur)listeFour.SelectedItem;
                var selectedArticle = (Article)liste.SelectedItem;
                int fourId = selectedFournisseur.fournisseurId;
                int articleId = selectedArticle.articleId;
                int achatId = Convert.ToInt32(id.Text);

                string rqt = $"UPDATE [Achat] SET  fournisseur_id = '{fourId}'  WHERE  id = {achatId}";

                // Exécuter la requête de mise à jour
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                string rqt2 = $"UPDATE [ligneAchat] SET  article_id = '{articleId}', qte='{qteArticle}'  WHERE achat_id = {achatId}";
                SqlCommand command2 = new SqlCommand(rqt2, conn);
                command2.ExecuteNonQuery();
                MessageBox.Show("Achat modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeAchat();
            }
            conn.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {

            conn.Open();
            // Vérifier s'il y a une ligne sélectionnée
            if (listeAchats.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = listeAchats.SelectedRows[0].Index;

                // Obtenir la valeur de la colonne contenant l'ID de l'utilisateur
                int achatId = Convert.ToInt32(listeAchats.Rows[rowIndex].Cells["id"].Value);

                string rqt = $"DELETE FROM [ligneAchat] WHERE achat_id = {achatId}";

                // Exécuter la requête de suppression
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                // Exécuter la requête SQL DELETE pour supprimer l'utilisateur de la base de données
                string rqt2 = $"DELETE FROM [Achat] WHERE id = {achatId}";

                // Exécuter la requête de suppression
                SqlCommand command2 = new SqlCommand(rqt2, conn);
                command2.ExecuteNonQuery();
                MessageBox.Show("Achat Supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeAchat();
            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Achat achat = new Achat();
            achat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fournisseurs fournisseurs = new Fournisseurs();
            fournisseurs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articles article = new Articles();
            article.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commandes cmd = new Commandes();
            cmd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();

            int qteArticle = Convert.ToInt32(qte.Text);
            var selectedFournisseur = (Fournisseur)listeFour.SelectedItem;
            var selectedArticle = (Article)liste.SelectedItem;

            DateTime date = DateTime.Now;
            int fourId = selectedFournisseur.fournisseurId;
            int articleId = selectedArticle.articleId;

            string sqlQuery = "INSERT INTO [Achat] (date, fournisseur_id) VALUES (@date, @FourId)";

            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@FourId", fourId);
                command.ExecuteNonQuery();

                command.CommandText = "SELECT MAX(id) FROM Achat";
                string achatId = command.ExecuteScalar().ToString();

                for (int i = 0; i < listeAchats.Rows.Count - 1; i++)
                {
                    string rqt2 = "INSERT INTO [ligneAchat] (achat_id, article_id, qte) VALUES (@AchatId, @ArticleId, @QTE)";
                    using (SqlCommand command1 = new SqlCommand(rqt2, conn))
                    {
                        int artid = Convert.ToInt32(listeAchats.Rows[i].Cells[1].Value);
                        int qte = Convert.ToInt32(listeAchats.Rows[i].Cells[5].Value);

                        command1.Parameters.AddWithValue("@AchatId", Convert.ToInt32(achatId));
                        command1.Parameters.AddWithValue("@ArticleId", artid);
                        command1.Parameters.AddWithValue("@QTE", qte);
                        command1.ExecuteNonQuery();

                    }


                }
                MessageBox.Show("Achat ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listeAchat();
                listeAchats.Rows.Clear();

            }


            conn.Close();
        }

        private void modifier_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            if (achatValidé.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = achatValidé.SelectedRows[0].Index;

                // Obtenir les valeurs modifiées de chaque colonne

                int achatId = Convert.ToInt32(achatValidé.Rows[rowIndex].Cells["id"].Value);
                string article = achatValidé.Rows[rowIndex].Cells["libelle_article"].Value.ToString();
                string fournisseur = achatValidé.Rows[rowIndex].Cells["nom_fournisseur"].Value.ToString();
                int qteArticle = Convert.ToInt32(achatValidé.Rows[rowIndex].Cells["qte"].Value.ToString());
                int idArt = Convert.ToInt32(achatValidé.Rows[rowIndex].Cells["code_article"].Value.ToString());

                qte.Text = qteArticle.ToString();

                id.Text = achatId.ToString();
                idArticle.Text = idArt.ToString();

                listeAchat();

            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void modif_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            if (qte.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int qteArticle = Convert.ToInt32(qte.Text);
                var selectedFournisseur = (Fournisseur)listeFour.SelectedItem;
                var selectedArticle = (Article)liste.SelectedItem;
                int clientId = selectedFournisseur.fournisseurId;
                int articleId = Convert.ToInt32(idArticle.Text);
                int achatId = Convert.ToInt32(id.Text);

                string rqt = $"UPDATE [Achat] SET  fournisseur_id = '{clientId}'  WHERE  id = {achatId}";

                // Exécuter la requête de mise à jour
                SqlCommand command = new SqlCommand(rqt, conn);
                command.ExecuteNonQuery();
                string rqt2 = $"UPDATE [ligneAchat] SET  qte='{qteArticle}'  WHERE achat_id = {achatId} AND article_id = {articleId}";
                SqlCommand command2 = new SqlCommand(rqt2, conn);
                command2.ExecuteNonQuery();
                MessageBox.Show("Achat modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeAchat();
            }
            conn.Close();
        
        }

        private void supprimer_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            // Vérfier s'il y a une ligne sélectionnée
            if (achatValidé.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = achatValidé.SelectedRows[0].Index;

                // Obtenir la valeur de la colonne contenant l'ID de l'utilisateur
                int achatId = Convert.ToInt32(achatValidé.Rows[rowIndex].Cells["id"].Value);
                int artieId = Convert.ToInt32(achatValidé.Rows[rowIndex].Cells["code_article"].Value);

                // Exécuter la requête SQL DELETE pour supprimer l'utilisateur de la base de données
                string rqt2 = $"DELETE FROM [ligneAchat] WHERE achat_id = {achatId} AND article_id = {artieId}";

                // Exécuter la requête de suppression
                SqlCommand command2 = new SqlCommand(rqt2, conn);
                command2.ExecuteNonQuery();
                MessageBox.Show("Achat Supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeAchat();
            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }



}


