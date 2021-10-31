using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppTest.Common
{
    public class PasswordHelper
    {
        static bool isupdating = false;

        //后端属性绑定前端的PasswordBox中的Password  若后端发生改变则改变前端的密码显示
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new
                FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        //对注册的Password属性进行 Get和Set操作
        public static string GetPassword(DependencyObject d)
        {
            return d.GetValue(PasswordProperty).ToString();
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged -= Password_PasswordChanged;
            if(!isupdating)
                password.Password = e.NewValue?.ToString();
            password.PasswordChanged += Password_PasswordChanged;

        }

        //前端改变密码时触发Password_PasswordChanged事件
        //改变中间件PasswordProperty的值影响后端，再而后端值发生改变影响前端
        public static readonly DependencyProperty AttachProperty =
    DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new
        FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttached)));

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }

        public static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordbox = sender as PasswordBox;
            isupdating = true;
            SetPassword(passwordbox, passwordbox.Password);
            isupdating = false;
        }
    }
}
