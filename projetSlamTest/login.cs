using System;
using System.Windows.Forms;

namespace projetSlamTest
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            var login = loginTB.Text;
            var password = pwTB.Text;
            if (Db.Authentification(login, password))
            {
                DialogResult = DialogResult.OK;
                Form1.Utilisateur = Db.GetUser(login);
                Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // je sais pas ce que c'est mais j'arrive pas à le supprimer
            // il a l'air de se sentir bien ici donc je vais pas le déranger
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // pareil, trop choupi la fonction
        }
    }
}