using System;
using System.Collections.Generic;
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
            InitializeComponent();
            db = new DB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Martin\source\repos\lolitee\aplikace-zoo\databaze.mdf;Integrated Security=True;Connect Timeout=30");
#if DEBUG
            new Debug(db);
#endif
        }
    }
}
