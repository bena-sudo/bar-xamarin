using IscaBar.DAO.Servidor;
using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace iscaBar.DAO.Servidor
{
    public class ProductSDAO
    {
        public static async Task<Product> GetAsync(int ids)
        {
            string URL = Constant.UrlApi + "restaurapp_app/getProduct/" + ids;
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> response = client.GetAsync(URI);
            Product p = new Product();
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                JArray array = JsonConvert.DeserializeObject<JArray>(content);
                foreach (JObject ob in array)
                {
                    int id = int.Parse(ob.GetValue("id").ToString());
                    string name = ob.GetValue("name").ToString();
                    decimal price = Convert.ToDecimal(ob.GetValue("price").ToString());

                    p.Id = id;
                    p.Name = name;
                    p.Price = price;
                }
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}