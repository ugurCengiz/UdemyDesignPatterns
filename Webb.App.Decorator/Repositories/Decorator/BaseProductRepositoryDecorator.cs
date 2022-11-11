using System.Collections.Generic;
using System.Threading.Tasks;
using Webb.App.Decorator.Models;

namespace Webb.App.Decorator.Repositories.Decorator
{

    public class BaseProductRepositoryDecorator : IProductRepository
    {
        public readonly IProductRepository _ProductRepository;

        public BaseProductRepositoryDecorator(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public virtual async Task<Product> GetById(int id)
        {
            return await _ProductRepository.GetById(id);

        }

        public virtual async Task<List<Product>> GetAll()
        {
            return await _ProductRepository.GetAll();
        }

        public virtual async Task<List<Product>> GetAll(string userId)
        {

            return await _ProductRepository.GetAll(userId);
        }

        public virtual async Task<Product> Save(Product product)
        {
            return await _ProductRepository.Save(product);

        }

        public virtual async Task Update(Product product)
        {
            await _ProductRepository.Update(product);
        }

        public virtual async Task Remove(Product product)
        {
            await _ProductRepository.Remove(product);
        }
    }
}
