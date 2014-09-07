using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using CNCMatch.MyControls;

namespace CNCMatch
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();

            CNCButton startGame = new CNCButton();
            startGame.setButtonContent("Play");
            Canvas.SetLeft(startGame, 80);
            Canvas.SetTop(startGame, 120);
            startPageCanvas.Children.Add(startGame);
            startGame.Tap += startGame_Tap;

            CNCButton help = new CNCButton();
            help.setButtonContent("Help");
            Canvas.SetLeft(help, 80);
            Canvas.SetTop(help, 200);
            startPageCanvas.Children.Add(help);
            help.Tap += help_Tap;

            CNCButton about = new CNCButton();
            about.setButtonContent("About");
            Canvas.SetLeft(about, 80);
            Canvas.SetTop(about, 280);
            startPageCanvas.Children.Add(about);
            about.Tap += about_Tap;
        }

        void startGame_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
        }

        void help_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        void about_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }
       
    }
}