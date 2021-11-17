using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Common;
using WpfAppTest.Model;
using WpfAppTest.Service;

namespace WpfAppTest.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> PriceCategory { get; set; }

        public ObservableCollection<CategoryItemModel> PlatformCategory { get; set; }

        public ObservableCollection<CategoryItemModel> TeacherCategory { get; set; }

        public ObservableCollection<CoursePageView_CourseModel> CourseList { get; set; }

        public CommandBase OpenCourseUrl { get; set; }

        public CoursePageViewModel()
        {
            //点击课程名方法
            this.OpenCourseUrl = new CommandBase();
            this.OpenCourseUrl.DoCanExecute = new Func<object, bool>((o) => true);
            this.OpenCourseUrl.DoExecute = new Action<object>((o) => { System.Diagnostics.Process.Start(o.ToString()); });

            //初始化搜索栏
            InitCategory();

            //初始化第二行的课程
            InitCourseList();
        }

        public void InitCategory()
        {
            //付费类型
            this.PriceCategory = new ObservableCollection<CategoryItemModel>();
            PriceCategory.Add(new CategoryItemModel("全部", true));
            PriceCategory.Add(new CategoryItemModel("付费"));
            PriceCategory.Add(new CategoryItemModel("免费"));

            //平台类型
            this.PlatformCategory = new ObservableCollection<CategoryItemModel>();
            PlatformCategory.Add(new CategoryItemModel("全部", true));
            PlatformCategory.Add(new CategoryItemModel("单机"));
            PlatformCategory.Add(new CategoryItemModel("联机"));

            //授课老师类型
            this.TeacherCategory = new ObservableCollection<CategoryItemModel>();
            TeacherCategory.Add(new CategoryItemModel("全部", true));
            foreach (var item in LocalDataAccess.GetInstance().CoursePageView_GetTeacher())
            {
                TeacherCategory.Add(new CategoryItemModel(item));
            }
        }

        public void InitCourseList()
        {
            CourseList = new ObservableCollection<CoursePageView_CourseModel>(LocalDataAccess.GetInstance().CoursePageView_GetCourses());
        }
    }
}
