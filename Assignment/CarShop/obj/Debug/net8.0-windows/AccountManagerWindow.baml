   M S B A M L   `   `   `  ����B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop  5   	   "    CarShop.AccountManagerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CarShop     5   	   -   5          � Title$  Account Management��5      $	��685��60   $
��1265��6=   ���#b8edff � WindowStartupLocation$ CenterScreen=�6_    � 
ResizeMode$ NoResize=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��586* �6   �� 5      $
��679* �6   .+�5   
   �� $��Account Management��6   $
��Left=�6-   $��80��6H   $��	31,20,0,0q�6T   $	��Top=�6g   $	��569��6   $��Heavy"�6�   $��50(�6�   $��Italic$�6�   $��2��6�   �� 5   
   $��
ver. 24-SU��6   $
��Left=�6%   $��50��6@   $��	12,40,0,0q�6L   $	��Top=�6_   $	��275��6w   $��30(�6�   $��Italic$�6�   $��1��6�   �� 5   
   -   5         ��Name$ HelloMsgLabel��5      $��Hello, Role��6'   $
��Left=�6=   $��50��6X   $��	343,6,0,0q�6d   $	��Top=�6w   $	��315��6�   $��25(�6�   $��Italic$�6�      YellowLabelStyle#��[  6�   $��Right=�6�   $��1��6	  �� 5   
   $
��Left=�6   $��95��6/   $��335,140,0,0q�6;   
���   �$	��Top=�6_   $	��875��6w   ���#1e90ff �� RadiusX$ 10��6�    �� RadiusY$ 10��6�   $��2��6�   �� 5   
   -   5         ��Name$ SearchButton��5      $��Search Account��6'   $
��Left=�6@   $��50��6[   $��
40,162,0,0q�6g   $	��Top=�6{   $	��262��6�   $��2��6�   6�   �� 5   
   $
��Name��6   $
��Left=�6   $��45��6:   $��434,167,0,0q�6F   $	��Top=�6[   $	��152��6s   
������� J� RenderTransformOrigin$ 0.158,0.405&�6�   �� 5   
   -   5        	 ��Name$	 NameTextBox��5      $
��Left=�6'   $��45��6B   $��526,165,0,0q�6N   
 �� TextWrapping$

 Wrap=�6c   $	��Top=�6x   $	��324��6�   $��0��6�   $��2��6�   �� 5   
   $��Email��6   $
��Left=�6    $��45��6;   $��311,170,0,0q�6G   $	��Top=�6\   $	��108��6t   
�������$��1��6�   �� 5   
   -   5        $	 EmailTextBox��5      $
��Left=�6(   $��45��6C   $��373,165,0,0q�6O   $

 Wrap=�6d   $	��Top=�6y   $	��229��6�   $��1��6�   $��1��6�   �� 5   
   -   5        $ CreateButton��5      $��Create��6'   $
��Left=�68   $��50��6S   $��478,294,0,0q�6_   $	��Top=�6t   $	��124��6�   $��3��6�   $��1��6�   6�   �� 5   
   -   5        $ UpdateButton��5      $��Update��6'   $
��Left=�68   $��50��6S   $��478,367,0,0q�6_   $	��Top=�6t   $	��124��6�   $��4��6�   $��1��6�   6�   �� 5   
   -   5        $ DeleteButton��5      $��Delete��6'   $
��Left=�68   $��50��6S   $��478,444,0,0q�6_   $	��Top=�6t   $	��124��6�   $��5��6�   $��1��6�   6�   �� 5   
   -	   5        $ 
QuitButton��5      $
��Quit��6%   $
��Left=�64   $��50��6O   $��478,540,0,0q�6[   $	��Top=�6p   $	��124��6�   $��6��6�   $��1��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ AdminDataGrid��5      $
��Left=�6*   $	��310��6E   $��
40,289,0,0q�6R   $	��Top=�6f   $	��973��6~      AutoGenerateColumns$ False��6�   $��7��6�   $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *UserId+  5!      $
 Name��6%   $	 150 63    6?   �� *Name+  5"      $ Email��6%   $	 150 64    6@   �� *Email+  5#      $ Adress��6%   $	 170 65    6A   �� *	Address+  5$      $ Phone��6%   $	 100 64    6@   �� *Phone+  5%      $ Username��6%   $	 120 67    6C   �� *
Username+  5&      $ Password��6%   $	 100 67    6C   �� *
Password+  5'      $
 Role��6%   $ 80 63    6>   �� *Role+5*      5,      5-      