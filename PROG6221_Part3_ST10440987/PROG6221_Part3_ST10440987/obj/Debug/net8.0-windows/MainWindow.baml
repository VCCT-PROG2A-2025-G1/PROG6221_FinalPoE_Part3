   M S B A M L   `   `   `  ����T  PPROG6221_Part3_ST10440987, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PROG6221_Part3_ST10440987PROG6221_Part3_ST10440987  5   	   *    $PROG6221_Part3_ST10440987.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PROG6221_Part3_ST10440987     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��910��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ ChatHistory��5      $��Consolas)�5      $��0��5      $��0 0 0 0q�5      " �� VerticalScrollBarVisibility$
 Auto=�5       �� 
IsReadOnly$
 True��5       �� TextWrapping$
 Wrap=�5       �� AcceptsReturn$
 True��5      
���   �
��� � �5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   
���   �.+�5      �� -   5        $ 	UserInput��5      $	��550��6)   $��30��65   $��10 10 10 10q�6A   
���iii�
�������6�   �� 5      -   5         ��Name$ ViewTasksButton��5      $��View/Manage Tasks��6.   $	��115��6J   $��
0 10 10 10q�6V   
���� ��
�������6�   �� 5      -   5        $ 
QuizButton��5      $��Play Quiz Game��6)   $	��100��6B   $��
0 10 10 10q�6N   
����� �
���   �6�   �� 5      -   5        $ 
sendButton��5      $
��Send��6)   $��80��68   $��
0 10 10 10q�6C   
��� � �6p   5      5       5!      