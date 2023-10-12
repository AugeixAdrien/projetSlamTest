using System;

namespace projetSlamTest
{
    /// <summary>
    /// Cette classe représente un technicien dans votre système.
    /// </summary>
    public class Technicien : Personnel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe Technicien.
        /// </summary>
        /// <param name="matricule">Le matricule du technicien.</param>
        /// <param name="dateEmbauche">La date d'embauche du technicien.</param>
        /// <param name="motDePasse">Le mot de passe du technicien.</param>
        /// <param name="type">Le type de technicien.</param>
        /// <param name="materielId">L'identifiant du matériel associé au technicien.</param>
        /// <param name="id">L'identifiant du technicien.</param>
        /// <param name="niveau">Le niveau du technicien.</param>
        /// <param name="formation">La formation du technicien.</param>
        /// <param name="competences">Les compétences du technicien.</param>
        public Technicien(string matricule, DateTime dateEmbauche, string motDePasse, int type, int materielId, int id,
            string niveau, string formation, string competences) : base(matricule, dateEmbauche, motDePasse, type, materielId)
        {
            Id = id;
            Niveau = niveau;
            Formation = formation;
            Competences = competences;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du technicien.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le niveau du technicien.
        /// </summary>
        public string Niveau { get; set; }

        /// <summary>
        /// Obtient ou définit la formation du technicien.
        /// </summary>
        public string Formation { get; set; }

        /// <summary>
        /// Obtient ou définit les compétences du technicien.
        /// </summary>
        public string Competences { get; set; }
    }
}
