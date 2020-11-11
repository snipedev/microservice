using myApp.catalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.catalogue.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProduct();
        public Task<Product> GetProductByName(string Name);

        public Task<Product> GetProductById(string Id);
        public Task<IEnumerable<Product>> GetProductByCategory(string category);
        public Task create(Product product);
        public Task<bool> update(Product product);
        public Task<bool> Delete(string Id);

    }
}
