using iscaBar.Models;
using IscaBar.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    [Table("Category")]

    public class Categoria:ModelBase
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        private string description;
        public string Description { get { return description; } set { description = value; OnPropertyChanged(); } }
        private List<Categoria> subcategories;
        [OneToMany]
        public List<Categoria> Subcategories { get { return subcategories; } set { subcategories = value; OnPropertyChanged(); } }
        private Categoria catFather;
        private int catFatherId;
        [ForeignKey(typeof(int))]
        public int CatFatherId { get { return catFatherId; } set { catFatherId = value; OnPropertyChanged(); } }
        [ManyToOne]
        public Categoria CatFather { get { return catFather; } set { catFather = value; OnPropertyChanged(); } }

        private List<Product> products;
        [ManyToMany(typeof(CategoryProduct))]
        public List<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }
        public Categoria()
        {
            Subcategories = new List<Categoria>();
        }

    }
}
