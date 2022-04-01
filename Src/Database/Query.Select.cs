using System;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Select(params string[] column)
        {
            string str = "";

            str = String.Join(", ", column);

            if (column.Length <= 0)
            {
                str = "*";
            }

            sql += $"SELECT {str} FROM [{this._TableName}] ";
            return this;
        }
    }
}