   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   K GSorterVisualizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:SorterVisualizer.Resources.Localization'SorterVisualizer.Resources.Localization 5   	   D   >SorterVisualizer.Windows.ArrayInitializationFromDatabaseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   Nlocalization5clr-namespace:SorterVisualizer.Resources.Localization     5   	     � Title$  Database��5   	   $	��350��6   $	��500��6'    � 
ResizeMode$ NoResize=�63    � WindowStyle$ 
ToolWindow=�6I    � 	Resources 5	      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType��%+  '        '  L     �� 5
   
   "  6   .�5      ��  � ��$ Center=�6;   5      �� 5   
   "  6   .�5      ��  � �� 5      �� 5      "  6&   .R�5      � #��z��6   .+�5      �� $��Center=�6/   $��Right=�6J   5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5       $��10 �6   	 � RowDefinitions	 5"   
   �� 5#      $��10 �6   �� 5$      $
��auto �6   �� 5%      $��* �6   �� 5&      $��10 �6   .+�5*   
   �� -   5        
 ��Name$
 tbDescription��5*      $��1��6+   $��1��6;   [  USorterVisualizer.Resources.Localization.MessagesArrayInitializationFromDatabaseWindow   DescriptionText#��Z 6H   �� 5-   
   -   5         ��Name$ btApply��5-      $��2��6"   $��1��62      	ApplyText#��Z 6?   $
��15,0q�5.      $��5q�6    ��6+   ��  �� Path$ ApplyArrayIDCommand�&   System.Windows.Controls.DataGrid  51   
   -   5          Name$ dgSortersInfo��51      $��1��6*   $��2��6:   $��2��6G      
IsReadOnly .    SelectionMode$ Single=�52   %      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     RowHeaderWidth$ 30Q�54   <      	RowHeight$ 25Q�6P   ��6   �� $ InputArrays�.   (System.Windows.Interactivity.Interaction   Triggers 56      /   )System.Windows.Interactivity.EventTrigger  57         	EventName$ SelectionChanged��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 58      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� $ SelectArrayCommand�   CommandParameter 6X   ��  �� ElementName$ dgSortersInfo��$ CurrentItem�59         Columns 5<      0	  *System.Windows.Controls.DataGridTextColumn	  5=      ,
  &System.Windows.Controls.DataGridColumn 
  
Visibility$ 	Collapsed=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� $ ArrayId�	  5>        
  Width5  /System.Windows.Controls.DataGridLengthConverter$  * 6%   !   ColumnsNumberText" 
  Header#" Z! 6/    5?   %   �� $ NumberOfColumns�	  5@      $  * 6%   #   RowsNumberText#" Z# 6/    5A   %   �� $ NumberOfRows�5C      5E      5F      