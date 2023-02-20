using IscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace IscaBar.ViewModels
{
    public class CategoryListVM : ModelBase
    {
        private ObservableCollection<Category> _BindingCategories;
        public ObservableCollection<Category> BindingCategories
        {
            get { return _BindingCategories; }
            set
            {
                _BindingCategories = value;
                OnPropertyChanged();
            }
        }
        private Category cat;
        public Category Cat { get { return cat; } set { cat = value; OnPropertyChanged(); } }

        public CategoryListVM()
        {
            getCategories();
        }

        public CategoryListVM(Category cat)
        {
            getCategoriesPerCategory(cat);
            Cat = cat;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadCategoriesAsync()
        {
            getCategories();
        }

        private async Task getCategories()
        {
            List<Category> categoriesList = await CategorySDAO.Instance.GetAllAsync();
            BindingCategories = new ObservableCollection<Category>(categoriesList);
        }
        private void getCategoriesPerCategory(Category cat)
        {
            List<Category> categoriesList = cat.Subcategories;
            BindingCategories = new ObservableCollection<Category>(categoriesList);
        }

        public void buscarFills(Category cat)
        {
            Cat = cat;
            ObservableCollection<Category> categories = new ObservableCollection<Category>(cat.Subcategories);
            BindingCategories = categories;
        }
    }
}