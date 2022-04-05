using MongoDB.Driver;
using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Data
{
    public  interface IProductsContext
    {
         IMongoCollection<ProductDetails> Product{ get;  }
    }
}
