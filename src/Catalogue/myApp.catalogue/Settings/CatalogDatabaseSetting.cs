﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.catalogue.Settings
{
    public class CatalogDatabaseSetting : ICatalogDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set ; }
        public string CollectionName { get; set ; }
    }
}
