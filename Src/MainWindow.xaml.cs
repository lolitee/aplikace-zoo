using System;
using System.Collections.Generic;
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
using static Zoo.Helper;

namespace Zoo
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB db;

        public MainWindow()
        {
            
            db = new DB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Martin\source\repos\lolitee\aplikace-zoo\databaze.mdf;Integrated Security=True;Connect Timeout=30");
#if DEBUG
            new Debug(db);
            Console.WriteLine("Test");
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

            using (var swapper_data = db.Query("Table").Select().Get())
            {
                ComboSwapper.DisplayMemberPath = "Jmeno";
                ComboSwapper.ItemsSource = swapper_data.DefaultView;
                ComboSwapper.SelectedIndex = 0;
            }

            IModel model = new GetAnimalList();

            ComboFilter.ItemsSource = GetEnumValues<Sort>();
            ComboFilter.SelectedIndex = 0;
        }

        private void ButtonFilter(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
