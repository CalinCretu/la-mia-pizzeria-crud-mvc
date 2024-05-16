using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Pizzas = la_mia_pizzeria_static.Data.Pizzas;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            //PizzaManager.ResetTable();
            return View(PizzaManager.GetAllPizzas());
        }

        public IActionResult VediPizza(int id)
        {
            var pizza = PizzaManager.VediPizza(id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return View("errore");
            }
        }
    }
}