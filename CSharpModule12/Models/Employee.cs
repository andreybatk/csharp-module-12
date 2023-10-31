using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using CSharpModule12.ViewModels.Base;

namespace CSharpModule12.Models
{
    internal abstract class Employee : ViewModel
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
            [Display(Name="Консультант")]
            Consultant = 0,
            [Display(Name = "Менеджер")]
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
            var EmployeeDisplayName = JobTitle.GetAttribute<DisplayAttribute>();

            return EmployeeDisplayName.Name;
        }
        public void TakeChangesInfo(string info)
        {
            this.ChangesInfo.Add(info);
        }
        private static int NextId() => _id++;
    }
    public static class Extensions
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
