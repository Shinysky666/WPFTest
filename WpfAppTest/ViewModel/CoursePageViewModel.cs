using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public ObservableCollection<CoursePageView_CourseModel> CourseList { get; set; } = new ObservableCollection<CoursePageView_CourseModel>();

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
            /*this.TeacherFilterCommand = new CommandBase();
            this.TeacherFilterCommand.DoCanExecute = new Func<object, bool>((o) => true);
            this.TeacherFilterCommand.DoExecute = new Action<object>(Category_TeacherFilter);*/

            
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

        //远程加载数据库时会耗时,因此加入异步线程 并采用YHJ_WPF_Controls里的 SkeletonScreen骨骼阴影 给用户进行显示提示
        public void InitCourseList()
        {
            for(int i=0;i<10;i++)
            {
                CourseList.Add(new CoursePageView_CourseModel { IsShowSkeleton = true });
            }

            Task.Run(new Action(async () => 
            {
                CourseAll = LocalDataAccess.GetInstance().CoursePageView_GetCourses();
                await Task.Delay(3000);

                //子线程对 UI主线程进行操作时 需要进行调度
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    CourseList.Clear();
                    foreach (var item in CourseAll)
                    {
                        //绑定显示的列表
                        CourseList.Add(item);
                    }
                }));
            }));
        }

        //ViewModel 鼠标点击分类栏老师名时 传递老师名字(已通过View层完成 RadioButton_Click )
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
