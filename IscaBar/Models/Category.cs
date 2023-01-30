using IscaBar.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace IscaBar.Models
{
    [Table("Category")]
    internal class Category : ModelBase
    {
        private int _Id;
        [PrimaryKey, AutoIncrement]
        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged(); } }

        private int _CategoryParentId;
        [ForeignKeyAttribute(typeof(int))]
        private int CategoryParentId { get { return _CategoryParentId; } set { _CategoryParentId = value; OnPropertyChanged(); } }

        private Category _CategoryParent;
        [ManyToOne]
        public Category CategoryParent { get { return _CategoryParent; } set { _CategoryParent = value; OnPropertyChanged(); } }
        private List<Category> _Categories;
        [OneToMany]
        public List<Category> Categories { get { return _Categories; } set { _Categories = value; OnPropertyChanged(); } }

        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; OnPropertyChanged(); } }

        public Category(){
            Categories= new List<Category>();
        }
    }
}
