﻿using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _007.Views
{
    /// <summary>
    /// Interaction logic for WheelView.xaml
    /// </summary>
    public partial class WheelView : UserControl
    {
        public WheelView()
        {
            InitializeComponent();
            DataContext = new WheelViewModel();
        }
    }
}
