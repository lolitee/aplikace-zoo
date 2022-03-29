using System;
using System.Data;
using System.Data.SqlClient;

namespace Zoo.Database
{
    public partial class Query
    {
        private string _TableName;
        private string sql = "";

        private string[] parameters;
        private object[] values;

        public SqlConnection Connection { get; set; }

        public Query(string table)
        {
            _TableName = table;
        }

        public Query()
        { }

        /// <summary>
        /// https://docs.microsoft.com/cs-cz/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter
        /// </summary>
        /// <returns></returns>
        /// 

        private SqlCommand Cmd(string sql, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);

            if ((parameters != null))
            {
                if (values == null)
                    throw new Exception("Cannot insert without value!");

                if (parameters.Length == values.Length)
                    throw new Exception("Parameters and values have to be same length!");

                for (int i = 0; i < parameters.Length; i++)
                {
                    if (values[i] == null)
                    {
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", values[i]);
                    }
                }
            }

            return cmd;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = Cmd(sql, Connection);
            adapter.Fill(ds);

            return ds;
        }

        public void GetNonQuery() => _ = Cmd(sql, Connection).ExecuteNonQuery();


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