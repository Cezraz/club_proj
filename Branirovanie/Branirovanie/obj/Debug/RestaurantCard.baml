   M S B A M L   `   `   `  ����G  CBranirovanie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BranirovanieBranirovanie  5      !    Branirovanie.RestaurantCard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Branirovanie     5      $��Roboto)�5   7   .��5	      �� ���#e9e9e9  �� CornerRadius$  10��5
      
�������$��1q�5      $��15 10q�5      ._�5   
   � .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ Avatar��5      $	��170��5      $	��170��6(   $��10 15q�5      ��5      �� 5       �� ImageSource 6%   �� *	ImagePath+5      �� 5      -   5         ��Name$ spInfo��5      .+�5      �� $	��225��5      $��40��6(   $��	0 15 0 10q�5      
���   �$��Center=�5      $��Center=�5      $��22(�5      $
��Bold"�5      ��5      �� *Title+5      �� 5       $ 
Horizontal=�6!   $��0 0 0 15q�6:   .+�5!      �� ���	#DD000000$	��105��6;   $	��5 0q�6G   �� 5"      $��18(�6"   $
��Bold"�60   �6B   �� *MinOrderSum+6a   �� 5#      �� 5$      $��10(�6"   .�60    мин.сумма заказа6B   5%      �� 5&      ���	#DD000000$	��110��6;   �� 5'      $��18(�6"   $
��Bold"�60   �6B   �� *DeliveryCost+6b   �� 5(      �� 5)      $��10(�6"   .�60   %#стоимость доставки6D   5*      5+      �� 5,      
���   �$��Center=�5.      $��0 0 0 15q�5/      ��5,      �� *
WorkTime+5/      �� 50      -   5        $��34��50      ���#d3d3d3
�������$��0 0 15 0q�53      $��Заказать��54      ���	#DD000000$��15(�56      6+   57      58      59       J� Effect 5:   
   3  -System.Windows.Media.Effects.DropShadowEffect  5;      -   5        
cardShadow��   Color$
 Gray��5;   3      Opacity$	 0.5Q�6@    � Triggers 5=   
   :� 5>      	 :� RoutedEvent$	 Border.MouseEnter��6   .[�5?      �� .��5@      �� .��5A      W� 
 �� 
TargetName$
 
cardShadow��6*    �� TargetProperty$ Opacity�5B   *   	 W� To$	 0.8X�5C   *    g� Duration$ 0:0:0.25D�5D   *   5E      5F      5G      :� 5H      $	 Border.MouseLeave��6   .[�5I      �� .��5J      �� .��5K      W� $
 
cardShadow��6*   $ Opacity�5L   *   $	 0.5X�5M   *   $ 0:0:0.25D�5N   *   5O      5P      5Q      5S      5T      