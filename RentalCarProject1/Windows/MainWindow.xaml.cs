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
using MaterialDesignThemes.Wpf;
using RentalCarProject1.Resources;
using RentalCarProject1.Windows;

namespace RentalCarProject1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //EntitnyConnection
        RentalCarProjectEntities2 database = new RentalCarProjectEntities2(); //вот это пиши так же
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = new Roles();
            //Variables
            var login = UserName.Text; //это пиши
            var pass= UserPass.Password; //это пиши

            if (database.Clients.Any(u => u.client_name == login && u.client_passport_number == pass)) //это
            {

                foreach (var client in database.Clients) //это
                {
                    if (client.client_name == login) //измени тут на if(client.Логин == login && client.Пароль == pass)
                                                     //{
                                                           // this.Visibility = Visibility.Collapsed;
                                                           //тут админ виндов - следуещее окно так что там хз какое у тебя пропиши сам
                                                            //AdminWindow administratorWindow = new AdminWindow();
                                                            //administratorWindow.Show();
                                                      //}
                    {
                        if (client.client_passport_number == pass)
                        {
                            var role = database.Roles.Find(client.client_role);

                            roles.UserLogin = login;
                            roles.UserRole = role.Role1;
                            this.Visibility = Visibility.Collapsed;
                            AdminWindow administratorWindow = new AdminWindow(roles.UserLogin, roles.UserRole);
                            administratorWindow.Show();                     


                        }
                        else //это
                        {
                            MessageBox.Show("Вы ввели неправильный пароль"); //это
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Пользователь не найден :с");
            }
        }

        private void helpMe(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Иди нахуй кто тебе поможет? Дебил блять...");
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            string UserLogin = "Гость";
            string UserRole = "Гость";
            AdminWindow administratorWindow = new AdminWindow(UserLogin, UserRole);
            administratorWindow.Show();
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
                    this.Width = 400;
                    this.Height = 710;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }
    }
}

