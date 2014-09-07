using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using CNCMatch.MyControls;


namespace CNCMatch
{
    public partial class GamePage : PhoneApplicationPage
    {
        private Card firstCard;
        private Card secondCard;
        private TimeBar timeBar;
        private DispatcherTimer timer = new DispatcherTimer();
        private int remainCard;

        public GamePage()
        {
            InitializeComponent();
            remainCard = 16;

            timeBar = new TimeBar();
            Canvas.SetLeft(timeBar, 30);
            Canvas.SetTop(timeBar, 450);
            gamePageCanvas.Children.Add(timeBar);


            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

            List<int> cardNumList = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                cardNumList.Add(i);
                cardNumList.Add(i);
            }

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Card card = new Card();
                    card.gotoAndStop(0);
                    Random ran = new Random();
                    int r = ran.Next(0, cardNumList.Count);
                    card.setCardImageFrame(cardNumList[r] + 1);
                    cardNumList.Remove(cardNumList[r]);
                    card.Tap += card_Tap;
                    Canvas.SetLeft(card, x * 80 + 30);
                    Canvas.SetTop(card, y * 90 + 50);
                    gamePageCanvas.Children.Add(card);
                }
            }
        }
        
        void card_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Card thisCard = (sender as Card);


            if (firstCard == null)
            {
                firstCard = thisCard;
                firstCard.startFlip(firstCard.getCardImageFrame());
            }
            else if (firstCard == thisCard)
            {
                firstCard.gotoAndStop(0);
                firstCard = null;
            }
            else if (secondCard == null)
            {
                secondCard = thisCard;
                secondCard.startFlip(secondCard.getCardImageFrame());
                if (firstCard.getCardImageFrame() == secondCard.getCardImageFrame())
                {
                    firstCard.disappear();
                    secondCard.disappear();

                    firstCard = null;
                    secondCard = null;
                    remainCard--;
                }
            }
            else
            {
                firstCard.startFlip(0);
                secondCard.startFlip(0);
                firstCard = null;
                secondCard = null;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (remainCard == 0)
            {
                timer.Tick -= timer_Tick;
                gamePageCanvas.Children.Remove(timeBar);
                NavigationService.Navigate(new Uri("/WinPage.xaml", UriKind.Relative));
            }

            else if (timeBar.getTimeBarWidth() == 0)
            {
                timer.Tick -= timer_Tick;
                gamePageCanvas.Children.Remove(timeBar);
                NavigationService.Navigate(new Uri("/DefeatPage.xaml", UriKind.Relative));
            }
        }
    }
}