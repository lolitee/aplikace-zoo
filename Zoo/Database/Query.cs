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
    public partial class Query
    {

        string _TableName;
        string sql = "";

        public SqlConnection Connection { get; set; }

        public Query(string table)
        {
            _TableName = table;
        }
        public string Get()
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                            reader[0], reader[1]));
                    }
                }
            }

            return sql;
        }
        public string GetNonQuery()
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.ExecuteNonQuery();
                
            }

            return sql;
        }

        public string Sql()
        {
            return sql;
        }
        public string First()
        {
            return Get();
        }

        public string Last()
        {
            return Get();
        }
        public string Index(int i)
        {
            return Get();
        }
        public int Length()
        {
            return 0;
        }

    }
}
