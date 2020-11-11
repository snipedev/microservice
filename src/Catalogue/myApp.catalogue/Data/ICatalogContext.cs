using MongoDB.Driver;
using myApp.catalogue.Entities;

namespace myApp.catalogue.Data
{
    public interface ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
    }
}
