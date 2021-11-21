using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppTest.Model;

namespace WpfAppTest.Common
{
    public class CoursePageView_CourseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SkeletonTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if ((item as CoursePageView_CourseModel).IsShowSkeleton)
            {
                return SkeletonTemplate;
            }
            else
            {
                return DefaultTemplate;
            }
        }
    }
}
