using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _Roulette007
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        SoundSettingsViewModel soundSettings = new SoundSettingsViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            //PlayBackgroundMusic();
        }

        private void PlayBackgroundMusic()
        {
            mediaPlayer.Open(new Uri(@"Resources\CasinoMusic.mp3", UriKind.Relative));
            mediaPlayer.Volume = 0.1;//soundSettings.Volume;
            mediaPlayer.Play();
        }
    }
}
