using System;
using Zoo.Database;

namespace Zoo.Models.Gender.Queries
{
    internal class GetGenderDetail : IDetail
    {
        void IDisposable.Dispose()
        {
        }

        public string GetData(DB db, string value) => (string)db.Query("Gender").Select().Where(Where.WHERE, "ID", Operator.EQUALS, value).First()[1];
    }
}