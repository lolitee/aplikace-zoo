using System;
using System.Linq;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Update(params string[] parameters)
        {
            // update informací v tabulce
            this.parameters = parameters;
            sql += $"UPDATE {this._TableName} SET {String.Join(", ", parameters.Select(x => $"{x}=@{x}"))} ";
            return this;
        }
    }
}