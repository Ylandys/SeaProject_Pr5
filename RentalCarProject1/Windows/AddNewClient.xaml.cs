using System;
using System.Windows;
using System.Windows.Input;

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        StorageSeaEntities1 db;
        public AddNewClient()
        {
            InitializeComponent();
            db = new StorageSeaEntities1();
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
           /* Car car= new Car();

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
           */
        }

        private void btn_exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
