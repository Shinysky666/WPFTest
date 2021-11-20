using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Model
{
    public class CoursePageView_CourseModel
    {
        public string CourseName { get; set; }
        public List<string> Teachers { get; set; }
        public string Description { get; set; }
        public string CourseImage { get; set; }
        public string Url { get; set; }
        public bool IsShowSkeleton { get; set; }
    }
}
