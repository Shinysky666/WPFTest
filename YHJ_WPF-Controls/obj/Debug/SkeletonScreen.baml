   M S B A M L   `   `   `  ����K  GYHJ_WPF-Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:YHJ_WPF_ControlsYHJ_WPF_Controls  5      %    YHJ_WPF_Controls.SkeletonScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:YHJ_WPF_Controls     5        � Triggers  5
      :� 5   
    :� RoutedEvent$ UserControl.Loaded��6   .[�5      �� .��5      �� .��5      ��  g� Duration$ 0:0:1D�6%   	 �� To$ #F7F9FAX�66    �� 
TargetName$ imgBlock��6C    �� TargetProperty$* $(Background).(SolidColorBrush.Color)�5   %    g� RepeatBehavior$ Forever��5   %    g� AutoReverse . 5   %   W� 5      $ 0:0:1.5D�6&   	 W� To$ 1X�69   $ border1��6@   $( "Background.GradientStops[1].Offset�5   %   $ Forever��5   %    . 5   %   W� 5      $ 0:0:2D�6&   $ 1X�67   $ border2��6>   $( "Background.GradientStops[1].Offset�5   %   $ Forever��5   %    . 5   %   W� 5      $ 0:0:1D�6&   $ 1X�67   $ border3��6>   $( "Background.GradientStops[1].Offset�5    %   $ Forever��5!   %    . 5"   %   5$      5&      5'      .��5*      � $	��0,9q�6   	 � ColumnDefinitions	 5+   
   �� 5,      $	��160 �6   �� 5-      .+�50   
   �� -   5        
 ��Name$
 imgBlock��50      $��80��6#   $��65��6.   ���#DDD �� CornerRadius$ 10��6L   �� 52   
   $��1��6   $��Center=�6%   .+�53      �� }�. ._�54      �� -   5        $��border1��54      $��16��6(   $	��650��64   $
��Left=�6@   $��-200,0q�6[   ��55      �� 56       �� EndPoint$ 1,0.5&�6.    �� 
StartPoint$ 0,0.5&�6?   .��57      �  � Color$
 #DDD��6+    � Offset$ 0Q�68   � 58      $ #F7F9FA��6+   $ 0Q�6;   � 59      $
 #DDD��6+   $ 1Q�68   5:      5<      5=      �� 5?      }�. ._�5@      �� -   5        $��border2��5@      $��16��6(   $��-200,5q�64   ��5A      �� 5B      $ 1,0.5&�6.   $ 0,0.5&�6?   .��5C      � $
 #DDD��6+   $ 0Q�68   � 5D      $ #F7F9FA��6+   $ 0Q�6;   � 5E      $
 #DDD��6+   $ 1Q�68   5F      5H      5I      �� 5L      }�. ._�5M      �� -   5        $��border3��5M      $��-200,0q�6(   $��16��68   $	��580��6D   $
��Left=�6P   ��5N      �� 5O      $ 1,0.5&�6.   $ 0,0.5&�6?   .��5P      � $
 #DDD��6+   $ 0Q�68   � 5Q      $ #F7F9FA��6+   $ 0Q�6;   � 5R      $
 #DDD��6+   $ 1Q�68   5S      5U      5V      5Y      5[      5\      