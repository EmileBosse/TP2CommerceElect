using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Database;

namespace WebApplication.Models
{
    public class TypeTournois : DataAccess
    {
        private List<TypeTournoi> _listeTypeTournois;

        public List<TypeTournoi> ListeTypeTournois => _listeTypeTournois ?? (_listeTypeTournois = ObtenirListeTypeTournois());

        private List<TypeTournoi> ObtenirListeTypeTournois()
        {
            List<TypeTournoi> typeTournois = new List<TypeTournoi>();          

            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select id, nom from typetournoi";

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    typeTournois.Add(new TypeTournoi
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1)                      
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur :  {e.Message}");
            }
            finally
            {
                Connexion.Close();
            }
            return typeTournois;


        }
    }
}
