   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TravelAgency.viewTravelAgency.view  5      A%clr-namespace:TravelAgency.view_modelTravelAgency.view_model  5      "    TravelAgency.view.PackageTab   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TravelAgency.view     5      ;	viewModel%clr-namespace:TravelAgency.view_model     5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��300 �6   �� 62   $	��160 �6@   �� 6U   $
��Auto �6c   �� 5      $
��Auto �6   �� 62   $
��Auto �6@   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��PackageDataGrid��5         AutoGenerateColumns$ False��5      $��0��6/   $��10q�6<      SelectionMode$ Single=�5         
IsReadOnly$
 True��5         CanUserAddRows$ False��5      ��5      �� *
Packages+ �� Mode$ TwoWay=� �� SelectedItem 5      �� *SelectedPackage+$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 Id��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Id+$ TwoWay=�  5      $ * 6%   $	 Destination��6/   
 6D   �� *Destination+$ TwoWay=�  5      $ * 6%   $	 Period��6/   
 6?   �� *Period+$ TwoWay=�  5      $ * 6%   $	 Price��6/   
 6>   �� *Price+$ TwoWay=�  5      $ * 6%   $	 Image 1��6/   
 6@   �� *Image1+$ TwoWay=�  5      $ * 6%   $	 Image 2��6/   
 6@   �� *Image2+$ TwoWay=�  5      $ * 6%   $	 Image 3��6/   
 6@   �� *Image3+$ TwoWay=�5       � 5"   
   $��1��6   $��10q�6    � ColumnDefinitions 5#      �� 5$      $��* �6#   �� 5%      $��* �6#   �� 5&      $��* �6#   .+�5)      �� $��0��6   
�������$��1q�68   $��5q�6L   ._�5*      �� $��Uniform=�6   ��5+      �� *SelectedPackage.Image1+ �� TargetNullValue Z�  �� FallbackValue Z�  � ToolTip 5,      �� *SelectedPackage.Image1+5-      �� 5/      $��1��6   
�������$��1q�68   $��5q�6L   ._�50      �� $��Uniform=�6   ��51      �� *SelectedPackage.Image2+ Z�  Z�  52      �� *SelectedPackage.Image2+53      �� 55      $��2��6   
�������$��1q�68   $��5q�6L   ._�56      �� $��Uniform=�6   ��57      �� *SelectedPackage.Image3+ Z�  Z�  58      �� *SelectedPackage.Image3+59      5:      � 5<   
   $��2��6   $��10q�6     5=      �� 5>      $
��Auto �6    �� 5?      $
��Auto �6    �� 5@      $
��Auto �6    �� 5A      $
��Auto �6    �� 5B      $
��Auto �6     5D      �� 5E      $
��Auto �6#   �� 5F      $��* �6#   �� 5G      $
��Auto �6#   �� 5H      $��* �6#   .+�5K      �� $	��Id:��6   $��0��6#   $��0��60   $��Center=�6@   �� 5L      -   5        $��	PackageId��5L      $��0��6'   $��1��64   $��5q�6D    �� 
IsReadOnly$
 True��5M   L   ��6   ��  �� Path$ SelectedPackage.Id�$ TwoWay=�6L   �� 5O      $��Destination:��6   $��1��6,   $��0��69   $��Center=�6I   �� 5P      -   5        $��PackageDestination��5P      $��1��60   $��1��6=   $��5q�6M   ��5Q      �� $! SelectedPackage.Destination�$ TwoWay=��� 5S      $��Period:��6   $��2��6'   $��0��64   $��Center=�6D   �� 5T      -   5        $��PackagePeriod��5T      $��2��6+   $��1��68   $��5q�6H   ��5U      �� $ SelectedPackage.Period�$ TwoWay=��� 5W      $��Price:��6   $��3��6&   $��0��63   $��Center=�6C   �� 5X      -   5        $��PackagePrice��5X      $��3��6*   $��1��67   $��5q�6G   ��5Y      �� $ SelectedPackage.Price�$ TwoWay=��� 5[      $��Image 1:��6   $��0��6(   $��2��65   $��Center=�6E   �� 5\      -   5        $��PackageImage1��5\      $��0��6+   $��3��68   $��5q�6H   ��5]      �� $ SelectedPackage.Image1�$ TwoWay=��� 5_      $��Image 2:��6   $��1��6(   $��2��65   $��Center=�6E   �� 5`      -   5        $��PackageImage2��5`      $��1��6+   $��3��68   $��5q�6H   ��5a      �� $ SelectedPackage.Image2�$ TwoWay=��� 5c      $��Image 3:��6   $��2��6(   $��2��65   $��Center=�6E   �� 5d      -   5        $��PackageImage3��5d      $��2��6+   $��3��68   $��5q�6H   ��5e      �� $ SelectedPackage.Image3�$ TwoWay=�5f      A� 5h   
   $��3��6   $��10q�6#    A� Columns$ 5��6/   .+�5i      �� $	��Add��6   $��5q�6#   $	��150��6.   ��6:   �� *AddPackageCommand+�� 5j      $��Update��6   $��5q�6&   $	��150��61   ��6=   �� *UpdatePackageCommand+�� 5k      $��Delete��6   $��5q�6&   $	��150��61   ��6=   �� *DeletePackageCommand+�� 5l      $��Export to CSV��6   $��5q�6-   $	��150��68   ��6D   �� *ExportToCsvCommand+�� 5m      $��Export to DOC��6   $��5q�6-   $	��150��68   ��6D   �� *ExportToWordCommand+5n      � 5p   
   $��4��6   $��10q�6     5q      �� 5r      $
��Auto �6    �� 5s      $
��Auto �6     5u      �� 5v      $
��Auto �6#   �� 5w      $
��Auto �6#   �� 5x      $��* �6#   �� 5y      $
��Auto �6#   .+�5|      �� $��
Filter by:��6   $��0��6*   $��0��67   $��Center=�6G   $��5,0,0,0q�6b   �� 5}      -	   5        $��FilterByComboBox��5}      $��0��5~      $��1��6$   $��5q�5      $	��200��6"   ��5�      �� *FilterByOptions+ 5�      �� *SelectedFilterBy+�� 5�      -
   5        $��FilterValueTextBox��5�      $��0��5�      $��2��6#   $��5q�5�      $	��150��6!   $# Examples: Paris, >5, =1000.50��5�      ��5�      �� *FilterValue+ �� UpdateSourceTrigger$ PropertyChanged=�5�      �� 5�      $��Filter��6   $��0��5�      $��3��6"   $��5q�5�      $	��100��6    ��5�      �� *FilterCommand+�� 5�      $��Sort by:��6   $��1��6(   $��0��65   $��Center=�6E   $��5,0,0,0q�6`   �� 5�      -   5        $��SortByComboBox��5�      $��1��5�      $��1��6$   $��5q�5�      $	��200��6"   ��5�      �� *SortByOptions+ 5�      �� *SelectedSortBy+�� 5�      $
��Sort��6   $��1��5�      $��3��6"   $��5q�5�      $	��100��6    ��5�      �� *SortCommand+5�      5�      5�      