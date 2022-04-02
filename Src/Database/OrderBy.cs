using System;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query OrderBy(params string[] columns)
        {
            // Sortovací mechanizmus
            string str = "";
            foreach (var item in columns)
            {
                str += item + ",";
            }

            sql += "ORDER BY " + String.Join(", ", columns);

            return this;
        }
    }
}