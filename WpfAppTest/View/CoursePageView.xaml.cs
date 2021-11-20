using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppTest.Model;
using WpfAppTest.ViewModel;

namespace WpfAppTest.View
{
    /// <summary>
    /// CoursePageView.xaml 的交互逻辑
    /// </summary>
    public partial class CoursePageView : UserControl
    {
        public CoursePageView()
        {
            InitializeComponent();
            this.DataContext = new CoursePageViewModel();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioBtn = sender as RadioButton;
            string teacher = radioBtn.Content.ToString();

            ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemCourseList.ItemsSource);

            if (teacher == "全部")
            {
                view.Filter = null;

                // 对 CourseName 进行排序
                //view.SortDescriptions.Add(new SortDescription("CourseName", ListSortDirection.Descending));
            }
            else
            {
                view.Filter = new Predicate<object>((o) =>
                {
                    return (o as CoursePageView_CourseModel).Teachers.Exists(t => t == teacher);
                });
            }
        }
    }
}
