   M S B A M L   `   `   `  ����G  CBranirovanie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BranirovanieBranirovanie  5   	       Branirovanie.MainFood   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Branirovanie     5   	   b ^MaterialDesignThemes.Wpf, Version=4.2.0.2581, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ FoodOrderingApp��5
   	   $	��600��6!   $
��1000��6.    � 
ResizeMode$ NoResize=�6;    � WindowStyle$
 None=�6Q   $��Roboto)�6�    � 	Resources 5         PrimaryColor �� Color  SecondaryColor  
ThirdColor  OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	CloseMenu��%  &	        &	 #     &	 B     &	 c     &	 �    �� 5   
   $ 	#FF673AB7��6/   �� 5   
   $ White��61   �� 5   
   $ #898c9b��6-   �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 	rectangle��5   ,   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.3��6'   $
	 43.5Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 
rectangle1��5   ,   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.3��6'   $	 -43.5Q�69   5      U� 5      $ (UIElement.Opacity)�6,   $ 
rectangle2��5   ,   .\�5        $ 0��6'   $	 1Q�63     5      $ 0:0:0.3��6'   $	 0Q�69   5      U� 5       $ (FrameworkElement.Width)�6,   $ GridMenu��5!   ,   .\�5"        $ 0��6'   $	 70Q�63     5#      $ 0:0:0.3��6'   $		 240Q�69   5$      5%      �� 5&   
   .��5'      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 	rectangle��5(   ,   .\�5)        $ 0��6'   $
	 43.5Q�63     5*      $ 0:0:0.3��6'   $	 0Q�69   5+      U� 5,      $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 
rectangle1��5-   ,   .\�5.        $ 0��6'   $	 -43.5Q�63     5/      $ 0:0:0.3��6'   $	 0Q�69   50      U� 51      $ (UIElement.Opacity)�6,   $ 
rectangle2��52   ,   .\�53        $ 0��6'   $	 0Q�63     54      $ 0:0:0.3��6'   $	 1Q�69   55      U� 56      $ (FrameworkElement.Width)�6,   $ GridMenu��57   ,   .\�58        $ 0��6'   $		 240Q�63     59      $ 0:0:0.3��6'   $	 70Q�69   5:      5;      5<      .��5>      � .+�5?   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5        
  Name$
 czHead��5?   #   $��Рестораны��63   $��Center=�5@   #   $��Center=�5A   #   $��70��5B   #   $
��1000��6/      Mode$ 
PrimaryMid=�5C   #   $��40(�5D   #   #��[ 5E   #   � 5F   
   -   5         �Name$ GridMenu��5F      $
��Left=�5G      $��70��5H      #��[  5I       K� ZIndex$ 1��5J      .+�5K      �� .+�5L      �� -   5         ��Name$ btMenu��5L      $��Right=�5M      $	��Top=�5N      #��[  5O      #��[  5P      $��70��5Q      $��70��6    +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5R      +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback
 ���� .��5U      � $��Center=�6   $��Center=�68   .+�5V      �� -   5         ��Name$ 	rectangle��5V   $   $��30��5W       $��5��6+   $��0q�5X       #��[ 5Y       $��Center=�5Z       $	��Top=�5[        J� RenderTransformOrigin$ -0,0.5&�5\       z�5]      V� 5^   "   .~�5_   &   �� �� 5`   &   �� 5a   &   T� 5b   &   5c   #   5e      �� 5f      -   5        $ 
rectangle1��5f   $   $��30��5g       $��5��6+   $��0 20 0 0q�5h       #��[ 5i       $��Center=�5j       $	��Top=�5k       $ -0,0.5&�5l       z�5m      V� 5n   "   .~�5o   &   �� �� 5p   &   �� 5q   &   T� 5r   &   5s   #   5u      �� 5v      -   5        $ 
rectangle2��5v   $   $��30��5w       $��5��6+   $��0 10 0 0q�5x       #��[ 5y       $��Center=�5z       $	��Top=�5{       5|      5}      �� 5~      -   5         ��Name$ lvMenu��5~      #��[ 5      $��Disabled=�5�      .@�5�      �� -	   5         ��Name$ lviRestaurants��5�   #   $��60��6;   .��5�      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Food=�66   $��40��5�   6   $��40��6B   $��5 0 0 0q�5�   6   �� 5�      $��Рестораны��6(   $��Center=�5�   (   $��20 10q�5�   (   $��20(�5�   (   5�      5�      �� 5�      -
   5        $ 	lviBasket��5�   #   $��60��66   4  .System.Windows.Automation.AutomationProperties   Name$ 	lviBasket��5�   #   .��5�      �� $ 
