using System;
using System.Data.SqlClient;

namespace Zoo.Database
{
    public class DB
    {
        protected string connection_string;
        public string GetErrorMessage { get; private set; }

        public DB(string connection_string)
        {
            this.connection_string = connection_string;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                GetErrorMessage = e.Message;
            }
            return conn;

        }

        public bool TryConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                GetErrorMessage = e.Message;
                return false;
            }
        }

        public Query Query(string table)
        {
            var qr = new Query(table);

            qr.Connection = CreateConnection();

            return qr;
        }

        public Query Query()
        {
            var qr = new Query();

            qr.Connection = CreateConnection();

            return qr;
        }
    }
}