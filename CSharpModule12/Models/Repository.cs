using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpModule12.Models
{
    internal class Repository<T> where T : class
    {
        public Repository(string path)
        {
            this._path = path;
            this.Clients = new ObservableCollection<T>();
            CheckFileExists();
            LoadPersons();
        }
        public ObservableCollection<T> Clients { get; private set; }
        private string _path;

        public void SavePersons()
        {
            string json = JsonConvert.SerializeObject(this.Clients, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
        private void LoadPersons()
        {
            string json = File.ReadAllText(_path, Encoding.UTF8);

            if (string.IsNullOrEmpty(json)) 
            {
                return;
            }

            this.Clients = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
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
