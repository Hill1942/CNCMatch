using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace CNCMatch.MyControls
{
    public partial class CNCButton : UserControl
    {
        public CNCButton()
        {
            this.InitializeComponent();
            this.Tap += CNCButton_Tap;
        }


        void CNCButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //buttonImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Photos/ButtonBGLight.png"));
            buttonSound.Play();
        }

        public void setButtonContent(string buttonContent)
        {
            txt.Text = buttonContent;

        }
    }
}
