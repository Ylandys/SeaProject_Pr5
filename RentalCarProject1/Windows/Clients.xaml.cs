using System;
using System.Data;
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

            /*db = new StorageSeaEntities1();
            Car item = TableCars.SelectedItem as Car;

            Car car = db.Cars.Where(c => c.id_car == item.id_car).Single();

            car.car_model = (TableCars.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            car.car_color = (TableCars.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            car.car_year = DateTime.Parse((TableCars.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            car.car_number= (TableCars.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

            try
            {
                db.SaveChanges();
                refreshdatagrid();  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            */
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            

              /*  db = new RentalCarProjectEntities2();
                Car item = TableCars.SelectedItem as Car;
                try
                {
                    Car car = db.Cars.Where(c => c.id_car == item.id_car).Single();
                    db.Cars.Remove(car);
                    db.SaveChanges();

                    MessageBox.Show("Клиент успешно удалён!");
                    //Метод обновления таблицы после удаления
                    refreshdatagrid();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            */
        }

        private void btn_AddClient(object sender, RoutedEventArgs e)
        {

            AddNewClient newClientWindow = new AddNewClient();
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }
    }
}
