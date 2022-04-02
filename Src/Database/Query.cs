using System;
using System.Data;
using System.Data.SqlClient;

namespace Zoo.Database
{
    public partial class Query
    {
        // proměnné
        private string _TableName;
        private string sql = "";

        private string[] parameters;
        private object[] values;

        // připojení
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

            // zachytávání chyb
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
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue($"@{parameters[i]}", values[i]);
                }
            }

            return cmd;
        }

        public DataTable Get()
        {
            // navrátí data tabulky 
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
            using (adapter)
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void GetNonQuery() => _ = Cmd(sql, Connection).ExecuteNonQuery();


        public string Sql()
        {
            // navrátí sql řetězec
            return sql;
        }

        public string First()
        {
            // první řádek tabulky
            return Get().Rows[0].ToString();
        }

        public string Last()
        {
            // počet položek v tabulce
            return Get().Rows[Get().Rows.Count].ToString();
        }

        public string Index(int i)
        {
            // specifický řádek tabulky
            return Get().Rows[i].ToString();
        }

        public int Length()
        {
            // počet řádků tabulky
            return Get().Rows.Count;
        }
    }
}