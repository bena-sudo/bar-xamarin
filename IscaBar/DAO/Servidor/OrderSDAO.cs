using iscaBar.DAO.Interfaces;
using iscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iscaBar.DAO.Servidor
{
    public class OrderSDAO : IDAO<Order>
    {
        private static OrderSDAO _instance = null;
        public static OrderSDAO Instance
        {
            get
            {
                if (_instance != null) { return _instance; }
                else
                {
                    _instance = new OrderSDAO(); return _instance;
                }
            }

        }

        public async Task<List<Order>> GetAllAsync()
        {
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(BaseUrl.UrlApi);

                HttpResponseMessage response = await client.GetAsync("/restaurapp_app/getOrder");
                string content = await response.Content.ReadAsStringAsync();

                try
                {
                    response.EnsureSuccessStatusCode();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                    List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(data["data"].ToString());
                    return orders;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            var dic = new { id = order.Id, name = order.Table, client = order.Clients, pax = order.Pax, waiter = order.Waiter };
            string json = JsonConvert.SerializeObject(dic);
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(BaseUrl.UrlApi);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("/restaurapp_app/updateOrder/" + order.Id, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public async Task<Order> AddAsync(Order order)
        {
            var dic = new { name = order.Table, client = order.Clients, pax = order.Pax, waiter = order.Waiter };
            string json = JsonConvert.SerializeObject(dic);
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(BaseUrl.UrlApi);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/restaurapp_app/addOrder", content);
                string responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var data = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        order.Id = data.result.id;
                        return order;
                    }
                    else
                    {
                        throw new Exception("Error al crear la orden");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl.UrlApi);

            var content = new StringContent(JsonConvert.SerializeObject(new { id }), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/restaurapp_app/delOrder", content);
            string responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public async Task<Order> GetWithChildrenAsync(int id)
        {
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(BaseUrl.UrlApi);

                HttpResponseMessage response = await client.GetAsync("/restaurapp_app/getOrder/"+id);
                string content = await response.Content.ReadAsStringAsync();

                try
                {
                    response.EnsureSuccessStatusCode();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                    Order order = JsonConvert.DeserializeObject<Order>(data["data"].ToString());
                    return order;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    } 

}

    
