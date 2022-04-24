using System.Collections.Generic;
using System.Data;
using Zoo.Models;
using static Zoo.Helper;

namespace Zoo
{
    public partial class MainWindow
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
        public IEnumerable<Sort> ListFiltersMain => (IEnumerable<Sort>)GetEnumValues<Zoo.Models.Animal.Queries.Sort>();

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
                if (_listMainItems != value)
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

        private DataView _listFilterItems;

        public DataView ListFilterItems
        {
            get => _listFilterItems;
            set
            {
                if (_listFilterItems != value)
                {
                    _listFilterItems = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _listFilterDisplay;

        public string ListFilterDisplay
        {
            get => _listFilterDisplay;
            set
            {
                if (_listFilterDisplay != value)
                {
                    _listFilterDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        private DataView _comboZooItems;

        public DataView ComboZooItems
        {
            get => _comboZooItems;
            set
            {
                if (_comboZooItems != value)
                {
                    _comboZooItems = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _comboZooDisplay;

        public string ComboZooDisplay
        {
            get => _comboZooDisplay;
            set
            {
                if (_comboZooDisplay != value)
                {
                    _comboZooDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        private DataView _comboGenderItems;

        public DataView ComboGenderItems
        {
            get => _comboGenderItems;
            set
            {
                if (_comboGenderItems != value)
                {
                    _comboGenderItems = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _comboGenderDisplay;

        public string ComboGenderDisplay
        {
            get => _comboGenderDisplay;
            set
            {
                if (_comboGenderDisplay != value)
                {
                    _comboGenderDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        private DataView _comboCaregiverItems;

        public DataView ComboCaregiverItems
        {
            get => _comboCaregiverItems;
            set
            {
                if (_comboCaregiverItems != value)
                {
                    _comboCaregiverItems = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _comboCaregiverDisplay;

        public string ComboCaregiverDisplay
        {
            get => _comboCaregiverDisplay;
            set
            {
                if (_comboCaregiverDisplay != value)
                {
                    _comboCaregiverDisplay = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}