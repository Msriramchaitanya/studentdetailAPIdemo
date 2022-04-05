using Microsoft.AspNetCore.Mvc;
//using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using studentdetailAPIdemo.Models;
using studentdetailAPIdemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace studentdetailAPIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _product;
        public ProductsController(IProductsRepository product)
        {
            _product = product;
        }
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task< IEnumerable<ProductDetails>> Get()
        {
           return await _product.Get();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task< ProductDetails> GetById(int id)
        {
            return await _product.GetByID(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] ProductDetails product)
        {
            await _product.Post(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, ProductDetails product)
        {

            await _product.Put(id,product);
        }

        // DELETE api/<ProductsController>/5B
        [HttpDelete("{id}")]
        public async Task delete(int id)
        {
            await _product.delete(id);
        }
    }
}
