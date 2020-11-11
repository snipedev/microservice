using MongoDB.Driver;
using myApp.catalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.catalogue.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> ProductCollection)
        {
            bool existProduct = ProductCollection.Find(p => true).Any();
            if (!existProduct)
            {
                ProductCollection.InsertManyAsync(GetProductsCollections());
            }
        }

        private static IEnumerable<Product> GetProductsCollections()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone xs",
                    Category="Phone",
                    Summary="Mast mehnga phone",
                    Description="Jhakkas garda phone",
                    Price = 799
                },
                new Product()
                {
                    Name = "Iphone xii",
                    Category="tab",
                    Summary="bhot mehnga phone",
                    Description="Jhakkas garda phone 5 camera",
                    Price = 1299
                },
                new Product()
                {
                    Name = "Iphone x",
                    Category="simtel",
                    Summary="bhot mehnga phone se sasta",
                    Description="Jhakkas garda phone 4 camera",
                    Price = 999
                },
                new Product()
                {
                    Name = "Micromax ab1",
                    Category="average phone",
                    Summary="bhot mehnga phone se sasta",
                    Description="Jhakkas garda phone 4 camera",
                    Price = 299
                },
            };
        }
    }
}
