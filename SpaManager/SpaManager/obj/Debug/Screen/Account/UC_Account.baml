   M S B A M L   `   `   `  ����E  ASpaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SpaManager.Screen.AccountSpaManager.Screen.Account  5      *    $SpaManager.Screen.Account.UC_Account   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3local'clr-namespace:SpaManager.Screen.Account  5      .��5
      � 
�������.+�5   
   �� .+�5      �� $��80��6   .+�5      ��   �� Orientation$  
Horizontal=�6   $��0 15 0 0q�66   .+�5      �� -   5        $��
btn_active��5      $��50��61   $��50��6=   $��50 0 0 0q�6H   
���   �
��� � �5      �� 5      $��Active��6    $��20��6.   $��
-20 -2 0 0q�6:   $��16(�6N   �� 5      -   5        $��btn_blocked��5      $��50��62   $��50��6>   $��50 0 0 0q�6I   
���   �
��� � �5   =   �� 5      $��Blocked��6    $��20��6/   $��
-20 -2 0 0q�6;   $��16(�6O   5      5      � 5      $	��450��6   $	��800��6    .+�5      �� $
��Auto=�6   $	��600��6B   .��5      �� .+�5      �� -   5        $��	list_user��5   #    �� View 5      �� 5   "   .P�5   &   �� $��Username��5    !    �� Width$	 200��5!   %    �� DisplayMemberBinding 5   !   �� *
username+5!   %   �� 5#   &   $ 50��65    �� CellTemplate 5$   *   �� 5%   .   .R�5&   2   �� $��	btn_block��6l   -   5           MaterialDesignToolButton#���   5&   9   $��30��6}   $��Center=�5'   1   .��5(   6   '  !MaterialDesignThemes.Wpf.PackIcon     Kind 6N   �� *block+5)   3   5*   /   5,   '   �� 5.   &   $ 50��65    5/   *   �� 50   .   .R�51   2   �� $��
btn_delete��6l   -   5        #���   51   9   $��30��6~   $��Center=�6�   .��53   6     $ Delete=�6N   54   3   55   /   58   '   59   #   5;      5<      5=      5>      5?      �� 5@   
   $	��100��6   .+�5A      � -   5        $��progress_bar��5C   O   $��60��5A      $��60��6%   $��10 0 0 0q�61    % !MaterialDesignCircularProgressBar#��[ 6D    � Value$ 0Q�5B   &    � IsIndeterminate . 
��� � �5C   O   5D      5E      5F      