using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Zoo
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
#if DEBUG
            Debug.Log(propertyName);
#endif
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
#if DEBUG
            Debug.Log($"{propertyName} {value}");
#endif

            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void ValidateProperty<T>(T value, string name)
        {
#if DEBUG
            Debug.Log($"{value} {name}");
#endif
            // ignoruj exception nebo switching z debugu na release
            // https://files.loli.support/i/2i90k.mp4
            /*            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
                        {
                            MemberName = name
                        });*/
        }
    }
}