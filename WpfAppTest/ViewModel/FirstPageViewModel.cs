using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    public class FirstPageViewModel : NotifyBase
    {
        public Random random = new Random();
        public bool taskSwitch = true;
        public List<Task> tasklist = new List<Task>();
        public ObservableCollection<CourseSeriesModel> CourseSeriesList { get; set; } = new ObservableCollection<CourseSeriesModel>();


        private int _instrucmentValue = 20;
        public int InstrucmentValue
        {
            get { return _instrucmentValue; }
            set { _instrucmentValue = value; this.DoNotify(); }
        }

        private int _itemCount;

        public int ItemCount
        {
            get { return _itemCount; }
            set { _itemCount = value; this.DoNotify(); }
        }

        public FirstPageViewModel()
        {
            this.RefreshInstrucmentValue();
            this.InitCourseSeriesList();
        }

        //指针仪表数据监控盘 数据自动刷新 后面可绑定真实数据
        public void RefreshInstrucmentValue()
        {
            Task InstrucmentValuetask = Task.Factory.StartNew(new Action(async () =>
            {
                while (taskSwitch)
                {
                    InstrucmentValue = random.Next
                    (Math.Max(this.InstrucmentValue - 5, 0), Math.Min(this.InstrucmentValue + 5, 100));

                    await Task.Delay(1500);
                }
            }
            ));
            tasklist.Add(InstrucmentValuetask);
        }

        //关闭应用时防止指针仪表数据监控盘报错
        public void Dispose()
        {
            try
            {
                taskSwitch = false;
                Task.WaitAll(tasklist.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine("FirstPageViewModel发生未知错误: \n" + e);
            }
        }

        //初始化学员监控情况内容 SeriesList与Seriescollection应一一对应
        public void InitCourseSeriesList()
        {
            #region 写死代码
            /*CourseSeriesList.Add(new CourseSeriesModel 
            { 
                CourseName = "铲车人",
                Seriescollection = new LiveCharts.SeriesCollection {
                    new PieSeries{
                    Title = "我是头部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(111)},
                    DataLabels = false
                    },
                    new PieSeries{
                    Title = "我是根部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(55)},
                    DataLabels = false
                    },
                    new PieSeries{
                    Title = "我是尾部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(55)},
                    DataLabels = false
                    }
                },
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="JAVA",CurrentValue=121,IsGrowing=false,ChangeRate=75},
                    new SeriesModel{SeriesName="Python",CurrentValue=80,IsGrowing=false,ChangeRate=-5},
                    new SeriesModel{SeriesName="Go",CurrentValue=75,IsGrowing=false,ChangeRate=3},
                    new SeriesModel{SeriesName="C#",CurrentValue=333,IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="C++",CurrentValue=44,IsGrowing=false,ChangeRate=2},
                }

            });

            CourseSeriesList.Add(new CourseSeriesModel
            {
                CourseName = "铲车人",
                Seriescollection = new LiveCharts.SeriesCollection {
                    new PieSeries{
                    Title = "我是头部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(111)},
                    DataLabels = false
                    },
                    new PieSeries{
                    Title = "我是根部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(55)},
                    DataLabels = false
                    },
                    new PieSeries{
                    Title = "我是尾部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(55)},
                    DataLabels = false
                    }
                },
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="JAVA",CurrentValue=121,IsGrowing=false,ChangeRate=75},
                    new SeriesModel{SeriesName="Python",CurrentValue=80,IsGrowing=false,ChangeRate=-5},
                    new SeriesModel{SeriesName="Go",CurrentValue=75,IsGrowing=false,ChangeRate=3},
                    new SeriesModel{SeriesName="C#",CurrentValue=333,IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="C++",CurrentValue=44,IsGrowing=false,ChangeRate=2},
                }

            });

            CourseSeriesList.Add(new CourseSeriesModel
            {
                CourseName = "铲车人",
                Seriescollection = new LiveCharts.SeriesCollection {
                    new PieSeries{
                    Title = "我是头部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(111)},
                    DataLabels = false
                    },
                    new PieSeries{
                    Title = "我是根部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(55)},
                    DataLabels = false
                    },
                    new PieSeries{
                    Title = "我是尾部",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(55)},
                    DataLabels = false
                    }
                },
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="JAVA",CurrentValue=121,IsGrowing=false,ChangeRate=75},
                    new SeriesModel{SeriesName="Python",CurrentValue=80,IsGrowing=false,ChangeRate=-5},
                    new SeriesModel{SeriesName="Go",CurrentValue=75,IsGrowing=false,ChangeRate=3},
                    new SeriesModel{SeriesName="C#",CurrentValue=333,IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="C++",CurrentValue=44,IsGrowing=false,ChangeRate=2},
                }

            });*/
            #endregion

            var Courselist = LocalDataAccess.GetInstance().GetCoursePlayRecord();
            //计算数据库中课程中平台的最大数量 通过数据绑定改变 FirstPageView(UniformGrid Columns)的值
            this.ItemCount = Courselist.Max(c => c.SeriesList.Count);

            foreach (var item in Courselist)
            {
                this.CourseSeriesList.Add(item);
            }
        }
    }
}
