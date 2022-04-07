using System;
using System.IO;

namespace Zoo
{
    public class Logs
    {
        string CurrentDir = Environment.CurrentDirectory;
        public Logs(string txt, out string file_path, string file_name = "Error")
        {
            string path = $@"{CurrentDir}\{file_name}-{DateTime.Now:fffffff}.log";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"[{DateTime.Now:T}]: {txt}");
            }
            file_path = path;
        }
    }
}
