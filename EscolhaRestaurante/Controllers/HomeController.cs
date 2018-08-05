using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscolhaRestauranteCore.Controller;
using EscolhaRestauranteCore.Model;

namespace EscolhaRestaurante.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Peoples = new SelectList(new PeopleController().GetPeoples(), "Id", "Name");
            ViewBag.Restaurants = new SelectList(new RestaurantController().GetRestaraunts(), "Id", "Name");
            ViewBag.ReturnMessage = "";
            return View();
        }

        public ActionResult SaveVote(string peoples, string restaurants)
        {
            if (!new VoteController().AddVote(peoples, restaurants, DateTime.Now))
                ViewBag.ReturnMessage = "Você ja votou nes restaurante :(";
            else
                ViewBag.ReturnMessage = "Obrigado por votar :)";

            ViewBag.Peoples = new SelectList(new PeopleController().GetPeoples(), "Id", "Name");
            ViewBag.Restaurants = new SelectList(new RestaurantController().GetRestaraunts(), "Id", "Name");
            return View("Index");
        }

        public ActionResult Escolha()
        {
            if (new VoteController().GetVotes().Count() > 0)
            {
                ViewBag.Message = String.Format("Hoje vamos almoçar no(a): {0}", new RestaurantController().GetRestaurantOfTheDay(DateTime.Now).Name);
            }
            else
            {
                ViewBag.Message = "Precisamos de votos para decidir o local ;)";
            }

            return View();
        }
    }
}