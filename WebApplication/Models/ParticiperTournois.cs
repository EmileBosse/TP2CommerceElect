using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Database;

namespace WebApplication.Models
{
    public class ParticiperTournois : DataAccess
    {
        private List<ParticiperTournoi> _listeParticiperTournois;

        public List<ParticiperTournoi> ListeParticiperTournois => _listeParticiperTournois ?? (_listeParticiperTournois = ObtenirParticiperTournois());

        private List<ParticiperTournoi> ObtenirParticiperTournois()
        {
            Participants participants = new Participants();
            Tournois tournois = new Tournois();
            List<ParticiperTournoi> participerTournois = new List<ParticiperTournoi>();

            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select idParticipant, idTournoi, numero from participerTournoi";

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    participerTournois.Add(new ParticiperTournoi
                    {
                        Participant = participants.ListeParticipants.FirstOrDefault(p => p.Id == reader.GetInt32(0)),
                        Tournoi = tournois.ListeTournois.FirstOrDefault(t => t.Id == reader.GetInt32(1)),
                        Numero = reader.GetInt32(2)
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
            return participerTournois;


        }

        public List<ParticiperTournoi> ObtenirParticipantsByTournoi(int id)
        {
            List<ParticiperTournoi> participants = new List<ParticiperTournoi>();
            Tournois tournois = new Tournois();
            Tournoi tournoi = tournois.ListeTournois.FirstOrDefault(t => t.Id == id);
            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select p.id, p.nom, p.prenom, pt.numero from Participant p inner join participerTournoi pt on p.id = pt.idParticipant  where pt.idTournoi = @id";
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    participants.Add(new ParticiperTournoi
                    {
                        Participant = new Participant
                        {
                            Id = reader.GetInt32(0),
                            Nom = reader.GetString(1),
                            Prenom = reader.GetString(2)
                        },
                        Tournoi = tournoi,
                        Numero = reader.GetInt32(3)
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

        public void AjouterParticipantTournoi(int idTournoi, int idParticipant, int numero)
        {
            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Insert into participerTournoi (idParticipant, idTournoi, numero) VALUES (@idParticipant, @idTournoi, @numero)";
            cmd.Parameters.AddWithValue("@idParticipant", idParticipant);
            cmd.Parameters.AddWithValue("@idTournoi", idTournoi);
            cmd.Parameters.AddWithValue("@numero", numero);

            try
            {
                Connexion.Open();
                var o = cmd.ExecuteNonQuery();
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
