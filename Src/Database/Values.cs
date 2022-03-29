namespace Zoo.Database
{
    public partial class Query
    {
        public Query Values(params object[] values)
        {
            //sql += $"VALUES ({String.Join(", ", values.Select(x => $"'@{x}'"))})";
            this.values = values;
            return this;
        }
    }
}