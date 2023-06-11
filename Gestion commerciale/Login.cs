using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_commerciale
{
    public partial class Login : Form
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.GestionCommercialeConnectionString);
        SqlDataAdapter adapter;
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        public void RemplirChampEmail(string emailAuto)
        {
            email.Text = emailAuto;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM [User] WHERE email='" + email.Text + "'and pwd ='" + motPasse.Text + "'",conn);
            string emailUs = email.Text;
            adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int existe = ds.Tables[0].Rows.Count;
            if(existe == 1)
            {
                int roleId = Convert.ToInt32(ds.Tables[0].Rows[0]["role_id"]);
                if (roleId == 1)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide(); // Masquer le formulaire de connexion actuel
                }
                else
                {

                    Client client = new Client(emailUs);
               
                    client.Show();
                    this.Hide(); // Masquer le formulaire de connexion actuel
                }
             
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        private void Inscrire_Click(object sender, EventArgs e)
        {
            Inscription inscription = new Inscription();
            inscription.Show();
            this.Hide(); // Masquer le formulaire de connexion actuel
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Affichez le mot de passe en clair
                motPasse.UseSystemPasswordChar = false;
            }
            else
            {
                // Affichez le mot de passe caché
                motPasse.UseSystemPasswordChar=true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
