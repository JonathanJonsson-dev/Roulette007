﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _007.Views
{
    /// <summary>
    /// Interaction logic for UserMessenger.xaml
    /// </summary>
    public partial class UserMessenger : Window
    {
        public UserMessenger(string text, string title)
        {
            InitializeComponent();
            txbMessage.Text = text;
            lblTitle.Content = title;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
    }
}
