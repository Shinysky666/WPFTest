   M S B A M L   `   `   `  ����E  AWpfAppTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfAppTest.ViewWpfAppTest.View  5      K GYHJ_WPF-Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:YHJ_WPF_Controls;assembly=YHJ_WPF-ControlsYHJ_WPF_Controls 5      5clr-namespace:WpfAppTest.CommonWpfAppTest.Common  5      $    WpfAppTest.View.CoursePageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfAppTest.View     5      O
yhjcontrol8clr-namespace:YHJ_WPF_Controls;assembly=YHJ_WPF-Controls     5      4mycommonclr-namespace:WpfAppTest.Common     5        � 	Resources  5       �� 
TargetType   CategoryItemButton ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  courseTemplate
 � ColumnDefinitions J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth   
BlurRadius   Opacity   	Direction j� Stretch �� ImageSource �� Orientation �� Command �� RelativeSource �� AncestorType �� Mode �� CommandParameter �� Triggers }� Location $� Orientation �� Path �� 
LineHeight  skeletonTemplate%  YHJ_WPF_Controls.SkeletonScreen��%�  &	        &	 �    &	 7    �� 5   
   " 	�6   .R�5      � 
������ .+�5      �� $ Firstlineback��6   ���#EEE$ 5��6B   ._�5      �� #��z��6    $
��15,6q�6A   $��Center=�5       $��Center=�6;   5      5       5      P� 5       �@d�	IsChecked$
 TrueY�6/   . �5      �� $ Firstlineback��6    � ��
	 � ���6N   �� 5       � ��
	 �����63   5      5      �� 5   
   .R�5      � 
 5       �� 5!      $	��150 �6'   �� 5"      �� 5#      $	��100 �6'   .+�5&      �� $��90��6   $��70��6$   $ 5��60   $
��0,15q�6A    5'        5(      $
 Gray��6+   $ 0Q�68   $ 10Q�6H   $	 0.3Q�6X   $ 0Q�6f   ��5*      �� 5+      $ UniformToFill=�6I    6%   �� *CourseImage+6I   5-      �� 50      $��1��6   $��Center=�6-   .+�51      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�52      �� $��16(�6$   �� 54   *   ���#333 55   4   �� *" DataContext.OpenCourseUrlCommand+ �� $ UserControlL�$ FindAncestor=� 56   4   �� *Url+.�6U   ��57   .   �� 58   2   .�59   .   ��  � ��	 6Z   Z�  5:   2   P� 5;   6    �@��IsMouseOver . . �5<   :   ��  � ��	 5=   >   |� 5>   B   }� 5?   F   $ 	Underline=�6U   5@   C   5B   ;   5C   7   5E   3   .�5G   ?   .�5H   .   �� ��68   �� *
CourseName+5I   +   5J   '   �� 5M      $
��15,0q�6'   ��65   �� *
Teachers+��5N      �� 5O   "   .R�5P   &   $� $ 
Horizontal=�6=   5Q   #   ��5S      �� 5T   "   .R�5U   &   �� ���#EEE$	��5,0q�6?   $ 5��6L   ._�5V   *   �� $
��12,3q�6L   ��64   �� $ .�6L   5W   '   5X   #   5Z      5[      �� 5]      $
��Wrap=�5^   $   $ 20��68   ���#AAA��5]       �� *Description+5^   H   5_      �� 5b      $��2��6   $ 
Horizontal=�6-   $��Center=�6F   $��Center=�6c   .+�5c      �� $	��5,0q�6    �� 5e      $  ��6(   .�63   详情67   5f      �� 5g      $	��5,0q�6    �� 5h      .�6(   删除6,   5i      5j      5k      5l      �� 5n   
   .R�5o        $��skeleton��65   $��1��6(   65   5p      5r      .��5u      �� 
�������$ 5��6    ._�5v   
   �  � RowDefinitions 5w      �� 5x      $
��auto �6    �� 5y      .+�5}      �� ���#DDD$��0,0,0,1q�6(   $
��20,0q�6B   ._�5~      � $��10,18q�6    5      �� 5�      $��35��6(   $
��auto �67   �� 5�      $��35��6(   $
��auto �67   �� 5�      $��35��6(   $
��auto �67   .+�5�      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� $��付费类型��6$   $��Center=�60   $��0,0,10,0q�6K   ���#6666]   �� 5�      ��6'   �� *PriceCategory+��5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   5�   #   ��5�      �� 5�   "   .R�5�   &   	� #��[  5�   2    	� 	GroupName$ Price��5�   2   $	��5,0q�6D   ��5�   2   �� *CategoryItemNmae+  d� 	IsChecked  6W   �� *	IsChecked+5�   D   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6!   $��1��6:   $��Center=�6G   .+�5�      �� $��平台类型��6$   $��Center=�60   $��0,0,10,0q�6K   ���#6666]   �� 5�      ��6'   �� *PlatformCategory+��5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   5�   #   ��5�      �� 5�   "   .R�5�   &   	� #��[  5�   2   $ Platform��5�   2   $	��5,0q�6G   ��5�   2   �� *CategoryItemNmae+  6W   �� *	IsChecked+5�   G   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6!   $��2��6:   $��Center=�6G   .+�5�      �� $��授课老师��6$   $��Center=�60   $��0,0,10,0q�6K   ���#6666]   �� 5�      ��6'   �� *TeacherCategory+��5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   5�   #   ��5�      �� 5�   "   .R�5�   &   	� -   5        #��[  5�   2   $ Teacher��5�   2   $	��5,0q�6F   ��5�   2   �� *CategoryItemNmae+  6W   �� *	IsChecked+5�   2   5�   #   5�      5�      �� 5�      $��2��6   $��+ 添加课程��6*   $��80��6;   $��30��6F   $��Right=�6R   $��Center=�6n   5�      5�      �� 5�      $��1��6   $��Hidden=�6(   .��5�      �� -   5        ! ��Name$! ItemCourseList��5�   B   ��6   �� *
CourseList+��5�      �� 5�      .R�5�      $� 5�      ��5�      A   ;WpfAppTest.Common.CoursePageView_CourseDataTemplateSelector  5�      "   DefaultTemplate#" [ 5�      #   SkeletonTemplate## [ 5�      5�      5�      5�      5�      5�      