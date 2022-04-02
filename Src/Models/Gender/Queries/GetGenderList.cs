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
            throw new NotImplementedException();
        }
    }
}
