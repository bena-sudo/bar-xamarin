using iscaBar.Models;
using IscaBar.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    [Table("Ingredient")]
    public class Ingredient:ModelBase
    {
        private int id;
        private string name;
        private string observations;
        private bool gluten;
        private List<Product> products;

        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        public string Observations { get { return observations; } set { observations = value; OnPropertyChanged(); } }
        public bool Guten { get { return gluten; } set { gluten = value; OnPropertyChanged(); } }
        [ManyToMany(typeof(ProdIngre))]
        public List<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }
    }
}
