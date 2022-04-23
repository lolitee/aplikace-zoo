using System;
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