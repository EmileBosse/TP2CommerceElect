using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Participants
    {
        public List<Participant> ObtenirListeParticipants()
        {
            return new List<Participant> {
                new Participant{ Nom = "Bossé" , Prenom = "Émile", numero = 1 },
                new Participant{ Nom = "Beaulieu" , Prenom = "Anthony", numero = 2 },
                new Participant{ Nom = "Pelletier" , Prenom = "Samuel", numero = 3 },
                new Participant{ Nom = "Arsenault" , Prenom = "Pascale", numero = 4 },
                new Participant{ Nom = "Biras" , Prenom = "Jean", numero = 5 },
                new Participant{ Nom = "Bourgoin" , Prenom = "Shawn", numero = 6 },
                new Participant{ Nom = "Patoine" , Prenom = "Laura", numero = 7 },
                new Participant{ Nom = "April" , Prenom = "Geneviève", numero = 8 },
                new Participant{ Nom = "Garneau" , Prenom = "Patrique", numero = 9 },
                new Participant{ Nom = "Létourneau" , Prenom = "Marcel", numero = 10 },
                new Participant{ Nom = "Lepage" , Prenom = "James", numero = 11 },
                new Participant{ Nom = "Tremblay" , Prenom = "Jeanot", numero = 12 },
                new Participant{ Nom = "Veilleux" , Prenom = "Alexis", numero = 13 }
            };
        }
    }
}
