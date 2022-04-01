using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Caretaker.Queries
{
    internal class GetCaretakerList : IModel
    {
        public DataSet GetData(DB db)
        {
            throw new NotImplementedException();
        }

        public DataSet GetSortedData(DB db, Sort method)
        {
            throw new NotImplementedException();
        }
    }
}
