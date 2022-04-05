using Microsoft.Extensions.Options;
using MongoDB.Driver;
using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Data
{
    public class ProductsContext : IProductsContext
    {
        private readonly IMongoDatabase _database = null;
        public ProductsContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
           // if (client != null)
            _database = client.GetDatabase(settings.Value.Database);
            
        }
        public IMongoCollection<ProductDetails> Product {
            get {
                return _database.GetCollection<ProductDetails>("Products"); 
            }
        }
    }
}
