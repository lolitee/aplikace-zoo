using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Gender.Queries
{
    internal class GetGenderList : IModel, IDisposable
    {
        void IDisposable.Dispose() { }
        public string DisplayMemberPath => "Gender";

        public DataTable GetData(DB db)
        {
            return db.Query("Gender").Select().Get();
        }

        public DataTable GetSortedData(DB db, Sort method)
        {
            switch (method)
            {
                case Sort.ID: return db.Query("Gender").Select().Get();
                case Sort.Ascending: return db.Query("Gender").Select().OrderBy("Gender ASC").Get();
                case Sort.Descending: return db.Query("Gender").Select().OrderBy("Gender DESC").Get();
            }

            return null;
        }
    }
}
