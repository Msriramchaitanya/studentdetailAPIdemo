using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using studentdetailAPIdemo.Data;
using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Repositories
{
    public class ProductRepository : IProductsRepository
    {
       // IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        private readonly IProductsContext _productsContext;
        public ProductRepository(IProductsContext productsContext )
        {
            _productsContext = productsContext;
        }
        public async Task delete(int Id)
        {
          
            await _productsContext.Product.DeleteOneAsync(product=>product.ProductID==Id);
            
        }

        public async Task< IEnumerable<ProductDetails>> Get()
        {

            IEnumerable<ProductDetails> productResults;
            string serializedProducts;
            
            productResults = await _productsContext.Product.Find<ProductDetails>(a => true).ToListAsync();
          
            serializedProducts = JsonConvert.SerializeObject(productResults);
            return  (IEnumerable<ProductDetails>)productResults;
        }

        public async Task< ProductDetails> GetByID(int Id)

        {
            
           var  productResults =await _productsContext.Product.Find<ProductDetails>(a => a.ProductID==Id).ToListAsync();
            
            var serializedProducts = JsonConvert.SerializeObject(productResults);
            
            return productResults.FirstOrDefault();
        }

        public async Task Post([FromBody] ProductDetails product)
        {
       
            await _productsContext.Product.InsertOneAsync(product);
        }

        public async Task Put(int Id,  ProductDetails product)
        {
           
            var filter = Builders<ProductDetails>.Filter.Eq("ProductID", Id);
          

            var update = Builders<ProductDetails>.Update.Set(a=>a.ProductName,product.ProductName);
            
          
            await _productsContext.Product.UpdateOneAsync(filter, update);

        
        }
    }
}