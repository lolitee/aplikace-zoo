using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Zoo.Queries
{
    internal class GetZooList : IModel
    {
        void IDisposable.Dispose() { }
        public string DisplayMemberPath => "Zoo";

        public DataTable GetData(DB db)
        {
            return db.Query("Zoo").Select().Get();
        }

        public DataTable GetSortedData(DB db, Sort method)
        {
            switch (method)
            {
                case Sort.ID: return db.Query("Zoo").Select().OrderBy("ID").Get();
                case Sort.Ascending: return db.Query("Zoo").Select().OrderBy("Zoo ASC").Get();
                case Sort.Descending: return db.Query("Zoo").Select().OrderBy("Zoo DESC").Get();
            }

            return null;
        }
    }
}
