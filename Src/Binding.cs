using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using Zoo.Models;
using static Zoo.Helper;

namespace Zoo
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public DataView ListTables
        {
            get
            {
                DataTable data = db.ListTables();
                foreach (var item in data.Select("TABLE_NAME='Animal'"))
                    item.Delete();
                return data.DefaultView;
            }
        }
        public IEnumerable<Sort> ListFilters => GetEnumValues<Sort>();

        private DataView _listAddonItems;
        public DataView ListAddonItems
        {
            get => _listAddonItems;
            set
            {
                if (_listAddonItems != value)
                {
                    _listAddonItems = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _listAddonDisplay;
        public string ListAddonDisplay
        {
            get => _listAddonDisplay;
            set
            {
                if (_listAddonDisplay != value)
                {
                    _listAddonDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        private DataView _listMainItems;
        public DataView ListMainItems
        {
            get => _listMainItems;
            set
            {
                if(_listMainItems != value)
                {
                    _listMainItems = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _listMainDisplay;
        public string ListMainDisplay
        {
            get => _listMainDisplay;
            set
            {
                if (_listMainDisplay != value)
                {
                    _listMainDisplay = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
#if DEBUG
            Debug.Log(propertyName);
#endif
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
