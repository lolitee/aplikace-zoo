using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Zoo.Database;

namespace Zoo.Models
{
    internal interface IModel : IDisposable
    {
        DataTable GetData(DB db);
        DataTable GetSortedData(DB db, Sort model);
        string DisplayMemberPath { get; }
        string TableName { get; }
    }
}
