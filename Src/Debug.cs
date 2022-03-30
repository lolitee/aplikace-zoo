using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo
{
    internal class Debug
    {
        public Debug(DB db)
        {
            

            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table")
                .Select()
                .Get().Tables[0].Rows[0]["Jmeno"].ToString()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select()
                .OrderBy("Prijmeni")
                .Get().Tables[0].ToString()
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
                .Get().Tables[0].ToString()
                );
            Console.WriteLine("----");
            Console.WriteLine(
                db.Query("Table").Select()
                .Where(Where.WHERE, "Jmeno", Operator.EQUALS, "David")
                .Where(Where.AND, "Prijmeni", Operator.EQUALS, "Kolacik")
                .Get().Tables[0].ToString()
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
                .Sql()
                );
            Console.WriteLine(
                db.Query("Table")
                .Insert("hi", "dwadw", "ww")
                .Values("ye", "eee", "2dasd")
                .Sql());
            Console.WriteLine(
                db.Query("Table")
                .Update("yeah", "no")
                .Set("chungus", "big big")
                .Sql()
                );
        }
    }
}
