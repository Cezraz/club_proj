   M S B A M L   `   `   `  ����J  FFoodOrderingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FoodOrderingAppFoodOrderingApp  5          FoodOrderingApp.OrderBox   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FoodOrderingApp     5        � 	Resources  5	         HeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius F�Name E� IsFilled E� 
StartPoint	 �� Point
 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity � Triggers :� RoutedEvent �� 
TargetName �� TargetProperty	 W� To g� Duration��%�  &	        �� 5
   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   #��z��5   !   #��z��5   !   #��z��5   !   $��2q�5   !   
�������._�5      ]� .+�5   "   (� $��10 4 0 3q�6*   $��Center=�5   *   $
��Left=�5   *   .��5   &   �� #��z��60   $
��Bold"�5   0   ���	#DD0000005   0   5   #   � 5   "   $��Right=�6'   $��0 0 10 3q�5   '   $	��180��5   '   $��40��63   .+�5   &   �� ���	#DD000000$��19(�5    0   $��Center=�5!   0   $
��Left=�5"   0   �� 5#   *   $�Позиций:��6.    �� 5$   *   �6.   �� *
ItemsCount+5%   '   � 5&   &   $��16��6+   .+�5'   *   F� $ 	pathArrow��6/   
�������$��2��5)   +   $��Right=�5*   +   ��5+   .   B� 5,   2   .��5-   6   E�  .  $	 1,1&�5.   =   .��5/   :   �� $	 15, 15&�6F   �� 50   :   $	 29, 1&�6F   51   7   52   3   54   +   55   '   57   #   58      
 59        5:   "   headerShadow��$
 Gray��5;   3   $	 0.5Q�5<   3    5>      :� 5?   "   $ Border.MouseEnter��6/   .[�5@   &   �� .��5A   *   �� .��5B   .   W� $ headerShadow��6>   $ Opacity�5C   >   $	 0.8X�5D   >   $ 0:0:0.25D�6G   5E   +   5F   '   5G   #   :� 5H   "   $ Border.MouseLeave��6/   .[�5I   &   �� .��5J   *   �� .��5K   .   W� $ headerShadow��6>   $ Opacity�5L   >   $	 0.5X�5M   >   $ 0:0:0.25D�6G   5N   +   5O   '   5P   #   5R      5S      5U      5V      5W      .��5Y      � $
��0 10q�6   .+�5Z   
   �� .+�5[      �� -   5         ��Name$ btHeader��5\      #��[  5^      $��40��5_      $��Stretch=�5`      
���������5[      �� *Title+5a      �� 5b      -   5        $
��Body��5b      $y�	Collapsed=�5c      
�������$��2q�5e      ���#e9e9e9 K� ZIndex$ -1��5g      $��2 5 2 0q�5h      $ 5��5i      ._�5j      A� -   5         A�Name$ ugItems��5j       A� Columns$ 3��5k   "   $
��auto��5l   "   $��8 5 0 0q�5m   "   
 5n        5o      -   5        
bodyShadow��$
 Gray��5p   '   $	 0.5Q�5q   '   5s      5t      5u      5v      