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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizzas data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }
            using (PizzasContext context = new PizzasContext())
            {
                var pizzasToCreate = new Pizzas(data.Name, data.Description, data.Image, data.Price);
                context.Pizzas.Add(pizzasToCreate);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}