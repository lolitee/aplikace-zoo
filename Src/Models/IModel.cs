using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Zoo.Database;

namespace Zoo.Models
{
    internal interface IModel
    {
        DataSet GetData(DB db);
        DataSet GetSortedData(DB db, Sort model);
    }
}
