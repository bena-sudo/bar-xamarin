using IscaBar.DAO.Interfaces;
using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                string URL = Constant.UrlApi + "/restaurapp_app/getOrder";
                URI = new Uri(URL);
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> response = client.GetAsync(URI);
                try
                {
                    response.Result.EnsureSuccessStatusCode();
                    string content = await response.Result.Content.ReadAsStringAsync();
                    List<Order> list = JsonConvert.DeserializeObject<List<Order>>(content);
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            string URL = Constant.UrlApi + "/restaurapp_app/UpdateOrder";
            Uri URI = new Uri(URL);
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
            string URL = Constant.UrlApi + "restaurapp_app/addTable";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                Order list = JsonConvert.DeserializeObject<Order>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(Order order)
        {
            string URL = Constant.UrlApi + "restaurapp_app/delOrder";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(order.Id);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                if (list != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

                HttpResponseMessage response = await client.GetAsync("/restaurapp_app/getOrder/" + id);
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


