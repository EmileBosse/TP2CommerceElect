using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ParticiperTournoi
    {
        public Tournoi Tournoi { get; set; }

        public Participant Participant { get; set; }

        public int Numero { get; set; }
    }
}
