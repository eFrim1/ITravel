   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TravelAgency.viewTravelAgency.view  5      A%clr-namespace:TravelAgency.view_modelTravelAgency.view_model  5      (    "TravelAgency.view.BoughtPackageTab   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TravelAgency.view     5      ;	viewModel%clr-namespace:TravelAgency.view_model     5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��300 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��BoughtPackageDataGrid��5       $��0��6      AutoGenerateColumns$ False��5      $��10q�6/      SelectionMode$ Single=�5         
IsReadOnly$
 True��5         CanUserAddRows$ False��5      ��5      �� *BoughtPackages+ �� Mode$ TwoWay=� �� SelectedItem 5      �� *SelectedBoughtPackage+$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 ID��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Id+$ TwoWay=�  5      $ * 6%   $	 	Client ID��6/   
 6B   �� *
ClientId+$ TwoWay=�  5      $ * 6%   $	 
Package ID��6/   
 6C   �� *	PackageId+$ TwoWay=�  5      $ * 6%   $	 Bought Date��6/   
 6D   �� *
BoughtDate+$ TwoWay=�  5      $ * 6%   $	 	Departure��6/   
 6B   �� *	Departure+$ TwoWay=�  5      $ * 6%   $	 Arrival��6/   
 6@   �� *	Arrival+$ TwoWay=�5!      � 5"   
   $��1��6   $��10q�6     5#      �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6     � ColumnDefinitions 5)      �� 5*      $
��Auto �6#   �� 5+      $��* �6#   �� 5,      $
��Auto �6#   �� 5-      $��* �6#   .+�50      �� $	��ID:��6   $��0��6#   $��0��60   $��Center=�6@   �� 51      -   5        $��BoughtPackageId��51      $��0��6-   $��1��6:   $��5q�6J    �� 
IsReadOnly$
 True��52   R   ��6   ��  �� Path$ SelectedBoughtPackage.Id�$ TwoWay=�6R   �� 54      $��
Client ID:��6   $��1��6*   $��0��67   $��Center=�6G   �� 55      -   5        $��ClientId��55      $��1��6&   $��1��63   $��5q�6C   ��56      �� $$ SelectedBoughtPackage.ClientId�$ TwoWay=��� 58      $��Package ID:��6   $��2��6+   $��0��68   $��Center=�6H   �� 59      -   5        $��	PackageId��59      $��2��6'   $��1��64   $��5q�6D   ��5:      �� $% SelectedBoughtPackage.PackageId�$ TwoWay=��� 5<      $��Bought Date:��6   $��3��6,   $��0��69   $��Center=�6I   (  "System.Windows.Controls.DatePicker  5=      -   5        $��
BoughtDate��5=      $��3��6+   $��1��68   $��5q�6H      SelectedDate 5>      �� $&  SelectedBoughtPackage.BoughtDate�$ TwoWay=��� 5@      $��
Departure:��6   $��0��6*   $��2��67   $��Center=�6G     5A      -   5        $��	Departure��5A      $��0��6*   $��3��67   $��5q�6G    5B      �� $% SelectedBoughtPackage.Departure�$ TwoWay=��� 5D      $��Arrival:��6   $��1��6(   $��2��65   $��Center=�6E     5E      -   5        $��Arrival��5E      $��1��6(   $��3��65   $��5q�6E    5F      �� $# SelectedBoughtPackage.Arrival�$ TwoWay=�5H      A� 5J   
   $��2��6   $��10q�6#    A� Columns$ 5��6/   .+�5K      �� $	��Add��6   $��5q�6#   $	��150��6.   ��6:   �� *AddBoughtPackageCommand+$ TwoWay=��� 5L      $��Update��6   $��5q�6&   $	��150��61   ��6=   �� *UpdateBoughtPackageCommand+$ TwoWay=��� 5M      $��Delete��6   $��5q�6&   $	��150��61   ��6=   �� *DeleteBoughtPackageCommand+$ TwoWay=��� 5N      $��Export to CSV��6   $��5q�6-   $	��150��68   ��6D   �� *ExportToCsvCommand+�� 5O      $��Export to DOC��6   $��5q�6-   $	��150��68   ��6D   �� *ExportToWordCommand+5P      � 5R   
   $��3��6   $��10q�6     5S      �� 5T      $
��Auto �6    �� 5U      $
��Auto �6     5W      �� 5X      $
��Auto �6#   �� 5Y      $��* �6#   �� 5Z      $
��Auto �6#   .+�5]      �� $��Search by client name:��6   $��0��66   $��0��6C   $��Center=�6S   �� 5^      -   5        $��SearchClientNameTextBox��5^      $��0��65   $��1��6B   $��5q�6R   ��6]   �� *
ClientName+$ TwoWay=��� 5_      $��Search��6   $��0��6&   $��2��63   $��5q�6C   $	��150��6N   ��6Z   �� *SearchCommand+$ TwoWay=�5`      5a      5b      