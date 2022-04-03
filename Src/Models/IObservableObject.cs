using System.ComponentModel;
using System.Runtime.CompilerServices;


/// <summary>
/// #if DEBUG
/// Debug.Log(propertyName);
/// #endif
/// PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
/// </summary>

namespace Zoo.Models
{
    internal interface IObservableObject
    {
        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}