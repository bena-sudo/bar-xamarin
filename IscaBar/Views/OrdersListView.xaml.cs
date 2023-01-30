using iscaBar.Models;
using iscaBar.ViewModels;
using IscaBar.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iscaBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersListView : ContentPage
    {
        /// <summary>
        /// Declarar el modelo VM de lista de Ordenes
        /// </summary>
        OrdersListVM vm = new OrdersListVM();
       /// <summary>
       /// Constructor de la lista de ordenes
       /// </summary>
        public OrdersListView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        /// <summary>
        /// Metodo que actualiza la lista de ordenes en pantalla
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await vm.LoadOrdersAsync();
        }
        /// <summary>
        /// Metodo que se usa al pulsar una orden de la lista, llama a OrderDetai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Order order = (Order)e.Item;
            if (order == null)
                return;

            //se pone false para indicar que la orden que se envia no es nueva
            await Navigation.PushAsync(new OrderDetailView(order, false));

            ((ListView)sender).SelectedItem = null;
        }


        /// <summary>
        /// Boton "Nueva Orden" de la vista, llama al metodo NewOrderAsync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedNewOrder(object sender, EventArgs e)
        {
            Order order = new Order();
            NewOrderAsync(order);
        }
        /// <summary>
        /// Metodo new Orden que llama a una nueva ventana de Orden detail con una orden nueva
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private async Task NewOrderAsync(Order order)
        {
            //se le pasa la nueva orden junto con true para indicar que la orden es nueva 
            await Navigation.PushAsync(new OrderDetailView(order, true));
        }
        /// <summary>
        /// Boton eliminar Orden de la lista - recoge la orden desde el binding CommandParameter // Luego llama al metodo deleteOrder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ClickedDeleteOrder(object sender, EventArgs e)
        {
            //Saber el boton pulsado
            var button = (Button)sender;
            // segun el boton es la orden indicada
            var selectedOrder = (Order)button.CommandParameter;

            var answer = await DisplayAlert("Eliminar Orden", "¿Desea eliminar esta orden?", "Sí", "No");
            if (answer)
            {
                await DeleteOrderAsync(selectedOrder);
            }
        }
        /// <summary>
        /// Se llama al metodo delete de OrdersListVM
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private async Task DeleteOrderAsync(Order order)
        {
            try
            {
                await vm.DeleteOrderAsync(order);

                await DisplayAlert("Aviso", "Orden borrada", "OK");
                OnAppearing();
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al borrar orden", ex.Message, "OK");
            }
        }
    }
}
