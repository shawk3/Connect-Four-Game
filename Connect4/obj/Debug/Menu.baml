   M S B A M L   `   `   `  ����C  ?Connect4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Connect4Connect4  5   	       Connect4.Menu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Connect4     5   	     � Title$
  Menu��5   	   $	��350��6   $	��525��6#   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Connect Four��5      $��30(�5      $��5q�5      $��Center=�5      �� 5   
   -   5        $��2��5      $��Single Player��5      $��20(�5      $	��150��5      $��5q�5      5      �� 5    
    �� Orientation$ 
Horizontal=�6   $��3��5!      .+�5"      	� -   5        $
��Easy��5"      $
��70,5q�5#       d� 	IsChecked$
 TrueY�5%      	� 5&      -   5        $��Medium��5&      $
��50,5q�5'      5(      	� 5)      -   5        $
��Fred��5)      $
��50,5q�5*      5+      5,      �� 5-   
   $ 
Horizontal=�6   $��4��5.      .+�5/      	� -   5        $��First��5/      $��150,5,100,5q�50      $
 TrueY�51      52      	� 53      -   5        $��Second��53      $
��30,5q�54      55      56      �� 57   
   -   5        $��6��57      $��Two Players��58      $��20(�59      $	��150��5:      $��5q�5;      5<      �� 5=   
   -   5        $��7��5=      $��
Train Fred��5>      $��12(�5?      $��5q�5@      5A      5B      5C      