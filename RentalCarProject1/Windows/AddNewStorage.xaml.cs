﻿using System;
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
    /// Логика взаимодействия для AddNewStorage.xaml
    /// </summary>
    public partial class AddNewStorage : Window
    {
        StorageSeaEntities1 database;
        public AddNewStorage(StorageSeaEntities1 db, Storage storage)
        {
            InitializeComponent();
            this.database = db;
            this.DataContext = storage;
        }

        private void AddStorageButton_Click(object sender, RoutedEventArgs e)
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
                        //Я ОБЯЗАТЕЛЬНО ВЫЖИВУ В ЭТОМ СЕМЕСТРЕ....
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
