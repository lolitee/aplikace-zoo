using System;
using Zoo.Database;

namespace Zoo.Models.Caregiver.Queries
{
    internal class GetCaregiverDetail : IDetail
    {
        void IDisposable.Dispose()
        {
        }

        public string GetData(DB db, string value) => (string)db.Query("Caregiver").Select().Where(Where.WHERE, "ID", Operator.EQUALS, value).First()[1];
    }
}