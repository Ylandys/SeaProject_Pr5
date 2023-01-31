using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
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
            InitializeComponent();
            db = new StorageSeaEntities1();
            TableCars.ItemsSource = db.Clients.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            Button r1 = sender as Button;
            var r2 = r1.DataContext as Client;
            var r3 = new AddNewClient(db, r2);
            r3.ShowDialog();
            TableCars.ItemsSource = db.Clients.ToList();

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
                    //ЧТОО ПАСХАЛКА УЭНСДЕЙЙ???
                    refreshdatagrid();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void btn_AddClient(object sender, RoutedEventArgs e)
        {
            var NewDob = new Client();
            db.Clients.Add(NewDob);

            AddNewClient newClientWindow = new AddNewClient(db, NewDob);
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }

        private void refreshdatagrid()
        {
            TableCars.ItemsSource = db.Clients.ToList();
            TableCars.Items.Refresh();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Поиск
        }
    }
}
