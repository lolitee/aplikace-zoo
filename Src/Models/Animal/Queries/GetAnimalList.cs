using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Animal.Queries
{
    internal class GetAnimalList : IModel
    {
        public DataTable GetData(DB db)
        {
            return db.Query("Animal").Select().Get();
        }

        public DataTable GetSortedData(DB db, Sort method)
        {
            throw new NotImplementedException();
        }
    }
}
