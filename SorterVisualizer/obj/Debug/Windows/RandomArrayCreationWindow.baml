   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   K GSorterVisualizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:SorterVisualizer.Resources.Localization'SorterVisualizer.Resources.Localization 5   	   8   2SorterVisualizer.Windows.RandomArrayCreationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   Nlocalization5clr-namespace:SorterVisualizer.Resources.Localization     5   	     � Title$  Array Creation��5   	   $	��300��6    $	��300��6-    � 
ResizeMode$ NoResize=�69    � WindowStyle$ 
ToolWindow=�5   	    � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value
 �� RelativeSource �� Path��%s  '��       �� 5	   
   " ��6    5
      P� 5       �@=�HasError . . �5      ��  �@�ToolTip	 60   �� 
 �� *Self+$) #(Validation.Errors)[0].ErrorContent��� 5       � ��
	 �  ��63   5      P� 5       �@=�HasError .  . �5      ��  � ��$	 2q�68   �� 5       � ��
	 � � �64   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��10 �6    � RowDefinitions 5    
   �� 5!      $��10 �6   �� 5"      $
��auto �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $
��auto �6   �� 5(      $��10 �6   .+�5,   
   �� -   5         ��Name$ tbDescription��5,      $��1��6,   $��1��6<   $��3��5-      $��0,0,0,5q�6(   O  ISorterVisualizer.Resources.Localization.MessagesRandomArrayCreationWindow   DescriptionText#��Z 69   $��WrapWithOverflow=�5.      �� 51   
   -   5         ��Name$ 
tbxColumns��51      $��1��6&   $��2��66   $��20��52      $��60��6!   $��Center=�6/   .��53      ��54      �� 55      $ ArrayInfo.ColumnsNumb�6    �� Mode$ OneWayToSource=�67    �� UpdateSourceTrigger$ PropertyChanged=�56       �� ValidatesOnDataErrors .  �� ValidationRules 57      5  /System.Windows.Controls.DataErrorValidationRule  58      5:      .��5;      5<      �� 5>   
   -   5        $ tbxRows��5>      $��1��6#   $��3��63   $��20��5?      $��60��6!   $��Center=�6/   .��6J   ��5@      �� 5A      $ ArrayInfo.RowsNumb�6   $ OneWayToSource=�64   $ PropertyChanged=�5B       5C        5D      5F      .��5G      5H      �� 5J   
   -   5        $ tbxMinValue��5J      $��1��6'   $��4��67   $��20��5K      $��60��6!   $��Center=�6/   .��6K   ��5L      �� 5M      $ ArrayInfo.MinValue�6   $ TwoWay=�64   $ PropertyChanged=�5N       5O        5P      5R      .��5S      5T      �� 5V   
   -   5        $ tbxMaxValue��5V      $��1��6'   $��5��67   $��20��5W      $��60��6!   $��Center=�6/   .��6J   ��5X      �� 5Y      $ ArrayInfo.MaxValue�6   $ TwoWay=�64   $ PropertyChanged=�5Z       5[        5\      5^      .��5_      5`      �� 5c   
   $��2��6   $��2��6$   $��2��61      ColumnsNumbText#��Z 5d      $��Center=�5e      $��5,0,0,0q�6/   �� 5f   
   $��2��6   $��3��6$   $��2��61      RowsNumbText#��Z 5g      $��Center=�5h      $��5,0,0,0q�6/   �� 5i   
   $��2��6   $��4��6$   $��2��61      MinValueText#��Z 5j      $��Center=�5k      $��5,0,0,0q�6/   �� 5l   
   $��2��6   $��5��6$   $��2��61      MaxValueText#��Z 5m      $��Center=�5n      $��5,0,0,0q�6/   �� 5q   
   -   5         ��Name$ btApply��5q      $��3��6"   $��6��62   $
��15,0q�5r      $��0,5,0,0q�6       	ApplyText#��Z 5s      ��5u      �� 5v      " ��6   .�5w      ��  � {�	 .  62    5x      ^� 5y       ^� 
Conditions 5z      �� 5{   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ 
tbxColumns�� �� Value	 False6s   �� 5|   "    6,   �� $ (Validation.HasError)�$ tbxRows��	 False6p   �� 5}   "    6,   �� $ (Validation.HasError)�$ tbxMinValue��	 False6t   �� 5~   "    6,   �� $ (Validation.HasError)�$ tbxMaxValue��	 False6t   .0�5�      ��  � {�	 . 6:   5�      5�      .   (System.Windows.Interactivity.Interaction   Triggers 5�      /   )System.Windows.Interactivity.EventTrigger  5�          	EventName$  Click��6!   .   (System.Windows.Interactivity.TriggerBase!   Actions.! 5�      6   0System.Windows.Interactivity.InvokeCommandAction  "   Command" 6,   �� $ CreateArrayCommand�5�      5�      5�      5�      