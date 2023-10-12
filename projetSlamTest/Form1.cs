using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projetSlamTest
{
    /// <summary>
    /// chargement du formulaire principal
    /// </summary>
    public partial class Form1 : Form
    {
        public static Personnel Utilisateur;

        private List<Ticket> _userTickets;
        private List<Ticket> _allTickets;

        private Ticket _selectedTicket;
        
        /// <summary>
        /// rafrachit les tickets de l'utilisateur et les affiche dans le datagridview correspondant
        /// </summary>
        private void RefreshUserTickets()
        {
            var bindingSource = new BindingSource();
            // Affiche les tickets ouverts par l'utilisateur connecté 
            _userTickets = new List<Ticket>();
            _userTickets = Db.GetTicketsByUser(Utilisateur);
            bindingSource.DataSource = _userTickets;
            dataGridView2.DataSource = bindingSource;
        }

        /// <summary>
        /// raffraichit tous les tickets et les affiche dans le datagridview correspondant pour les techniciens et les responsables
        /// </summary>
        private void RefreshAllTickets()
        {
            var bindingSource = new BindingSource();
            _allTickets = new List<Ticket>();
            _allTickets = Db.GetAllTickets();
            bindingSource.DataSource = _allTickets;
            dataGridView3.DataSource = bindingSource;
        }

        /// <summary>
        /// affiche tout le matériel dans le datagridview pour les techniciens et les responsables
        /// </summary>
        private void RefreshMateriels()
        {
            var bindingSourceMateriel = new BindingSource();
            var materiels = Db.GetAllMateriel();
            bindingSourceMateriel.DataSource = materiels;
            dataGridMateriel.DataSource = bindingSourceMateriel;
        }

        /// <summary>
        /// initialise le formulaire principal
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ouvre la fenetre login.cs et attend la fermeture de celle-ci, si le login est bon on active cette fenetre, sinon on ferme le programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (Utilisateur.Type >= 0)
                {
                    numericUpDown1.Value = Utilisateur.MaterielId;
                }

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

        /// <summary>
        /// quand on clique sur le bouton "déclarer un incident" on ajoute un ticket dans la base de données avec les informations rentrées dans les champs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count <= 0) return; // si y'a rien on skip
            
            var selectedRow = dataGridView3.SelectedRows[0]; // Prend la première ligne sélectionnée
            // Vous pouvez accéder aux cellules de la ligne sélectionnée comme ceci :
            var cellValue = (int)selectedRow.Cells["id"].Value;
            _selectedTicket = Db.GetTicketById(cellValue);
            if (_selectedTicket == null) return;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Db.CloseTicket(_selectedTicket.Id);
            RefreshAllTickets();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var logiciels = new List<string>();
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
            var materiel = new Materiel(textBox2.Text, textBox3.Text, textBox4.Text, logiciels, dateTimePicker1.Value, textBox5.Text, textBox6.Text);
            Db.AddMateriel(materiel);
            RefreshMateriels();
            // clear les champs
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}