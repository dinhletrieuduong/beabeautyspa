   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SpaManager.Screen.OutletSpaManager.Screen.Outlet  5      (    "SpaManager.Screen.Outlet.UC_Outlet   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      2local&clr-namespace:SpaManager.Screen.Outlet  5      .��5
      � 
�������.+�5   
   �� .+�5      �� $��50��6   $��0 20 0 0q�6%     �� Orientation$  
Horizontal=�67   .+�5      �� -   5        $��
btn_create��5   z   $��Create��6   ���#27ae60���#27ae60
�������$��20 0 0 0q�6h   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      6N   �� 5      -   5        $��
btn_delete��5   z   $��Delete��6   ���#27ae60���#27ae60
�������$��20 0 0 0q�6h   $ Depth0=�5      6N   �� 5      -   5        $��btn_viewservice��5   �   $��Manage service��6   ���#2980b9���#2980b9
�������$��20 0 0 0q�6p   $ Depth0=�5      $	��160��5      �� 5      -   5        $��
btn_active��5   {   $��Active��6   ���#27ae60���#27ae60
�������$��	500 0 0 0q�6h   $ Depth0=�5      6N   �� 5      -   5        $��btn_deactive��5   }   $��	De-Active��6   ���#27ae60���#27ae60
�������$��20 0 0 0q�6k   $ Depth0=�5      6N   5      � 5      $	��470��6   .+�5      �� $��Hidden=�6   $
��1000��6D   .��5      �� .+�5      �� -   5         ��Name$ list_itemoutlet��5   '   $	��950��6@   ��5       �� 5!   "   .R�5"   &   �� $��Border��6-   $��2q�6;    �� CornerRadius$ 2��6O   
��� � �$��0 10 0 0q�5#   5   ._�5%   *   �� $  
Horizontal=�65   .+�5&   .   ��  ��Name$ 	btn_check��67   $��Center=�5'   -   
���   �
��� � �$��20 0 0 0q�6o    d� 	IsChecked 5&   J   �� *outlet_check+5'   o   �� 5)   .   $��60��64   $��Center=�6@   $��50 10 10 10q�6[   $��60��6p   ��5+   2   �� 5,   6    �� 	UriSource 6B   �� *outlet_image+5.   /   �� 5/   .   $��20 0 0 0q�69   $��Center=�6K   .+�50   2   �� $��20(�6Z   $
��Bold"�6h   
���   ���6<   �� *outlet_name+6z   �� 51   2   
���   �$	��350��6o   ��6<   �� *outlet_address+6o   52   /   �� 54   .   $��txt_status_outlet��56   -   $��Center=�54   \   $��50 0 0 0q�55   -   $
��Bold"�6?   ��54   8   �� *outlet_status_name+��57   2   �� 58   6    �� 
TargetType" ��6<   .�59   :   ��  �� Property � ��	 �� Value
	 � � �6W   
 �� Triggers
 5:   :   �� 5;   >    �� Binding 6J   �� *outlet_status_name+ �� Value Không hoạt động6q   .a�5<   B   ��  � ��
	 �  ��6_   5=   ?   5?   7   5A   /   �� 5C   .   $��btn_eyes��5D   )   -   5           MaterialDesignToolButton#���   5C   5   $��	100 0 0 0q�6h   .��5E   2   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	EyeCircle=�6J   $��25��6[   $��25��6g   
��� � �6r   5F   /   5H   +   5I   '    �� Triggers 5J   &   �� 5K   *   $
 true��5M   %    5L   %   �� *outlet_check+.a�5O   .   ��  �� 
TargetName$ Border��65     MaterialDesignSelection#	 �  5Q   )    � ��5S   +   5V   #   5X      5Z      5[      5\      5_      �� 5`   
   $	��100��6   .+�5a      � -   5        $��progress_bar��5c   O   $��60��5a      $��60��6%   $��10 0 0 0q�61    % !MaterialDesignCircularProgressBar#��[ 6D    � Value$ 0Q�5b   &    � IsIndeterminate . 
��� � �5c   O   5d      5f      5g      