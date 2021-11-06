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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YHJ_WPF_Controls
{
    /// <summary>
    /// Instrucment.xaml 的交互逻辑
    /// </summary>
    public partial class Instrucment : UserControl
    {
        //继承了UserControl 可单独作为依赖对象设置其依赖属性
        //对比 WpfAppTest.Common:PasswordHelper里对Password和Attach对属性的Get和Set方法
        //指针所指向的值
        public double Value
        {
            get { return (double)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Instrucment),
            new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnPropertyChanged)));


        //圆盘刻度文本最大值
        public double MaxiValue
        {
            get { return (double)GetValue(MaxiValueProperty); }
            set { SetValue(MaxiValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MaxiValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxiValueProperty =
            DependencyProperty.Register("MaxiValue", typeof(double), typeof(Instrucment),
                new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnPropertyChanged)));


        //圆盘刻度文本最小值
        public double MiniValue
        {
            get { return (double)GetValue(MiniValueProperty); }
            set { SetValue(MiniValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MiniValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MiniValueProperty =
            DependencyProperty.Register("MiniValue", typeof(double), typeof(Instrucment),
                new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnPropertyChanged)));

        //圆盘背景
        public Brush PlateBackground
        {
            get { return (Brush)GetValue(PlateBackgroundProperty); }
            set { SetValue(PlateBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlateBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlateBackgroundProperty =
            DependencyProperty.Register("PlateBackground", typeof(Brush), typeof(Instrucment), 
                new PropertyMetadata(default(Brush)));


        //文本和刻度字体大小
        public int ScaleSize
        {
            get { return (int)GetValue(ScaleSizeProperty); }
            set { SetValue(ScaleSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleSizeProperty =
            DependencyProperty.Register("ScaleSize", typeof(int), typeof(Instrucment),
                new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        //文本和刻度颜色
        public Brush Scalebrush
        {
            get { return (Brush)GetValue(ScalebrushProperty); }
            set { SetValue(ScalebrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Scalebrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScalebrushProperty =
            DependencyProperty.Register("Scalebrush", typeof(Brush), typeof(Instrucment),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));

        //分成多少个区域
        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Interval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(int), typeof(Instrucment),
                new PropertyMetadata(1, new PropertyChangedCallback(OnPropertyChanged)));

        //绑定的属性变化时触发委托
        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Instrucment).Refresh();
        }

        public Instrucment()
        {
            InitializeComponent();
            this.SizeChanged += UserControl1_SizeChanged;
        }
             

        //用户控件的尺寸发生变化时 将Ellipse圆的尺寸自动变化
        private void UserControl1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double minsize = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            this.backEllipse.Width = minsize;
            this.backEllipse.Height = minsize;
        }

        //画布上画线
        public void Refresh()
        {
            double radius = this.backEllipse.Width / 2;//半径

            if (double.IsNaN(radius))
                return;

            this.mainCanvas.Children.Clear();//等待最后的一个数值进行绘画

            double min = this.MiniValue, max = this.MaxiValue;
            double step = 270.0 / (max - min); //获取每一步的度数
            int scaleAreaCount = this.Interval;//分成多少个区域

            for (int i = 0; i < max-min; i++)
            {
                //起始坐标点为画布坐上角  x轴需要顺时针旋转45度
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 13) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 13) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);

                lineScale.Stroke = this.Scalebrush;//线条为白色
                lineScale.StrokeThickness = 1;
                this.mainCanvas.Children.Add(lineScale);
            }

            double scaletext = min;
            Console.WriteLine(scaletext);
            for (int i = 0; i <= scaleAreaCount; i++)
            {
                step = 270.0 / scaleAreaCount;
                //绘制整除10的粗线    
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 20) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 20) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);

                lineScale.Stroke = this.Scalebrush;//线条为白色
                lineScale.StrokeThickness = 1;
                this.mainCanvas.Children.Add(lineScale);

                //设置刻度值
                TextBlock textscale = new TextBlock();
                textscale.Width = 34;
                textscale.TextAlignment = TextAlignment.Center;
                textscale.FontSize = this.ScaleSize;
                textscale.Text = ((int)(scaletext + (max - min) / scaleAreaCount * i)).ToString();
                textscale.Foreground = this.Scalebrush;

                Canvas.SetLeft(textscale, radius - (radius - 36) * Math.Cos((i * step - 45) * Math.PI / 180) - 17);
                Canvas.SetTop(textscale, radius - (radius - 36) * Math.Sin((i * step - 45) * Math.PI / 180) - 10);
                this.mainCanvas.Children.Add(textscale);
            }

            //绘制圆弧 通过替换数据达到
            string sData = "M {0} {1} A{0} {0} 0 1 1 {1} {2}";
            sData = string.Format(sData, radius / 2, radius, radius * 1.5);
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.circle.Data = (Geometry)converter.ConvertFrom(sData);


            //根据绑定的Value值 通过动画改变其面板角度 而不是改变绘制的指针(步骤繁杂)
            //DoubleAnimation(旋转的角度值,动画的持续时间)
            step = 270.0 / (max - min);
            DoubleAnimation da = new DoubleAnimation(((int)(this.Value - min) * step) - 45,
                new Duration(TimeSpan.FromMilliseconds(150)));
            this.rtpointer.BeginAnimation(RotateTransform.AngleProperty, da);

            //绘制指针
            sData = "M {0} {1} {1} {2} {1} {3}";
            sData = string.Format(sData, radius * 0.3, radius, radius - 5, radius + 5);
            this.pointer.Data = (Geometry)converter.ConvertFrom(sData);
  
        }
    }
}
