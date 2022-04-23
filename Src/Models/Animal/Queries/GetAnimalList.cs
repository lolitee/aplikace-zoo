using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;
using Zoo.Models;

namespace Zoo.Models.Animal.Queries
{
    public enum Sort
    {
        ID,
        Nazev,
        Latinsky,
        Prezdivka,
        Id_Zvire,
        Narozeni,
        Postizeni,
        Vaha,
        Pohlavi,
        Pecovatel,
        Zoo,
    }
    public class GetAnimalList : IModel
    {
        void IDisposable.Dispose() { }
        public string DisplayMemberPath => "Animal";

        public string TableName => "Animal";

        public DataTable GetData(DB db)
        {
            return db.Query(TableName).Select().Get();
        }

        public DataTable GetSortedData(DB db, Models.Sort method)
        {
            switch (method)
            {
                case Models.Sort.ID: return db.Query("Animal").Select().Get();
                case Models.Sort.Ascending: return db.Query("Animal").Select().OrderBy("Animal ASC").Get();
                case Models.Sort.Descending: return db.Query("Animal").Select().OrderBy("Animal DESC").Get();
            }

            return null;
        }

        public DataTable GetSortedData(DB db, Queries.Sort method)
        {
            switch (method)
            {
                case Sort.ID: return db.Query("Animal").Select().Get();
                case Sort.Nazev: return db.Query("Animal").Select().OrderBy("Animal").Get();
                case Sort.Latinsky: return db.Query("Animal").Select().OrderBy("Latin").Get();
                case Sort.Prezdivka: return db.Query("Animal").Select().OrderBy("Nickname").Get();
                case Sort.Id_Zvire: return db.Query("Animal").Select().OrderBy("AniID").Get();
                case Sort.Narozeni: return db.Query("Animal").Select().OrderBy("Birth").Get();
                case Sort.Postizeni: return db.Query("Animal").Select().OrderBy("Disabled").Get();
                case Sort.Vaha: return db.Query("Animal").Select().OrderBy("Weight").Get();
                case Sort.Pohlavi: return db.Query("Animal").Select().OrderBy("IDGend").Get();
                case Sort.Pecovatel: return db.Query("Animal").Select().OrderBy("IDCare").Get();
                case Sort.Zoo: return db.Query("Animal").Select().OrderBy("IDZoo").Get();
            }

            return null;
        }
    }
}
