using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Animal.Commands
{
    internal class CreateAnimal : ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void IDisposable.Dispose() { }
        
        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
#if DEBUG
            Debug.Log(propertyName);
#endif
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
