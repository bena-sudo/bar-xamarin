using IscaBar.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace IscaBar.Models
{
    [Table("Category")]

    public class Category : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        private int id;

        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        private string name;

        public string Description { get { return description; } set { description = value; OnPropertyChanged(); } }
        private string description;

        [OneToMany]
        public List<Category> Subcategories { get { return subcategories; } set { subcategories = value; OnPropertyChanged(); } }
        private List<Category> subcategories;


        [ForeignKey(typeof(Category))]
        public int Parent_id { get { return parent_id; } set { parent_id = value; OnPropertyChanged(); } }
        private int parent_id;

        [ManyToOne]
        public Category CatFather { get { return catFather; } set { catFather = value; OnPropertyChanged(); } }
        private Category catFather;

        [ManyToMany(typeof(CategoryProduct))]
        public List<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }
        private List<Product> products;

        public Category()
        {
            Subcategories = new List<Category>();
            Products = new List<Product>();
        }
    }
}
