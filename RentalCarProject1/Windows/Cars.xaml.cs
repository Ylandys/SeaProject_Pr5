using System;
using System.Collections.Generic;
using System.Data;
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
using RentalCarProject1;
using RentalCarProject1.Resources;
using RentalCarProject1.Windows;

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        RentalCarProjectEntities2 db;

        public Cars()
        {
            db = new RentalCarProjectEntities2();
            InitializeComponent();
            TableClients.ItemsSource = db.Cars.ToList();
            //Client c = new Client();
            //c.id_client;


            
            

        }

        private void refreshdatagrid()
        {
            TableClients.ItemsSource = db.Cars.ToList();
            TableClients.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            db = new RentalCarProjectEntities2();
            Car item = TableClients.SelectedItem as Car;

            Car car = db.Cars.Where(c => c.id_car == item.id_car).Single();

            car.car_model = (TableClients.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            car.car_color = (TableClients.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            car.car_year = DateTime.Parse((TableClients.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            car.car_number= (TableClients.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

            try
            {
                db.SaveChanges();
                refreshdatagrid();  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            

                db = new RentalCarProjectEntities2();
                Car item = TableClients.SelectedItem as Car;
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
            
        }

        private void btn_AddClient(object sender, RoutedEventArgs e)
        {

            AddNewClient newClientWindow = new AddNewClient();
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }
    }
}
