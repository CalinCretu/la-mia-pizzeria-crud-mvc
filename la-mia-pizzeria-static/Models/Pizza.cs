using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizze")]
    [Index(nameof(Id), IsUnique = true)]
    public class Pizzas
    {
        [Key] public int Id { get; set; }
        [StringLength(30, ErrorMessage ="Il nome deve avere massimo 30 caratteri")]
        [Required(ErrorMessage ="Il nome è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        public string Description { get; set; }
        [Url(ErrorMessage = "Il campo immagine deve essere un URL valido")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di zero")]
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