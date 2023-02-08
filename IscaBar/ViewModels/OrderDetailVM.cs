using IscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System;
using System.Threading.Tasks;

namespace IscaBar.ViewModels
{
    internal class OrderDetailVM : ModelBase
    {
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
       
        public OrderDetailVM(Order order)
        {
            Order = order;
        }

        internal void newOrder()
        {
            Order = new Order();
        }
        
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
        internal async Task<bool> DeleteOrderAsync()
        {
            try
            {
                await OrderSDAO.Instance.DeleteAsync(Order);
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
