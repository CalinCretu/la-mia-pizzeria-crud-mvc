using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using PizzasContext db = new PizzasContext();

            if (!db.Pizzas.Any())
            {
                List<Pizzas> DbPizza = new List<Pizzas>
                {
                    new Pizzas("Quattro Stagioni", "Pomodoro, fiordilatte, funghi, prosciutto cotto, carciofi e olive nere", "~/img/quattro-stagioni.jpg", 7),
                    new Pizzas("Capricciosa", "Pomodoro, fiordilatte, funghi, prosciutto cotto, carciofi e olive", "~/img/capricciosa.jpg", 7),
                    new Pizzas("Margherita D.O.P.", "Pomodoro San Marzano D.O.P., mozzarella di bufala campana D.O.P. e basilico fresco", "~/img/margherita-dop.jpg", 8),
                    new Pizzas("Ortolana", "Pomodoro, fiordilatte, melanzane, zucchine, peperoni e cipolla", "~/img/ortolana.jpg", 6.5),
                    new Pizzas("Tonno e Cipolla", "Pomodoro, fiordilatte, tonno e cipolla", "~/img/tonno-cipolla.jpg", 6),
                    new Pizzas("Quattro Formaggi", "Pomodoro, fiordilatte, gorgonzola, provola affumicata, pecorino romano e parmigiano reggiano", "~/img/quattro-formaggi.jpg", 7.5),
                    new Pizzas("Calzone", "Pomodoro, fiordilatte, prosciutto cotto e funghi, chiusa a calzone", "~/img/calzone.jpg", 7),
                    new Pizzas("Rustica", "Pomodoro, fiordilatte, salsiccia, patate e rosmarino", "~/img/rustica.jpg", 6.5),
                    new Pizzas("Tartufata", "Pomodoro, fiordilatte, funghi champignon, prosciutto crudo e crema di tartufo", "~/img/tartufata.jpg", 8),
                    new Pizzas("Salsiccia e Friarielli", "Pomodoro, fiordilatte, salsiccia e friarielli", "~/img/salsiccia-friarielli.jpg", 7)
                };
                foreach (Pizzas pizza in DbPizza)
                {
                    db.Add(pizza);
                }
                db.SaveChanges();
            }
            List<Pizzas> pizzas = db.Pizzas.ToList();
            return View("Index", pizzas);
        }

        public IActionResult VediPizza(int id)
        {
            return View();
        }

    }
}