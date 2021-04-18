using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoNetCRUD.Data.AdoNetQueries
{
    public class SqlConnectionConfiguration
    {
        public string Value;
        public SqlConnectionConfiguration(string value) => Value = value;
    }
}
