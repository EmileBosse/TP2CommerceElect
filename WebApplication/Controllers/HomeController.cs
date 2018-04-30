using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Participants participants = new Participants();
            ViewData["Participants"] = participants.ListeParticipants;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult VoirParticipant(string id)
        {
            int numero = Convert.ToInt32(id);
            Participants participants = new Participants();
            Participant participant = participants.ListeParticipants.FirstOrDefault(p => p.Id == numero);
            if(participant != null)
            {
                ViewData["Nom"] = participant.Nom;
                ViewData["Prenom"] = participant.Prenom;
                //ViewData["numero"] = participant.Numero;
                return View();
            }
            return View();
        }

        public IActionResult AddParticipant()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
