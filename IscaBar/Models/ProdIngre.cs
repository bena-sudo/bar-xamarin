using iscaBar.Models;
using IscaBar.Model;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    public class ProdIngre:ModelBase
    {
        private int productId;
        private int ingredientId;
        [ForeignKey(typeof(Product))]
        public int ProductId { get { return productId; } set { productId = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Ingredient))]
        public int IngredeitnId { get { return ingredientId; } set { ingredientId = value; OnPropertyChanged(); } }
    }
}
