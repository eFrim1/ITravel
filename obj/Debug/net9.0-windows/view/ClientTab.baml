   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TravelAgency.viewTravelAgency.view  5      A%clr-namespace:TravelAgency.view_modelTravelAgency.view_model  5      !    TravelAgency.view.ClientTab   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TravelAgency.view     5      ;	viewModel%clr-namespace:TravelAgency.view_model     5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��300 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ClientDataGrid��5       $��0��6      AutoGenerateColumns$ False��66   $��10q�6R      SelectionMode$ Single=�5         
IsReadOnly$
 True��5         CanUserAddRows$ False��5      ��5      �� *	Clients+ �� Mode$ TwoWay=� �� SelectedItem 5      �� *SelectedClient+$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 ID��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Id+$ TwoWay=�  5      $ * 6%   $
	 Name��6/   
 6=   �� *Name+$ TwoWay=�  5      $ * 6%   $	 Email��6/   
 6>   �� *Email+$ TwoWay=�  5      $ * 6%   $	 Phone��6/   
 6>   �� *Phone+$ TwoWay=�5      � 5   
   $��1��6   $��10q�6     5      �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6     � ColumnDefinitions 5$      �� 5%      $
��Auto �6#   �� 5&      $��* �6#   .+�5)      �� $	��Id:��6   $��0��6#   $��0��60   $��Center=�6@   �� 5*      -   5        $��ClientId��5*      $��0��6&   $��1��63   $��5q�6C    �� 
IsReadOnly$
 True��5+   >   ��6   ��  �� Path$ SelectedClient.Id�6>   �� 5-      $��Name:��6   $��1��6%   $��0��62   $��Center=�6B   �� 5.      -   5        $��
ClientName��5.      $��1��6(   $��1��65   $��5q�6E   ��5/      �� $ SelectedClient.Name�$ TwoWay=��� 51      $��Email:��6   $��2��6&   $��0��63   $��Center=�6C   �� 52      -   5        $��ClientEmail��52      $��2��6)   $��1��66   $��5q�6F   ��53      �� $ SelectedClient.Email�$ TwoWay=��� 55      $��Phone:��6   $��3��6&   $��0��63   $��Center=�6C   �� 56      -   5        $��ClientPhone��56      $��3��6)   $��1��66   $��5q�6F   ��57      �� $ SelectedClient.Phone�$ TwoWay=�59      A� 5:   
   $��2��6   $��10q�6#    A� Columns$ 5��6/   .+�5;      �� $	��Add��6   $��5q�6#   $	��150��6.   ��6:   �� *AddClientCommand+$ TwoWay=��� 5<      $��Update��6   $��5q�6&   $	��150��61   ��6=   �� *UpdateClientCommand+$ TwoWay=��� 5=      $��Delete��6   $��5q�6&   $	��150��61   ��6=   �� *DeleteClientCommand+$ TwoWay=��� 5>      $��Export to CSV��6   $��5q�6-   $	��150��68   ��6D   �� *ExportToCsvCommand+�� 5?      $��Export to DOC��6   $��5q�6-   $	��150��68   ��6D   �� *ExportToWordCommand+5@      5A      5B      