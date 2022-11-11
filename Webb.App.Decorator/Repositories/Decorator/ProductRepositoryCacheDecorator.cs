using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Webb.App.Decorator.Models;

namespace Webb.App.Decorator.Repositories.Decorator
{
    public class ProductRepositoryCacheDecorator : BaseProductRepositoryDecorator
    {
        private readonly IMemoryCache _memoryCache;
        private const string ProductCacheName = "products";
        public ProductRepositoryCacheDecorator(IProductRepository productRepository, IMemoryCache cache) : base(productRepository)
        {
            _memoryCache = cache;
        }

        public async override Task<List<Product>> GetAll()
        {
            if (_memoryCache.TryGetValue(ProductCacheName, out List<Product> cacheProducts))
            {
                return cacheProducts;
            }

            await UpdateCache();

            return _memoryCache.Get<List<Product>>(ProductCacheName);

        }

        public async override Task<List<Product>> GetAll(string userId)
        {
            var products = await GetAll();
            return products.Where(x => x.UserId == userId).ToList();

        }

        public async override Task<Product> Save(Product product)
        {
            await base.Save(product);
            await UpdateCache();
            return product;
        }

        public async override Task Update(Product product)
        {
            await base.Update(product);
            await UpdateCache();
        }

        public async override Task Remove(Product product)
        {
            await base.Remove(product);
            await UpdateCache();
        }

        private async Task UpdateCache()
        {
            _memoryCache.Set(ProductCacheName, await base.GetAll());

        }
    }
}
