using Demo.Common;
using Demo.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demo.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService productService;
        public ProductsController()
        {
            this.productService = new ProductService();
        }
        public ProductsController(ProductService _productService)
        {
            this.productService = _productService;
        }

        public ActionResult Index()
        {
            List<Product> products = productService.getProducts();
            return View(products);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = productService.getProduct(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult updateProduct(Product product)
        {
            productService.updateProduct(product);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult addProduct(Product product)
        {
            productService.addProduct(product);
            return RedirectToAction("index");
        }


        public ActionResult Delete(int id)
        {
            productService.deleteProduct(id);
            return RedirectToAction("index");
        }

    }
}