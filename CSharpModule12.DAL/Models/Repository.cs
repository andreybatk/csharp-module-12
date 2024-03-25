using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CSharpModule12.DAL.Models
{
    public class Repository<T> where T : class
    {
        private string _path;

        public Repository(string path)
        {
            _path = path;
            Clients = new ObservableCollection<T>();
            CheckFileExists();
            Load();
        }

        public ObservableCollection<T> Clients { get; private set; }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Clients, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
        private void Load()
        {
            string json = File.ReadAllText(_path, Encoding.UTF8);

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            Clients = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
        }
        private void CheckFileExists()
        {
            if (!IsFileExists(_path))
            {
                FileStream fileStream = new FileStream(_path, FileMode.Create);
                fileStream.Close();
                Console.WriteLine($"Файла \"{_path}\" не существует. Файл был создан.");
            }
        }
        static bool IsFileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
