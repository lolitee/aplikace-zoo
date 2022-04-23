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

                if (parameters.Length != values.Length)
                    throw new Exception("Parameters and values have to be same length!");

                for (int i = 0; i < parameters.Length; i++)
                {
                    if (values[i] == null)
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", values[i]);

                    Console.WriteLine(values[i]);
                }
            }

            return cmd;
        }

        public DataTable Get()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
            using (adapter)
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public void GetNonQuery() => _ = Cmd(sql, Connection).ExecuteNonQuery();

        public string Sql() => sql;

        public object[] First() => Get().Rows[0].ItemArray;

        public object[] Last() => Get().Rows[Get().Rows.Count].ItemArray;

        public string Index(int i) => Get().Rows[i].ToString();

        public int Length() => Get().Rows.Count;
    }
}