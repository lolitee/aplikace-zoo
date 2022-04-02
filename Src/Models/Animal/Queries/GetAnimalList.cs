using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Animal.Queries
{
    internal class GetAnimalList : IModel, IDisposable
    {
        void IDisposable.Dispose() { }
        public string DisplayMemberPath => "Animal";

        public string TableName => "Animal";

        public DataTable GetData(DB db)
        {
            return db.Query(TableName).Select().Get();
        }

        public DataTable GetSortedData(DB db, Sort method)
        {
            switch (method)
            {
                case Sort.ID: return db.Query("Animal").Select().Get();
                case Sort.Ascending: return db.Query("Animal").Select().OrderBy("Animal ASC").Get();
                case Sort.Descending: return db.Query("Animal").Select().OrderBy("Animal DESC").Get();
            }

            return null;
        }
    }
}
