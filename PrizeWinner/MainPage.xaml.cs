using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PrizeWinner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
        }

        private void scrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Tick += (ss, ee) =>
            {
                if (timer.Interval.Ticks == 300)
                {
                    //each time set the offset to scrollviewer.HorizontalOffset + 5
                    scrollviewer.ScrollToHorizontalOffset(scrollviewer.HorizontalOffset + 5);
                    //if the scrollviewer scrolls to the end, scroll it back to the start.
                    if (scrollviewer.HorizontalOffset == scrollviewer.ScrollableWidth)
                        scrollviewer.ScrollToHorizontalOffset(0);
                }
            };
            timer.Interval = new TimeSpan(300);
            timer.Start();
        }

        private void scrollviewer_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
