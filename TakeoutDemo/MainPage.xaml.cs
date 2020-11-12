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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TakeoutDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static Frame MainFrame;
        int currentPage = 0;
        Grid lastGrid;
        public MainPage()
        {
            this.InitializeComponent();
            lastGrid = mainPage;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }




        private void TabSwitch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            int page = (int)grid.GetValue(Grid.ColumnProperty); //获取是哪个按钮被点击
            if (page != currentPage) //如果跳转到的页面不是当前页面
            {
                lineButtom.SetValue(Grid.ColumnProperty, page);
                lastGrid.Background = new SolidColorBrush(Colors.White);
                lastGrid = grid;
                grid.Background = new SolidColorBrush(Colors.WhiteSmoke);

                switch (page)
                {
                    case 0:
                        pages.Navigate(typeof(HomePage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
                        break;
                    case 1:
                        pages.Navigate(typeof(MyOrder), null, 
                            new SlideNavigationTransitionInfo() 
                            { 
                                Effect = currentPage > page 
                                    ? SlideNavigationTransitionEffect.FromLeft
                                    : SlideNavigationTransitionEffect.FromRight
                            }
                            );
                        break;
                    case 2:
                        pages.Navigate(typeof(Me), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
                        break;
                }
                currentPage = page;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame = Frame;
            pages.Navigate(typeof(HomePage));
        }
    }
}
