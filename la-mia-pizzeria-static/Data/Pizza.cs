using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace la_mia_pizzeria_static.Data
{
    [Table("pizze")]
    [Index(nameof(Id), IsUnique = true)]
    public class Pizzas
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }

        public Pizzas(string name, string description, string immage, double price)
        {
            Name = name;
            Description = description;
            Image = immage;
            Price = price;
        }
        public Pizzas(int id, string name, string description, string image, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }

        public Pizzas() { }
    }
}