using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Zoo.Models;
using Zoo.Models.Animal.Queries;
using Zoo.Models.Caregiver.Queries;
using Zoo.Models.Gender.Queries;
using Zoo.Models.Zoo.Queries;

namespace Zoo
{
    public partial class MainWindow : Window
    {
        private IModel model;

        private void RefreshListAddon() => ListAddonItems = model.GetSortedData(db, ComboFilter.Text.ToEnum<Sort>()).DefaultView;

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!db.TryConnection())
            {
                var log = new Logs(db.GetErrorMessage, out string file_path);
                MessageBox.Show("Couldn't open database! Shutting down.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.Start("notepad.exe", file_path);
                Close();
                return;
            }

#if DEBUG
            var timer = Debug.timer;
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Debug.Log($"Time to load: {timeTaken.ToString()}");
#endif

            using (var animal_data = new GetAnimalList())
            {
                ListMainItems = animal_data.GetData(db).DefaultView;
                ListAddonDisplay = animal_data.DisplayMemberPath;
            }
            using (var zoo_data = new GetZooList())
            {
                ComboZooItems = zoo_data.GetData(db).DefaultView;
                ComboZooDisplay = zoo_data.DisplayMemberPath;
            }
            using (var gender_data = new GetGenderList())
            {
                ComboGenderItems = gender_data.GetData(db).DefaultView;
                ComboGenderDisplay = gender_data.DisplayMemberPath;
            }
            using (var caregiver_data = new GetCaregiverList())
            {
                ComboCaregiverItems = caregiver_data.GetData(db).DefaultView;
                ComboCaregiverDisplay = caregiver_data.DisplayMemberPath;
            }

                DataContext = this;
        }

        private void ComboSwapper_DropDownClosed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ComboSwapper.Text)) return;

            ComboFilter.SelectedIndex = 0;

            switch (ComboSwapper.Text)
            {
                case "Caregiver":
                    model = new GetCaregiverList();
                    break;

                case "Gender":
                    model = new GetGenderList();
                    break;

                case "Zoo":
                    model = new GetZooList();
                    break;
            }
            using (var model_data = model)
            {
                ListAddonItems = model.GetData(db).DefaultView;
                ListAddonDisplay = model.DisplayMemberPath;
            }
        }

        private void ButtonFilter(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ComboSwapper.Text)) return;
            RefreshListAddon();
        }

        private void ListAddon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListAddon.SelectedItem == null) return;

            TextSelection.Text = ((DataRowView)ListAddon.SelectedItem)[1].ToString();
        }

        private void ButtonAddonDelete(object sender, RoutedEventArgs e)
        {
            if (ListAddon.SelectedItem == null) return;

            db.Query(model.TableName)
            .Delete()
            .Where(Where.WHERE, "ID", Operator.EQUALS, ((DataRowView)ListAddon.SelectedItem)[0].ToString())
            .GetNonQuery();

            RefreshListAddon();
        }

        private void ButtonAddonCreate(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddonUpdate(object sender, RoutedEventArgs e)
        {

        }
    }
}