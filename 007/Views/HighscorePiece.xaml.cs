using System;
using System.Windows;
using System.Windows.Controls;

namespace _007.Views
{
    /// <summary>
    /// Interaction logic for Highscore.xaml
    /// </summary>
    public partial class HighscorePiece : UserControl
    {
        public string PlayerName
        {
            get { return (string)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerNameProperty =
            DependencyProperty.Register("PlayerName", typeof(string), typeof(HighscorePiece), new PropertyMetadata("No Name Available check Highscore PlayerName prop"));

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Score.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(int), typeof(HighscorePiece), new PropertyMetadata(0));

        public HighscorePiece()
        {
            InitializeComponent();
        }
    }
}
