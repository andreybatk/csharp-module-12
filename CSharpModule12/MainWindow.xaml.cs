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
        public MainWindow()
        {
            InitializeComponent();
            List<Client> clients = new List<Client>();

            for (int i = 0; i < 5; i++)
            {
                clients.Add(new Client($"Имя_{i}", $"Фамилия_{i}"));
            }
            clients[0].CreateBankAccount(2000);
            clients[1].CreateBankAccount(2000);

            dataGridClients.ItemsSource = clients;
        }
    }
}
