using System.Linq;
using System.Windows;
using System.Windows.Input;
using RentalCarProject1.Windows;

namespace RentalCarProject1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //EntitnyConnection
        StorageSeaEntities1 database = new StorageSeaEntities1();
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
            var login = UserName.Text; 
            var pass= UserPass.Password;

            if (database.Operators.Any(u => u.operator_login == login && u.operator_password == pass)) 
            {

                foreach (var _operator in database.Operators)
                {
                    if (_operator.operator_login == login)
                    {
                        if (_operator.operator_password == pass)
                        {
                            var role = database.Roles.Find(_operator.role_id);

                            roles.UserLogin = login;
                            roles.UserRole = role.role_name;
                            this.Visibility = Visibility.Collapsed;
                            AdminWindow administratorWindow = new AdminWindow(roles.UserLogin, roles.UserRole);
                            administratorWindow.Show();                     


                        }
                        else //exc
                        {
                            MessageBox.Show("Вы ввели неправильный пароль");
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
            MessageBox.Show("Ты можешь помочь сам себе(Вообще посмотри в коде я оставил записки - комментариями)");
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
            //I wanna die...
        }
    }
}

