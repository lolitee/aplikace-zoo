using System;
using System.Diagnostics;
using Zoo.Database;

namespace Zoo
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly DB db;

        public MainWindow()
        {
            db = new DB($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Environment.CurrentDirectory}\db.mdf;Integrated Security=True;Connect Timeout=30");
#if DEBUG
            Debug.timer.Start();
            new Debug(db);
#endif
        }
    }
}