using System;
using System.Collections;
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
    public partial class Client : Form
    {
        DataTable dt;
        int price = 0;        
        SqlDataAdapter adapter;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
  
        List<Article> articles;
        public string emailUser;
        public Client(string text)
        {

            InitializeComponent();
            listeCommandes();
            LoadArticles();
            emailUser = text;
            nomUser.Text = "Bienvenue " + NomUser(emailUser);
          
        }


        public string NomUser(string emailUser)
        {
            string clientNom = string.Empty;

            string rqt = "SELECT nom FROM [User] WHERE email = @Email";

            using (SqlCommand command = new SqlCommand(rqt, conn))
            {
                command.Parameters.AddWithValue("@Email", emailUser);
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        clientNom = reader.GetString(0);
                    }
                }
            }

            conn.Close();

            return clientNom;
        }

        public int IdUser(string em)
        {
            int clientId = 0;

            string rqt = "SELECT id FROM [User] WHERE email = @Email";

            using (SqlCommand command = new SqlCommand(rqt, conn))
            {
                command.Parameters.AddWithValue("@Email", em);
                conn.Open();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clientId = reader.GetInt32(0);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }

            return clientId;
        }



        private void LoadArticles()
        {
            articles = new List<Article>();

            try
            {

                conn.Open();
                string query = "SELECT * FROM Article";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int articleId = reader.GetInt32(0);
                    string articleLibelle = reader.GetString(1);
                    float articlePu = reader.GetFloat(2);
                    Article art = new Article(articleId, articleLibelle, articlePu);
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
                
                string rqt = "SELECT * FROM [User] WHERE email = @Email";

                using (SqlCommand command = new SqlCommand(rqt, conn))
                {
                    command.Parameters.AddWithValue("@Email", emailUser);
                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Move to the first row
                        {
                            int clientId = reader.GetInt32(0); // Assuming the first column is the client ID
                            string clientNom = reader.GetString(1); // Assuming the second column is the client name
                            int qteArticle = Convert.ToInt32(qte.Text);

                            var selectedArticle = (Article)liste.SelectedItem;
                            int cliId = clientId;

                            int articleId = selectedArticle.articleId;
                            String articleLibelle = selectedArticle.articleLibelle;
                            double articlePu = selectedArticle.articlePU;
                            String total = (qteArticle * articlePu).ToString();
                            price = price + Convert.ToInt32(total);
                            prix.Text = price.ToString() + " DH";
                            listeCmd.Rows.Add(articleLibelle, articleId, articlePu, qteArticle, total);
                           
                        }
                        
                    }
                    conn.Close();
                }
                


            


            }
        }


        public DataTable reccuperer(String request)
        {
            dt = new DataTable();
            adapter = new SqlDataAdapter(request, conn);
            adapter.Fill(dt);
            return dt;
        }
        public void listeCommandes()
        {
            String rqt = "SELECT c.id, c.date_cmd, lc.qte, ar.libelle AS libelle_article,ar.id AS code_article " +
                           "FROM [Commande] c " +
                           "JOIN ligneCmd lc ON c.id = lc.commande_id " +
                           "JOIN article ar ON lc.article_id = ar.id ";
                         
                          



            CmdValidé.DataSource = reccuperer(rqt);
        }




        private void button6_Click(object sender, EventArgs e)
        {

            int cliId = IdUser(emailUser);
            conn.Open();

            int qteArticle = Convert.ToInt32(qte.Text);
         
            var selectedArticle = (Article)liste.SelectedItem;

            DateTime date = DateTime.Now;
           
            int articleId = selectedArticle.articleId;

            string sqlQuery = "INSERT INTO [Commande] (date_cmd, client_id) VALUES (@date, @CliId)";

            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@CliId", cliId);
                command.ExecuteNonQuery();

                command.CommandText = "SELECT MAX(id) FROM Commande";
                string commandeId = command.ExecuteScalar().ToString();

                for (int i = 0; i < listeCmd.Rows.Count - 1; i++)
                {
                    string rqt2 = "INSERT INTO [ligneCmd] (commande_id, article_id, qte) VALUES (@CmdId, @ArticleId, @QTE)";
                    using (SqlCommand command1 = new SqlCommand(rqt2, conn))
                    {
                        int artid = Convert.ToInt32(listeCmd.Rows[i].Cells[1].Value);
                        int qte = Convert.ToInt32(listeCmd.Rows[i].Cells[3].Value);

                        command1.Parameters.AddWithValue("@CmdId", Convert.ToInt32(commandeId));
                        command1.Parameters.AddWithValue("@ArticleId", artid);
                        command1.Parameters.AddWithValue("@QTE", qte);
                        command1.ExecuteNonQuery();

                    }


                }
                MessageBox.Show("Commande ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listeCommandes();
                listeCmd.Rows.Clear();

            }


            conn.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (CmdValidé.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = CmdValidé.SelectedRows[0].Index;

                // Obtenir les valeurs modifiées de chaque colonne

                int cmdId = Convert.ToInt32(CmdValidé.Rows[rowIndex].Cells["id"].Value);
                string article = CmdValidé.Rows[rowIndex].Cells["libelle_article"].Value.ToString();
                
                int qteArticle = Convert.ToInt32(CmdValidé.Rows[rowIndex].Cells["qte"].Value.ToString());
                int idArt = Convert.ToInt32(CmdValidé.Rows[rowIndex].Cells["code_article"].Value.ToString());

                qte.Text = qteArticle.ToString();

                id.Text = cmdId.ToString();
                idArticle.Text = idArt.ToString();

                listeCommandes();

            }
            else
            {
                MessageBox.Show("Séléctionner la ligne à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void modif_Click(object sender, EventArgs e)
        {
            int clientId = IdUser(emailUser);
            conn.Open();
            if (qte.Text == "")
            {
                MessageBox.Show("Remplissez tout le formulaire SVP .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int qteArticle = Convert.ToInt32(qte.Text);
          
                var selectedArticle = (Article)liste.SelectedItem;
            
                int articleId = Convert.ToInt32(idArticle.Text);
                int cmdId = Convert.ToInt32(id.Text);

              
                string rqt2 = $"UPDATE [ligneCmd] SET  qte='{qteArticle}'  WHERE commande_id = {cmdId} AND article_id = {articleId}";
                SqlCommand command2 = new SqlCommand(rqt2, conn);
                command2.ExecuteNonQuery();
                MessageBox.Show("Commande modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeCommandes();
            }
            conn.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            conn.Open();
            // Vérifier s'il y a une ligne sélectionnée
            if (CmdValidé.SelectedRows.Count > 0)
            {
                // Obtenir l'index de la ligne sélectionnée
                int rowIndex = CmdValidé.SelectedRows[0].Index;

                // Obtenir la valeur de la colonne contenant l'ID de l'utilisateur
                int commandeId = Convert.ToInt32(CmdValidé.Rows[rowIndex].Cells["id"].Value);
                int artieId = Convert.ToInt32(CmdValidé.Rows[rowIndex].Cells["code_article"].Value);

                // Exécuter la requête SQL DELETE pour supprimer l'utilisateur de la base de données
                string rqt2 = $"DELETE FROM [ligneCmd] WHERE commande_id = {commandeId} AND article_id = {artieId}";

                // Exécuter la requête de suppression
                SqlCommand command2 = new SqlCommand(rqt2, conn);
                command2.ExecuteNonQuery();
                MessageBox.Show("Commande Supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mettre à jour le DataGridView après la suppression
                listeCommandes();
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

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
