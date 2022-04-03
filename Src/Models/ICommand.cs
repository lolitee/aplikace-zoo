using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models
{
    internal interface ICommand : IDisposable
    {
        void Execute(DB db);
    }
}
