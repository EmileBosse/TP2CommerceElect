using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: Tournoi
        public ActionResult Index()
        {
            Participants participants = new Participants();
            ViewData["Participants"] = participants.ListeParticipants;
            return View();
        }

        // GET: Tournoi/Details/5
        public ActionResult Details(int id)
        {
            Participants participants = new Participants();
            Participant t = participants.ObtenirParticipant(id);
            return View();
        }

        // GET: Tournoi/Create
        public ActionResult Create()
        {

            //TypeTournois typeTournois = new TypeTournois();
            //IEnumerable<SelectListItem> listeTypeTournois = typeTournois.ListeTypeTournois.Select(tt => new SelectListItem { Text = tt.Nom, Value = tt.Id.ToString() }).ToList();
            //ViewBag.TypesTournoi = listeTypeTournois;

            return View();
        }

        // POST: Tournoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //Tournois tournois = new Tournois();
                //tournois.InsererTournoi(collection["Nom"], Convert.ToInt32(collection["TypeTournoi"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tournoi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tournoi/Edit/5
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

        // GET: Tournoi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tournoi/Delete/5
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