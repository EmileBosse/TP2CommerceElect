using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class ParticiperTournoiController : Controller
    {
        // GET: ParticiperTournoi
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParticiperTournoi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticiperTournoi/Create
        public ActionResult Create(string id)
        {
            int idTournoi = Convert.ToInt32(id);
            Tournois tournois = new Tournois();
            ParticiperTournois participerTournois = new ParticiperTournois();
            Participants participants = new Participants();
            ViewData["Tournoi"] = tournois.ListeTournois.FirstOrDefault(t => t.Id == idTournoi);
            ViewBag.Participants = participants.ListeParticipants.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.Prenom} {p.Nom}" });
            return View();
        }

        // POST: ParticiperTournoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ParticiperTournois participerTournois = new ParticiperTournois();
                participerTournois.AjouterParticipantTournoi(Convert.ToInt32(collection["Tournoi"]), Convert.ToInt32(collection["Participant"]), Convert.ToInt32(collection["Numero"]));

                return RedirectToAction("Details", "Tournoi", new { id = Convert.ToInt32(collection["Tournoi"]) });
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticiperTournoi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticiperTournoi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticiperTournoi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticiperTournoi/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}