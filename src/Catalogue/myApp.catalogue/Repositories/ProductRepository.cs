using myApp.catalogue.Data;
using MongoDB.Driver;
using myApp.catalogue.Entities;
using myApp.catalogue.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.catalogue.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task create(Product product)
        {
           await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string Id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);

            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _context
                    .Products
                    .Find(p => true)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            //var filter = Builders<Product>.Filter.ElemMatch(p => p.Category, category);
            return await _context.
                        Products
                        .Find(p => p.Category == category).ToListAsync();
        }

        public async Task<Product> GetProductById(string Id)
        {
            return await _context.
                        Products
                        .Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByName(string Name)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, Name);
            return await _context.
                        Products
                        .Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> update(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
