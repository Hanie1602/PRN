   M S B A M L   `   `   `  ����B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop  5   	       CarShop.RegisterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CarShop     5   	     � Title$  Register Window��5   	   $	��500��6!   $	��800��6.   ���#b8edff � WindowStartupLocation$ CenterScreen=�6O    � 
ResizeMode$ NoResize=�6t   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6"   $	��450��62   .+�5      �� $��Username��6   $��0,0,0,5q�6(   $��15(�69   
����  �$
��Bold"�6Y   �� 5      -   5        $��usernameTextBox��5      $��0,0,0,20q�6-   $��30��6?   $��15(�6K   �� 5      $��Password��6   $��0,0,0,5q�6(   $��15(�69   
����  �$
��Bold"�6Y   G� 5      -   5        $��passwordBox��5      $��0,0,0,20q�6-   $��30��6?   $��15(�6K   �� 5      $
��Name��6   $��0,0,0,5q�6$   $��15(�65   
����  �$
��Bold"�6U   �� 5      -   5        $��nameTextBox��5      $��0,0,0,20q�6)   $��30��6;   $��15(�6G   �� 5      $��Email��6   $��0,0,0,5q�6%   $��15(�66   
����  �$
��Bold"�6V   �� 5      -   5        $��emailTextBox��5      $��0,0,0,20q�6*   $��30��6<   $��15(�6H   �� 5!      $��Phone��6   $��0,0,0,5q�6%   $��15(�66   
����  �$
��Bold"�6V   �� 5"      -   5        $��phoneTextBox��5"      $��0,0,0,20q�6*   $��30��6<   $��15(�6H   �� 5$      $��Address��6   $��0,0,0,5q�6'   $��15(�68   
����  �$
��Bold"�6X   �� 5%      -   5        $��addressTextBox��5%      $��0,0,0,20q�6,   $��30��6>   $��15(�6J   5&      �� 5'   
   -   5        $��Register��5'      $	��158��6$   $��Center=�60   $��2��6j   $��0,291,0,113q�6z   $��1��6�   �� 5(   
   -   5        $��Back to Login��5(      $	��158��6)   $��Center=�65   $��0,225,0,177q�6R   $��2��6�   $��1��6�    J� RenderTransformOrigin$ 0.693,0.524&�6�   �� 5)   
   -	   5        $
��Quit��5)      $	��158��6    $��Center=�6,   $��2��6J   $��
0,359,0,46q�6Z   $��1��6n   6{   5*      5+      