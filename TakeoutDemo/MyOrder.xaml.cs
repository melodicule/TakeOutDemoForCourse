using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace TakeoutDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyOrder : Page
    {
        int currentPage = 0;
        Border lastBorder;
        public MyOrder()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            lastBorder = firstTab;
        }


        private void TabSwitch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            int page = (int)border.GetValue(Grid.ColumnProperty); //获取是哪个按钮被点击
            if (page != currentPage) //如果跳转到的页面不是当前页面
            {
                underline.SetValue(Grid.ColumnProperty, page);
                TextBlock lastText = lastBorder.Child as TextBlock;
                lastText.Foreground = new SolidColorBrush(Colors.Gray);
                lastBorder = border;
                (border.Child as TextBlock).Foreground = new SolidColorBrush(Colors.DodgerBlue);
                currentPage = page;

                switch (page)
                {
                    case 0:
                        //pages.Navigate(typeof(HomePage));
                        break;
                    case 1:
                        //pages.Navigate();
                        break;
                    case 2:
                        //pages.Navigate(typeof(Me));
                        break;
                }
            }
        }
    }
}
