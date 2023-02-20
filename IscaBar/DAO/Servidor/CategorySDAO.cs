using iscaBar.DAO.Servidor;
using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public static List<int> fillsIds = new List<int>();

        public async Task<List<Category>> GetAllAsync()
        {
            {
                string URL = Constant.UrlApi + "/restaurapp_app/category";
                Uri URI = new Uri(URL);
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> response = client.GetAsync(URI);

                try
                {
                    response.Result.EnsureSuccessStatusCode();
                    string content = await response.Result.Content.ReadAsStringAsync();
                    JArray array = JsonConvert.DeserializeObject<JArray>(content);
                    List<Category> list = new List<Category>();
                    foreach (JObject o in array)
                    {
                        Category c = new Category();
                        int id = int.Parse(o.GetValue("id").ToString());
                        if (fillsIds.Contains(id)) continue;
                        string name = o.GetValue("name").ToString();
                        string description = o.GetValue("description").ToString();
                        JToken llista = o.GetValue("products");
                        List<Product> products = new List<Product>();
                        for (int i = 0; i < llista.Count(); i++)
                        {
                            int idp = int.Parse(llista[i].ToString());
                            Product p = await ProductSDAO.GetAsync(idp);
                            p.Categories.Add(c);
                            products.Add(p);
                        }
                        c.Id = id;
                        c.Name = name;
                        c.Description = description;
                        list.Add(c);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
            public static async Task<Category> GetAsync(int cat)
            {
                string URL = Constant.UrlApi + "restaurapp_app/getCategory/" + cat;
                Uri URI = new Uri(URL);
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> response = client.GetAsync(URI);
                Category c = new Category();
                try
                {
                    response.Result.EnsureSuccessStatusCode();
                    string content = await response.Result.Content.ReadAsStringAsync();
                    JArray array = JsonConvert.DeserializeObject<JArray>(content);
                    foreach (JObject ob in array)
                    {
                        int id = int.Parse(ob.GetValue("id").ToString());
                        if (fillsIds.Contains(id)) continue;
                        string name = ob.GetValue("name").ToString();
                        string desc = ob.GetValue("description").ToString();
                        JToken child_ids = ob.GetValue("child_id");
                        List<Category> childs = new List<Category>();
                        for (int i = 0; i < child_ids.Count(); i++)
                        {
                            int idc = int.Parse(child_ids[i].ToString());
                            Category fill = await CategorySDAO.GetAsync(idc);
                            fillsIds.Add(fill.Id);
                            childs.Add(fill);
                        }
                        c.Id = id;
                        c.Name = name;
                        c.Description = desc;
                        c.Subcategories = childs;
                    }
                    return c;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

