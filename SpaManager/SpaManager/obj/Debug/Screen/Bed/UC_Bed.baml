   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SpaManager.Screen.BedSpaManager.Screen.Bed  5      "    SpaManager.Screen.Bed.UC_Bed   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      /local#clr-namespace:SpaManager.Screen.Bed  5      .��5
      � 
�������.+�5   
   �� .+�5      �� $��50��6   $��0 20 0 0q�6%     �� Orientation$  
Horizontal=�67   .+�5      �� -   5        $��
btn_create��5   u   $��Create��6   
��� � �
�������
�������$��50,9,0,9q�6c   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $
��Auto��6g   �� 5      -   5        $��
btn_delete��5   u   $��Delete��6   
��� � �
�������
�������$��20 0 0 0q�6c   $ Depth0=�5      5      5      � 5      $	��470��6   .+�5      �� $
��1060��6   $��Hidden=�6,   .��5      �� .+�5      �� -   5        $��list_itembed��5   '   $	��950��6;   ��5      �� 5   "   .R�5   &   �� $��Border��6x   
��� � �$��2q�6A    �� CornerRadius$ 2��6U   $��0 10 0 0q�6f   $��60��6�   ._�5   *   �� $  
Horizontal=�65   .+�5   .   ��  ��Name$ btn_checkitem��67   $��30 0 0 0q�6n   $��Center=�6�   
��� � � d� 	IsChecked 6N   �� *	bed_check+6�   �� 5!   .   $��80��6Q   $��Center=�6\   $
��Bold"�6w   $��20(�6�   $��20 0 0 0q�5"   4   ��5!   8   �� *	bedName+5"   4   5#   +   5$   '    �� Triggers 5%   &   �� 5&   *    �� Value$
 True��5'   2    �� Binding 5&   6   �� *	bed_check+.a�5(   .   ��  �� 
TargetName$ Border��5)   )      MaterialDesignSelection	 �� Value#	 �   5+   )   
 �� Property
 � ��5,   +   5.   #   50      51      52      53      55      �� 57   
   $	��100��6   .+�58      � -   5        $��progress_bar��5:   O   $��60��58      $��60��6)   $��10 0 0 0q�65    % !MaterialDesignCircularProgressBar#��[ 6H    � Value$ 0Q�59   &    � IsIndeterminate . 
��� � �5:   O   5;      5=      5>      