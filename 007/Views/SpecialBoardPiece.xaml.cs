using _007.Data;
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
    /// Interaction logic for SpecialBoardPiece.xaml
    /// </summary>
    public partial class SpecialBoardPiece : UserControl
    {
        public BetType BetType
        {
            get { return (BetType)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(BetType), typeof(SpecialBoardPiece), new PropertyMetadata(BetType.Column));

        public string BoardPieceLabel
        {
            get { return (string)GetValue(BoardPieceLabelProperty); }
            set { SetValue(BoardPieceLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoardPieceLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardPieceLabelProperty =
            DependencyProperty.Register("BoardPieceLabel", typeof(string), typeof(SpecialBoardPiece), new PropertyMetadata("Error"));

        public SolidColorBrush BoardPieceColor
        {
            get { return (SolidColorBrush)GetValue(BoardPieceColorProperty); }
            set { SetValue(BoardPieceColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoardPieceColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardPieceColorProperty =
            DependencyProperty.Register("BoardPieceColor", typeof(SolidColorBrush), typeof(SpecialBoardPiece), new PropertyMetadata(Brushes.Green));

        public SpecialBoardPiece()
        {
            InitializeComponent();
        }
    }
}
