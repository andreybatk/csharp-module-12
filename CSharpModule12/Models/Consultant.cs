using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpModule12.Models
{
    internal class Consultant : Employee
    {
        public Consultant(EmployeeName jobTitle,string firstName, string lastName) : base(jobTitle, firstName, firstName) { }
    }
}
