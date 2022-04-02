namespace Zoo.Database
{
    public partial class Query
    {
        public Query Delete()
        {
            // mazání z tabulky
            sql += $"DELETE FROM {_TableName} ";
            return this;
        }
    }
}