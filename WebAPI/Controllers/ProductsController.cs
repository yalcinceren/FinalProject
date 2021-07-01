using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        [HttpGet]
        public List<Product> Get()
        {
            var ret = new List<Product>();
            Product product = new Product();
            product.CategoryId = 9;
            product.ProductId = 8;
            product.ProductName = "Nur";
            product.UnitPrice = (decimal)9.99;
            product.UnitsInStock = 1;
            ret.Add(product);
            return ret;
        }
    }
}
