using System;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Select(params string[] column)
        {
            string str = "";
            foreach (var item in column)
            {
                str += $"[{item}],";
            }

            if (column.Length <= 0)
            {
                str = "*";
            }
            else
            {
                str = str.Remove(str.Length - 1, 1);
            }
            sql += $"SELECT {str} FROM [{this._TableName}] ";
            return this;
        }
    }
}