Horizontal=�6%   .+�5�        $ Basket=�66   $��40��5�   6   $��40��6B   $��5 0 0 0q�5�   6   �� 5�      $��Корзина��6(   $��Center=�5�   (   $��20 10q�5�   (   $��20(�5�   (   5�      5�      5�      5�      �� 5�      $��Меню��6   $
��Left=�5�      $	��Top=�5�      $��72��5�      $��87��6    $��28(�5�      #��[ 5�      $��Center=�5�      $��Center=�5�      $ -2��5�      $��10,0,0,0q�5�      5�      �� 5�   
   -   5        $ CloseButton��5�      $
��Left=�5�      $��	930,0,0,0q�5�      $	��Top=�5�      $��70��5�      $��70��6   $ Depth0=�5�      
 ���� $ 1��5�   +   .��5�      � .+�5�      �� $��30��6   $��5��6'   #��[ 5�      $��Center=�5�      $	��Top=�5�      $ 0.5,0.5&�5�      z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�       �� Angle$	 -45Q�6.   T� 5�      5�      5�      �� 5�      $��30��6   $��5��6'   #��[ 5�      $��Center=�5�      $	��Top=�5�      $ 0.5,0.5&�5�      z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 45Q�6.   T� 5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ tcPages��5�      $
��Left=�5�      $	��551��5�      $	��930��6"   $��70,70,0,-21q�5�      $	��Top=�5�       �� TabStripPlacement$ Bottom=�5�      $��0q�5�      .@�5�      �� -   5         ��Name$ tiRest��5�      $��Рестораны��6&   .��5�      � ���	#FFE5E5E5.+�5�      �� $
��Auto=�6#   $
��Auto=�5�   #   .��5�      � -   5         �Name$ wpCards��5�   $   $	��900��5�   $   $
��Auto��60   $
��0 20q�5�   $   5�   $   5�      5�      5�      �� 5�      -   5        $ tiFood��5�      $��
Блюда��6&   .��5�      � ���	#FFE5E5E5 � ColumnDefinitions 5�      �� 5�      $��50 �6+   �� 5�      $	��260 �6+   �� 5�      $	��590 �6+   .+�5�      �� -   5        $ btBack��5�      $
��Left=�5�      $	��Top=�5�      $	��5 5q�5�      $��0q�5�      
������ 
������ $��50��5�      $��50��6(   $ Depth0=�5�      
 ���� $��0��5�      .��5�      � $��0q�6   $��45��6*   $��45��65   .+�5�        $ 	ArrowBack=�66   #��[ 5�   6   $��45��5�   6   $��45��6A   5�      5�      �� 5�      $��Hidden=�6#   $��Hidden=�5�   #   $��1��5�   #   .��5�      �� -   5         ��Name$ 
spSections��5�   %   $
��Auto��5�   %   $
��0 15q�5�   %   $��Right=�5�   %   5�      5      �� 5     $��Hidden=�6#   $��Hidden=�5  #   $��2��5  #   .��5     � -   5        $ wpFood��5  $   $	��580��5  $   $
��Auto��60   $��Center=�5  $   $
��0 20q�5  $    � 
ItemHeight$	 255��5  $     � 	ItemWidth$	  175��65   5	     5
     5     5     �� 5     -   5        $ tiBasket��5     $��Корзина��6(   .��5     � ���	#FFE5E5E5 5     �� 5     $	��590 �6+   �� 5     $	��320 �6+   .+�5     �� $��Hidden=�6#   $��Hidden=�5  #   $��0��5  #   .��5     �� -   5        $ spOrderBoxes��5  %   $	��580��5  %   $
��auto��5  %   5     5     � 5     $��1��6   .+�5     �� $��Bottom=�6$   $
��0 60q�5  $   $��25(�5  $   $
��Bold"�5  $   �� 5      $�Итого:��6"    �� 5!     �6"   �� *
TotalPrice+ �� 5"     $�руб.��6"   5#     �� 5$     -   5        $ btOrder��5$  !   $��Bottom=�5%  !   $
��0 20q�5&  !   $��Заказать��5'  !   64   5(     5)     5*     5+     5,     5-     