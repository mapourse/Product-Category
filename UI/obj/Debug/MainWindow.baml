   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  Product List��5   	   $	��400��6   $	��600��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �5      �� 5      $	��10* �5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DG_Info��5      $��1��5      $��
5, 0, 5, 5q�5       � ContextMenu 5      �� 5      .@�5      m� -   5        $��
CMI_Modify��5      $��Modify��5      5      m� 5      -   5        $��
CMI_Delete��5      $��Delete��5      5      5      5       �� 5!   
   -   5        $��Bttn_NewProduct��5%      $��5q�5"      $��20��5#      $
��5, 0q�5$      $��Center=�5&      $��Right=�5'      .��5(   +   Add5*      �� 5+   
   $��0q�5,      $��20(�5-      $��	ExtraBold"�5.      $��Center=�5/      .��6*   PRODUCT LIST51      52      53      