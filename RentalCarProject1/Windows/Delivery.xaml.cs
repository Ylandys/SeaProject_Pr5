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

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {
        StorageSeaEntities1 db;
        public Delivery()
        {
            db = new StorageSeaEntities1();
            
            InitializeComponent();

            TableDelivery.ItemsSource = db.Deliveries.ToList();
        }

        private void btn_AddProducts(object sender, RoutedEventArgs e)
        {
            AddNewDelivery addNewDelivery = new AddNewDelivery();
            addNewDelivery.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_exitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
