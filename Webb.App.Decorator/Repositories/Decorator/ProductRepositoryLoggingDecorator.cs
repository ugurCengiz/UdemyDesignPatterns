﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Webb.App.Decorator.Models;

namespace Webb.App.Decorator.Repositories.Decorator
{
    public class ProductRepositoryLoggingDecorator:BaseProductRepositoryDecorator
    {
        private readonly ILogger<ProductRepositoryLoggingDecorator> _log;
        public ProductRepositoryLoggingDecorator(IProductRepository productRepository, ILogger<ProductRepositoryLoggingDecorator> log) : base(productRepository)
        {
            _log = log;
        }

        public override Task<List<Product>> GetAll()
        {
            _log.LogInformation("GetAll methodu çalıştı");
            return base.GetAll();
        }

        public override Task<List<Product>> GetAll(string userId)
        {
            _log.LogInformation("GetAll(userId) methodu çalıştı");
            return base.GetAll(userId);
        }

        public override Task Update(Product product)
        {
            _log.LogInformation("Update methodu çalıştı");
            return base.Update(product);
        }

        public override Task Remove(Product product)
        {
            _log.LogInformation("Remove methodu çalıştı");
            return base.Remove(product);
        }

        public override Task<Product> Save(Product product)
        {
            _log.LogInformation("Save methodu çalıştı");
            return base.Save(product);
        }
    }
}
