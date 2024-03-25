using CSharpModule12.DAL.Enums;
using System.Collections.ObjectModel;

namespace CSharpModule12.DAL.Models
{
    public abstract class Employee : CustomNotifyPropertyChanged
    {
        private static int _id;
        private ObservableCollection<string> _changesInfo;

        public Employee(EmployeeName jobTitle, string firstName, string lastName)
        {
            JobTitle = jobTitle;
            FirstName = firstName;
            LastName = lastName;
            Id = NextId();
            ChangesInfo = new ObservableCollection<string>();
        }
        static Employee()
        {
            _id = 0;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; }
        public EmployeeName JobTitle { get; private set; }
        public ObservableCollection<string> ChangesInfo { get { return _changesInfo; } private set { Set(ref _changesInfo, value); } }

        public void TakeChangesInfo(string info)
        {
            ChangesInfo.Add(info);
        }
        public string DisplayEmployeeName()
        {
            return JobTitle.ToString();
        }
        private static int NextId() => _id++;
    }
}
