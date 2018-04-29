using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Database;

namespace WebApplication.Models
{
    public class Participants : DataAccess
    {

        private List<Participant> _listeParticipants;

        public List<Participant> ListeParticipants => _listeParticipants ?? (_listeParticipants = ObtenirListeParticipants());

        private List<Participant> ObtenirListeParticipants()
        {
            List<Participant> participants = new List<Participant>();

            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select id, numero, nom, prenom from participant";

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    participants.Add(new Participant
                    {
                        Id = reader.GetInt32(0),
                        Numero = reader.GetInt32(1),
                        Nom = reader.GetString(2),
                        Prenom = reader.GetString(3)
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
            return participants;


        }

            /*public List<Participant> ObtenirListeParticipants()
            {
                return new List<Participant> {
                    new Participant{ Nom = "Bossé" , Prenom = "Émile", Numero = 1 },
                    new Participant{ Nom = "Beaulieu" , Prenom = "Anthony", Numero = 2 },
                    new Participant{ Nom = "Pelletier" , Prenom = "Samuel", Numero = 3 },
                    new Participant{ Nom = "Arsenault" , Prenom = "Pascale", Numero = 4 },
                    new Participant{ Nom = "Biras" , Prenom = "Jean", Numero = 5 },
                    new Participant{ Nom = "Bourgoin" , Prenom = "Shawn", Numero = 6 },
                    new Participant{ Nom = "Patoine" , Prenom = "Laura", Numero = 7 },
                    new Participant{ Nom = "April" , Prenom = "Geneviève", Numero = 8 },
                    new Participant{ Nom = "Garneau" , Prenom = "Patrique", Numero = 9 },
                    new Participant{ Nom = "Létourneau" , Prenom = "Marcel", Numero = 10 },
                    new Participant{ Nom = "Lepage" , Prenom = "James", Numero = 11 },
                    new Participant{ Nom = "Tremblay" , Prenom = "Jeanot", Numero = 12 },
                    new Participant{ Nom = "Veilleux" , Prenom = "Alexis", Numero = 13 }
                };
            }*/
        }
}
