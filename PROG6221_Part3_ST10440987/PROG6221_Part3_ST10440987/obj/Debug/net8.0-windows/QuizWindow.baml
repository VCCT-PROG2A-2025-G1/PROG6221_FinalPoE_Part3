   M S B A M L   `   `   `  ����T  PPROG6221_Part3_ST10440987, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PROG6221_Part3_ST10440987PROG6221_Part3_ST10440987  5   	   *    $PROG6221_Part3_ST10440987.QuizWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PROG6221_Part3_ST10440987     5   	     � Title$  
QuizWindow��5   	   $	��450��6   $	��920��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ QuizHistory��5      $��Consolas)�5      $��0��5      $��0 0 0 0q�5      " �� VerticalScrollBarVisibility$
 Auto=�5       �� 
IsReadOnly$
 True��5       �� TextWrapping$
 Wrap=�5       �� AcceptsReturn$
 True��5      
���   �
��� � �5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   
���   �.+�5      �� -   5        $ 
UserAnswer��5      $	��540��6*   $��30��66   $��10 10 10 10q�6B   
���iii�
�������6�   �� 5      -   5         ��Name$ StartQuizButton��5      $��
Start Quiz��6.   $	��105��6C   $��
0 10 10 10q�6O   
���� ��
�������6�   �� 5      -   5        $ AnswerButton��5      $��Submit Answer��6+   $	��105��6C   $��
0 10 10 10q�6O   
��� � �
���   �6�   �� 5      -   5        $ BackToChatbotButton��5      $��Back to ChatBot��62   $	��105��6L   $��
0 10 10 10q�6X   
����� �
���   �6�   5      5       5!      