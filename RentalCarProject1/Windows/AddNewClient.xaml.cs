using System;
using System.Data.Entity.Validation;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Input;

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        StorageSeaEntities1 database;
        public AddNewClient(StorageSeaEntities1 db, Client reda1)
        {
            this.DataContext = reda1;
            this.database = db;
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Border_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
        }

        public void btn_addClient(object sender, RoutedEventArgs e)
        {

            try
            {
                database.SaveChanges();
                this.Close();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void btn_exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
//Sup :)