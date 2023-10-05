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
            // récupère les données du formulaire
            string id = idTB.Text;
            string mdp = pwTB.Text;
            // ferme definitivement le formulaire et ouvre form1
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            
            
        }
    }
}