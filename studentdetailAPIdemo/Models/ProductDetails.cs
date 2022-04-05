using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Models
{
    [BsonIgnoreExtraElements]
    public class ProductDetails
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductType { get; set; }
        //[BsonId]
        //       public ObjectId _id { get; set; }
    }
}
