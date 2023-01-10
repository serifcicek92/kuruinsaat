using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kuruinsaat.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("connectionString")
        {

        }
    }
}