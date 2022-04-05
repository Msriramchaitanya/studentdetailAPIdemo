using Microsoft.AspNetCore.Mvc;
using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Repositories
{
    public interface IProductsRepository
    {
       Task< IEnumerable<ProductDetails>> Get();
        Task Post([FromBody] ProductDetails product);
        Task Put(int Id, ProductDetails product);
        Task delete(int Id);
       Task< ProductDetails > GetByID(int Id); 
    }
}
