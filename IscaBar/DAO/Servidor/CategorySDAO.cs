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
    internal class CategorySDAO
    {
        public static async Task<List<Categoria>> GetAllAsync()
        {
            string URL = Constant.UrlApi + "restaurapp_app/getAllCategory";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> response = client.GetAsync(URI);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                List<Categoria> list = JsonConvert.DeserializeObject<List<Categoria>>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<String> UpdateAsync(Categoria cat)
        {
            string URL = Constant.UrlApi + "restaurapp_app/updateCategory";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat);
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

        public static async Task<String> AddAsync(Categoria cat)
        {
            string URL = Constant.UrlApi + "restaurapp_app/addCategory";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat);
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

        public static async Task<String> DeleteAsync(Categoria cat)
        {
            string URL = Constant.UrlApi + "restaurapp_app/deleteCategory";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat.Id);
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
