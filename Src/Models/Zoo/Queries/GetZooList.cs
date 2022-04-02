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
            throw new NotImplementedException();
        }
    }
}
