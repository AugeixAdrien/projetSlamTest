using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetSlamTest
{
    public partial class Form1 : Form
    {
        
        public static Personnel utilisateur;
        
        public Form1()
        {
            InitializeComponent();
            //test2
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ouvre la fenetre login.cs et attend la fermeture de celle-ci
            // si le login est bon on active cette fenetre
            // sinon on ferme le programme
            Login login = new Login();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //test

        }
        
        // créé une fonction qui print 
    }
}