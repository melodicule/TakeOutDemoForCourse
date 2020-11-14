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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace TakeoutDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Me : Page
    {
        BitmapImage img1 = new BitmapImage(new Uri("ms-appx:///head.jpg"));
        BitmapImage img2 = new BitmapImage(new Uri("ms-appx:///blank.jpg"));
        public Me()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (App.IsLogined)
            {
                bgImg.Source = img1;
                userName.Text = App.User.UserName;
            }
            else
            {
                bgImg.Source = img2;
                userName.Text = "请登录";
            }
        }

        private void userName_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!App.IsLogined)
            {
                MainPage.MainFrame.Navigate(typeof(Login));
            }
        }
    }
}
