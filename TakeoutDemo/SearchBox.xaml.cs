﻿using System;
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
    public sealed partial class SearchBox : Page
    {
        public SearchBox()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void BackToHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Border_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            iconBack.Foreground = new SolidColorBrush(Colors.LightSkyBlue);
            await Task.Delay(100);
            iconBack.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Search()
        {
            Frame.Navigate(typeof(SearchResult));
        }

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbWord.Text))
            {
                Search();
            }
        }

        private void Suggestion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            TextBlock text = border.Child as TextBlock;
            tbWord.Text = text.Text;
            Search();
        }
    }
}
