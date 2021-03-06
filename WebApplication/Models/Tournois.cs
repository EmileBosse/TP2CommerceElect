﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Database;

namespace WebApplication.Models
{
    public class Tournois : DataAccess
    { 
        private List<Tournoi> _listeTournois;

        public List<Tournoi> ListeTournois => _listeTournois ?? (_listeTournois = ObtenirListeTournois());

        public Tournoi ObtenirTournoi(int id)
        {
            Tournoi tournoi = null;
            TypeTournois typeTournois = new TypeTournois();
            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select * from tournoi where id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    tournoi = new Tournoi{
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        TypeTournoi = typeTournois.ListeTypeTournois.FirstOrDefault(t => t.Id == reader.GetInt32(2))
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
            return tournoi;
        }

        private List<Tournoi> ObtenirListeTournois()
        {
            List<Tournoi> tournois = new List<Tournoi>();
            TypeTournois typeTournois = new TypeTournois();

            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Select id, nom, idType from tournoi";
            

            try
            {
                Connexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tournois.Add(new Tournoi
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        TypeTournoi = typeTournois.ListeTypeTournois.FirstOrDefault(t => t.Id == reader.GetInt32(2))
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
            return tournois;


        }

        public void InsererTournoi(string nom, int idTypeTournoi)
        {
            MySqlCommand cmd = Connexion.CreateCommand();
            cmd.CommandText = "Insert into tournoi (nom, idType) VALUES (@nom, @idType)";
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@idType", idTypeTournoi);

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
