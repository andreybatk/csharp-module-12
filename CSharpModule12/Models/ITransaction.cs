using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpModule12.Models
{
    internal interface ITransaction<T>
    {
        void MoneyTransfer(T taken, double money);
    }
}
