using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTest.Common;
using WpfAppTest.Model;

namespace WpfAppTest.ViewModel
{
    public class MainViewModel : NotifyBase
    {     
        public UserModel UserInfo { get; set; }

        private string serchtext;
        public string SerchText
        {
            get { return serchtext; }
            set { serchtext = value; this.DoNotify(); }
        }

        private FrameworkElement _mainContent;                           
        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set { _mainContent = value; this.DoNotify(); }
        }
        public CommandBase NvChangedCommand { get; set; }

        public MainViewModel()
        {
            // GlobalValues.UserInfo在 LoginViewModel的DoLogin()方法中登录成功进行了赋值
            this.UserInfo = new UserModel();
            this.UserInfo.UserName = GlobalValues.UserInfo.RealName;
            this.UserInfo.Avator = GlobalValues.UserInfo.Avator;
            this.UserInfo.Gender = GlobalValues.UserInfo.Gender;

            this.NvChangedCommand = new CommandBase();
            this.NvChangedCommand.DoExecute = new Action<object>(DoNvChanged);
            this.NvChangedCommand.DoCanExecute = new Func<object, bool>((o) => true);

            //首页加载
            DoNvChanged("FirstPageView");
        }
            
        private void DoNvChanged(object obj)
        {
            //反射自身程序集的内容 则不需要加载程序集
            //Assembly assembly = Assembly.LoadFrom(@"WpfAppTest.View.dll");
            Type type = Type.GetType("WpfAppTest.View." + obj.ToString());
            ConstructorInfo ctinfo = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)ctinfo.Invoke(null);
        }

    }
}
