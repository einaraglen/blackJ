   M S B A M L   `   `   `  ����L  Happ_wpf_blackjack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:app_wpf_blackjackapp_wpf_blackjack  5   	   "    app_wpf_blackjack.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:app_wpf_blackjack     5   	   -   5          �Name$  
App_Window��5   l    � Title$ blackJ��6	   $	��550��6   $
��1000��6%   $	��550��62   $
��1000��6B   .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
   �� 5      �� 5      $	��200 �6   �� 5      $��30 �6   .+�5   
   � $��Stretch=�6   $��Stretch=�6-   $��0��6I   $��0��6V   ���#8E44AD � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0 0 2 0q�6   ���#7D3C98$��0��6E   $��0��6R   ._�5      � $��Stretch=�6   $��Stretch=�65    � ShowGridLines$ False��6Q    5       �� 5!      �� 5"      $��60 �6(   .+�5%      � $��0��6   $��1��6(   $ False��68    5&      �� 5'      -   5         ��Name$ utop_c��5'   8   $��50 �6,   68   �� 5(      �� 5)      -   5        $ 	split_row��5)   ,   $��* �6?   �� 5*      -   5        $ ubot_c��5*   8   $��50 �6,   68   .+�5-      �� -   5         ��Name$ 	userCards��5-   %   $��1��68    �� Orientation$ 
Horizontal=�6E   ���#7D3C98$��	10 5 20 5q�6s   53      �� 55      -   5        $ 
splitCards��55   %   $��2��69   $ 
Horizontal=�6F   ���#7D3C98$��	10 5 20 5q�6t   57      � 5:      -   5         �Name$ max_buttons��5:      $��3��64   $ False��6A   $y�	Collapsed=�6W    5;      �� 5<   "   �� 5=   "   �� 5>   "   �� 5?   "   .+�5B      �� -   5        	 ��Name$	 btn_max��5B   %   $��1��6I   $	��Top=�6Y   
 � Cursor$

 Hand��6q   $��45��6   $��5 5 5 5q�6�   .��6�   Max6�   �� 5C      -	   5        $	 btn_min��5C   %   $��2��6I   $	��Top=�6Y   $

 Hand��6q   $��45��6   $��5 5 5 5q�6�   .��6�   Min6�   5E      5G      �� 5K      -
   5         ��Name$ 	userTotal��5K      $��1��6/   $��0��6<   $��0 0 20 0q�6L   ���#FFF$��30(�6p   $��Center=�6~   $��Right=�6�   .��6�   05M      5N      5P      �� 5S      $��2 0 0 0q�6   ���#7D3C98$��0��6E   $��1��6R   ._�5T      � $��Stretch=�6   $��Stretch=�65   $ False��6Q    5U      �� 5V      �� 5W      $��60 �6(   .+�5Z      � $��0��6   $��1��6(   $ False��68    5[      �� 5\      -   5        $ top_c��5\   8   $��50 �6,   68   �� 5]      �� 5^      -   5        $ bot_c��5^   8   $��50 �6,   68   .+�5a      �� -   5        $ dealerCards��5a   %   $��1��6:   $ 
Horizontal=�6G   ���#7D3C98$��	20 5 10 5q�6u   5e      5g      �� 5j      -   5        $ dealerTotal��5j      $��1��61   $��0��6>   $��20 0 0 0q�6N   ���#FFF$��30(�6r   $	��100��6�   $��Center=�6�   $
��Left=�6�   .��6�   05l      5m      5n      5p      � 5s   
   $��1��6   $��0��6   $��Stretch=�6,   $��Stretch=�6H   ���#FFF 5t      �� 5u      �� 5v      �� 5w      .+�5z      �� $��0 6 0 0q�6   ���#A569BD$��0��6E   $��0��6R   ._�5|      � $��Stretch=�6   $��Stretch=�63   $ False��6Q    5}      �� 5~      �� 5      �� 5�      .+�5�      �� $��0��6   $��0��6*   ���#A569BD$��0 0 1 0q�6P   ._�5�      � .+�5�      �� -   5        $	 up_25��5�   %   $��40��6F   $	��Top=�6R   $��10q�6j   $

 Hand��6v   .��6�   +256�   �� 5�      -   5        $	 up_50��5�   %   $��40��6F   $��Center=�6R   $��10q�6m   $

 Hand��6y   .��6�   +506�   �� 5�      -   5        $	 up_100��5�   %   $��40��6H   $��Bottom=�6T   $��10q�6o   $

 Hand��6{   .��6�   +1006�   5�      5�      �� 5�      $��0��6   $��1��6*   ���#A569BD$��0 0 1 0q�6P   ._�5�      � $��Stretch=�6   $��Stretch=�6;   $ False��6Y    5�      �� 5�   "   �� 5�   "    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6%   $��0��62   $��0 0 0 1q�6B   ���#A569BD._�5�   "   �� $��13(�6(   $��Right=�66   $��Center=�6R   ���#8E44AD$
��Bold"�6�   .��6�   	Score :6�   5�      �� 5�      $��0��6%   $��1��62   $��0 0 0 1q�6B   ���#A569BD._�5�   "   �� -   5        $ 	scoreText��5�   (   $��13(�6;   $
��Left=�6I   $��Center=�6d   ���#8E44AD$
��Bold"�6�   6�   5�      �� 5�      $��1��6$   $��0��61   $��13(�6A   $��Right=�6O   $��Center=�6k   ���#8E44AD$
��Bold"�6�   .��6�   Bet :6�   �� 5�      -   5        $ betText��5�   $   $��1��65   $��1��6B   $��13(�6R   $
��Left=�6`   $��Center=�6{   ���#8E44AD$
��Bold"�6�   6�   5�      5�      �� 5�      $��0��6   $��2��6*   ���#A569BD$��0 0 0 0q�6P   5�      5�      5�      �� 5�      $��0 6 0 0q�6   ���#A569BD$��0��6E   $��1��6R   ._�5�      � $��0��6   $��1��6$   $��Stretch=�64   $��Stretch=�6P   ���#FFF 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -   5        $	 drawBtn��5�      $��0��6.   $��0��6;   $��70��6K   $��5q�6W   $

 Hand��6b   .��6�   Draw6�   �� 5�      -   5        $	 holdBtn��5�      $��0��6.   $��1��6;   $��70��6K   $��5q�6W   $

 Hand��6b   .��6�   Hold6�   �� 5�      -   5        $	 splitBtn��5�      $��0��6/   $��2��6<   $��70��6L   $��5q�6X   $

 Hand��6c   .��6�   Split6�   5�      5�      �� 5�      $��0 6 0 0q�6   ���#A569BD$��0��6E   $��2��6R   5�      5�      �� 5�   
   $��2��6   $��0 1 0 1q�6   ���#A569BD._�5�      �� -   5        $ 
updateText��5�      $��Center=�6(   
�������.��6W   start6^   5�      5�      5�      