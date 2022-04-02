using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Caregiver.Queries
{
    internal class GetCaregiverList : IModel, IDisposable
    {
        void IDisposable.Dispose() { }
        public string DisplayMemberPath => "Caregiver";

        public DataTable GetData(DB db)
        {
            return db.Query("Caregiver").Select().Get();
        }

        public DataTable GetSortedData(DB db, Sort method)
        {
            switch (method)
            {
                case Sort.ID: return db.Query("Cavegiver").Select().Get();
                case Sort.Ascending: return db.Query("Caregiver").Select().OrderBy("Caregiver ASC").Get();
                case Sort.Descending: return db.Query("Caregiver").Select().OrderBy("Caregiver DESC").Get();
            }

            return null;
        }
    }
}
