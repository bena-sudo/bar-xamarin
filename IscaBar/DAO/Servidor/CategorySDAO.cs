using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IscaBar.DAO.Servidor
{
    public class CategorySDAO
    {
        private static CategorySDAO _instance = null;
        public static CategorySDAO Instance
        {
            get
            {
                if (_instance != null) { return _instance; }
                else
                {
                    _instance = new CategorySDAO(); return _instance;
                }
            }

        }

        public async Task<List<Category>> GetAllAsync()
        {
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(BaseUrl.UrlApi);

                HttpResponseMessage response = await client.GetAsync("/restaurapp_app/getCategory");
                string content = await response.Content.ReadAsStringAsync();

                try
                {
                    response.EnsureSuccessStatusCode();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(data["data"].ToString());
                    return categories;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
