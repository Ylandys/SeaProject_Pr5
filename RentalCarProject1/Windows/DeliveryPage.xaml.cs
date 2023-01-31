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
    /// Логика взаимодействия для DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        StorageSeaEntities1 db;
        public DeliveryPage()
        {
            InitializeComponent();
            db = new StorageSeaEntities1();
            TableDelivery.ItemsSource = db.Deliveries.ToList();
        }

        private void btn_AddDelivery(object sender, RoutedEventArgs e)
        {
            var NewDob = new Delivery();
            db.Deliveries.Add(NewDob);

            AddNewDelivery newClientWindow = new AddNewDelivery(db, NewDob);
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button r1 = sender as Button;
            var r2 = r1.DataContext as Delivery;
            var r3 = new AddNewDelivery(db, r2);
            r3.ShowDialog();
            TableDelivery.ItemsSource = db.Deliveries.ToList();

            refreshdatagrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            db = new StorageSeaEntities1();
            Delivery item = TableDelivery.SelectedItem as Delivery;
            try
            {
                Delivery _delivery = db.Deliveries.Where(d => d.id_delivery == item.id_delivery).Single();
                db.Deliveries.Remove(_delivery);
                db.SaveChanges();

                MessageBox.Show("Доставка успешно удалена!");
                //Метод обновления таблицы после удаления
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshdatagrid()
        {
            TableDelivery.ItemsSource = db.Deliveries.ToList();
            TableDelivery.Items.Refresh();
        }

    }
}
