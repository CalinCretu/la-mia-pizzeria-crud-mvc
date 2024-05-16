namespace la_mia_pizzeria_static.Data
{
    public class PizzaManager
    {
        public static int CountDbPizzas()
        {
            using PizzasContext db = new PizzasContext();
            return db.Pizzas.Count();
        }

        public static List<Pizzas> GetAllPizzas()
        {
            using PizzasContext db = new PizzasContext();
            return db.Pizzas.ToList();
        }

        public static Pizzas GetPizza(int id)
        {
            using PizzasContext db = new PizzasContext();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }
        public static void InsertPizza(Pizzas pizza)
        {
            using PizzasContext db = new PizzasContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }
        public static void Seed()
        {
            if (PizzaManager.CountDbPizzas() == 0)
            {
                PizzaManager.InsertPizza(new Pizzas("Quattro Stagioni", "Pomodoro, fiordilatte, funghi, prosciutto cotto, carciofi e olive nere", "~/img/quattro-stagioni.jpg", 7));
                PizzaManager.InsertPizza(new Pizzas("Capricciosa", "Pomodoro, fiordilatte, funghi, prosciutto cotto, carciofi e olive", "~/img/capricciosa.jpg", 7));
                PizzaManager.InsertPizza(new Pizzas("Margherita D.O.P.", "Pomodoro San Marzano D.O.P., mozzarella di bufala campana D.O.P. e basilico fresco", "~/img/margherita-dop.jpg", 8));
                PizzaManager.InsertPizza(new Pizzas("Ortolana", "Pomodoro, fiordilatte, melanzane, zucchine, peperoni e cipolla", "~/img/ortolana.jpg", 6.5));
                PizzaManager.InsertPizza(new Pizzas("Tonno e Cipolla", "Pomodoro, fiordilatte, tonno e cipolla", "~/img/tonno-cipolla.jpg", 6));
                PizzaManager.InsertPizza(new Pizzas("Quattro Formaggi", "Pomodoro, fiordilatte, gorgonzola, provola affumicata, pecorino romano e parmigiano reggiano", "~/img/quattro-formaggi.jpg", 7.5));
                PizzaManager.InsertPizza(new Pizzas("Calzone", "Pomodoro, fiordilatte, prosciutto cotto e funghi, chiusa a calzone", "~/img/calzone.jpg", 7));
                PizzaManager.InsertPizza(new Pizzas("Rustica", "Pomodoro, fiordilatte, salsiccia, patate e rosmarino", "~/img/rustica.jpg", 6.5));
                PizzaManager.InsertPizza(new Pizzas("Tartufata", "Pomodoro, fiordilatte, funghi champignon, prosciutto crudo e crema di tartufo", "~/img/tartufata.jpg", 8));
                PizzaManager.InsertPizza(new Pizzas("Salsiccia e Friarielli", "Pomodoro, fiordilatte, salsiccia e friarielli", "~/img/salsiccia-friarielli.jpg", 7));
            }
        }
    }
}
