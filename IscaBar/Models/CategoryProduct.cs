using iscaBar.Models;
using IscaBar.Model;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    public class CategoryProduct:ModelBase
    {
        private int productId;
        private int categoryId;
        [ForeignKey(typeof(Product))]
        public int ProductId { get { return productId; } set { productId = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Categoria))]
        public int CategoryId { get { return categoryId; } set { categoryId = value; OnPropertyChanged(); } }

    }
}
