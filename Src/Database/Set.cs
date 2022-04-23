namespace Zoo.Database
{
    public partial class Query
    {
        // skládání stringu pro update v databázi
        public Query Set(params object[] values)
        {
            this.values = values;
            return this;
        }
    }
}