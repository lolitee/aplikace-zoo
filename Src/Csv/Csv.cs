using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace Zoo.Csv
{
    public class Csv
    {
        private Dictionary<string, List<string>> _value;

        public Dictionary<string, List<string>> Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Csv() => Value = new Dictionary<string, List<string>>();

        public void AddColumn(string key, string value)
        {
            if (!Value.ContainsKey(key))
                Value.Add(key, new List<string>());
            Value[key].Add(value);
        }

        public void Export()
        {
            try
            {
                string data = String.Join(";", Value.Select(c => c.Key).Distinct()) + "\n";
                int size = Value.ElementAt(0).Value.Count;
                int index = 0;

                while (index != size)
                {
                    List<string> temp = null;
                    foreach (var item in Value.Keys)
                    {
                        temp = new List<string>();
                        for (int i = 0; i < Value.Keys.Count; i++)
                        {
                            temp.Add(Value.ElementAt(i).Value[index]);
                        }
                    }
                    data += String.Join(";", temp) + "\n";
                    index++;
                }

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = Environment.CurrentDirectory;
                sf.Filter = "Csv file (*.csv)|*.csv";
                sf.Title = "Save";
                sf.FileName = $"zvirata-{DateTime.Now.ToString("F").Replace(':', '-')}";

                if ((bool)sf.ShowDialog())
                {
                    File.WriteAllText(sf.FileName, data, encoding: System.Text.Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pri ulozeni souboru!!!!!!");
                Debug.Log(ex.Message);
            }
        }
    }
}