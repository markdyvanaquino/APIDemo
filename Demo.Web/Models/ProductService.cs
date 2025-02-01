using Demo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demo.Web.Models
{
    public class ProductService
    {

        private string baseUrl = "http://localhost:1213/api/products";
        private HttpClient client;

        public ProductService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Product> getProducts()
        {
            List<Product> products = new List<Product>();
            using (client)
            {
                HttpResponseMessage response =  client.GetAsync(baseUrl + "/Get").Result;
                if (response.IsSuccessStatusCode)
                {
                var responseData = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(responseData);
                }
            }
            return products;
        }

        public Product getProduct(int id)
        {
            Product product = null;
            using (client)
            {
                HttpResponseMessage response =  client.GetAsync(baseUrl + "/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(responseData);
                }
            }
            return product;
        }

        public bool addProduct(Product product)
        {
            bool added = false;
            using (client)
            {
                HttpResponseMessage response = 
                    client.PostAsJsonAsync(baseUrl + "/Post/",
                    product
                    ).Result;
                if (response.IsSuccessStatusCode)
                {
                    added = response.Content.ReadAsAsync<bool>().Result;
                }
            }
            return added;
        }

        public bool updateProduct(Product product)
        {
            bool updated = false;
            using (client)
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(baseUrl + "/Put/",
                    product
                    ).Result;
                if (response.IsSuccessStatusCode)
                {
                    updated = response.Content.ReadAsAsync<bool>().Result;
                }
            }
            return updated;
        }

        public bool deleteProduct(int id)
        {
            bool updated = false;
            using (client)
            {
                HttpResponseMessage response =
                   client.DeleteAsync(baseUrl + "/Delete/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    updated = response.Content.ReadAsAsync<bool>().Result;
                }
            }
            return updated;
        }

    }
}