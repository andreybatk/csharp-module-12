using CSharpModule12.DAL.Enums;

namespace CSharpModule12.DAL.Models
{
    public class Manager : Employee
    {
        public Manager(string firstName, string lastName) : base(EmployeeName.Manager, firstName, lastName)
        {
        }
    }
}
