using System;
using Zoo.Database;

namespace Zoo.Models.Animal.Commands
{
    internal class CreateAnimal : ICommand
    {
        void IDisposable.Dispose()
        {
        }

        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }
    }
}