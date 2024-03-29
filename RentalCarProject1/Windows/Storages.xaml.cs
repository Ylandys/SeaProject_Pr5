﻿using System;
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
    /// Логика взаимодействия для Storages.xaml
    /// </summary>
    public partial class Storages : Page
    {
        StorageSeaEntities1 db;
        public Storages()
        {
            db = new StorageSeaEntities1();
            InitializeComponent();
            TableStorages.ItemsSource = db.Storages.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            db = new StorageSeaEntities1();

            Storage item = TableStorages.SelectedItem as Storage;
            Storage storages = db.Storages.Where(c => c.id_storage == item.id_storage).Single();
            db.SaveChanges();
            refreshdatagrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            db = new StorageSeaEntities1();
            Storage item = TableStorages.SelectedItem as Storage;
            try
            {
                Storage storages = db.Storages.Where(c => c.id_storage == item.id_storage).Single();
                db.Storages.Remove(storages);
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

        private void btn_AddProducts(object sender, RoutedEventArgs e)
        {
            var NewDob = new Storage();
            db.Storages.Add(NewDob);

            AddNewStorage addNewStorage= new AddNewStorage(db, NewDob);
            addNewStorage.ShowDialog();

            refreshdatagrid();
        }

        private void refreshdatagrid()
        {
            TableStorages.ItemsSource = db.Storages.ToList();
            TableStorages.Items.Refresh();
        }
    }
}
