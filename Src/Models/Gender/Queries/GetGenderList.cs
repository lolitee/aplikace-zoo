using System;
using System.Data;
using Zoo.Database;

namespace Zoo.Models.Gender.Queries
{
    internal class GetGenderList : IModel
    {
        void IDisposable.Dispose()
        {
        }

        public string DisplayMemberPath => "Gender";

        public string TableName => "Gender";

        public DataTable GetData(DB db)
        {
            return db.Query(TableName).Select().Get();
        }

        public DataTable GetSortedData(DB db, Sort method)
        {
            switch (method)
            {
                case Sort.ID: return db.Query(TableName).Select().Get();
                case Sort.Ascending: return db.Query(TableName).Select().OrderBy($"{TableName} ASC").Get();
                case Sort.Descending: return db.Query(TableName).Select().OrderBy($"{TableName} DESC").Get();
            }

            return null;
        }
    }
}