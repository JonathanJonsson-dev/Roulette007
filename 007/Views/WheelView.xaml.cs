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

            //DataContext = new WheelViewModel();

        }

      

        //private void SetAngle()
        //{
        //    double angle = 0.0;
        //    Transform transform = WheelSpin.RenderTransform;
        //    rotate = (RotateTransform);
        //    angle = rotate.Angle;
        //}


        //public void SpinWheel()
        //{


        //    W

        //    //Random angle generator
        //    Random angleGenerator = new Random();
        //    //spin wheel counter-clockwise
        //    WheelStopAngle = -1 * angleGenerator.Next(0, 361);
        //    //initialize Double Animation
        //    DoubleAnimation spinWheelAmination = new DoubleAnimation();
        //    spinWheelAmination.From = 0;
        //    spinWheelAmination.By = WheelStopAngle;
        //    spinWheelAmination.Duration = TimeSpan.FromSeconds(30); //duration of spin in seconds
        //    spinWheelAmination.RepeatBehavior = new RepeatBehavior(2);
        //    spinWheelAmination.FillBehavior = FillBehavior.HoldEnd;

        //    spinWheelAmination.SetValue(Storyboard.TargetProperty, view.WheelControl);
        //    spinWheelAmination.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath(RotateTransform.AngleProperty));
        //    //or
        //    //Storyboard.SetTargetName(spinWheelAmination, "WheelControl");
        //    //Storyboard.SetTargetProperty(spinWheelAmination, new PropertyPath(RotateTransform.AngleProperty));

        //    //Ball media element
        //    MediaElement ballMediaElement = new MediaElement();
        //    view.MainGrid.Children.Add(ballMediaElement); //add media to WheelView
        //    //ballMediaElement.LoadedBehavior = MediaState.Play;
        //    //ballMediaElement.UnloadedBehavior = MediaState.Stop;
        //    ballMediaElement.Volume = 2.0;
        //    //ballMediaElement.IsMuted = false;
        //    ballMediaElement.MediaOpened += new RoutedEventHandler(BallMediaElementMediaOpenedEventHandler);

        //    // Ball media timeline (sound).
        //    MediaTimeline ballRollingMediaTimeline = new MediaTimeline
        //    {
        //        FillBehavior = FillBehavior.Stop,
        //        BeginTime = new TimeSpan(0, 0, 0),
        //        Duration = new Duration(TimeSpan.FromSeconds(60)),
        //        Source = new Uri(@"C:\Users\HP\Source\Repos\SUP21_Grupp7\007\Views\Utilities\BallRolling.mp4"),
        //    };
        //    ballRollingMediaTimeline.SetValue(Storyboard.TargetProperty, ballMediaElement); //or
        //    //Storyboard.SetTarget(ballRollingMediaTimeline, ballMediaElement);


        //    //Storyboard
        //    Storyboard spinWheelStoryBoard = new Storyboard();
        //    spinWheelStoryBoard.Children.Add(spinWheelAmination); //add animation to storyboard    
        //    spinWheelStoryBoard.Children.Add(ballRollingMediaTimeline); //add media time line to storyboard
        //    spinWheelStoryBoard.SlipBehavior = SlipBehavior.Slip;
        //    //Start the storyboard Specifying a containing element
        //    spinWheelStoryBoard.Begin(view.WheelControl, true);

        //    //spinWheelStoryBoard.Completed += new EventHandler(WheelSpinStopped); 
        //    //check is clock created when storyboard began has finished executing the animation
        //    if (spinWheelStoryBoard.GetCurrentState(view.WheelControl) == ClockState.Stopped)
        //    {
        //        //Get winning number
        //        WinningNumber = DetermineWinningNumber(WheelStopAngle);

        //        //change IsWinningNumber to true for winning wheelPiece
        //        foreach (WheelPiece piece in WheelCollection)
        //        {
        //            if (piece.Number == WinningNumber)
        //            {
        //                piece.IsWinningNumber = true;
        //            }
        //        }
        //    }
        //}

    }
}
