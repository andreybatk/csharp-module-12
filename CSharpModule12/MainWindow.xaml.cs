using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpModule12
{
    public partial class MainWindow : Window
    {
        private Client _currentClient;
        private BankAccount _currentCBankAccount;
        private Repository _clients;
        private readonly string path = "clients.json";
        public MainWindow()
        {
            InitializeComponent();
            _clients = new Repository(path);

            dataGridClients.ItemsSource = _clients.Clients;
        }

        private void dataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentClient = dataGridClients.SelectedItem as Client;

            if (_currentClient.ClientBankAccount != null)
            {
                comboBoxCurrentBankAccount.ItemsSource = _currentClient.ClientBankAccount;
                comboBoxCurrentBankAccount.SelectedIndex = 0; // выбираем в combo box первый существующий счет
            }
        }

        private void comboBoxCurrentBankAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCurrentBankAccount.SelectedItem == null)
            {
                textBlockCurrentBankAccount.Text = "";
                return;
            }

            _currentCBankAccount = comboBoxCurrentBankAccount.SelectedItem as BankAccount;
            string statucBankAccount = _currentCBankAccount.IsOpen ? "Открыт" : "Закрыт";
            textBlockCurrentBankAccount.Text = 
                $"ID: {_currentCBankAccount.Id}\n" +
                $"Статус: {statucBankAccount}\n" +
                $"Колличество средств: {_currentCBankAccount.Money}";
        }
    }
}
