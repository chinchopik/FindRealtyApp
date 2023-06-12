using FindRealtyApp.Models;
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
using System.Windows.Shapes;

namespace FindRealtyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {

        public ReceiptWindow(Deal deal)
        {
            InitializeComponent();

            AddressBox.Text = deal.Address;
            ClientBox.Text = deal.Client;
            AgentBox.Text = deal.Agent;
            DateBox.Text = deal.Date.ToString();
            PriceBox.Text = deal.Price.ToString();
        }
    }
}
