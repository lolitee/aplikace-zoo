using System;
using System.Data;
using Zoo.Database;

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
        void IDisposable.Dispose()
        {
        }

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

        public DataTable GetSortedData(DB db, Queries.Sort method, MainWindow form)
        {
            switch (method)
            {
                case Sort.ID: return db.Query("Animal").Select().Get();
                case Sort.Nazev: return db.Query("Animal").Select().Where(Where.WHERE, "Animal", Operator.EQUALS, form.TextName.Text).Get();
                case Sort.Latinsky: return db.Query("Animal").Select().Where(Where.WHERE, "Latin", Operator.EQUALS, form.TextLatin.Text).Get();
                case Sort.Prezdivka: return db.Query("Animal").Select().Where(Where.WHERE, "Nickname", Operator.EQUALS, form.TextNickname.Text).Get();
                case Sort.Id_Zvire: return db.Query("Animal").Select().Where(Where.WHERE, "AniID", Operator.EQUALS, form.TextAnimalID.Text).Get();
                case Sort.Narozeni:
                    if(form.DatePicker.DisplayDate == null)
                        return db.Query("Animal").Select().Where(Where.WHERE, "Birth", Operator.EQUALS, "").Get();
                    Console.WriteLine(form.DatePicker.DisplayDate.ToString("d"));
                    return db.Query("Animal").Select().Where(Where.WHERE, "Birth", Operator.EQUALS, form.DatePicker.DisplayDate.ToString("yyyy-MM-dd HH:mm:ss.fff")).Get();
                case Sort.Postizeni: return db.Query("Animal").Select().Where(Where.WHERE, "Disabled", Operator.EQUALS, ((bool)form.ComboMainYes.IsChecked).ToString().ToUpper()).Get();
                case Sort.Vaha: return db.Query("Animal").Select().Where(Where.WHERE, "Weight", Operator.EQUALS, form.TextWeight.Text).Get();
                case Sort.Pohlavi:
                    if (!form.ComboGender.Text.Equals(""))
                    {
                        var row = db.Query("Gender").Select().Where(Where.WHERE, "Gender", Operator.EQUALS, form.ComboGender.Text).First();
                        return db.Query("Animal").Select().Where(Where.WHERE, "IDGend", Operator.EQUALS, ((int)row[0]-1).ToString()).Get();
                    }
                    return db.Query("Animal").Select().Where(Where.WHERE, "IDGend", Operator.EQUALS, "").Get();
                case Sort.Pecovatel:
                    if (!form.ComboCaregiver.Text.Equals(""))
                    {
                        var row = db.Query("Caregiver").Select().Where(Where.WHERE, "Caregiver", Operator.EQUALS, form.ComboCaregiver.Text).First();
                        return db.Query("Animal").Select().Where(Where.WHERE, "IDCare", Operator.EQUALS, ((int)row[0]-1).ToString()).Get();
                    }
                    return db.Query("Animal").Select().Where(Where.WHERE, "IDCare", Operator.EQUALS, "").Get();
                case Sort.Zoo: 
                    if (!form.ComboZoo.Text.Equals(""))
                    {
                        var row = db.Query("Zoo").Select().Where(Where.WHERE, "Zoo", Operator.EQUALS, form.ComboZoo.Text).First();
                        Console.WriteLine(row[1].ToString());
                        return db.Query("Animal").Select().Where(Where.WHERE, "IDZoo", Operator.EQUALS, ((int)row[0] - 1).ToString()).Get();
                    }
                    return db.Query("Animal").Select().Where(Where.WHERE, "IDZoo", Operator.EQUALS, "").Get();
            }

            return null;
        }
    }
}