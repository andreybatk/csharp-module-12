using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.Models;

namespace CSharpModule12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private Client _currentClient;
        private BankAccount _currentCBankAccount;
        private Repository _clients;
        private readonly string path = "clients.json";

        public MainWindowViewModel()
        {
            _clients = new Repository(path);

            //dataGridClients.ItemsSource = _clients.Clients;
        }
    }
}
