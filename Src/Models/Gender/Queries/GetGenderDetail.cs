using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Gender.Queries
{
    internal class GetGenderDetail : IDetail
    {
        void IDisposable.Dispose() { }

        public string GetData(DB db, string value) => (string)db.Query("Gender").Select().Where(Where.WHERE, "ID", Operator.EQUALS, value).First()[1];
    }
}
