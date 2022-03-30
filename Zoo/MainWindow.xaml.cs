﻿using System;
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
            db = new DB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\škola\PGV4\Spolecna\Data\db.mdf;Integrated Security=True;Connect Timeout=30");
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select().Get()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select()
                .OrderBy("Prijmeni")
                .Get()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table")
                .Select("test", "test23", "test34")
                .Sql()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select()
                .Where(Where.WHERE, "Jmeno", Operator.EQUALS, "David")
                .Where(Where.OR, "Jmeno", Operator.EQUALS, "hate")
                .Get()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select()
                .Where(Where.WHERE, "Jmeno", Operator.EQUALS, "David")
                .Where(Where.AND, "Prijmeni", Operator.EQUALS, "Kolacik")
                .Get()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select()
                .Where(Where.WHERE, "Jmeno", Operator.IN, "David", "Tomas", "Pepa")
                .Sql()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table")
                .Insert("test", "asd", "wasd")
                .Values("test", "asd", "wasd")
                .Sql()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query()
                .Create(
                    "bigchungus",
                    new TableProperties
                    {
                        field = "test",
                        size = 20,
                        dataType = DataType.VARCHAR
                    },
                    new TableProperties
                    {
                        field = "yea",
                        dataType = DataType.INT,
                    },
                    new TableProperties
                    {
                        field = "noo",
                        dataType = DataType.BIGINT,
                        isNotNull = true,
                    })
                .GetNonQuery()
                );
            //Console.WriteLine(db.Query("Table").Update().Where());
        }
    }
}
