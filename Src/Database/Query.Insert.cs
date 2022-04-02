using System;
using System.Linq;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Insert(params string[] column)
        {
            // Vklad informací do tabulky
            sql += $"INSERT INTO [{this._TableName}] ({String.Join(", ", column)}) VALUES ({String.Join(", ", column.Select(x => $"@{x}"))}) ";
            this.parameters = column;
            return this;
        }
    }
}