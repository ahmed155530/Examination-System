   M S B A M L   `   `   `  ����D  @projectex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projectex	projectex  5   	        projectex.updateinstructor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projectex     5   	     � Title$  update1��5   	   $	��600��6   $	��900��6&   ���#e1f4f3.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5    
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataGrid1��5!   '   $	��148��5       $
��Left=�6    $��0��6;   $��3��6H   $��
150,30,0,0q�5!      $	��Top=�6:   $	��600��6R   6x   �� 5#   
   -   5         ��Name$
 name��5#   !   $��_Name:��6   $��1��6/   $��0��6<   $��Right=�6L   $��0 20 0 0q�6h   �� 5%   
   -   5         ��Name$ Instructor_Name��5%   O   
���   � �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6;   $��1��6h   $��1��6u   $��
12,28,11,0q�6�   $	��200��6�   �� 5&   
   -   5        $ Salary��5&   "   $��Salary:��6   $��2��62   $��0��6?   $��Right=�6O   �� 5(   
   -   5        $ Instructor_Salary��5(   O   
���   � . $
 Wrap=�6;   $��2��6j   $��1��6w   $��
12,10,11,1q�6�   �� 5*   
   -   5        $ Branch��5*   "   $��Branch:��6   $��4��62   $��0��6?   $��Right=�6O   �� 5+   
   -   5         ��Name$ 	Branch_Id��5+   2   $��4��6   $��1��6!   $��0,3,0,6q�6E   6X   �� 56   
   -   5        	 ��Name$
	 save��56   E   $��10q�6   ���#333333
�������$
��Save��6S   $��8��6b   $��1��6o   6   �� 57   
   -	   5        $	 delete��57   E   $��10q�6   ���#333333
�������$��Delete��6U   $��9��6f   $��1��6s   6�   58      59      