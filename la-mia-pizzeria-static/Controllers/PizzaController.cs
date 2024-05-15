using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizzas> miepizze = new List<Pizzas>()
            {
                new Pizzas("Margherita", "Buona", "", 20.0)
            };
            return View(miepizze);
        }

        public IActionResult VediPizza(int id)
        {
            return View();
        }


    }
}