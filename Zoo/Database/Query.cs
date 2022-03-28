using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Zoo.Database
{
    public partial class Query
    {

        string _TableName;
        string sql = "";

        string[] parameters;
        string[] values;

        public SqlConnection Connection { get; set; }

        public Query(string table)
        {
            _TableName = table;
        }
        public Query() { }

        /// <summary>
        /// https://docs.microsoft.com/cs-cz/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter
        /// </summary>
        /// <returns></returns>
        public DataSet Get()
        {

            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                if((parameters != null) && (values != null))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", values[i]);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                
            }

            return ds;
        }
        public string GetNonQuery()
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                if ((parameters != null) && (values != null))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", values[i]);
                    }
                }

                _ = cmd.ExecuteNonQuery();
            }

            return sql;
        }

        public string Sql()
        {
            return sql;
        }
        public string First()
        {
            return Get().Tables[0].ToString();
        }

        public string Last()
        {
            return Get().Tables[Get().Tables.Count].ToString();
        }
        public string Index(int i)
        {
            return Get().Tables[i].ToString();
        }
        public int Length()
        {
            return Get().Tables.Count;
        }

    }
}
