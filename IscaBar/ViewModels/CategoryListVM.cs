using IscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
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

        public CategoryListVM()
        {
            getCategories();
        }

        private async Task getCategories()
        {
            List<Category> categoriesList = await CategorySDAO.Instance.GetAllAsync();
            BindingCategories = new ObservableCollection<Category>(categoriesList);
        }
    }
}
