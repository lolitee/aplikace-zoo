using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public TableProperties() { }
        }
    public partial class Query
    {
        public Query Create(string table_name, params TableProperties[] tables)
        {

                String.Join(",", 
                    tables
                    .Select(x => $"{x.field} {x.dataType}({x.size})"));



/*                Console.WriteLine(item.field);
                Console.WriteLine(item.size);
                Console.WriteLine(item.isPrimary);
                Console.WriteLine(item.isNotNull);
                Console.WriteLine(item.dataType);
                Console.WriteLine(item.@default);
                Console.WriteLine("-------");*/
            
            //sql += $"CREATE TABLE {table_name}";
            return this;
        }
    }
}
