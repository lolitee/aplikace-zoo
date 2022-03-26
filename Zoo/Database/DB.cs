using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Zoo.Database
{
    public class DB
    {

        protected string connection_string;

        public DB(string connection_string)
        {
            this.connection_string = connection_string;
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(connection_string);
            return conn;
        }
        public Query Query(string table)
        {
            return new Query(table);
        }
    }
}
