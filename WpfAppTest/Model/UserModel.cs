using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Common;

namespace WpfAppTest.Model
{
    public class UserModel : NotifyBase
    {
        private string user_name;

        public string UserName
        {
            get { return user_name; }
            set { user_name = value; this.DoNotify(); }
        }

        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; this.DoNotify(); }
        }

        private string avator;

        public string Avator
        {
            get { return avator; }
            set { avator = value; this.DoNotify(); }
        }
    }
}
