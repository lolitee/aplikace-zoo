using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo.Database;
using Zoo.Models;
using Zoo.Models.Animal.Queries;
using Zoo.Models.Caregiver.Queries;
using Zoo.Models.Gender.Queries;
using Zoo.Models.Zoo.Queries;
using static Zoo.Helper;

namespace Zoo
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB db;
        IModel model;

        public MainWindow()
        {
            db = new DB($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Environment.CurrentDirectory}\db.mdf;Integrated Security=True;Connect Timeout=30");
#if DEBUG
            new Debug(db);
#endif
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!db.TryConnection())
            {
                var log = new Logs(db.GetErrorMessage, out string file_path);
                MessageBox.Show("Couldn't open database! Shutting down.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.Start("notepad.exe", file_path);
                Close();
            }

            using (var animal_data = new GetAnimalList())
            {
                ListMainItems = animal_data.GetData(db).DefaultView;
                ListAddonDisplay = animal_data.DisplayMemberPath;
            }

            DataContext = this;

        }

        private void ComboSwapper_DropDownClosed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ComboSwapper.Text)) return;

            ComboFilter.SelectedIndex = 0;

            switch (ComboSwapper.Text)
            {
                case "Caregiver":
                    model = new GetCaregiverList();
                    break;
                case "Gender":
                    model = new GetGenderList();
                    break;
                case "Zoo":
                    model = new GetZooList();
                    break;
            }
            using (var model_data = model)
            {
                ListAddonItems = model.GetData(db).DefaultView;
                ListAddonDisplay = model.DisplayMemberPath;
            }
        }
        private void ButtonFilter(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ComboSwapper.Text)) return;
            ListAddonItems = model.GetSortedData(db, ComboFilter.Text.ToEnum<Sort>()).DefaultView;
        }
    }
}
