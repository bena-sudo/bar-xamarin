using IscaBar.DAO.Interfaces;
using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IscaBar.DAO.Servidor
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
        private static string URL { get; set; }
        private static Uri URI { get; set; }

        public async Task<List<Order>> GetAllAsync()
        {
            {
                URL = Constant.UrlApi + "/restaurapp_app/getOrder";
                URI = new Uri(string.Format(URL, string.Empty));
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> response = client.GetAsync(URI);
                try
                {
                    response.Result.EnsureSuccessStatusCode();
                    string content = await response.Result.Content.ReadAsStringAsync();
                    List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(content);
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
            URL = Constant.UrlApi + "/restaurapp_app/UpdateOrder";
            URI = new Uri(string.Format(URL, string.Empty));
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PostAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);
                if (data == null) throw new Exception("Problemas con Internet");
                if (data.result.status != Constant.Success)
                    throw new Exception(data.result);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> AddAsync(Order order)
        {
            string json = JsonConvert.SerializeObject(order);
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

    
