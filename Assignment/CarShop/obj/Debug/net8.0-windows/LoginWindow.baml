   M S B A M L   `   `   `  ����B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop  5   	       CarShop.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CarShop     5   	   -   5          � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*   ���#b8edff � WindowStartupLocation$ CenterScreen=�6K    � 
ResizeMode$ NoResize=�6p   .��5	      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   �� 5      $��93.55 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $	��300��6%   $��	0,65,0,31q�61   $��2��6D   .+�5      �� $��Log in��6   $��80��6%   $	��300��61   $��Heavy"�6=   $��50(�6P   $��Center=�6_   �� 5      $��Username��6   $��0,0,0,5q�6(   $��18(�69   
����  �$
��Bold"�6Y   �� 5      -   5         ��Name$ usernameTextBox��5      $��0,0,0,20q�6/   $��30��6A   $��15(�6M   �� 5      $��Password��6   $��0,0,0,5q�6(   $��18(�69   
����  �$
��Bold"�6Y   G� 5      -   5         G�Name$ passwordBox��5      $��0,0,0,20q�6/   $��30��6A   $��15(�6M   5      �� 5   
   -   5        $
��Quit��5      $��0,10,176,47q�69   $��2��6N   $��1��6[   �� 5    
   -   5        $��Login��5       $��1��6;   $��176,10,0,47q�6K   $��2��6`   �� 5!   
   -   5        $��Register��5!      $��2��6A   $��116,10,10,259q�6Q   5"      5#      