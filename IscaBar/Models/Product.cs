using IscaBar.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace IscaBar.Models
{
    [Table("product")]
    public class Product:ModelBase
    {
        private int id;
        private string name;
        private string description;
        private decimal price;
        private List<Ingredient> ingredients;
        private List<Order> orders;

        [PrimaryKey,AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        public decimal Price { get { return price; } set { price = value; OnPropertyChanged(); } }
        [ManyToMany(typeof(ProdIngre))]
        public List<Ingredient> Ingredients { get { return ingredients; } set { ingredients = value; OnPropertyChanged(); } }
        
        private List<Category> categories;
        [ManyToMany(typeof(CategoryProduct))]
        public List<Category> Categories { get { return categories; } set { categories = value; OnPropertyChanged(); } }
        [OneToMany]
        public List<Order> Orders { get { return orders; } set { orders = value; OnPropertyChanged(); } }
    }
}
