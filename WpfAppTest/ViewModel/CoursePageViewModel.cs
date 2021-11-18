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

        public List<CoursePageView_CourseModel> CourseAll { get; set; }

        public CommandBase OpenCourseUrlCommand { get; set; }

        public CommandBase TeacherFilterCommand { get; set; }

        public CoursePageViewModel()
        {
            //初始化搜索栏
            InitCategory();

            //初始化第二行的课程
            InitCourseList();

            //点击课程名跳转网址方法
            this.OpenCourseUrlCommand = new CommandBase();
            this.OpenCourseUrlCommand.DoCanExecute = new Func<object, bool>((o) => true);
            this.OpenCourseUrlCommand.DoExecute = new Action<object>((o) => { System.Diagnostics.Process.Start(o.ToString()); });

            //点击老师名筛选课程
            this.TeacherFilterCommand = new CommandBase();
            this.TeacherFilterCommand.DoCanExecute = new Func<object, bool>((o) => true);
            this.TeacherFilterCommand.DoExecute = new Action<object>(Category_TeacherFilter);

            
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
            CourseAll = LocalDataAccess.GetInstance().CoursePageView_GetCourses();
            //绑定显示的列表
            CourseList = new ObservableCollection<CoursePageView_CourseModel>(CourseAll);
        }

        //鼠标点击分类栏老师名时 传递老师名字
        public void Category_TeacherFilter(object o)
        {
            string teachername = o.ToString();
            List<CoursePageView_CourseModel> temp = CourseAll;
            if (teachername != "全部")
            {
                //筛选 CourseAll 中所选中对应的老师名
                temp = CourseAll.Where(t => t.Teachers.Exists(e => e.Equals(teachername))).ToList();
            }

            CourseList.Clear();
            foreach (var item in temp)
            {
                CourseList.Add(item);
            }
        }
    }
}
