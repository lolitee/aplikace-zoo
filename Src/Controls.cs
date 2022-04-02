using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Zoo.Models;
using Zoo.Models.Animal.Queries;
using Zoo.Models.Caregiver.Queries;
using Zoo.Models.Gender.Queries;
using Zoo.Models.Zoo.Queries;

namespace Zoo
{
    public partial class MainWindow
    {

        IModel model;
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!db.TryConnection())
            {
                var log = new Logs(db.GetErrorMessage, out string file_path);
                MessageBox.Show("Couldn't open database! Shutting down.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.Start("notepad.exe", file_path);
                Close();
            }

            using (var animal_data = new GetAnimalList())
            {
                ListMainItems = animal_data.GetData(db).DefaultView;
                ListAddonDisplay = animal_data.DisplayMemberPath;
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
            ListAddonItems = model.GetSortedData(db, ComboFilter.Text.ToEnum<Sort>()).DefaultView;
        }

        private void ListAddon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListAddon.SelectedItem == null) return;

            TextSelection.Text = ((DataRowView)ListAddon.SelectedItem)[1].ToString();
        }
    }
}
