using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Database
{
    public partial class Query
    {

        string _TableName;

        public Query(string table)
        {
            _TableName = table;
        }

    }
}
