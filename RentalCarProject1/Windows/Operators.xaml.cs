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

namespace RentalCarProject1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Operators.xaml
    /// </summary>
    public partial class Operators : Page
    {
        StorageSeaEntities1 db;
        public Operators()
        {
            db = new StorageSeaEntities1();
            InitializeComponent();
            TableOperators.ItemsSource = db.Operators.ToList();
        }

        private void btn_AddProducts(object sender, RoutedEventArgs e)
        {
            var NewDob = new Operator();
            db.Operators.Add(NewDob);

            AddNewOperator addNewOperator = new AddNewOperator(db, NewDob);
            addNewOperator.ShowDialog();

            refreshdatagrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button r1 = sender as Button;
            var r2 = r1.DataContext as Operator;
            var r3 = new AddNewOperator(db, r2);
            r3.ShowDialog();
            TableOperators.ItemsSource = db.Operators.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            db = new StorageSeaEntities1();
            Operator item = TableOperators.SelectedItem as Operator;

            try
            {
                Operator _operator = db.Operators.Where(o => o.id_operator == item.id_operator).Single();
                db.Operators.Remove(_operator);
                db.SaveChanges();

                MessageBox.Show("Клиент успешно удалён!");
                //Метод обновления таблицы после удаления
                refreshdatagrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshdatagrid()
        {
            TableOperators.ItemsSource = db.Operators.ToList();
            TableOperators.Items.Refresh();
        }
    }
}
