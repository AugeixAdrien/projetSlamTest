using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace projetSlamTest
{
    public class Db
    {
        // classe de la base de donnée

        private static string connectionString = "Server=127.0.0.1;Database=projet_cs;Uid=root;Password=;SslMode=none";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void AddTechnicien(Technicien technicien)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO techniciens (niveau, formation, competences, matricule) VALUES (@niveau, @formation, @competences, @matricule)";
            cmd.Parameters.AddWithValue("@niveau", technicien.Niveau);
            cmd.Parameters.AddWithValue("@formation", technicien.Formation);
            cmd.Parameters.AddWithValue("@competences", technicien.Competences);
            cmd.Parameters.AddWithValue("@matricule", technicien.Matricule);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void EditTechnicien(Technicien technicien)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE techniciens SET niveau = @niveau, formation = @formation, competences = @competences, matricule = @matricule WHERE id = @id";
            cmd.Parameters.AddWithValue("@niveau", technicien.Niveau);
            cmd.Parameters.AddWithValue("@formation", technicien.Formation);
            cmd.Parameters.AddWithValue("@competences", technicien.Competences);
            cmd.Parameters.AddWithValue("@matricule", technicien.Matricule);
            cmd.Parameters.AddWithValue("@id", technicien.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void DeleteTechnicien(Technicien technicien)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM techniciens WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", technicien.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void PriseEnChargeIncident(Ticket ticket, Technicien technicien)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE tickets SET technicienId = @technicienId WHERE id = @ticketId";
            cmd.Parameters.AddWithValue("@ticketId", ticket.Id);
            cmd.Parameters.AddWithValue("@technicienId", technicien.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void EditUser(Personnel personnel)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE personnels SET dateEmbauche = @dateEmbauche, motDePasse = @motDePasse, type = @type, materielId = @materielId WHERE matricule = @matricule";
            cmd.Parameters.AddWithValue("@matricule", personnel.Matricule);
            cmd.Parameters.AddWithValue("@dateEmbauche", personnel.DateEmbauche);
            cmd.Parameters.AddWithValue("@motDePasse", personnel.MotDePasse);
            cmd.Parameters.AddWithValue("@type", personnel.Type);
            cmd.Parameters.AddWithValue("@materielId", personnel.MaterielId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static int NbIncidents()
        {
            int nb = 0;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM tickets";
            nb = (int)cmd.ExecuteScalar();
            connection.Close();
            return nb;
        }

        public static int ResolvedIncidents()
        {
            int nb = 0;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM tickets WHERE etatDemande = 'résolu'";
            nb = (int)cmd.ExecuteScalar();
            connection.Close();
            return nb;
        }

        public static int SolvedIncidentsByTechnician(Technicien technicien)
        {
            int nb = 0;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM tickets WHERE etatDemande = 'résolu' AND technicienId = @technicienId";
            cmd.Parameters.AddWithValue("@technicienId", technicien.Id);
            nb = (int)cmd.ExecuteScalar();
            connection.Close();
            return nb;
        }
        
        public static bool Authentification(string id, string mdp)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM personnels WHERE matricule = @matricule AND motDePasse = @motDePasse";
            cmd.Parameters.AddWithValue("@matricule", id);
            cmd.Parameters.AddWithValue("@motDePasse", mdp);
            var reader = cmd.ExecuteReader();
            var result = reader.HasRows;
            connection.Close();
            return result;
        }
        
        public static void AddMateriel(Materiel materiel)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO materiels (processeur, memoire, disque, logiciels, dateAchat, garantie, " +
                              "fournisseur) VALUES (@processeur, @memoire, @disque, @logiciels, @dateAchat, @garantie, " +
                              "@fournisseur)";
            cmd.Parameters.AddWithValue("@processeur", materiel.Processeur);
            cmd.Parameters.AddWithValue("@memoire", materiel.Memoire);
            cmd.Parameters.AddWithValue("@disque", materiel.Disque);
            var logicielsString = string.Join(",", materiel.Logiciels);
            cmd.Parameters.AddWithValue("@logiciels", logicielsString);
            cmd.Parameters.AddWithValue("@dateAchat", materiel.DateAchat);
            cmd.Parameters.AddWithValue("@garantie", materiel.Garantie);
            cmd.Parameters.AddWithValue("@fournisseur", materiel.Fournisseur);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        

        public static Materiel ConsultMateriel(int identifiant) {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM materiels WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", identifiant);
            var reader = cmd.ExecuteReader();
            
            var logicielListe = reader.GetString(4).Split(new char[] { ',' }, StringSplitOptions
                .RemoveEmptyEntries).ToList();
            
            reader.Read();
            var materiel = new Materiel(reader.GetInt32(0), reader.GetString(1), 
                reader.GetString(2), reader.GetString(3), logicielListe, reader.GetDateTime(5), 
                reader.GetString(6), reader.GetString(7));
            connection.Close();
            return materiel;
        }
        
        public static void DeleteMateriel(Materiel materiel)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM materiels WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", materiel.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        public void DeclareIncident(Ticket ticket)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO tickets (objet, niveauUrgence, dateCreation, etatDemande, " +
                              "technicienId, materielId) VALUES (@objet, @niveauUrgence, @dateCreation," +
                              " @etatDemande, @technicienId, @materielId, @personnelId)";
            cmd.Parameters.AddWithValue("@objet", ticket.Objet);
            cmd.Parameters.AddWithValue("@niveauUrgence", ticket.NiveauUrgence);
            cmd.Parameters.AddWithValue("@dateCreation", ticket.DateCreation);
            cmd.Parameters.AddWithValue("@etatDemande", ticket.Etat);
            cmd.Parameters.AddWithValue("@technicienId", ticket.IdTechnicien);
            cmd.Parameters.AddWithValue("@materielId", ticket.IdMateriel);
            cmd.Parameters.AddWithValue("@personnelId", ticket.Matricule);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        
        public static Ticket ConsultIncident(int identifiant)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM tickets WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", identifiant);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var ticket = new Ticket(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), 
                reader.GetDateTime(3), reader.GetString(4), reader.GetInt32(5), 
                reader.GetInt32(6), reader.GetString(7));
            connection.Close();
            return ticket;
        }
        
        // besoin de passer le ticket en résolu avant de le donner à la methode
        public static void ResoudreIncident(Ticket ticket, Technicien technicien)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE tickets SET etatDemande = @etatDemande WHERE id = @id";
            cmd.Parameters.AddWithValue("@etatDemande", ticket.Etat);
            cmd.Parameters.AddWithValue("@id", ticket.Id);
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO phaseTechniciens (dateDebut, dateFin, travailRealise) " +
                              "VALUES (@dateDebut, @dateFin, @travailRealise)";
            cmd.Parameters.AddWithValue("@dateDebut", ticket.DateCreation);
            cmd.Parameters.AddWithValue("@dateFin", DateTime.Now);
            cmd.Parameters.AddWithValue("@travailRealise", ticket.Etat);
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO intervients (technicienId, ticketId) VALUES (@technicienId, @ticketId)";
            cmd.Parameters.AddWithValue("@technicienId", technicien.Id);
            cmd.Parameters.AddWithValue("@ticketId", ticket.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        public static void AddUser(Personnel personnel)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO personnels (matricule, dateEmbauche, motDePasse, type, materielId) " +
                              "VALUES (@matricule, @dateEmbauche, @motDePasse, @type, @materielId)";
            cmd.Parameters.AddWithValue("@matricule", personnel.Matricule);
            cmd.Parameters.AddWithValue("@dateEmbauche", personnel.DateEmbauche);
            cmd.Parameters.AddWithValue("@motDePasse", personnel.MotDePasse);
            cmd.Parameters.AddWithValue("@type", personnel.Type);
            cmd.Parameters.AddWithValue("@materielId", personnel.MaterielId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        public static int GetStatsUtilisateur(Personnel personnel)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM tickets WHERE materielId = @materielId";
            cmd.Parameters.AddWithValue("@materielId", personnel.MaterielId);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var nbIncidents = reader.GetInt32(0);
            connection.Close();
            return nbIncidents;
        }
        
        public static Personnel GetUser(string matricule)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM personnels WHERE matricule = @matricule";
            cmd.Parameters.AddWithValue("@matricule", matricule);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var personnel = new Personnel(reader.GetString(0), reader.GetDateTime(1), reader.GetString(2), 
                reader.GetInt32(3), reader.GetInt32(4));
            connection.Close();
            return personnel;
        }
    }
}