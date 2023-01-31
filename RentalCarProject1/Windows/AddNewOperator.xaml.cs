using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddNewOperator.xaml
    /// </summary>
    public partial class AddNewOperator : Window
    {
        StorageSeaEntities1 database;
        public AddNewOperator(StorageSeaEntities1 db, Operator _operator)
        {
            InitializeComponent();
            this.database = db;
            this.DataContext = _operator;
        }

        private void AddOperatorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                database.SaveChanges();
                this.Close();
                //How are u today, Elizabeth/Pavel, who read that(right now :3 )?
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
