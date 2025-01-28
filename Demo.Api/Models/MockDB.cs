using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Api.Models
{
    public class MockDB
    {
        private List<Product> Products;

        public MockDB()
        {
            this.Products = new List<Product>();
            Initialise();
        }
        public void Initialise()
        {
            this.Products.Add(new Product() { Id= 1, Name="Product 1", Price = 10.00m});
            this.Products.Add(new Product() { Id = 2, Name = "Product 2", Price = 20.00m });
            this.Products.Add(new Product() { Id = 3, Name = "Product 3", Price = 30.00m });
            this.Products.Add(new Product() { Id = 4, Name = "Product 4", Price = 40.00m });
            this.Products.Add(new Product() { Id = 5, Name = "Product 5", Price = 50.00m });
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
        public Product GetProduct(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            Product prodToUpdate = Products.FirstOrDefault(p => p.Id == product.Id);
            if (prodToUpdate != null)
            {
                prodToUpdate.Name = product.Name;
                prodToUpdate.Price = product.Price;
            }
        }
        public void DeleteProduct(int id)
        {
            Product product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
    }
}