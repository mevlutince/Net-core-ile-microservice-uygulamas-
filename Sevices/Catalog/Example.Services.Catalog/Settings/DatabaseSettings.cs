using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        //bu degerleri startupta dolduracagız
        public string CourseCollectionName { get  ; set  ; }
        public string CategoryCollectionName { get ; set  ; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get  ; set ; }
    }
}
