using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Animal.Queries
{
    public class GetAnimalList
    {
        public DataSet GetData(DB db)
        {
            return db.Query("Zvire")
                .Select("Zvire")
                .Get();
        }

/*        public DataSet QuerySorted(DB db, string table_name)
        {

        }*/
    }
}
