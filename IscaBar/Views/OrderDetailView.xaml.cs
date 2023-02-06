using IscaBar.Models;
using IscaBar.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IscaBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailView : ContentPage
    {
        //Declaracion del VM
        OrderDetailVM vm;
        /// <summary>
        /// Para saber si la orden que hay en pantalla es nueva o no
        /// </summary>
        bool newOrder=false;
        /// <summary>
        /// Constructor de OrderDetailView
        /// </summary>
        /// <param name="order"></param>
        /// <param name="isNew"></param>
        public OrderDetailView(Order order, bool isNew)
        {

            InitializeComponent();
            vm = new OrderDetailVM(order);
            BindingContext = vm;

            //Se indica si la orden es nueva o no
            newOrder = isNew;
        }

        /// <summary>
        /// Boton delete de la vista llama al metodo deleteOrder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ClickedDeleteOrder(object sender, EventArgs e)
        {
           
            var answer = await DisplayAlert("Eliminar Orden", "¿Desea eliminar esta orden?", "Sí", "No");
            if (answer)
            {
                await DeleteOrderAsync();
            }
        }

        /// <summary>
        /// Llama al metodo deleteOrder del VM / Luego cierra la venta y recarga la lista
        /// </summary>
        /// <returns></returns>
        private async Task DeleteOrderAsync()
        {
            try
            {
                await vm.DeleteOrderAsync();

                await DisplayAlert("Aviso", "Orden borrada", "OK");
                //Cerrar la ventana actual
                await Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al borrar orden", ex.Message, "OK");
            }
        }

        /// <summary>
        /// Metodo save, si la orden es nueva, llama al metodo addOrder, en caso contrario al update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedSaveOrder(object sender, EventArgs e)
        {
            if (newOrder)
            {
                AddOrderAsync();
            }
            else
            {
                SaveOrderAsync();   
            }   
        }

        /// <summary>
        /// Metodo save que llama al updateOrder del VM
        /// </summary>
        /// <returns></returns>
        private async Task SaveOrderAsync()
        {
            try
            {
                if (await vm.SaveOrderAsync())
                await DisplayAlert("Aviso", "Orden guardada", "OK");
                else { await DisplayAlert("Error", "Orden no guardada", "OK"); }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al guardar orden", ex.Message, "OK");
            }
        }

        /// <summary>
        /// Metodo addOrder que es llamado cuando la orden es nueva
        /// </summary>
        /// <returns></returns>
        private async Task AddOrderAsync()
        {
            try
            {
                if (await vm.AddOrderAsync())
                {
                    await DisplayAlert("Aviso", "Nueva orden guardada", "OK");
                    newOrder = false;
                }
         
                else { await DisplayAlert("Error", "Orden no guardada", "OK"); }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al guardar orden", ex.Message, "OK");
            }
        }
    }
}