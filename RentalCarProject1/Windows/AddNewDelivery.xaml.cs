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

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewDelivery.xaml
    /// </summary>
    public partial class AddNewDelivery : Window
    {
        public AddNewDelivery()
        {
            InitializeComponent();
        }

        private void btn_exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addDelivery(object sender, RoutedEventArgs e)
        {

        }
    }
}
