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
                Form1.utilisateur = Db.GetUser(login);
                Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect");
            }
            
        }
        
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}