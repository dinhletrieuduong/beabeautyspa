   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SpaManager.Screen.LoginSpaManager.Screen.Login  5   	   #    SpaManager.Screen.Login.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:SpaManager.Screen.Login  5   	     � Title$  Login��5	   	   $	��600��6   $	��500��6$    � WindowStartupLocation$ CenterScreen=�60   .��5
      � .+�5   
   �� ��5      �� 5      .��5      �  � Color$ #2ecc71��6#    � Offset$	 0.6Q�63   � 5      $ #27ae60��6#   $	 0.4Q�63   5      5      �� 5   
   $��0 50 0 0q�6   .+�5      �� $	��200��6   $��Center=�6&   $��Center=�6A   .+�5      �� $	��200��6   ��5      �� 5       �� 	UriSource$ BeaBeautyLogo.png?�6&   5      5      �� 5      $	��300��6   $��0 20 0 0q�6&   .+�5      �� $	��300��6   $��Center=�6+   .+�5      �� $��40��6!   $	��300��6-    �� Orientation$ 
Horizontal=�69   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�62   $��30��6>   $��30��6J   
�������6U   �� 5       $��Username��6$   $��16(�64   $��30��6B   $��10 0 0 0q�6N   
�������6`   5!      �� 5"      $��30��6!   $ 
Horizontal=�6-   $	��300��6F   .+�5#      �� $	��300��6!   $��30��6-   $��2q�69    �� CornerRadius$ 5��6M   
��� � �
�������._�5$      �� -   5         ��Name$ txt_username��5$   &   $��0q�6<   .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 Hidden=�6f   $��Center=�6�   
 �� 
CaretBrush
 6P   Z� 6�   5%      5&      �� 5'      $��40��6!   $	��300��6-   $ 
Horizontal=�69   $��	00 10 0 0q�6R   .+�5(        $
 lock=�62   $��30��6>   $��30��6J   
�������6U   �� 5)      $��Password��6$   $��16(�64   $��30��6B   $��10 0 0 0q�6N   
�������6`   5*      �� 5+      $��30��6!   $ 
Horizontal=�6-   $	��300��6F   .+�5,      �� $	��300��6!   $��30��6-   $��2q�69   $ 5��6M   
��� � �
�������._�5-      G� -   5         G�Name$ txt_password��5-   *   $��0q�6@   $	 Hidden=�6j   $��Center=�6�    G� 
CaretBrush 6T   Z� 6�   5.      5/      �� 51      $��50��6!   $	��300��6-   $
��0 30q�69   $ 
Horizontal=�6G   .+�52      �� -   5        $��	btn_login��52   !   $��Login��62   $	��100��6B   $��45��6N   
�������$��95 0 0 0q�6m   
�������$
��Bold"�6�   $��20(�53   !   $��2q�6/   
��� � �6[   � 54      -   5        $��progress_bar��56   O   $��30��54   &   $��30��61   $��10 0 0 0q�6=    %  !MaterialDesignCircularProgressBar#��[  6P    � Value$ 0Q�55   &    � IsIndeterminate . 
�������$y�	Collapsed=�56   c   59      5;      5<      5=      5>      5?      