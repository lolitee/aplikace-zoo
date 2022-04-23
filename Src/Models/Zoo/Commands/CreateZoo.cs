using System;
using Zoo.Database;

namespace Zoo.Models.Zoo.Commands
{
    internal class CreateZoo : ICommand
    {
        void IDisposable.Dispose()
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }
    }
}