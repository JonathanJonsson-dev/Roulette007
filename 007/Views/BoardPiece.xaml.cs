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


        public int BoardPieceNumber
        {
            get { return (int)GetValue(BoardPieceNumberProperty); }
            set { SetValue(BoardPieceNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoardPieceNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardPieceNumberProperty =
            DependencyProperty.Register("BoardPieceNumber", typeof(int), typeof(BoardPiece), new PropertyMetadata(0));

        public SolidColorBrush BoardPieceColor
        {
            get { return (SolidColorBrush)GetValue(BoardPieceColorProperty); }
            set { SetValue(BoardPieceColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoardPieceColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardPieceColorProperty =
            DependencyProperty.Register("BoardPieceColor", typeof(SolidColorBrush), typeof(BoardPiece), new PropertyMetadata(Brushes.Red));

        public BoardPiece()
        {
            InitializeComponent();
        }
    }
}
