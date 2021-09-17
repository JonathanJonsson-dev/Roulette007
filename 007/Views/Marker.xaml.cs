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
    /// Interaction logic for Marker.xaml
    /// </summary>
    public partial class Marker : UserControl
    {
        public Marker()
        {
            InitializeComponent();
        }


        public Color MarkerColor
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(Marker), new PropertyMetadata(Color.FromRgb(0,0,0)));


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Marker), new PropertyMetadata(0));

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(marker, new DataObject(DataFormats.Serializable, marker), DragDropEffects.Move);
            }
        }
    }
}
