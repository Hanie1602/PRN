   M S B A M L   `   `   `  ����B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop  5   	   #    CarShop.ProductsManagerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CarShop     5   	   -   5          � Title$  Product Window��5      $	��685��6(   $
��1265��65   ���#b8edff � WindowStartupLocation$ CenterScreen=�6W    � 
ResizeMode$ NoResize=�6|   .��5	      � .+�5   
   �� $��Product Management��6   $
��Left=�6-   $��80��6H   $��	31,20,0,0q�6T   $	��Top=�6g   $	��569��6   $��Heavy"�6�   $��50(�6�   $��Italic$�6�   �� 5   
   $��
ver. 24-SU��6   $
��Left=�6%   $��50��6@   $��
598,40,0,0q�6L   $	��Top=�6`   $	��275��6x   $��30(�6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ HelloMsgLabel��5      $��Hello, Role��6'   $
��Left=�6=   $��50��6X   $��	929,6,0,0q�6d   $	��Top=�6w   $	��315��6�   $��25(�6�   $��Italic$�6�      YellowLabelStyle#��[  6�   $��Right=�6�   �� 5   
   $
��Left=�6   $��95��6/   $��335,140,0,0q�6;   
���   �$	��Top=�6_   $	��875��6w   ���#1e90ff �� RadiusX$ 10��6�    �� RadiusY$ 10��6�   �� 5   
   -   5         ��Name$ SearchButton��5      $��Search Product��6'   $
��Left=�6@   $��50��6[   $��
40,162,0,0q�6g   $	��Top=�6{   $	��262��6�   $��2��6�   6�   �� 5   
   $��Car Name��6   $
��Left=�6#   $��45��6>   $��389,170,0,0q�6J   $	��Top=�6_   $	��109��6w   
������� J� RenderTransformOrigin$ 0.158,0.405&�6�   �� 5   
   -   5         ��Name$ CarNameTextBox��5      $
��Left=�6*   $��45��6E   $��526,165,0,0q�6Q   	 �� TextWrapping$
	 Wrap=�6f   $	��Top=�6{   $	��324��6�   $��0��6�   �� 5   
   $��Quantity��6   $
��Left=�6#   $��45��6>   $��905,169,0,0q�6J   $	��Top=�6_   $	��108��6w   
�������6�   �� 5   
   -   5        $ QuantityTextBox��5      $
��Left=�6+   $��45��6F   $��1003,165,0,0q�6R   $
	 Wrap=�6h   $	��Top=�6}   $	��185��6�   $��1��6�   �� 5   
   -   5        $ CreateButton��5      $��Create��6'   $
��Left=�68   $��50��6S   $��1064,294,0,0q�6_   $	��Top=�6u   $	��124��6�   $��3��6�   6�   �� 5   
   -   5        $ UpdateButton��5      $��Update��6'   $
��Left=�68   $��50��6S   $��1064,367,0,0q�6_   $	��Top=�6u   $	��124��6�   $��4��6�   6�   �� 5   
   -   5        $ DeleteButton��5      $��Delete��6'   $
��Left=�68   $��50��6S   $��1064,444,0,0q�6_   $	��Top=�6u   $	��124��6�   $��5��6�   6�   �� 5   
   -	   5        $ 
QuitButton��5      $
��Quit��6%   $
��Left=�64   $��50��6O   $��1064,540,0,0q�6[   $	��Top=�6q   $	��124��6�   $��6��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -
   5        
  Name$
 ProductDataGrid��5      $
��Left=�6,   $	��310��6G   $��
40,289,0,0q�6T   $	��Top=�6h   $	��973��6�      AutoGenerateColumns$ False��6�   $��7��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	ProductId+  5      $
 Name��6%   $	 200 63    6?   �� *ProductName+  5      $ Price��6%   $ 70 64    6?   �� *Price+  5       $ Quantity��6%   $ 70 67    6B   �� *
Quantity+  5!      $ Image��6%   $	 100 64    6@   �� *Image+  5#      $ Description��6%   $ 70 6:    6E   �� *Description+  5$      $ Model��6%   $	 100 64    6@   �� *Model.ModelName+  5%      $ Discount (%)��6%   $ 80 6;    6F   �� *Discount.DiscountRate+5(      5*      5+      