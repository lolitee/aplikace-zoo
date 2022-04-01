﻿using System;
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

            DataContext = this;

            

        }

        private void ButtonFilter(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
