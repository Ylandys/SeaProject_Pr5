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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        StorageSeaEntities1 db;
        public ProductsPage()
        {
            db = new StorageSeaEntities1();
            InitializeComponent();
            TableProducts.ItemsSource = db.Products.ToList();

        }

        private void btn_AddProducts(object sender, RoutedEventArgs e)
        {
            var NewDob = new Product();
            db.Products.Add(NewDob);

            AddNewProduct newClientWindow = new AddNewProduct(db, NewDob);
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button r1 = sender as Button;
            var r2 = r1.DataContext as Product;
            var r3 = new AddNewProduct(db, r2);
            r3.ShowDialog();
            TableProducts.ItemsSource = db.Products.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            db = new StorageSeaEntities1();
            Product item = TableProducts.SelectedItem as Product;
            try
            {
                Product _product = db.Products.Where(d => d.id_product == item.id_product).Single();
                db.Products.Remove(_product);
                db.SaveChanges();

                MessageBox.Show("Товар успешно удалён!");
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

                //Метод обновления таблицы после удаления
        private void refreshdatagrid()
        {
            TableProducts.ItemsSource = db.Products.ToList();
            TableProducts.Items.Refresh();
        }
    }
}
