using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
    public sealed partial class SignUp : Page
    {
        const string REGEX_PHONENUMBER = @"^(?:\+?86)?1(?:3\d{3}|5[^4\D]\d{2}|8\d{3}|7(?:[0-35-9]\d{2}|4(?:0\d|1[0-2]|9\d))|9[0-35-9]\d{2}|6[2567]\d{2}|4(?:(?:10|4[01])\d{3}|[68]\d{4}|[579]\d{2}))\d{6}$";
        public SignUp()
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

        private async void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(REGEX_PHONENUMBER);
            ContentDialog dialog = new ContentDialog
            {
                CloseButtonText = "我知道了"
            };
            if (App.UserDatabase[inputUid.Text] != null)
            {
                dialog.Title = "用户名已存在";
                dialog.Content = "请使用其他用户名";
                _ = await dialog.ShowAsync();
            }
            else if (inputPasw.Password.Length < 6)
            {
                dialog.Title = "密码太短";
                dialog.Content = "过短的密码并不安全，请使用长密码";
                _ = await dialog.ShowAsync();
            }
            else if (inputPasw.Password != inputPaswConfirm.Password)
            {
                dialog.Title = "密码不一致";
                dialog.Content = "请确认密码输入没有错误";
                _ = await dialog.ShowAsync();
            } 
            else if (inputPhone.Text.Length < 6 || !regex.IsMatch(inputPhone.Text))
            {
                dialog.Title = "手机号格式错误";
                dialog.Content = "请输入正确的手机号";
                _ = await dialog.ShowAsync();
            }
            else //没有问题
            {
                App.UserDatabase.Add(inputUid.Text, new User()
                {
                    UserName = inputUid.Text,
                    Password = inputPasw.Password,
                    PhoneNumber = inputPhone.Text
                });
                dialog.Title = "注册成功";
                dialog.Content = "注册成功";
                _ = await dialog.ShowAsync();
                Frame.GoBack();
            }
        }
    }
}
