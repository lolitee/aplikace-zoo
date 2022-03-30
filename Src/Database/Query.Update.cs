using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Update(params string[] parameters)
        {
            this.parameters = parameters;
            sql += $"UPDATE {this._TableName} SET {String.Join(", ", parameters.Select(x => $"{x}='@{x}'"))}";
            return this;
        }
    }
}
