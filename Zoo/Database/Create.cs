using System;
using System.Linq;

namespace Zoo.Database
{
    public class TableProperties
    {
        public string field { get; set; }
        public int size { get; set; }
        public bool isPrimary { get; set; }
        public bool isNotNull { get; set; }
        public DataType dataType { get; set; }
        public string @default { get; set; }

        public TableProperties(string field, int size, bool primary, bool @null, DataType dataType, string @default)
        {
            this.field = field;
            this.size = size;
            this.isPrimary = primary | false;
            this.isNotNull = @null | false;
            this.dataType = dataType;
            this.@default = @default;
        }

        public TableProperties()
        { }
    }

    public partial class Query
    {
        public Query Create(string table_name, params TableProperties[] tables)
        {
            var str = String.Join(",\n",
                tables
                .Select(x =>
                $"{x.field} " +
                $"{x.dataType}{(x.size == 0 ? "" : $"({x.size})").ToString()}" +
                $"{(String.IsNullOrEmpty(x.@default) ? "" : $"DEFAULT '{x.@default}'")} " +
                $"{(x.isNotNull ? "NOT NULL" : "").ToString()} " +
                $"{(x.isPrimary ? $"PRIMARY KEY ({x.field})" : "").ToString()} "));

            sql += $"CREATE TABLE [{table_name}] (\n{str}\n)";
            return this;
        }
    }
}