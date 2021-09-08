using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for BoardPiece.xaml
    /// </summary>
    public partial class BoardPiece : UserControl
    {
        public int Number { get; set; }

        public BoardPiece()
        {
            InitializeComponent();
        }
    }
}
