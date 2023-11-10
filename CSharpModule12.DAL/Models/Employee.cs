using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace CSharpModule12.DAL.Models
{
    public abstract class Employee : CustomNotifyPropertyChanged
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; }
        public EmployeeName JobTitle { get; private set; }
        public ObservableCollection<string> ChangesInfo { get { return _changesInfo; } private set { Set(ref _changesInfo, value); } }

        private static int _id;
        private ObservableCollection<string> _changesInfo;

        public enum EmployeeName
        {
            Consultant = 0,
            Manager = 1
        }
        public Employee(EmployeeName jobTitle, string firstName, string lastName)
        {
            this.JobTitle = jobTitle;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = NextId();
            this.ChangesInfo = new ObservableCollection<string>();
        }
        static Employee()
        {
            _id = 0;
        }

        public string DisplayEmployeeName()
        {
            return JobTitle.ToString();
        }
        public void TakeChangesInfo(string info)
        {
            this.ChangesInfo.Add(info);
        }
        private static int NextId() => _id++;
    }
}
