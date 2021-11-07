﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Common;
using WpfAppTest.Model;

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

        //初始化学员监控情况内容
        public void InitCourseSeriesList()
        {
            CourseSeriesList.Add(new CourseSeriesModel { CourseName = "铲车人" });
        }
    }
}
