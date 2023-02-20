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
        CategoryListVM vm;

        private Order _order;
        public Order Order { get { return _order; } set { _order = value; OnPropertyChanged(); } }

        public CategoryListView(Order order)
        {
            InitializeComponent();
            vm = new CategoryListVM();
            BindingContext = vm;
            Order = order;
        }

        public CategoryListView(Order order,Category cat)
        {
            InitializeComponent();
            vm = new CategoryListVM(cat);
            BindingContext = vm;
            Order = order;
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