using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Models
{
    public class MongoSettings
    {
        public const string MongoSection = "MongoConnection";
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
