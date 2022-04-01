using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Continent.Queries
{
    internal class GetContinentList : IModel
    {
        public DataSet GetData(DB db)
        {
            throw new NotImplementedException();
        }

        public DataSet GetSortedData(DB db, Sort method)
        {
            switch (method)
            {
                case Sort.Ascending:
                    break;
                case Sort.Descending:
                    break;
                case Sort.Id:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
