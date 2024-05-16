using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data
{
    public class PizzasContext : DbContext
    {
        public DbSet<Pizzas> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=InitialPizzasDB;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}