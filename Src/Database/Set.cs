using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Set(params object[] values)
        {
            this.values = values;
            return this;
        }
    }
}
