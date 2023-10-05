using MySql.Data.MySqlClient;

namespace projetSlamTest
{
    public static class Db
    {
        // classe de la base de donnée

        private string connectionString;
        private MySqlConnection connection;

        public Db(string connectionString)
        {
            this.connectionString = connectionString;
        }

    }
}