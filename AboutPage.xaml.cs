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
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            this.InitializeComponent();
            /*
            CNCButton returnStartPage = new CNCButton();
            returnStartPage.setButtonContent("Return");
            Canvas.SetLeft(returnStartPage, 80);
            Canvas.SetTop(returnStartPage, 650);
            aboutPageCanvas.Children.Add(returnStartPage);
            aboutPageCanvas.Tap += aboutPageCanvas_Tap;*/
        }
        /*
        void aboutPageCanvas_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.GoBack();
        }*/

    }
}