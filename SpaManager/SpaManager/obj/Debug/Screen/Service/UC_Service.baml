   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SpaManager.Screen.ServiceSpaManager.Screen.Service  5      *    $SpaManager.Screen.Service.UC_Service   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      3local'clr-namespace:SpaManager.Screen.Service  5      .��5
      � 
�������.+�5   
   �� .+�5      �� $��50��6   $��0 20 0 0q�6%     �� Orientation$  
Horizontal=�67   .+�5      �� -   5        $��
btn_create��5   z   $��Create��6   ���#27ae60���#27ae60
�������$��50 0 0 0q�6h   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $	��100��5      �� 5      -   5        $��
btn_delete��5   z   $��Delete��6   ���#27ae60���#27ae60
�������$��20 0 0 0q�6h   $ Depth0=�5      $	��100��5      5      �� 5      -   5        $��btn_selectall��5      $��
600 0 0 0 q�60   $��Center=�6D   
��� � �5   N   �� 5      $��
Select All��6   $��16(�6.   $��10 0 0 0q�6<   $��Center=�6N   5      � 5      $	��480��6   .+�5      �� $
��1000��6   $��Hidden=�6,   .��5      �� .+�5      �� -   5        $��list_itemservice��5   '   $	��970��6?   ��5       �� 5!   "   .R�5"   &   ��  ��Name$ Border��5#   %   
��� � �$��2q�5"   A    �� CornerRadius$ 2��6U   $��0 10 0 0q�5#   5   ._�5$   *   �� $  
Horizontal=�65   .+�5%   .   ��  ��Name$ 	btn_check��6e   
��� � �$��Center=�6J   $��30 0 0 0q�5&   O    d� 	IsChecked 6+   �� *service_check+6O   �� 5(   .   $��60��64   $��60��6?   $��30 10 10 10q�6K   ��5)   2   �� 5*   6    �� 	UriSource 6B   �� *service_photo+5,   /   �� 5.   .   $	��200��69   $��Center=�6E   $��20 0 0 0q�6`   .+�5/   2   �� $��20(�6Z   $
��Bold"�6h   
���   ���6<   �� *service_name+50   0   �� 51   2   $  
Horizontal=�6=   .+�52   6   �� $��Price: ��6@   
�������6O   �� 53   6   
���������6@   �� *service_cost+54   0   55   3   56   /   �� 58   .   $	��300��69   $��Center=�6E   .+�59   2   �� 
���������6<   �� *service_description+6a   5;   /   �� 5=   .   $  
Horizontal=�69   $��Center=�6R   $	��120��6m   .+�5>   2   �� $��
Duration: ��6<   
�������6N   �� 5?   2   
���������6<   �� *service_duration+5@   0   5A   /   �� 5C   .   $  
Horizontal=�69   $��Center=�6R   $	��120��6m   .+�5D   2   �� $��	Transit: ��6<   
�������6M   �� 5E   2   
���������6<   �� *service_transit+5F   0   5G   /   5I   +   5J   '    �� Triggers 5L   &   �� 5M   *    �� Value$
 true��5N   .   	 �� Binding	 5M   6   �� *service_check+.a�5O   .   �� 
 �� 
TargetName$
 Border��65      MaterialDesignSelection �� Value# �   5Q   -    �� Property � ��5R   +   5T   #   5V      5W      5X      5Y      5[      �� 5\   
   $	��100��6   .+�5]      � -   5        $��progress_bar��5_   O   $��60��5]      $��60��6%   $��10 0 0 0q�61    % !MaterialDesignCircularProgressBar#��[ 6D    � Value$ 0Q�5^   &    � IsIndeterminate . 
��� � �5_   O   5`      5a      5b      