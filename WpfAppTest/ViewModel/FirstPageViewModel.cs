using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Common;

namespace WpfAppTest.ViewModel
{
    public class FirstPageViewModel : NotifyBase
    {
        Random random = new Random();
        bool taskSwitch = true;
        List<Task> tasklist = new List<Task>();

        private int _instrucmentValue = 20;
        public int InstrucmentValue
        {
            get { return _instrucmentValue; }
            set { _instrucmentValue = value; this.DoNotify(); }
        }



        public FirstPageViewModel()
        {
            RefreshInstrucmentValue();
        }

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

    }
}
