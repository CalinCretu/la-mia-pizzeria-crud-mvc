using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using Pizzas = la_mia_pizzeria_static.Models.Pizzas;

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
            PizzasFormModel model = new PizzasFormModel();
            model.Pizzas = new Pizzas();
            model.Categories = PizzaManager.GetAllCategories();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzasFormModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            PizzaManager.InsertPizza(data.Pizzas);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var pizzaToEdit = PizzaManager.VediPizza(id);

            if (pizzaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                PizzasFormModel model = new PizzasFormModel();
                model.Pizzas = pizzaToEdit;
                model.Categories = PizzaManager.GetAllCategories();
                return View("UpdatePizza", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzasFormModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdatePizza", data);
            }

            if (PizzaManager.UpdatePizza(id, data.Pizzas.Name, data.Pizzas.Description, data.Pizzas.Price, data.Pizzas.CategoryId))
                return RedirectToAction("Index");
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PizzaManager.DeletePizza(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}