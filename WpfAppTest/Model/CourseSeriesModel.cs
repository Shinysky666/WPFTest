using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Model
{
    public class CourseSeriesModel
    {
        //课程名称
        public string CourseName { get; set; }

        //绑定圆表图数据
        public SeriesCollection Seriescollection { get; set; }

        //课程里的信息 <ItemsControl.ItemTemplate> <DataTemplate> 中的数据
        public ObservableCollection<SeriesModel> SeriesList { get; set; }
    }
}
