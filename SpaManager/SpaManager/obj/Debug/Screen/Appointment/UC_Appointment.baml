   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SpaManager.Screen.AppointmentSpaManager.Screen.Appointment  5      2    ,SpaManager.Screen.Appointment.UC_Appointment   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      7local+clr-namespace:SpaManager.Screen.Appointment  5      .��5
      � 
�������.+�5   
   � $	��470��6   .+�5      �� $
��1000��6   $��Hidden=�6(   .��5      �� .+�5      �� -   5        $��list_itemappt��5   0   $	��470��6#   $��	50 0 50 0q�6E   ��5      �� 5      .R�5   "   �� $��Border��6t   
��� � �$��2q�6=     �� CornerRadius$  2��6Q   $��0 10 0 0q�6b   $��60��6�   ._�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5   *   ��  ��Name$ btn_checkitem��63   $��30 0 0 0q�6k   $��Center=�6}   
��� � � d� 	IsChecked 6J   �� *
appt_check+6�   �� 5   *   $��80��6Q   $��Center=�6\   $
��Bold"�6w   $��20(�6�   $��20 0 0 0q�5   4   ��5   4   �� *status_name+5   4   �� 5   *   $��Center=�65   $ 
Horizontal=�6P   $��50 0 0 0q�6i   .+�5   .   �� $��Total price: ��68   �� 5   .   $��80��6U   $
��Bold"�6`   
��� � ���68   �� *total_price+6r   5   +   �� 5   *   $ 
Horizontal=�65   $��Center=�6N   $��50 0 0 0q�6i   .+�5   .   �� $	��120��6T   
���  ��$
��Bold"�6q   ��68   �� *
start_time+6q   �� 5   .   $��-��68   
���  ��$
��Bold"�6R   �� 5   .   $	��120��6R   $��10 0 0 0q�6^   
���  ��$
��Bold"�6�   ��68   �� *
end_time+6�   5    +   5!   '   5"   #    �� Triggers 5#   "   �� 5$   &    �� Value$
 True��5%   2    �� Binding 5$   2   �� *
appt_check+.a�5&   *   ��  �� 
TargetName$ Border��5'   )      MaterialDesignSelection �� Value# �   5)   )   	 �� Property	 � ��5*   '   5,      5.      5/      50      51      �� 53   
   $	��100��6   .+�54      � -   5        $��progress_bar��56   O   $��60��54      $��60��6%   $��10 0 0 0q�61    % !MaterialDesignCircularProgressBar#��[ 6D   
 � Value$
 0Q�55   &    � IsIndeterminate . 
��� � �56   O   57      58      59      