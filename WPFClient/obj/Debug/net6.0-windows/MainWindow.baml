   M S B A M L   `   `   `  ����D  @WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFClient	WPFClient  5   	       WPFClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $��18(�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ btnOpenConnection��5      $��0��6,   $��Center=�69   $��20 10q�5      $��20q�5      $��Open Connection��5      6+   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5         ��Name$ txtMessageInput��5      $	��300��6/   $��20q�6>   �� 5      -   5        $ btnSendMessage��5      $��20 10q�5      $��20q�5      $��Send Message��5      ${�False��6O   5      �� 5    
   $��2��6   $��Center=�6$   $��20q�6A   $	��200��6M   $
��Auto=�6]   .��5!      �� -   5         ��Name$ 
lbMessages��5!      $��Stretch=�6*   $��20 10q�6H   $��0q�6X   5"      �� 5$   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5%      �� -   5        $ btnOpenCounterConnection��5%      $��Open counter connection��67   $��Center=�6Y   $��20 10q�6v   6�   �� 5&      -   5        $ btnCounterIncrement��5&      $��Increment Counter��62   $��3��6N   $��Center=�6[   $��20 10q�6x   6�   5'      5)      5*      