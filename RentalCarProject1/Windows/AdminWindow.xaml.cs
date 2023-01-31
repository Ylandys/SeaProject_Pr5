using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        //variables
        StorageSeaEntities1 database = new StorageSeaEntities1();
        public AdminWindow(string UserLogin, string Roles)
        {
            
            InitializeComponent();

            Name.Text += $"Имя: {UserLogin}";
            Role.Text += $"Роль: {Roles}";

            
            if (Roles == "Admin")
            {
                Image.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RentalCarProject1\\RentalCarProject1\\Resources\\software-engineer.png", UriKind.Absolute));
            }
            else if (Roles == "Manager")
            {
                Image.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RentalCarProject1\\RentalCarProject1\\Resources\\man.png", UriKind.Absolute));
            }
            else if (Roles == "User")
            {
                Image.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RentalCarProject1\\RentalCarProject1\\Resources\\user.png", UriKind.Absolute));
            }
            else
            {
                Image.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RentalCarProject1\\RentalCarProject1\\Resources\\unknown.png", UriKind.Absolute));
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if(IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;

                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized=true;
                }
            }
        }

        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainWindow MW = new MainWindow();
            MW.Show();
        }

        private void btn_Products_Click(object sender, RoutedEventArgs e)
        {
            string roles = Role.Text;

            if (roles == "Роль: Admin" || roles == "Роль: Manager")
            {
                Main.Content = new ProductsPage();
            }
            else
            {
                MessageBox.Show("Недостаточно прав для совершения этой операции!");
            }
        }

        private void btn_Storages_Click(object sender, RoutedEventArgs e)
        {
            string roles = Role.Text;

            if (roles == "Роль: Admin" || roles == "Роль: Manager")
            {
                Main.Content = new Storages();
            }
            else
            {
                MessageBox.Show("Недостаточно прав для совершения этой операции!");
            }
        }

        private void btn_Clients_Click(object sender, RoutedEventArgs e)
        {
            string roles = Role.Text;

            if (roles == "Роль: Admin" || roles == "Роль: Manager")
            {
                Main.Content = new Clients();
            }
            else
            {
                MessageBox.Show("Недостаточно прав для совершения этой операции!");
            }
        }

        private void btn_Delivery_Click(object sender, RoutedEventArgs e)
        {
            string roles = Role.Text;

            if (roles == "Роль: Admin")
            {
                Main.Content = new Delivery();
            }
            else
            {
                MessageBox.Show("Недостаточно прав для совершения этой операции!");
            }
        }

        private void btn_Operators_Click(object sender, RoutedEventArgs e)
        {
            string roles = Role.Text;

            if (roles == "Роль: Admin")
            {
                Main.Content = new Operators();
            }
            else
            {
                MessageBox.Show("Недостаточно прав для совершения этой операции!");
            }
        }
    }
}
