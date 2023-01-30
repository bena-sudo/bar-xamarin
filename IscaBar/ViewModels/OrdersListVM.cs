using iscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace iscaBar.ViewModels
{
    public class OrdersListVM : ModelBase
    {
        /// <summary>
        /// Declarar la lista de ordenes que se enlaza a la lista
        /// </summary>
        private ObservableCollection<Order> _BindingOrders;
        public ObservableCollection<Order> BindingOrders
        {
            get { return _BindingOrders; }
            set
            {
                _BindingOrders = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Metodo para actualizar la lista en caso de cambio
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Metodo que recarga de nuevo la lista en pantalla
        /// </summary>
        /// <returns></returns>
        public async Task LoadOrdersAsync()
        {
            getOrders();
        }
        /// <summary>
        /// Constructor de las lista de ordenes llama directamente a la la lista de ordenes
        /// </summary>
        public OrdersListVM()
        {
            getOrders();
        }
        /// <summary>
        /// Metodo que conecta con el daoServidor para recoger todas lar ordenes getAllOrders
        /// </summary>
        /// <returns>lista de ordenes</returns>
        private async Task getOrders()
        {
            List<Order> orderList = await OrderSDAO.Instance.GetAllAsync();
            BindingOrders = new ObservableCollection<Order>(orderList);

        }


        /// <summary>
        /// Metodo para borrar ordenes, conecta con el DAO Servidor delete Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal async Task<bool> DeleteOrderAsync(Order order)
        {
            try
            {
                await OrderSDAO.Instance.DeleteAsync(order.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
