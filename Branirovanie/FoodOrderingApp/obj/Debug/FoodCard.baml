   M S B A M L   `   `   `  ����J  FFoodOrderingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FoodOrderingAppFoodOrderingApp  5          FoodOrderingApp.FoodCard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FoodOrderingApp     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $��Roboto)�5	   7   .��5
      �� ���#e9e9e9  �� CornerRadius$  10��5      
�������$��1q�5      ._�5   
   � .+�5      �� .+�5      �� -   5         ��Name$ Avatar��5      $	��145��5      $	��145��6$   $��10q�5       ^� ShowDuration$ 60000��5      ��5      �� *
ImageUrl+ � ToolTip 5      �� 5      $	��165��6$   $
��Wrap=�5   $   ��5   $   �� *Description+5   $   5      �� 5      ���	#DD000000$
��Auto��5      $��30��6)   $��10 0 5 5q�5      $
��Wrap=�5      $��11(�5      ��5       �� *
FoodName+]� 5!      $	��165��6   .+�5"      �� ���	#DD000000$
��Auto��67   $��10 0 5 0q�6D   �� 5#      $��14(�6"   $
��Bold"�60   �6B   �� *Price+ �� 5$      $��14(�6"   $
��Bold"�60   $	�₽��6B   �� 5%      �� 5&      $��10(�6"   .�60   
цена66   5'      �� 5(      -   5         ��Name$ btOrder��5(      $��48��6.   $��Right=�5)      $��Stretch=�5*      ���#d3d3d3
�������$��0 0 10 0q�5-      ���	#DD000000$��11(�5/      .��50      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Basket=�62   51      52      53      54       J� Effect 55   
   3  -System.Windows.Media.Effects.DropShadowEffect  56      -   5        
cardShadow��   Color$
 Gray��56   3      Opacity$	 0.5Q�6@   	 � Triggers	 58   
   :� 59      
 :� RoutedEvent$
 Border.MouseEnter��6   .[�5:      �� .��5;      �� .��5<      W�  �� 
TargetName$ 
cardShadow��6*    �� TargetProperty$ Opacity�5=   *   	 W� To$	 0.8X�5>   *    g� Duration$ 0:0:0.25D�5?   *   5@      5A      5B      :� 5C      $
 Border.MouseLeave��6   .[�5D      �� .��5E      �� .��5F      W� $ 
cardShadow��6*   $ Opacity�5G   *   $	 0.5X�5H   *   $ 0:0:0.25D�5I   *   5J      5K      5L      5N      5O      