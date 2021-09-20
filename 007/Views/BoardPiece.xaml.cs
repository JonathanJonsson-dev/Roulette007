using _007.Data;
using _007.Models;
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
		
        public BetType Type
        {
            get { return (BetType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(BetType), typeof(BoardPiece), new PropertyMetadata(BetType.Straightup));



        public List<int> Numbers
        {
            get { return (List<int>)GetValue(NumbersProperty); }
            set { SetValue(NumbersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Numbers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumbersProperty =
            DependencyProperty.Register("Numbers", typeof(List<int>), typeof(BoardPiece), new PropertyMetadata(null));




        public int BoardPieceFontSize
        {
            get { return (int)GetValue(BoardPieceFontSizeProperty); }
            set { SetValue(BoardPieceFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoardPieceFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardPieceFontSizeProperty =
            DependencyProperty.Register("BoardPieceFontSize", typeof(int), typeof(BoardPiece), new PropertyMetadata(20));


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


        public string BoardPieceLabel
        {
            get { return (string)GetValue(BoardPieceLabelProperty); }
            set { SetValue(BoardPieceLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoardPieceLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardPieceLabelProperty =
            DependencyProperty.Register("BoardPieceLabel", typeof(string), typeof(BoardPiece), new PropertyMetadata("Custom Label Not Set, Check DependencyProperty BoardPieceLabelProperty in BoardPiece.xaml.cs"));
        

        public BoardPiece()
        {
            InitializeComponent();
        }
    }
}
