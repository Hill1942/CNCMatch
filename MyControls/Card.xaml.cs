using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;



namespace CNCMatch.MyControls
{
    public partial class Card : UserControl
    {
        private List<BitmapImage> cardImageList = new List<BitmapImage>();
        //用于表示卡片类的帧
        private int cardFrame;
        //用于表示卡片图像所在帧
        private int cardImageFrame;
        //建立时间轴系统
        private DispatcherTimer timeLine = new DispatcherTimer();

        public Card()
        {
            this.InitializeComponent();

            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDICardBG.png", UriKind.RelativeOrAbsolute)));

            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIArmadillo.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIBulldog.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIDozer.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIEngineer.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIFirehawk.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIHammerhead.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIJuggernaut.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIMammothTank.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIMastodon.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIOrca.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDISpanner.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDISpartanTank.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIStriker.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDITalon.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDIThunderhead.png", UriKind.RelativeOrAbsolute)));
            cardImageList.Add(new BitmapImage(new Uri("/Assets/Photos/GDI/GDITitan.png", UriKind.RelativeOrAbsolute)));
           // cardImageList.Add(new BitmapImage(new Uri("ms-appx:///Assets/Photos/GDI/GDIWolf.png")));
            //cardImageList.Add(new BitmapImage(new Uri("ms-appx:///Assets/Photos/GDI/GDIZoneDefender.png")));
            //cardImageList.Add(new BitmapImage(new Uri("ms-appx:///Assets/Photos/GDI/GDIZoneRaider.png")));
            //cardImageList.Add(new BitmapImage(new Uri("ms-appx:///Assets/Photos/GDI/GDIZoneTrooper.png")));



            timeLine.Tick += timeLine_Tick;
            timeLine.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timeLine.Start();
        }

        public void timeLine_Tick(object sender, object e)
        {
            this.cardImageContainer.Source = cardImageList[cardFrame];
            cardFrame++;
            cardFrame = cardFrame % 21;
        }

        //对每一个Card，我们设置它初始的图像（这个图像是由某个帧所决定的）
        public void setCardImageFrame(int frame)
        {
            cardImageFrame = frame;
        }
        public int getCardImageFrame()
        {
            return cardImageFrame;
        }

        public void stop()
        {
            timeLine.Stop();
        }
        public void gotoAndStop(int frame)
        {
            this.cardImageContainer.Source = cardImageList[frame];
            timeLine.Stop();
        }

        public void startFlip(int frame)
        {
            this.cardImageContainer.Source = cardImageList[frame];
            cardAnimationStoryboard.Begin();
        }
        public void disappear()
        {
            opacityAnimationStoryboard.Begin();
        }
    }
}
