namespace Zoo.Database
{
    public partial class Query
    {
        public Query Delete()
        {
            sql += $"DELETE FROM {_TableName} ";
            return this;
        }
    }
}