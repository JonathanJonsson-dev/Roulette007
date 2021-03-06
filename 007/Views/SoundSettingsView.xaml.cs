using _007.Models;
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
        SongCollection songCollection = new SongCollection();
        int currentTrackIndex = 0;

        public SoundSettingsView()
        {
            InitializeComponent();
            DataContext = new SoundSettingsViewModel();
            InitializePropertyValues();
            
        }
        /// <summary>
        /// Changes the media volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }
        /// <summary>
        /// Starts the backgroundmusic and if the media has ended the nextbutton clicks. 
        /// </summary>
        private void InitializePropertyValues()
        {
            myMediaElement.Source = songCollection.songs[0].Filepath; 
            myMediaElement.Play();
            myMediaElement.Volume = (double)volumeSlider.Value;
            myMediaElement.MediaEnded += NextBtn_Click;
        }
        /// <summary>
        /// Play next song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrackIndex >= songCollection.songs.Count - 1)
            {
                currentTrackIndex = 0;
            }
            else
            {
                currentTrackIndex += 1;
            }
            
            myMediaElement.Source = songCollection.songs[currentTrackIndex].Filepath;
            myMediaElement.Play();
            
        }
        /// <summary>
        /// Play previous song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrackIndex <= 0)
            {
                currentTrackIndex = songCollection.songs.Count - 1;
            }
            
            else
            {
                currentTrackIndex -= 1;
            }
            
            myMediaElement.Source = songCollection.songs[currentTrackIndex].Filepath;
            myMediaElement.Play();
        }
    }
}