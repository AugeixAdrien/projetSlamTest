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
        
        // fais une fonction d'authentification qui prend en paramètre un id et un mdp
        // les id et mdp sont stockés dans la bdd dans la table personnels
        // si l'id et le mdp correspondent, la fonction retourne true
        // l'id correspond à la colonne matricule
        // le mdp correspond à la colonne motDePasse

    }
}