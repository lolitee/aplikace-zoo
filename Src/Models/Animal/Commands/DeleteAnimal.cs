using System;
using System.Runtime.CompilerServices;
using Zoo.Database;

namespace Zoo.Models.Animal.Commands
{
    internal class DeleteAnimal : ICommand
    {
        void IDisposable.Dispose()
        {
        }

        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            throw new NotImplementedException();
        }
    }
}