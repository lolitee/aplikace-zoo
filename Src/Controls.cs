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
using System.Text.RegularExpressions;
using System.Windows.Input;
using Zoo.Views;

namespace Zoo
{
    public partial class MainWindow : Window
    {
        private IModel model;

        private void RefreshListAddon()
        {
            using (var model_data = model)
            {
                ListAddonItems = model.GetData(db).DefaultView;
                ListAddonDisplay = model.DisplayMemberPath;
            }
            ListAddonItems = model.GetSortedData(db, ComboFilter.Text.ToEnum<Sort>()).DefaultView;
            RefreshData();
        }

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
            Debug.Log($"Time to load: {timeTaken}");
#endif

            RefreshData();

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
            if (TextSelection.Text.Equals("") || model == null)
                return;

            db.Query(model.TableName)
                .Insert(model.DisplayMemberPath)
                .Values(TextSelection.Text)
                .GetNonQuery();

            RefreshListAddon();
        }

        private void ButtonAddonUpdate(object sender, RoutedEventArgs e)
        {
            if (TextSelection.Text.Equals("") || model == null || ListAddon.SelectedItem == null)
                return;
        
            db.Query(model.TableName)
                .Update(model.DisplayMemberPath)
                .Set(TextSelection.Text)
                .Where(Where.WHERE, "ID", Operator.EQUALS, ((DataRowView)ListAddon.SelectedItem)[0].ToString())
                .GetNonQuery();

            RefreshListAddon();
        }

        private void ListMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMain.SelectedItem == null) return;
            TextName.Text = ((DataRowView)ListMain.SelectedItem)[1].ToString();
            TextLatin.Text = ((DataRowView)ListMain.SelectedItem)[2].ToString();
            TextNickname.Text = ((DataRowView)ListMain.SelectedItem)[3].ToString();
            TextAnimalID.Text = ((DataRowView)ListMain.SelectedItem)[4].ToString();
            DatePicker.Text = ((DataRowView)ListMain.SelectedItem)[5].ToString();

            if((bool)((DataRowView)ListMain.SelectedItem)[6])
                ComboMainYes.IsChecked = true;
            else
                ComboMainNo.IsChecked = true;

            TextWeight.Text = ((DataRowView)ListMain.SelectedItem)[7].ToString();

            ComboZoo.SelectedIndex = (int)((DataRowView)ListMain.SelectedItem)[8];
            ComboGender.SelectedIndex = (int)((DataRowView)ListMain.SelectedItem)[9];
            ComboCaregiver.SelectedIndex = (int)((DataRowView)ListMain.SelectedItem)[10];

        }

        // vytvorit
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TextName.Text.Equals("")
                || TextLatin.Text.Equals("")
                || TextAnimalID.Text.Equals("")
                || DatePicker.Equals("")
                || ComboZoo.SelectedIndex == -1
                || ComboGender.SelectedIndex == -1
                || ComboCaregiver.SelectedIndex == - 1)
            {
                MessageBox.Show("Neplatny udaj");
                return;
            }

            db.Query("Animal")
                .Insert("Animal", "Latin", "Nickname", "AniID", "Birth", "Disabled", "Weight", "IDGend", "IDCare", "IDZoo")
                .Values(TextName.Text,
                        TextLatin.Text,
                        TextNickname.Text,
                        TextAnimalID.Text,
                        DatePicker.SelectedDate.Value.Date,
                        ComboMainYes.IsChecked,
                        TextWeight.Text,
                        ComboZoo.SelectedIndex,
                        ComboGender.SelectedIndex,
                        ComboCaregiver.SelectedIndex)
                .GetNonQuery();

            RefreshData();
        }

        // upravit
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ListMain.SelectedIndex == -1) return;

            if (TextName.Text.Equals("")
            || TextLatin.Text.Equals("")
            || TextAnimalID.Text.Equals("")
            || DatePicker.Equals("")
            || ComboZoo.SelectedIndex == -1
            || ComboGender.SelectedIndex == -1
            || ComboCaregiver.SelectedIndex == -1)
            {
                MessageBox.Show("Neplatny udaj");
                return;
            }

            db.Query("Animal")
                .Update("Animal", "Latin", "Nickname", "AniID", "Birth", "Disabled", "Weight", "IDGend", "IDCare", "IDZoo")
                .Set(TextName.Text,
                        TextLatin.Text,
                        TextNickname.Text,
                        TextAnimalID.Text,
                        DatePicker.SelectedDate.Value.Date,
                        ComboMainYes.IsChecked,
                        TextWeight.Text,
                        ComboZoo.SelectedIndex,
                        ComboGender.SelectedIndex,
                        ComboCaregiver.SelectedIndex)
                .Where(Where.WHERE, "ID", Operator.EQUALS, ((DataRowView)ListMain.SelectedItem)[0].ToString())
                .GetNonQuery();

            using (var animal_data = new GetAnimalList())
            {
                ListMainItems = animal_data.GetData(db).DefaultView;
                ListMainDisplay = animal_data.DisplayMemberPath;
            }
        }

        // smazat
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ListMain.SelectedIndex == -1) return;

            db.Query("Animal")
                .Delete()
                .Where(Where.WHERE, "ID", Operator.EQUALS, ((DataRowView)ListMain.SelectedItem)[0].ToString())
                .GetNonQuery();

            RefreshData();
        }

        public void RefreshData()
        {
            using (var animal_data = new GetAnimalList())
            {
                ListMainItems = animal_data.GetData(db).DefaultView;
                ListMainDisplay = animal_data.DisplayMemberPath;
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
        }
        private void ExportButton(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var animal_data = new GetAnimalList())
            {
                Views.Csv view = new Views.Csv(animal_data, this.db);
                view.ShowDialog();
            }
        }
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}