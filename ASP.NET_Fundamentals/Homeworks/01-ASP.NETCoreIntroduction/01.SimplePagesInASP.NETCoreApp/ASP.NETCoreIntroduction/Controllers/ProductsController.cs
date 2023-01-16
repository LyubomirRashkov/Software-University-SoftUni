using ASP.NETCoreIntroduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ASP.NETCoreIntroduction.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00,
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50,
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50,
            }
        };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword is null)
            {
                return View(this.products);
            }

            var filteredProducts = this.products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

            return View(filteredProducts);
        }

        public IActionResult ById(int id)
        {
            var product = this.products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            return Json(this.products, options);
        }

        public IActionResult AllAsText()
        {
            var allProductsAsText = MakeAllProductsToString();

            return Content(allProductsAsText);
        }

        public IActionResult AllAsTextFile()
        {
            var allProductsAsString = this.MakeAllProductsToString();

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(allProductsAsString), "text/plain");
        }

        private string MakeAllProductsToString()
        {
            var sb = new StringBuilder();

            foreach (var product in this.products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price}lv.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
