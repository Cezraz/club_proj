   M S B A M L   `   `   `  ����J  FFoodOrderingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FoodOrderingAppFoodOrderingApp  5      %    FoodOrderingApp.FoodOrderedCard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FoodOrderingApp     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $��Roboto)�5	   7   .��5
      � .+�5   
   �� ���#e9e9e9  �� CornerRadius$  10��5      
�������$��1q�5      ._�5      � .+�5      �� .+�5      �� -   5         ��Name$ Avatar��5      $	��145��5      $	��145��6$   $��10q�5       ^� ShowDuration$ 60000��5      ��5      �� *
ImageUrl+ � ToolTip 5      �� 5      $	��165��6(   $
��Wrap=�5   $   ��5   $   �� *Description+5   $   5      �� 5      ���	#DD000000$
��Auto��5      $��30��6)   $��10 0 5 5q�5      $
��Wrap=�5      $��11(�5       ��5!      �� *
FoodName+]� 5"      $	��165��6    .+�5#      �� ���	#DD000000$
��Auto��6;   $��10 0 5 0q�6H   �� 5$      $��14(�6"   $
��Bold"�60   �6B   �� *Price+ �� 5%      $��14(�6"   $
��Bold"�60   $	�₽��6B   �� 5&      �� 5'      $��10(�6"   .�60   
цена66   5(      �� 5)       �� Orientation$ 
Horizontal=�6%   $��Right=�5*   %   $
��Auto��5+   %   $��0 0 15 0q�5,   %   .+�5-      �� -   5         ��Name$ btDec��5-   %   $��20��64   $��20��6?   ��5.   "   �� 5/   &    �� 
TargetType" ��66   .R�50   *   (� $��0q�62   .��51   .   � $��15��63   $��15��6>   .+�52   2   A� 
�������$��1��53   2   
�������54   2   �� 55   2   $��Center=�6<   $	��–��56   8    �� TextAlignment$ Center=�57   8   $��Center=�58   8   ���	#DD00000059   8   5:   /   5;   +   5<   '   5>      �� 5?      $��23��5@   (   $��20(�5A   (   $��Center=�5B   (   $	��5 0q�5C   (   ���	#DD000000��5?   (   �� *
Quantity+5D   (   �� 5E      -   5        $ btInc��5E   %   $��20��64   $��20��6?   ��5F   "   �� 5G   &   " ��66   .R�5H   *   (� $��0q�62   .��5I   .   � $��15��63   $��15��6>   .+�5J   2   A� 
�������$��1��5K   2   
�������5L   2   �� 5M   2   $��Center=�6<   $��+��5N   8   $ Center=�5O   8   $��Center=�5P   8   ���	#DD000000$
��0,-1q�5R   8   $��15��6F   5S   /   5T   +   5U   '   5W      5X      5Y      �� 5Z      -   5        $ btDelete��5Z      ���#d3d3d3
�������$��25��5\      $
��10 7q�5]      $��Удалить��5^      ���	#DD0000005_   4   5`      5a       J� Effect 5b      3  -System.Windows.Media.Effects.DropShadowEffect  5c      -   5        
cardShadow��	   Color$
	 Gray��5c   7   
   Opacity$	
 0.5Q�6D    � Triggers 5e      :� 5f       :� RoutedEvent$ Border.MouseEnter��6   .[�5g      �� .��5h      �� .��5i      W�  �� 
TargetName$ 
cardShadow��6.    �� TargetProperty$ Opacity�5j   *   	 W� To$	 0.8X�5k   *    g� Duration$ 0:0:0.25D�5l   *   5m      5n      5o      :� 5p      $ Border.MouseLeave��6   .[�5q      �� .��5r      �� .��5s      W� $ 
cardShadow��6.   $ Opacity�5t   *   $	 0.5X�5u   *   $ 0:0:0.25D�5v   *   5w      5x      5y      5{      5|      5}      