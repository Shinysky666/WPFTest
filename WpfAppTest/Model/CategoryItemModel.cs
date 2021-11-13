using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Model
{
    //CoursePageView 中各种类型分类的Model
    public class CategoryItemModel
    {
        public CategoryItemModel()
        {
            Console.WriteLine("CategoryItemModel 无参构造函数");
        }

        public CategoryItemModel(string name, bool state = false)
        {
            this.CategoryItemNmae = name;
            this.IsChecked = state;
        }

        public string CategoryItemNmae { get; set; }
        public bool IsChecked { get; set; }
    }
}
