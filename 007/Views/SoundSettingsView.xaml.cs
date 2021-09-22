using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _007.Views
{
    /// <summary>
    /// Interaction logic for SoundSettingsView.xaml
    /// </summary>
    public partial class SoundSettingsView : UserControl
    {
        public SoundSettingsView()
        {
            InitializeComponent();
            DataContext = new SoundSettingsViewModel();
            InitializePropertyValues();
            
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }

        private void InitializePropertyValues()
        {
            myMediaElement.Play();
            myMediaElement.Volume = (double)volumeSlider.Value;
        }
    }
}
