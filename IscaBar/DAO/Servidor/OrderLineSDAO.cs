using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iscaBar.DAO.Servidor
{
    public class OrderLineSDAO
    {
        public static async Task<List<Order>> GetAllAsync()
        {
            string URL = Constant.UrlApi + "restaurapp_app/getAllOrder";
            Uri URI = new Uri(URL);
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

        public static async Task<String> UpdateAsync(Order ord)
        {
            string URL = Constant.UrlApi + "restaurapp_app/updateOrder";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(ord);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<String> AddAsync(Order ord)
        {
            string URL = Constant.UrlApi + "restaurapp_app/addOrder";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(ord);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<String> DeleteAsync(Order ord)
        {
            string URL = Constant.UrlApi + "restaurapp_app/deleteOrder";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(ord.Id);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
