using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTest.Common;
using WpfAppTest.Model;
using WpfAppTest.Service;

namespace WpfAppTest.ViewModel
{
    public class LoginViewModel : NotifyBase
    {
       
        public LoginModel LoginModel { get; set; } = new LoginModel();      
        public CommandBase CloseWindowCommand { get; set; }       
        public CommandBase LoginCommand { get; set; }

        private string message;
        private Visibility showprogress = Visibility.Collapsed;

        //数据库连接进度条
        public Visibility ShowProgress
        {
            get { return showprogress; }
            set { showprogress = value; this.DoNotify(); }
        }


        //登录信息提示
        public string PromptMessage
        {
            get { return message; }
            set { message = value; this.DoNotify(); }
        }



        public LoginViewModel()
        {
            //关闭窗口按钮
            this.CloseWindowCommand = new CommandBase();

            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });

            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

            //登录按钮
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => {
                return ShowProgress == Visibility.Collapsed;});      
        }

        private void DoLogin(object o)
        {
            
            this.PromptMessage = "";
            this.ShowProgress = Visibility.Visible;
            Console.WriteLine(LoginModel.Password);
            if(string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.PromptMessage = "请输入用户名!";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if(string.IsNullOrEmpty(LoginModel.Password))
            {
                this.PromptMessage = "请输入密码!";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if(string.IsNullOrEmpty(LoginModel.ValidateCode))
            {
                this.PromptMessage = "请输入验证码";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if(LoginModel.ValidateCode.ToLower()!="6666")
            {
                this.PromptMessage = "验证码错误,请重新输入";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }

            //多线程执行登录操作
            Task.Run(new Action(() =>
            {            
                try
                {
                    var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.Password);
                    if (user == null)
                    {
                        throw new Exception("登录失败!用户名或密码错误!");
                    }
                    GlobalValues.UserInfo = user;
                    Console.WriteLine("登录成功");

                    //登录成功时将Window里的DialogResult结果设为true,再在App.xaml.cs中跳转到MainView
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        (o as Window).DialogResult = true;
                    }));
                }
                catch (Exception e)
                {
                    this.PromptMessage = e.Message;
                    this.ShowProgress = Visibility.Collapsed;


                    Console.WriteLine("数据库问题: " + e.Message);
                }
            }));
        }
    }
}
