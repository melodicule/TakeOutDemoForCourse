using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using System.Threading.Tasks;
using System.Diagnostics;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace TakeoutDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Login : Page
    {
        string _name = string.Empty;
        string _pswd = string.Empty;
        public string UserName 
        {
            get => _name;
            set
            {
                _name = value;
                Check();
            }
        }
        public string Password
        {
            get => _pswd;
            set
            {
                _pswd = value;
                Check();
            }
        }
        public Login()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Border_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            iconBack.Foreground = new SolidColorBrush(Colors.LightSkyBlue);
            await Task.Delay(100);
            iconBack.Foreground = new SolidColorBrush(Colors.White);
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (User.Check(App.UserDatabase, UserName, Password))
            {
                App.IsLogined = true;
                App.User = App.UserDatabase[UserName];
                Frame.GoBack();
            }
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "用户名或密码错误",
                    Content = "请输入正确的用户名和密码",
                    CloseButtonText = "我知道了"
                };
                _ = await dialog.ShowAsync();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }

        private void Check()
        {
            btLogin.IsEnabled = !string.IsNullOrWhiteSpace(_name) && _pswd.Length >= 6;
        }
    }
}
