   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SpaManager.Screen.RoomInfoSpaManager.Screen.RoomInfo  5      ,    &SpaManager.Screen.RoomInfo.UC_RoomInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      4local(clr-namespace:SpaManager.Screen.RoomInfo  5      .��5
      � 
�������.+�5   
   �� .+�5      �� $��50��6   $��0 20 0 0q�6%     �� Orientation$  
Horizontal=�67   .+�5      �� -   5        $��
btn_create��5   u   $��Create��6   
��� � �
�������
�������$��50,9,0,9q�6c   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $
��Auto��6g   �� 5      -   5        $��
btn_delete��5   u   $��Delete��6   
��� � �
�������
�������$��20 0 0 0q�6c   $ Depth0=�5      5      5      � 5      $	��480��6   .+�5      �� $
��1070��6   $��Hidden=�6,   .��5      �� .+�5      �� -   5        $��list_itemroom��5   '   $	��950��6<   ��5      �� 5   "   .R�5   &   �� $��Border��5   )   
��� � �$��2q�5   A    �� CornerRadius$ 2��6U   $��0 10 0 0q�6f   $��60��5   7   ._�5   *   �� $  
Horizontal=�65   .+�5   .   ��  ��Name$ btn_checkitem��67   $��30 0 0 0q�6o   $��Center=�6�   
��� � � d� 	IsChecked 6N   �� *
room_check+6�   �� 5!   .   $	��150��6R   $��Center=�6^   $
��Bold"�6y   $��20(�6�   $��30 0 0 0q�5"   4   ��5!   8   �� *
roomName+5"   4   �� 5$   .   $��Center=�6S   $	��180��6n   $��	300 0 0 0q�5%   0   ��5$   8   �� *	rTypeName+5%   0   �� 5&   .   $��Beds: ��68   $��Center=�6F   $��20 0 0 0q�6a   �� 5'   .   $��Center=�6Q   $��20��6l   ��68   �� *	maxBeds+6l   �� 5)   .   $��btn_eyes��5*   -   -   5           MaterialDesignToolButton#���   5)   5   $��	100 0 0 0q�6h   .��5+   2   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	EyeCircle=�6J   $��25��6[   $��25��6g   
��� � �6r   5,   /   5.   +   5/   '    �� Triggers 50   &   �� 51   *    �� Value$
 True��52   2    �� Binding 51   6   �� *
room_check+.a�53   .   �� 	 �� 
TargetName$	 Border��54   )     MaterialDesignSelection
 �� Value#
 �  56   )    �� Property � ��57   +   59   #   5;      5<      5=      5>      5@      �� 5A   
   $	��100��6   .+�5B      � -   5        $��progress_bar��5D   O   $��60��5B      $��60��6%   $��10 0 0 0q�61    % !MaterialDesignCircularProgressBar#��[ 6D    � Value$ 0Q�5C   &    � IsIndeterminate . 
��� � �5D   O   5E      5G      5H      