using Demo.Api.Models;
using Demo.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace Demo.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;
        public IProductService productService
        {
            get { return _productService; }
            set { _productService = value; }
        }

        public ProductsController()
        {
            _productService = new ProductService();
        }

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        public IHttpActionResult Get()
        {
            return Ok(_productService.GetProducts());
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.GetProduct(id));
        }

        // POST: api/Products

        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpOptions]
        public IHttpActionResult Post(Product product)
        {
            _productService.AddProduct(product);
            return Ok(true);
        }

        // PUT: api/Products/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpPut]
        [System.Web.Http.HttpOptions]
        public IHttpActionResult Put(Product product)
        {
            _productService.UpdateProduct(product);
            return Ok(true);
        }

        // DELETE: api/Products/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpDelete]
        [System.Web.Http.HttpOptions]
        public IHttpActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok(true);
        }
    }
}
