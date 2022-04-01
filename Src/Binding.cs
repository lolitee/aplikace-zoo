using System;
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
        public DataView ListTables => db.ListTables().DefaultView;
        public IEnumerable<Sort> ListFilters => GetEnumValues<Sort>();

        private DataView _listAddonItems;
        public DataView ListAddonItems
        {
            get => _listAddonItems;
            set
            {
                if (_listAddonItems == value)
                {
                    _listAddonItems = value;
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
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
