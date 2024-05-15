using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizze")]
    [Index(nameof(Id), IsUnique = true)]
    public class Pizzas
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public Pizzas() { }

        public Pizzas(string name, string description, string immage, double price)
        {
            Name = name;
            Description = description;
            Image = immage;
            Price = price;
        }
    }
}