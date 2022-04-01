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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
