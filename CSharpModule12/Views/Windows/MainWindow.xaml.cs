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
using CSharpModule12.ViewModels;

namespace CSharpModule12.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void dataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    _currentClient = dataGridClients.SelectedItem as Client;

        //    if (_currentClient.ClientBankAccount != null)
        //    {
        //        comboBoxCurrentBankAccount.ItemsSource = _currentClient.ClientBankAccount;
        //        comboBoxCurrentBankAccount.SelectedIndex = 0; // выбираем в combo box первый существующий счет
        //    }
        //}

        //private void comboBoxCurrentBankAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (comboBoxCurrentBankAccount.SelectedItem == null)
        //    {
        //        textBlockCurrentBankAccount.Text = "";
        //        return;
        //    }

        //    _currentCBankAccount = comboBoxCurrentBankAccount.SelectedItem as BankAccount;
        //    string statucBankAccount = _currentCBankAccount.IsOpen ? "Открыт" : "Закрыт";
        //    textBlockCurrentBankAccount.Text = 
        //        $"ID: {_currentCBankAccount.Id}\n" +
        //        $"Статус: {statucBankAccount}\n" +
        //        $"Колличество средств: {_currentCBankAccount.Money}";
        //}

        //private void openCloseBankAccount_Click(object sender, RoutedEventArgs e)
        //{
        //    if(_currentCBankAccount != null)
        //    {
        //        _currentCBankAccount.OpenOrCloseBankAccount(!_currentCBankAccount.IsOpen);
        //    }
        //}

        //private void addMoney_Click(object sender, RoutedEventArgs e)
        //{
        //    if (_currentCBankAccount != null)
        //    {
                
        //    }
        //}

        //private void transferMoney_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void addNewBankAccount_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
