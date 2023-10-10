using MySql.Data.MySqlClient;

namespace projetSlamTest
{
    public class Db
    {
        // classe de la base de donnée

        private static string connectionString = "Server=127.0.0.1;Database=projet_cs;Uid=root;Password=;SslMode=none";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void addTechnicien(Technicien technicien)
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

        public static void editTechnicien(Technicien technicien)
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
        public static void deleteTechnicien(Technicien technicien)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM techniciens WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", technicien.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void priseEnChargeIncident(Ticket ticket, Technicien technicien)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE tickets SET technicienId = @technicienId WHERE id = @ticketId";
            cmd.Parameters.AddWithValue("@ticketId", ticket.Id);
            cmd.Parameters.AddWithValue("@technicienId", technicien.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void editUser(Personnel personnel)
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

        public static int nbIncidents()
        {
            int nb = 0;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM tickets";
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

    }
}