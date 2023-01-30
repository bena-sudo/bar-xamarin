using iscaBar.Models;
using IscaBar.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    [Table("orderLine")]
    public class OrderLine:ModelBase
    {
        private int id;
        private Product product;
        private int quantity;
        private decimal price;
        private string observations;

        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        [ManyToOne]
        public Product Product { get { return product; } set { product = value; OnPropertyChanged(); } }
        public int Quantity { get { return quantity; } set { quantity = value; OnPropertyChanged(); } }
        public decimal Price { get { return price; } set { price = value; OnPropertyChanged(); } }
        public string Observations { get { return observations; } set { observations = value; OnPropertyChanged(); } }
    }
}
