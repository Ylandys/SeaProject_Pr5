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

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddProducts(object sender, RoutedEventArgs e)
        {

        }
    }
}