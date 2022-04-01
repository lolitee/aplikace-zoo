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
using Zoo.Animal.Queries;
using Zoo.Database;

namespace Zoo
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB db;
        bool isConnected = false;

        public MainWindow()
        {
            InitializeComponent();
            db = new DB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\db.mdf;Integrated Security=True;Connect Timeout=30");
            isConnected = db.TryConnection();
#if DEBUG
            new Debug(db);
            Console.WriteLine("Test");
#endif
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("Couldn't connect to the database!! Shutting down.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                new Logs(db.GetErrorMessage, out string file_path);
                Process.Start("notepad.exe", file_path);
                Close();
            }

            AnimalList.ItemsSource = new GetAnimalList().GetData(db).Tables;
        }
    }
}
