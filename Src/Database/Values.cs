namespace Zoo.Database
{
    public partial class Query
    {
        public Query Values(params object[] values)
        {
            // skládání stringu pro update v databázi
            //sql += $"VALUES ({String.Join(", ", values.Select(x => $"'@{x}'"))})";
            this.values = values;
            return this;
        }
    }
}