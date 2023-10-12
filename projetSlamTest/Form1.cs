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

        private Ticket selectedTicket;

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
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (utilisateur.Type >= 0)
                {
                    // Affiche les tickets ouverts par l'utilisateur connecté 
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

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0]; // Prend la première ligne sélectionnée
                                                                             // Vous pouvez accéder aux cellules de la ligne sélectionnée comme ceci :
                int cellValue = (int)selectedRow.Cells["id"].Value;
                selectedTicket = Db.GetTicketById(cellValue);
                if(selectedTicket != null)
                {
                    button2.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Db.CloseTicket(selectedTicket.Id);
            refreshAllTickets();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<string> logiciels = new List<string>();
            if (checkBox1.Checked)
            {
                logiciels.Add("Word");
            }
            if (checkBox2.Checked)
            {
                logiciels.Add("Excel");
            }
            if (checkBox3.Checked)
            {
                logiciels.Add("Ratio");
            }
            if (checkBox4.Checked)
            {
                logiciels.Add("Photoshop");
            }
            Materiel materiel = new Materiel(textBox2.Text, textBox3.Text, textBox4.Text, logiciels, dateTimePicker1.Value, textBox5.Text, textBox6.Text);
            Db.AddMateriel(materiel);
            refreshMateriels();
        }
    }
}