using System;
using Zoo.Database;

namespace Zoo.Models.Zoo.Queries
{
    internal class GetZooDetail : IDetail
    {
        void IDisposable.Dispose()
        {
        }

        public string GetData(DB db, string value) => (string)db.Query("Zoo").Select().Where(Where.WHERE, "ID", Operator.EQUALS, value).First()[1];
    }
}