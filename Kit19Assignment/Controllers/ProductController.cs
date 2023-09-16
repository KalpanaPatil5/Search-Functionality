using Kit19Assignment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kit19Assignment.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();

        // GET: Product
        public ActionResult Search()
        {
            List<Product> products = productRepository.GetAllProducts();
            SearchProduct searchProduct = new SearchProduct
            {
                Products = products
            };
            return View(searchProduct);
        }

        [HttpPost]
        public ActionResult Search(SearchProduct searchProduct)
        {
            List<Product> searchResults = productRepository.SearchProducts(searchProduct);
            searchProduct.Products = searchResults;
            return View(searchProduct);
        }
    }
}