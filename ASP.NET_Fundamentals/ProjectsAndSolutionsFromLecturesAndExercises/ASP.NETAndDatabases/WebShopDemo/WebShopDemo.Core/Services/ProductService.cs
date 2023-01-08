using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="config">Application configuration</param>
        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };
            
            await this.repo.AddAsync(product);
            
            await this.repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await this.repo.AllReadOnly<Product>(p => p.IsActive)
                                  .Select(p => new ProductDto()
                                      {
                                          Id = p.Id,
                                          Name = p.Name,
                                          Price = p.Price,
                                          Quantity = p.Quantity,
                                      })
                                  .ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await this.repo.All<Product>().FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;

                await this.repo.SaveChangesAsync();
            }
        }
    }
}
