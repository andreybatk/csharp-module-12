using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpModule12.Models
{
    internal abstract class Employee
    {
        public enum EmployeeName
        {
            Consultant,
            Manager
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; }
        public EmployeeName JobTitle { get; private set; }
        private static int _id;

        public Employee(EmployeeName jobTitle, string firstName, string lastName)
        {
            this.JobTitle = jobTitle;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = NextId();
        }
        static Employee()
        {
            _id = 0;
        }

        private static int NextId() => _id++;
    }
}
