using Demo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Api.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }

    public class ProductService: IProductService
    {
        private productsEntities _productContext;
        public productsEntities productContext
        {
            get
            {
                return _productContext;
            }
            set
            {
                _productContext = value;
            }
        }

        /* To do: Investigate injecting context instead */
        public ProductService()
        {
            this._productContext = new productsEntities();
        }
        public ProductService(productsEntities productContext)
        {
            this._productContext = productContext;
        }

        public void Initialise()
        {
            productContext.Products.Add(new Product() { Name = "Product 1", Price = 10.00m });
            productContext.Products.Add(new Product() { Name = "Product 2", Price = 20.00m });
            productContext.Products.Add(new Product() { Name = "Product 3", Price = 30.00m });
            productContext.Products.Add(new Product() { Name = "Product 4", Price = 40.00m });
            productContext.Products.Add(new Product() { Name = "Product 5", Price = 50.00m });
            save();
        }
        public IEnumerable<Product> GetProducts()
        {
            return productContext.Products.ToList();
        }
        public Product GetProduct(int id)
        {
            return productContext.Products.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {
            productContext.Products.Add(product);
            save();
        }
        public void UpdateProduct(Product product)
        {
            Product prodToUpdate = productContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (prodToUpdate != null)
            {
                prodToUpdate.Name = product.Name;
                prodToUpdate.Price = product.Price;
            }
            save();
        }
        public void DeleteProduct(int id)
        {
            Product product = productContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                productContext.Products.Remove(product);
            }
            save();
        }

        public void save()
        {
            productContext.SaveChanges();
        }

    }
}