using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await this.productService.GetAll();

            ViewData["Title"] = "Products";

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add new product";

            var model = new ProductDto();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.productService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]string id)
        {
            Guid guidId = Guid.Parse(id);

            await this.productService.Delete(guidId);

            return RedirectToAction(nameof(Index));
        }

    }
}
