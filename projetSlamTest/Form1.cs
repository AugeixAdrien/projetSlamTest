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
        
        public static Personnel Utilisateur;

        private List<Ticket> _userTickets;
        private List<Ticket> _allTickets;

        private void RefreshUserTickets()
        {
            var bindingSource = new BindingSource();
            // Affiche les tickets ouverts par l'utilisateur connecté 
            _userTickets = new List<Ticket>();
            _userTickets = Db.GetTicketsByUser(Utilisateur);
            bindingSource.DataSource = _userTickets;
            dataGridView2.DataSource = bindingSource;
        }

        private void RefreshAllTickets()
        {
            var bindingSource = new BindingSource();
            _allTickets = new List<Ticket>();
            _allTickets = Db.GetAllTickets();
            bindingSource.DataSource = _allTickets;
            dataGridView3.DataSource = bindingSource;
        }

        private void RefreshMateriels()
        {
            var bindingSourceMateriel = new BindingSource();
            var materiels = Db.GetAllMateriel();
            bindingSourceMateriel.DataSource = materiels;
            dataGridMateriel.DataSource = bindingSourceMateriel;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ouvre la fenetre login.cs et attend la fermeture de celle-ci
            // si le login est bon on active cette fenetre
            // sinon on ferme le programme
            var login = new Login();
            login.ShowDialog();
            comboBox1.SelectedIndex = 0;
            if (login.DialogResult == DialogResult.OK)
            {

                this.Show();

                numericUpDown1.Value = Utilisateur.MaterielId;

                if(Utilisateur.Type >= 0)
                {
                    // Affiche les tickets ouverts par l'utilisateur connecté 
                    RefreshUserTickets();
                }
                if(Utilisateur.Type >= 1)
                {
                    // Affiche tous les tickets
                    RefreshAllTickets();
                    
                    // affiche tout le matériel dans le datagridview dataGridMateriel
                    RefreshMateriels();
                    

                }
                if(Utilisateur.Type >= 2)
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
            var currentDateTime = DateTime.Now;
            var ticket = new Ticket(textBox1.Text, Convert.ToInt16(comboBox1.Text), currentDateTime, "En cours", Utilisateur.MaterielId, Utilisateur.Matricule);
            Db.DeclareIncident(ticket);
            //clear les champs
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            RefreshUserTickets();
            if(Utilisateur.Type >= 1)
            {
                RefreshAllTickets();
            }
        }
    }
}