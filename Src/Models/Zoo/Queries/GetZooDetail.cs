using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Zoo.Queries
{
    internal class GetZooDetail : IDetail
    {
        void IDisposable.Dispose() { }

        public string GetData(DB db, string value) => (string)db.Query("Zoo").Select().Where(Where.WHERE, "ID", Operator.EQUALS, value).First()[1];
    }
}
