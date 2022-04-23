using System;
using Zoo.Database;

namespace Zoo.Models
{
    internal interface ICommand : IDisposable
    {
        void Execute(DB db);
    }
}