namespace Zoo.Database
{
    public partial class Query
    {
        public string Select(params string[] column)
        {
            string str = "";
            foreach (var item in column)
            {
                str += $"[{item}],";
            }

            str = str.Remove(str.Length - 1, 1);

            if (column.Length <= 0)
            {
                str = "*";
            }

            return $"SELECT {str} FROM {this._TableName}";
        }
    }
}