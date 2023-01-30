using iscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System;
using System.Threading.Tasks;

namespace iscaBar.ViewModels
{
    internal class OrderDetailVM:ModelBase
    {
        /// <summary>
        /// Crear el objeto Order para acceder a ella desde cualquier metodo
        /// </summary>
        private Order _order;

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Se asigna la orden seleccionada en la lista
        /// </summary>
        /// <param name="order"></param>
        public OrderDetailVM(Order order)
        {
            Order=order;
        }

        /// <summary>
        /// Conecta con el metodo delete
        /// </summary>
        /// <returns>true or false</returns>
        internal async Task<bool> DeleteOrderAsync()
        {
            try
            {
                await OrderSDAO.Instance.DeleteAsync(Order.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        /// <summary>
        /// Crea una nueva orden
        /// </summary>
        internal void newOrder()
        {
            Order= new Order();
        }
        /// <summary>
        /// Conecta con el metodo update del DAO Servidor
        /// </summary>
        /// <returns>true or false</returns>
        public async Task<bool> SaveOrderAsync()
        {
            try
            {
                return await OrderSDAO.Instance.UpdateAsync(Order);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Conecta con el metodo addOrder del DAO servidor
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddOrderAsync()
        {
            try
            {
               Order = await OrderSDAO.Instance.AddAsync(Order);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
