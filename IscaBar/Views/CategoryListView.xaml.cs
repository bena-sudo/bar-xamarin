using IscaBar.Models;
using IscaBar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IscaBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryListView : ContentPage
    {
        CategoryListVM vm = new CategoryListVM();
        
        public CategoryListView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
     
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadCategoriesAsync();
        }
    
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Category category = (Category)e.Item;
            if (category == null)
                return;


            ((ListView)sender).SelectedItem = null;
        }
    }
}