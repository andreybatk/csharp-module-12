using CSharpModule12.DAL.Enums;

namespace CSharpModule12.DAL.Models
{
    public class Consultant : Employee
    {
        public Consultant(string firstName2, string lastName) : base(EmployeeName.Consultant, firstName2, lastName)
        {
        }
    }
}
