using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Common;

namespace WpfAppTest.Model
{
    public class LoginModel : NotifyBase
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set 
            { 
                userName = value;
                this.DoNotify();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                this.DoNotify();
            }
        }

        private string validatecode;
        public string ValidateCode
        {
            get { return validatecode; }
            set 
            { 
                validatecode = value;
                this.DoNotify();
            }
        }
    }
}
