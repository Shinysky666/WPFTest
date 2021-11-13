using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Model;
using WpfAppTest.Service;

namespace WpfAppTest.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> PriceCategory { get; set; }

        public ObservableCollection<CategoryItemModel> PlatformCategory { get; set; }

        public ObservableCollection<CategoryItemModel> TeacherCategory { get; set; }

        public CoursePageViewModel()
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
    }
}
