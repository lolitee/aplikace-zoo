using System;
using Zoo.Database;

namespace Zoo.Models
{
    internal interface IDetail : IDisposable
    {
        string GetData(DB db, string value);
    }
}