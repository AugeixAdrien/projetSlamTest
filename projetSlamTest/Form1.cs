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

        private List<Ticket> userTickets;
        private List<Ticket> allTickets;

        private void refreshUserTickets()
        {
            var bindingSource = new BindingSource();
            // Affiche les tickets ouverts par l'utilisateur connecté 
            userTickets = new List<Ticket>();
            userTickets = Db.GetTicketsByUser(utilisateur);
            bindingSource.DataSource = userTickets;
            dataGridView2.DataSource = bindingSource;
        }

        private void refreshAllTickets()
        {
            var bindingSource = new BindingSource();
            allTickets = new List<Ticket>();
            allTickets = Db.GetAllTickets();
            bindingSource.DataSource = allTickets;
            dataGridView3.DataSource = bindingSource;
        }

        private void refreshMateriels()
        {
            var bindingSourceMateriel = new BindingSource();
            var materiels = new List<Materiel>();
            materiels = Db.GetAllMateriel();
            bindingSourceMateriel.DataSource = materiels;
            dataGridMateriel.DataSource = bindingSourceMateriel;
        }

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

                numericUpDown1.Value = utilisateur.MaterielId;

                if(utilisateur.Type >= 0)
                {
                    refreshUserTickets();
                }
                if(utilisateur.Type >= 1)
                {
                    // Affiche tous les tickets
                    refreshAllTickets();
                    
                    // affiche tout le matériel dans le datagridview dataGridMateriel
                    refreshMateriels();
                    

                }
                if(utilisateur.Type >= 2)
                {

                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            Ticket ticket = new Ticket(textBox1.Text, Convert.ToInt16(comboBox1.Text), currentDateTime, "En cours", utilisateur.MaterielId, utilisateur.Matricule);
            Db.DeclareIncident(ticket);
            refreshUserTickets();
            if(utilisateur.Type >= 1)
            {
                refreshAllTickets();
            }
        }

        // créé une fonction qui print 
    }
}