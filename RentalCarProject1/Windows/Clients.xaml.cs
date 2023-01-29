using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Clients : Page
    {
        StorageSeaEntities1 db;

        public Clients()
        {
            db = new StorageSeaEntities1();
            InitializeComponent();
            TableCars.ItemsSource = db.Clients.ToList();
        }

        private void refreshdatagrid()
        {
            TableCars.ItemsSource = db.Clients.ToList();
            TableCars.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            Button reda = sender as Button;
            var reda1 = reda.DataContext as Client;

            AddNewClient newClientWindow = new AddNewClient(database, reda1);
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            

                db = new StorageSeaEntities1();
                Client item = TableCars.SelectedItem as Client;
                try
                {
                    Client client = db.Clients.Where(c => c.id_client == item.id_client).Single();
                    db.Clients.Remove(client);
                    db.SaveChanges();

                    MessageBox.Show("Клиент успешно удалён!");
                    //Метод обновления таблицы после удаления
                    refreshdatagrid();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void btn_AddClient(object sender, RoutedEventArgs e)
        {

            AddNewClient newClientWindow = new AddNewClient();
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }
    }
}
