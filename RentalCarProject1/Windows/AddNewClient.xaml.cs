using RentalCarProject1.Resources;
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
    /// Логика взаимодействия для AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        RentalCarProjectEntities2 db;
        public AddNewClient()
        {
            InitializeComponent();
            db = new RentalCarProjectEntities2();
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private bool IsMaximized = true;

        private void Border_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 480;
                    this.Height = 684;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        private void btn_addClient(object sender, RoutedEventArgs e)
        {
            Car car= new Car();

            //Добавление вводимых данных в базу
            car.car_model= car_model.Text;
            car.car_color= car_color.Text;
            car.car_year= DateTime.Parse(car_year.Text);
            car.car_number = car_number.Text;

            MessageBox.Show("Машина успешно добавлена!");

            try
            {
                db.Cars.Add(car);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
