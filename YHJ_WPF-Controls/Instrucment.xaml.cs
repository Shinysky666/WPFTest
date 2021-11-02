﻿using System;
using System.Collections.Generic;
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

namespace YHJ_WPF_Controls
{
    /// <summary>
    /// Instrucment.xaml 的交互逻辑
    /// </summary>
    public partial class Instrucment : UserControl
    {
        //继承了UserControl 可单独作为依赖对象设置其依赖属性
        //对比 WpfAppTest.Common:PasswordHelper里对Password和Attach对属性的Get和Set方法
        public double Value
        {
            get { return (double)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(double), typeof(Instrucment),
            new PropertyMetadata(double.NaN,new PropertyChangedCallback(OnPropertyChanged)));

        //Value变化时触发委托
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

            this.mainCanvas.Children.Clear();//等待最后的一个数值进行绘画

            double min = 0, max = 100;
            double step = 270.0 / (max - min);//获取每一步的度数
            int scaletext = (int)min;

            for (int i = 0; i <= max-min; i++)
            {
                //起始坐标点为画布坐上角  x轴需要顺时针旋转45度
                Line lineScale = new Line();

                if (i % 10 == 0)
                {
                    lineScale.X1 = radius - (radius - 20) * Math.Cos((i * step - 45) * Math.PI / 180);
                    lineScale.Y1 = radius - (radius - 20) * Math.Sin((i * step - 45) * Math.PI / 180);
                    lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                    lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);

                    //设置刻度值
                    TextBlock textscale = new TextBlock();
                    textscale.Text = (scaletext + step * i).ToString();
                    textscale.Foreground = Brushes.White;
                    Canvas.SetLeft(textscale, radius - (radius - 20) * Math.Cos((i * step - 45) * Math.PI / 180));
                    Canvas.SetTop(textscale, radius - (radius - 20) * Math.Sin((i * step - 45) * Math.PI / 180));
                    this.mainCanvas.Children.Add(textscale);

                }
                else
                {
                    lineScale.X1 = radius - (radius - 13) * Math.Cos((i * step - 45) * Math.PI / 180);
                    lineScale.Y1 = radius - (radius - 13) * Math.Sin((i * step - 45) * Math.PI / 180);
                    lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                    lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);
                }

                lineScale.Stroke = Brushes.White;//线条为白色
                lineScale.StrokeThickness = 1;

                this.mainCanvas.Children.Add(lineScale);
            }
        }
}
}
