using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using Zoo.Database;
using Zoo.Csv;
using Zoo.Models.Animal.Queries;
using Zoo.Models.Gender.Queries;
using Zoo.Models.Caregiver.Queries;
using Zoo.Models.Zoo.Queries;

namespace Zoo.Views
{
    /// <summary>
    /// Interaction logic for ExportToCsv.xaml
    /// </summary>
    public partial class Csv : Window
    {
        private GetAnimalList data { get; set; }
        private DB db { get; set; }

        public Csv(GetAnimalList data, DB db)
        {
            InitializeComponent();
            this.data = data;
            this.db = db;
        }

        // ((DataRowView)ListAddon.SelectedItem)[0].ToString()

        private void ExportButton(object sender, RoutedEventArgs e)
        {

            var item = data.GetData(db).AsEnumerable().ToList();
            var csv = new Zoo.Csv.Csv();

            for (int i = 0; i < item.Count; i++)
            {
                if ((bool)IdBox.IsChecked)
                    csv.AddColumn("ID", item[i][0].ToString());
                if ((bool)AnimalBox.IsChecked)
                    csv.AddColumn("Zvire", item[i][1].ToString());
                if ((bool)LatinBox.IsChecked)
                    csv.AddColumn("Latinsky nazev", item[i][2].ToString());
                if ((bool)NicknameBox.IsChecked)
                    csv.AddColumn("Prezdivka", item[i][3].ToString());
                if ((bool)AnimalIdBox.IsChecked)
                    csv.AddColumn("ID Zvire", item[i][4].ToString());
                if ((bool)BirthBox.IsChecked)
                    csv.AddColumn("Daturm narozeni", item[i][5].ToString());
                if ((bool)DisabledBox.IsChecked)
                    csv.AddColumn("Postizeni", item[i][6].ToString());
                if ((bool)WeightBox.IsChecked)
                    csv.AddColumn("Vaha", item[i][7].ToString());
                if ((bool)GenderBox.IsChecked)
                {
                    using (GetGenderDetail gender = new GetGenderDetail())
                    {
                        csv.AddColumn("Pohlavi", gender.GetData(db, item[i][8].ToString()));
                    }
                }
                if ((bool)CaregiverBox.IsChecked)
                {
                    using (GetCaregiverDetail caregiver = new GetCaregiverDetail())
                    {
                        csv.AddColumn("Pecovatel", caregiver.GetData(db, item[i][9].ToString()));
                    }
                }
                if ((bool)ZooBox.IsChecked)
                {
                    using (GetZooDetail zoo = new GetZooDetail())
                    {
                        csv.AddColumn("Pecovatel", zoo.GetData(db, item[i][10].ToString()));
                    }
                }
            }

            if (csv.Value.Count > 0)
            {
                csv.Export();
                MessageBox.Show("Ulozeno!");
                this.Close();
            }
            else
                MessageBox.Show("Vyberte moznosti!");
        }
    }
}