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
            cmd.CommandText = "Select id, nom, prenom from participant";

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    participants.Add(new Participant
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2)
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

        public Participant ObtenirParticipant(int id)
        {
            Participant participant = null;

            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select id, nom, prenom from participant where id=@id";
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    participant = new Participant
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2)
                    };
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
            return participant;


        }


        public void AjouterParticipant(string nom, string prenom)
        {
            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Insert into participant (nom, prenom) VALUES (@nom, @prenom)";
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);

            try
            {
                Connexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur :  {e.Message}");
            }
            finally
            {
                Connexion.Close();
            }
        }
    }
        
}
